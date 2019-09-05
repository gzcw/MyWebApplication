$.parser.plugins.push("boolcombobox");
$.parser.plugins.push("searchpanel");
$.parser.plugins.push("sjzdcombobox");
$.parser.plugins.push("attachmentgrid");
$.parser.plugins.push("mysearchbox");
$.parser.plugins.push("iconcombobox");

/*============================================================
  布尔型选择组件
 ============================================================*/
jQuery.fn.boolcombobox = function (options, param) {
    if (typeof options == "string") { return $.fn.combobox.apply(this, arguments); }
    options = options || {};

    return this.each(function () {
        var jq = $(this);

        var opts = $.extend({
            panelHeight: 100,
            data: [{ value: true, text: '是' }, { value: false, text: '否' }],
        }, $.fn.combobox.parseOptions(this), options);
        jq.combobox(opts);
        if (opts.value == 1) {
            jq.combobox('setValue', true)
        }
        else if (opts.value == 0) {
            jq.combobox('setValue', false)
        }
    });
};

/*============================================================
  查询面板
 ============================================================*/
jQuery.fn.searchpanel = function (options, param) {
    if (typeof options == "string") { return $.fn.panel.apply(this, arguments); }
    options = options || {};
    return this.each(function () {
        var jq = $(this);

        var opts = $.extend({ border: false }, $.fn.panel.parseOptions(this), options);

        var myopts = $.extend(true, { items: [] }, opts);

        if (myopts.items.length % 3 == 2) {
            myopts.items.push({ text: '', value: '' });
        }
        else if (myopts.items.length % 3 == 1) {
            myopts.items.push({ text: '', value: '' });
            myopts.items.push({ text: '', value: '' });
        }
        var rows = myopts.items.length / 3;

        var myform = $('<form style="height:' + (rows * 34 + 2) + 'px;min-height:35px;margin:2px"></form>').appendTo(jq);

        jQuery.fn.panel.call(jq, myopts);

        jq.append(myform);

        var table = $('<table></table>').appendTo(myform);

        var appendEditor = function (td, item) {

            item = $.extend(true, {
                easyType: 'textbox',
                easyConfig: {
                    width: 180,
                    permission: 0
                }
            }, item);

            var input = $('<input class="h-text" name="' + item.value + '" />');
            if (item.id) {
                input.attr('id', item.id);
            }
            td.append(input);
            $.each(item.easyConfig, function (property, value) {
                if (typeof value == "function") {
                    item.easyConfig[property] = $.proxy(value, window);
                }
            });
            input[item.easyType](item.easyConfig || {});
        };

        for (var i = 0; i < myopts.items.length; i++) {
            var tr = $('<tr></tr>');
            table.append(tr);
            tr.append('<th>' + myopts.items[i].text + '</th>');
            var td1 = $('<td></td>').appendTo(tr);
            appendEditor(td1, myopts.items[i]);

            tr.append('<th>' + myopts.items[i + 1].text + '</th>');
            if (myopts.items[i + 1].value) {
                var td2 = $('<td></td>').appendTo(tr);
                appendEditor(td2, myopts.items[i + 1]);
            }

            tr.append('<th>' + myopts.items[i + 2].text + '</th>');
            if (myopts.items[i + 2].value) {
                var td3 = $('<td></td>').appendTo(tr);
                appendEditor(td3, myopts.items[i + 2]);
            }

            if (i == 0) {
                var searchbutton = $('<a class="easyui-linkbutton" data-options="iconCls:\'icon-search\',permission:0">查询</a>');
                var retsetbutton = $('<a class="easyui-linkbutton" data-options="iconCls:\'icon-undo\',permission:0" style="margin-left:3px">重置</a>');
                var td = $('<td rowspan=' + rows + '></td>').append(searchbutton).append(retsetbutton);
                tr.append(td);

                jq.searchHandler = function () {

                    if (myopts.parentGrid) {
                        var queryParams = $.extend(true, {}, myopts.parentGrid.queryParams || {});
                        var values = myform.serializeArray();

                        var filters = JSON.parse(queryParams.filters || '[]');
                        var str_Regex = /^\(|\)|\b(and|or|exec|execute|insert|select|delete|update|alter|create|drop|count|\*|chr|char|asc|mid|substring|master|truncate|declare|xp_cmdshell|restore|backup|net +user|net +localgroup +administrators)\b$/;
                        $.each(values, function (index, filter) {

                            var myitems = $.grep(myopts.items, function (item) {
                                return item.value == filter.name;
                            });
                            var dataType = myitems.length > 0 && myitems[0].dataType ? myitems[0].dataType : 'varchar';
                            if (filter.value || myopts.sendEmpty) {
                                if (filter.value.length > 20 || str_Regex.test(filter.value.toLowerCase())) {
                                    alert("查询条件过长或包含敏感字符！");
                                }
                                filters.push({ property: filter.name, value: filter.value, relation: myopts.items[index].relation || 'like', dataType: dataType });
                            }
                        })

                        //queryParams.filterStr = JSON.stringify(filters);
                        queryParams.filters = JSON.stringify(filters);

                        myopts.gridType = myopts.parentGrid.datagrid('options').onCheckNode ? "treegrid" : "datagrid";
                        if (myopts.memory == undefined || myopts.memory == false) {

                            myopts.parentGrid[myopts.gridType]('clearSelections');
                        }

                        myopts.parentGrid[myopts.gridType]('load', queryParams);
                    }
                    else if (myopts.mySearchHandler) {
                        var values = myform.serializeArray();

                        var filters = [];

                        $.each(values, function (index, filter) {
                            var myitems = $.grep(myopts.items, function (item) {
                                return item.value == filter.name;
                            });
                            var dataType = myitems.length > 0 && myitems[0].dataType ? myitems[0].dataType : 'varchar';
                            if (filter.value || myopts.sendEmpty) {
                                filters.push({ property: filter.name, value: filter.value, relation: myopts.items[index].relation || 'like', dataType: dataType });
                            }
                        })
                        myopts.mySearchHandler(filters);
                    }
                };
                searchbutton.bind('click', jq.searchHandler);
                retsetbutton.bind('click', function () {
                    myform.form('reset');
                    try {
                        myform.find('.combotree-f').combotree('clear');
                    }
                    catch (ex) {
                        console.log(ex);
                    }
                });

                $(window).on("keydown", function (event) {
                    var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
                    if (keyCode == 13) {
                        jq.searchHandler();
                    }
                });
            }
            i += 2;
        }
        $.parser.parse(this);
    });
}

/*============================================================
  数据字典下拉框
 ============================================================*/
jQuery.fn.sjzdcombobox = function (options, param) {

    if (typeof options == "string") { return $.fn.combotree.apply(this, arguments); }
    options = options || {};

    return this.each(function () {
        var jq = $(this);

        var opts = $.extend({}, $.fn.combobox.parseOptions(this), options);
        opts = $.extend({
            url: window.applicationPath + '/Sjzd/GetData?orders=SORTNUMBER&filters=' + JSON.stringify([{ property: 'ZDBM', value: opts.zdbm }]),
            textField: 'Name',
            valueField: 'Sz'
        }, opts);
        return jq.combobox(opts);
    });
};

/*============================================================
  附件上传组件
 ============================================================*/
jQuery.fn.attachmentgrid = function (options, param) {
    if (typeof options == "string") {
        var method = $.fn.treegrid.methods[options];
        if (method) {
            return method(this, param);
        } else {
            return this.treegrid(options, param);
        }
    }
    options = options || {};

    return this.each(function () {
        var sender = this;
        var jq = $(this);

        var opts = $.extend({}, $.fn.treegrid.parseOptions(this), options);

        var myoptions = $.extend({ category: 'default' }, {
            nowrap: false,
            rownumbers: true,
            //animate: true,
            //collapsible: true,
            idField: 'ID',
            treeField: 'Name',
            singleSelect: false,
            border: true,
            //autoLoad: false,
            //autoRowHeight: true,
            //fitColumns: false,
            height: 300,
            queryParams: $.extend({ orders: 'SortNumber', category: opts.category }, options.queryParams || {}),
            url: applicationPath + '/Attachment/GetTreeDataByRecordID',
            toolbar: [{
                text: '新增附件',
                iconCls: 'icon-add',
                id: 'addFuJian',
                handler: function () { myevent.add(); }
            }, '-', {
                text: '新增目录',
                iconCls: 'icon-add',
                id: 'addFuJian_MuLu',
                handler: function () { myevent.addFolder(); }
            }, '-', {
                text: '修改',
                iconCls: 'icon-edit',
                id: 'editFuJian',
                handler: function () { myevent.update(); }
            }, '-', {
                text: '删除',
                iconCls: 'icon-remove',
                id: 'deleteFuJian',
                handler: function () { myevent.del(); }
            }, '-', {
                text: '刷新',
                iconCls: 'icon-reload',
                permission: 0,
                handler: function () { myevent.loadData(); }
            }, '-', {
                text: '打包下载',
                iconCls: 'icon-save',
                permission: 0,
                handler: function () { myevent.downloadAll(); }
            }],
            columns: [[
                { field: 'ck', checkbox: true },
                { field: 'ID', hidden: true },
                { field: 'Name', align: 'left', title: '文件名', width: 420 },
                { field: 'CreateTime', align: 'left', title: '上传时间', width: 145, formatter: function (value, row, index) { return value.substr(0, 16); } },
                {
                    field: 'operation', align: 'left', title: '操作', width: 75, formatter: function (value, row, index) {
                        if (row.Path) {
                            var fullPath = window.location.origin + applicationPath + row.Path;
                            return '<a href="#" onclick="viewFile(\'' + fullPath + '\')">查看</a>|<a href=\'' + applicationPath + '/Attachment/DownFile?filePath=' + fullPath + '&fileName=' + row.Name + '\'>下载</a>';
                        }
                        else {
                            return "";
                        }
                    }
                },
                {
                    field: 'SortNumber', align: 'left', title: '排序', width: 50, formatter: function (value, row, index) {
                        if (row.IsDirectory == 0) {
                            var strHtml = '<a href="#" title="向上" class="arrow_up_16" style="text-decoration:none" onclick="sortUp(\'' + row.ID + '\')">&nbsp;&nbsp;</a>';
                            strHtml += '&nbsp;&nbsp;<a title="向下" href="#" class="arrow_down_16" style="text-decoration:none" onclick="sortDown(\'' + row.ID + '\')">&nbsp;&nbsp;</a>';
                            return strHtml;
                        } else {
                            return "";
                        }
                    }
                }
            ]],
            loadFilter: function (data, parentId) {
                var fitIcon = function (data) {
                    return $.map(data, function (item) {
                        if (item.IsDirectory) {
                            item.iconCls = "folder_16";
                        }
                        if (item.children) {
                            item.children = fitIcon(item.children);
                        }
                        return item;
                    })
                }

                return fitIcon(data);
            }
        }, opts);

        var controlContainer = $("<div></div>").insertAfter(sender);

        var mytreegrid = jq.treegrid(myoptions);

        jq.datagrid('getPanel').parent().css('padding-left', 5);

        //if (!myoptions.width) {
        //    setTimeout(function () {
        //        jq.datagrid('getPanel').parent().find('.panel-header').css('padding', '5px 0px 5px 0px');
        //        jq.datagrid('getPanel').parent().find('.panel-header').css('width', '99%');
        //        jq.datagrid('getPanel').parent().css('width', '99%');
        //        jq.datagrid('getPanel').css('width', '99%');
        //        jq.datagrid('getPanel').find('.datagrid-view').css('width', '100%');
        //        jq.datagrid('getPanel').find('.datagrid-view2').css('width', '100%');
        //        jq.datagrid('getPanel').find('.datagrid-header').css('width', '100%');
        //    }, 2000);
        //}


        var myevent = {};
        myevent.add = function () {
            var idValue = myevent.getIdValue();
            if (!idValue) {
                $.messager.alert("提示", "请先保存表单");
                return;
            }
            commonhelper.openWindowInWorkArea(applicationPath + '/Attachment/NewUp?recordID=' + idValue + "&category=" + myoptions.category, {
                title: '新增附件',
                height: 380,
                callback: function () {
                    mytreegrid.treegrid('reload');
                    mytreegrid.treegrid('clearSelections');
                }
            });
        };
        myevent.addFolder = function () {
            var idValue = myevent.getIdValue();
            if (!idValue) {
                $.messager.alert("提示", "请先保存表单");
                return;
            }
            var url = applicationPath + '/Attachment/FolderForm?recordID=' + idValue + "&category=" + myoptions.category;
            commonhelper.openWindowInWorkArea(url, {
                title: '新增目录',
                width: 470,
                height: 350,
                callback: function () {
                    mytreegrid.treegrid('reload');
                    mytreegrid.treegrid('clearSelections');
                }
            });
        };
        myevent.update = function () {
            commonhelper.SingleSelectTreeGrid(mytreegrid, function (id, row) {
                var idValue = myevent.getIdValue();
                if (row.IsDirectory == 0) {
                    var url = applicationPath + '/Attachment/FileForm?id=' + id + '&recordID=' + idValue + "&category=" + myoptions.category;

                    commonhelper.openWindowInWorkArea(url, {
                        title: '修改附件',
                        width: 500,
                        height: 350,
                        callback: function () {
                            mytreegrid.treegrid('reload');
                            mytreegrid.treegrid('clearSelections');
                        }
                    });
                }
                else {
                    var url = applicationPath + '/Attachment/FolderForm?id=' + id + '&recordID=' + idValue + "&category=" + myoptions.category;
                    commonhelper.openWindowInWorkArea(url, {
                        title: '修改目录',
                        width: 470,
                        height: 350,
                        callback: function () {
                            mytreegrid.treegrid('reload');
                            mytreegrid.treegrid('clearSelections');
                        }
                    });
                }

            });
        };
        myevent.del = function () {
            commonhelper.RemoveTreeGridSelected(mytreegrid, function (ids, rows) {
                $.messager.progress();
                $.ajax({
                    url: applicationPath + '/Attachment/DeleteEntities',
                    data: { ids: ids },
                    traditional: true,
                    type: 'post',
                    success: function (result) {
                        $.messager.progress('close');
                        if (result.success) {
                            mytreegrid.treegrid('reload');
                            mytreegrid.treegrid('clearSelections');
                        }
                        else {
                            $.messager.alert("提示", result.Message == undefined ? result.msg : result.Message);
                        }
                    }
                });
            });
        };

        myevent.getIdValue = function () {
            if (myoptions.recordID) {
                return myoptions.recordID;
            }
            var idFields = document.getElementsByName('ID');
            if (idFields.length > 0) {
                return $(idFields[0]).val();
            }
            return null;
        };

        myevent.loadData = function () {
            var count = 0;
            var interval = setInterval(function () {
                var idValue = myevent.getIdValue();
                if (idValue) {
                    clearInterval(interval);
                    myoptions.queryParams.recordID = idValue;
                    jq.treegrid('load', myoptions.queryParams);
                }
                else if (count > 10) {
                    clearInterval(interval);
                }
                count++;
            }, 1000);
        };
        myevent.loadData();

        myevent.downloadAll = function () {
            commonhelper.MultiSelectGrid(mytreegrid, function (ids, rows) {
                window.open(applicationPath + '/Attachment/DownloadAll?ids=' + ids);
            });
        };

        viewFile = function (filepath, obj) {
            var container = $('<div/>').insertAfter(controlContainer);
            var newmini = filepath.substr(filepath.lastIndexOf(".")).toLowerCase();

            var controlHtml = "";
            if (newmini == ".pdf") {
                window.open(filepath + "?version=" + Math.random());
                return;
            }
            if (newmini == ".doc" || newmini == ".docx" || newmini == ".xlsx" || newmini == ".xls") {
                window.open(filepath, "_blank");
                return;
            }
            if (newmini == ".jpg" || newmini == ".png" || newmini == ".gif" || newmini == ".bmp" || newmini == ".tif") {
                window.open(filepath, "_blank");
                return;
            }
            else if (newmini == ".txt") {
                $('<iframe frameborder="0" charset="UTF-8" width="560" height="' + (container.closest('body').innerHeight() - 60) + '" src=' + encodeURI(filepath) + '/>').appendTo(container);
            }
            else {
                $.messager.alert("提示", "此文件暂不支持预览！");
                return;
            }
            container.dialog({
                title: '文件预览',
                width: 580,
                height: container.closest('body').innerHeight() - 10,
                maximizable: true,
                resizable: false,
                modal: true,
                onClose: function () {
                    container.dialog('destroy', true);
                },
                onMaximize: function () {
                    if (newmini == "text") {
                        var iframe0 = container.find('iframe')[0];
                        iframe0.height = container.closest('body').innerHeight() - 60, iframe0.width = container.closest('body').innerWidth() - 20;
                    }
                },
                onRestore: function () {
                    if (newmini == "text") {
                        var iframe0 = container.find('iframe')[0];
                        iframe0.height = container.closest('body').innerHeight() - 60,
                            iframe0.width = 560;
                    }
                }
            }).dialog('open');
        };

        sortUp = function (id) {
            var permission = commonhelper.getUrlParam('permission');
            if (permission == 0) {
                $.messager.alert('提示', '只读页面不能排序。');
                return;
            }
            $.messager.progress();
            $.ajax({
                url: applicationPath + '/Attachment/SortOrder',
                data: { id: id, type: 'up' },
                type: 'post',
                success: function (result) {
                    $.messager.progress('close');
                    if (result.success) {
                        mytreegrid.treegrid('reload');
                        mytreegrid.treegrid('clearSelections');
                    }
                    else {
                        $.messager.alert("提示", result.Message == undefined ? result.msg : result.Message);
                    }
                }
            });
        };

        sortDown = function (id) {
            var permission = commonhelper.getUrlParam('permission');
            if (permission == 0) {
                $.messager.alert('提示', '只读页面不能排序。');
                return;
            }
            $.messager.progress();
            $.ajax({
                url: applicationPath + '/Attachment/SortOrder',
                data: { id: id, type: 'down' },
                type: 'post',
                success: function (result) {
                    $.messager.progress('close');
                    if (result.success) {
                        mytreegrid.treegrid('reload');
                        mytreegrid.treegrid('clearSelections');
                    }
                    else {
                        $.messager.alert("提示", result.Message == undefined ? result.msg : result.Message);
                    }
                }
            });
        };

        return mytreegrid;
    });
};

jQuery.fn.attachmentgrid.methods = {
    load: function (jq, recordID) {
        var opts = $.fn.treegrid.parseOptions(jq[0]);
        opts.queryParams.recordID = recordID;
        return jq.treegrid('load', opts.queryParams);
    }
};

/*============================================================
  自定义组件【mysearchbox】，选择窗口，扩展自combobox 
 ============================================================*/
jQuery.fn.mysearchbox = function (options, param) {
    if (typeof options == "string") { return $.fn.combobox.apply(this, arguments); }
    options = options || {};
    return this.each(function () {
        var jq = $(this);

        var opts = $.extend({
        }, $.fn.combobox.parseOptions(this), options);

        opts.icons = $.extend([], $.fn.combobox.defaults.icons);

        opts.icons.push({
            iconCls: 'icon-search',
            handler: function () {
                var windowOptions = $.extend({
                    selectCallback: function (ids, rows) {
                        debugger;
                        if (opts.onBeforeSelect) {
                            opts.onBeforeSelect(ids, rows);
                        }
                        jq.combobox('setValues', ids);

                        jq.easyuiWindow.window('close');
                        if (opts.onAfterSelect) {
                            opts.onAfterSelect(ids, rows);
                        }
                    }
                    //,
                    //buttons: [{
                    //    text: '选择',
                    //    iconCls: 'icon-ok',
                    //    onClick: function () {
                    //        if (opts.multiple) {
                    //            easyuiWindow.contentWindow.commonhelper.MultiSelectGrid(easyuiWindow.contentWindow.mygrid, function (ids, rows) {
                    //                if (opts.onBeforeSelect) {
                    //                    opts.onBeforeSelect(ids, rows);
                    //                }
                    //                jq.combobox('setValues', ids);
                    //                if (opts.onAfterSelect) {
                    //                    opts.onAfterSelect(ids, rows);
                    //                }
                    //                easyuiWindow.window('close');
                    //            });
                    //        }
                    //        else {
                    //            easyuiWindow.contentWindow.commonhelper.SingleSelectGrid(easyuiWindow.contentWindow.mygrid, function (id, row) {
                    //                alert(2);
                    //                if (opts.onBeforeSelect) {
                    //                    opts.onBeforeSelect(id, row);
                    //                }
                    //                jq.combobox('setValue', id);
                    //                if (opts.onAfterSelect) {
                    //                    opts.onAfterSelect(id, row);
                    //                }
                    //                easyuiWindow.window('close');
                    //            });
                    //        }
                    //    }
                    //}]
                }, opts.windowOptions);

                jq.easyuiWindow = commonhelper.openWindowInWorkArea(opts.windowOptions.url, windowOptions);
            }
        });

        var filters = [];

        var defaults = {
            editable: true,
            hasDownArrow: false
        };

        var myconfig = $.extend(true, {}, defaults, opts);
        var result = $(jq).combobox(myconfig);

        jq.next().find('.textbox-text').unbind('click');

        return result;
    });
};

/*============================================================
  自定义组件【iconcombobox】，图标选择框，扩展自combobox
 ============================================================*/
jQuery.fn.iconcombobox = function (options, param) {
    if (typeof options == "string") { return $.fn.combobox.apply(this, arguments); }
    options = options || {};
    return this.each(function () {
        var jq = $(this);

        var opts = $.extend({
            url: applicationPath + "/Authorize/Authorization/GetIcons",
            showItemIcon: true
        }, $.fn.combobox.parseOptions(this), options);

        var result = $(jq).combobox(opts);

        return result;
    });
};