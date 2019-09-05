(function ($) {
    window.commonhelper = {
        addTab: function (targetTabs, title, url, iconCls, opts) {
            if (targetTabs.tabs("exists", title)) {
                targetTabs.tabs("select", title);
            } else {
                var mypots = $.extend(opts, {
                    refreshable: true,
                    title: title,
                    content: window.commonhelper.createIframe(url),
                    closable: true,
                    iconCls: iconCls
                });
                targetTabs.tabs("add", mypots);
            }
        },
        closeTab: function (targetTabs, title) {
            if ($(targetTabs).tabs("exists", title)) {
                $(targetTabs).tabs("close", title);
            }
        },
        createIframe: function (url) {
            var html = '<iframe scrolling="no" style="width:100%;height:100%;border:none;margin-bottom:-3px;" frameborder="no" src ="' + url + '" ></iframe>';
            return html;
        },
        //设置并呈现数据表格DataGrid（dataGridID：带#前缀的目标数据表格ID；customOptions：自定义的数据表格Options属性对象(可不传)）
        showDataGrid: function (dataGridID, customOptions) {
            var defaultOptions = {
                //noheader: true,//去除标题栏
                fitColumns: false, //填充页面
                striped: true, //斑马线效果
                rownumbers: true,//显示行号
                idField: 'ID',//标识列
                pagination: true, //是否显示分页
                pageNumber: 1,//分页加载数据默认当前页
                pageSize: 20,
                pageList: [10, 15, 20, 50]
            };
            var newOptions = $.extend(defaultOptions, customOptions);
            var flexColumns = [];
            //增加column的属性flex
            if (newOptions.columns) {
                flexColumns = $.grep(newOptions.columns[0], function (column) {
                    if (!column) {
                        return false;
                    }
                    return column.flex;
                });
            }

            if (flexColumns.length > 0) {
                _onLoadSuccess = newOptions.onLoadSuccess;
                _onResizeColumn = newOptions.onResizeColumn;

                var mygrid = $(dataGridID);
                $.extend(newOptions, {
                    onLoadSuccess: function (data) {
                        var mybody = mygrid.prev().find('.datagrid-body');
                        mybody.css('overflow-x', 'auto!important');
                        var btable = mybody.find('table');
                        var width = mybody.width() - btable.width();
                        if (width > 10) {
                            var sum = 0;
                            $.each(flexColumns, function (index, flexColumn) {
                                sum += flexColumn.flex;
                            });
                            $.each(flexColumns, function (index, flexColumn) {
                                var field = $.find('.datagrid-cell-c1-' + flexColumn.field);
                                $(field).width(width * flexColumn.flex / sum + $(field[0]).width());
                            });
                        }
                        if (_onLoadSuccess) {
                            _onLoadSuccess(data);
                        }
                    },
                    onResizeColumn: function (field, width) {
                        var field = $.find('.datagrid-cell-c1-' + field);
                        $(field).css('width', width);
                        if (_onResizeColumn) {
                            _onResizeColumn(field, width);
                        }
                    }
                });
            }
            //--------------------------------------------------------------
            $(dataGridID).datagrid(newOptions);
        },
        //Ajax加载数据表格数据（url：Ajax的目标URL；queryParameters：查询参数对象(可以不传，默认为'{}')；dataGridID：带#前缀的请求加载数据的数据表格ID(可以不传，默认值为'#gvList')）
        loadDataGridData: function (url, queryParameters, dataGridID) {
            if (!queryParameters) {
                queryParameters = {};
            }
            if (!dataGridID) {
                dataGridID = "#gvList";
            }
            $(dataGridID).datagrid('loading');
            $.ajax({
                url: url,
                type: 'POST',
                data: queryParameters,
                success: function (data) {
                    if (data) {
                        $(dataGridID).datagrid("loadData", data);
                    } else {
                        $(dataGridID).datagrid("loadData", []);
                    }
                    $(dataGridID).datagrid('loaded');
                }, error: function (data, e) {
                    $.messager.alert("错误", "数据加载过程出错！", "error");
                    $(dataGridID).datagrid('loaded');
                }
            });
        },
        //设置并呈现树形表格TreeGrid（treeGridID：带#前缀的目标树形表格ID；customOptions：自定义的树形表格Options属性对象(若数据列中含有名为'Name'的列，可不传此参数，否则需要在此参数对象中指明treeField列)）
        showTreeGrid: function (treeGridID, customOptions) {
            var defaultOptions = {
                noheader: true,//去除标题栏
                fitColumns: true, //填充页面
                striped: true, //斑马线效果
                rownumbers: true,//显示行号
                idField: 'ID',//标识列
                pageSize: 20,
                pagination: false
            };

            var newOptions = $.extend(defaultOptions, customOptions);

            $(treeGridID).treegrid(newOptions);
        },
        showMyTreeGrid: function (treeGridID, customOptions) {
            var defaultOptions = {
                noheader: true,//去除标题栏
                fitColumns: true, //填充页面
                striped: true, //斑马线效果
                rownumbers: true,//显示行号
                idField: 'ID',//标识列
                pageSize: 20,
                pagination: false //是否显示分页(树形列表尽量不分页)
            };

            var newOptions = $.extend(defaultOptions, customOptions);

            $(treeGridID).mytreegrid(newOptions);
        },
        //格式化JSON格式的日期为'yyyy-MM-dd'格式
        FormatDate1: function (value, row, index) {
            if (value != null && value.length > 0) {
                value = "new " + value.replace(/\//g, "");
                var date = eval("(" + value + ")");

                return date.getFullYear() + "-" + ((date.getMonth() + 101) + "").substring(1) + "-" + ((date.getDate() + 100) + "").substring(1);
            } else {
                return "";
            }
        },
        //格式化JSON格式的日期为'yyyy-MM-dd HH:mm:ss'格式(24小时制)
        FormatDate2: function (value, row, index) {
            if (value != null && value.length > 0) {
                value = "new " + value.replace(/\//g, "");
                var date = eval("(" + value + ")");

                return date.getFullYear() + "-" + ((date.getMonth() + 101) + "").substring(1) + "-" + ((date.getDate() + 100) + "").substring(1) + " " + date.toLocaleTimeString();
            } else {
                return "";
            }
        },
        //格式化针对JS有效的时间字符串为'yyyy-MM-dd'格式
        FormatDate3: function (dateString) {
            if (dateString != null && dateString.length > 0) {
                var date = new Date(dateString);
                return date.getFullYear() + "-" + ((date.getMonth() + 101) + "").substring(1) + "-" + ((date.getDate() + 100) + "").substring(1);
            }
            else {
                return "";
            }
        },
        //格式化“1/0”形式的数据为“是/否”形式
        FormatWhether: function (value) {
            var result = value;
            switch (value) {
                case 0:
                case "0":
                case "False":
                case "false":
                    result = "否";
                    break;
                case 1:
                case "1":
                case "True":
                case "true":
                    result = "是";
                    break;
            }
            return result;
        },
        //在当前页面打开Iframe窗口页，url：要打开的窗口页的URL地址；customOptions：自定义的窗口Options属性对象(可不传)
        openWindow: function (url, customOptions) {
            customOptions = customOptions || {};
            var windowContainer = document.createElement('div');
            windowContainer.id = "divWindowContainer";
            windowContainer.style.overflow = "visible";
            //windowContainer.style.padding = "2px 2px";
            //if (customOptions.frame) {
            //    windowContainer.style.backgroundColor = "#E0ECFF";
            //}
            var flag = false;

            var defaultOptions = {
                //title: '窗口',
                width: 900,
                height: 500,
                modal: true,
                collapsible: false,
                minimizable: false,
                maximizable: false,
                resizable: true,
                closable: true,
                onClose: function (sender) {
                    setTimeout(function () {
                        $(windowContainer).parent().next().remove();
                        $(windowContainer).parent().next().remove();
                        $(windowContainer).parent().parent().focus();
                        $(windowContainer).parent().remove();
                    }, 0);
                },
                onBeforeClose: function (sender) {
                    //if (flag == false) {
                    //    $.messager.alert('提示', '程序正在加载中，请稍候');
                    //    return false;
                    //}
                    try {
                        if (customOptions.mycallback) {
                            customOptions.mycallback();
                        }
                    }
                    catch (ex) {
                        return true;
                    }
                    return true;
                },
                onMove: function (left, top) {
                    if (left < 0) {
                        $(windowContainer).window({ left: 0, top: top });
                    }
                    if (top < 0) {
                        $(windowContainer).window({ left: left, top: 0 });
                    }
                }
            };
            var left = $('.panel.window').last().css('left');
            var top = $('.panel.window').last().css('top');
            if (left && top) {
                try {
                    var newLeft = parseInt(left.replace('px', '')) + 10;
                    var newTop = parseInt(top.replace('px', '')) + 10;
                    //customOptions.left = newLeft + 15;
                    //customOptions.top = newTop + 18;
                }
                catch (e) { }

            }

            var windowOptions = $.extend(defaultOptions, customOptions);

            var easyuiWindow = $(windowContainer).window(windowOptions);

            windowContainer.innerHTML = "<iframe src='" + url + "' height='100%' width='100%' frameborder=0></iframe>";

            if (customOptions) {
                var contentWindow = windowContainer.childNodes[0].contentWindow;

                var windowConfig = $.extend(true, {}, customOptions);
                delete windowConfig.top;

                $.extend(true, contentWindow, windowConfig);

                contentWindow.easyWindow = $(windowContainer);
                if (windowConfig.showProgress) {
                    $.messager.progress();
                }
                contentWindow.onload = function () {
                    var func = function () {
                        flag = true;
                        $.messager.progress('close');
                        var body = contentWindow.document.body;
                        var items = contentWindow.document.body.getElementsByTagName('*');
                        if (items.length == 1 && items[0].innerText.indexOf('"success":false') >= 0) {
                            var resultText = items[0].innerText;
                            var result = JSON.parse(resultText);
                            $.messager.alert('提示', result.Message);

                            contentWindow.easyWindow.window('close');
                        }
                    };
                    if (customOptions.delaySeconds) {
                        setTimeout(function () {
                            func();
                        }, customOptions.delaySeconds * 1000)
                    }
                    else {
                        func();
                    }
                }
            }
            easyuiWindow.contentWindow = contentWindow;
            return easyuiWindow;
        },
        //在浏览器的最顶层打开Iframe窗口页，url：要打开的窗口页的URL地址；customOptions：自定义的窗口Options属性对象(可不传)
        openWindowInTop: function (url, customOptions) {
            window.top.commonhelper.openWindow(url, customOptions);
        },
        //在工作区域打开Iframe窗口页
        openWindowInWorkArea: function (url, customOptions) {
            var win = commonhelper.getWorkAreaWindow();
            return win.commonhelper.openWindow(url, customOptions);
        },
        //以跳转的形式打开窗口
        openWindowAsRedirect: function (url, customOptions) {
            var win = commonhelper.getWorkAreaWindow();
            var myopts = $.extend(true, {
                fit: true,
                closable: false,
                modal: false,
                noheader: true,
                shadow: false,
                resizable: false,
                border: false,
                style: { padding: 0, border: 0 }
            }, customOptions || {});
            win.commonhelper.openWindow(url, myopts);
        },
        getWorkAreaWindow: function () {
            var win = window;
            //if (window.top.location.href.indexOf('/Home/') < 0) {
            //    return window.top;
            //}
            for (var i = 0; i < 10; i++) {
                if (win.parent == window.top) {
                    break;
                }
                else {
                    win = win.parent;
                }
            }
            return win;
        },
        onRedirect: function (url, customOptions, mywindow) {

            $.each(window.$("iframe"), function (index, frame) {
                if (frame.contentWindow == mywindow) {
                    var lastUrl = mywindow.location.href;
                    $(frame).attr("src", url);
                    $(frame).unbind("load");
                    $(frame).load(function () {
                        $.extend(frame.contentWindow, customOptions, {
                            lastUrl: lastUrl
                        });

                        if (frame.contentWindow.afterRender) {
                            frame.contentWindow.afterRender();
                        }
                    });
                }
            })
        },
        //跳转窗口
        redirect: function (url, customOptions) {
            window.parent.commonhelper.onRedirect(url, customOptions, window);
        },
        //跳转窗口
        parentRedirect: function (parentWindow, url, customOptions) {
            $.each(parentWindow.$("iframe"), function (index, frame) {
                if (frame.contentWindow == window) {
                    var lastUrl = window.location.href;
                    parentWindow.$(frame).attr("src", url);
                    parentWindow.$(frame).unbind("load");
                    parentWindow.$(frame).load(function () {
                        $.extend(frame.contentWindow, customOptions, {
                            lastUrl: lastUrl
                        });

                        if (frame.contentWindow.afterRender) {
                            frame.contentWindow.afterRender();
                        }
                    });
                }
            })
        },
        //从父窗口查找当前窗口所有的iframe
        getIframe: function (parentWindow, frameWindow) {
            var result = null;
            $.each(parentWindow.$("iframe"), function (index, frame) {
                if (frame.contentWindow == frameWindow) {
                    result = frame;
                    return false;
                }
            })
            return result;
        },

        openForm: function (url,customOptions) {
            customOptions = customOptions || {};
            var windowContainer = document.createElement('div');
            windowContainer.id = "divWindowContainer";
            windowContainer.style.overflow = "visible";
         
            var flag = false;

            var defaultOptions = {
                width: 900,
                height: 500,
                modal: true,
                collapsible: false,
                minimizable: false,
                maximizable: false,
                resizable: true,
                closable: true,
                onClose: function (sender) {
                    setTimeout(function () {
                        $(windowContainer).parent().next().remove();
                        $(windowContainer).parent().next().remove();
                        $(windowContainer).parent().parent().focus();
                        $(windowContainer).parent().remove();
                    }, 0);
                },
                onBeforeClose: function (sender) {
                    try {
                        if (customOptions.mycallback) {
                            customOptions.mycallback();
                        }
                    }
                    catch (ex) {
                        return true;
                    }
                    return true;
                },
                onMove: function (left, top) {
                    if (left < 0) {
                        $(windowContainer).window({ left: 0, top: top });
                    }
                    if (top < 0) {
                        $(windowContainer).window({ left: left, top: 0 });
                    }
                },
                buttons: [{
                    text: '保存',
                    handler: window.save
                    }, {
                        text: '关闭',
                        handler: window.cancel
                    }
                ]
            };
            var left = $('.panel.window').last().css('left');
            var top = $('.panel.window').last().css('top');
            if (left && top) {
                try {
                    var newLeft = parseInt(left.replace('px', '')) + 10;
                    var newTop = parseInt(top.replace('px', '')) + 10;
                }
                catch (e) { }

            }

            var windowOptions = $.extend(defaultOptions, customOptions);

            var easyuiWindow = $(windowContainer).dialog(windowOptions);

            windowContainer.innerHTML = "<iframe src='" + url + "' height='100%' width='100%' frameborder=0></iframe>";

            if (customOptions) {
                var contentWindow = windowContainer.childNodes[0].contentWindow;

                var windowConfig = $.extend(true, {}, customOptions);
                delete windowConfig.top;

                $.extend(true, contentWindow, windowConfig);

                contentWindow.easyWindow = $(windowContainer);
                if (windowConfig.showProgress) {
                    $.messager.progress();
                }
                contentWindow.onload = function () {
                    var func = function () {
                        flag = true;
                        $.messager.progress('close');
                        var body = contentWindow.document.body;
                        var items = contentWindow.document.body.getElementsByTagName('*');
                        if (items.length == 1 && items[0].innerText.indexOf('"success":false') >= 0) {
                            var resultText = items[0].innerText;
                            var result = JSON.parse(resultText);
                            $.messager.alert('提示', result.Message);

                            contentWindow.easyWindow.window('close');
                        }
                    };
                    if (customOptions.delaySeconds) {
                        setTimeout(function () {
                            func();
                        }, customOptions.delaySeconds * 1000)
                    }
                    else {
                        func();
                    }
                }
            }
            easyuiWindow.contentWindow = contentWindow;
            return easyuiWindow;
        },

        //打开对话框
        //dialogConfig:对话框的配置
        openDialog: function (config) {
            var div = document.createElement('div');

            var defaults = {
                title: '选择窗口',
                width: 400,
                height: 250,
                closed: false,
                cache: false,
                content: "<ul id='selectNode' style='padding:10px;'></ul>",
                modal: true,
                onClose: function () {
                    $(div).remove();
                },
                toolbar: [{
                    text: '确定',
                    iconCls: 'icon-edit',
                    handler: function () {
                        var items = $("#selectNode").tree('getChecked');
                        if (items.length == 0) {
                            $.messager.alert("提示", "您未选择任何选项，请选择");
                            return;
                        }
                        if (config.callback) {
                            var result = $.map(items, function (item) {
                                return item.id;
                            })
                            config.callback(result.join(','), items);
                        }
                        $(div).dialog('close');
                        $(div).remove();
                    }
                }, {
                    text: '取消',
                    iconCls: 'icon-help',
                    handler: function () {
                        $(div).dialog('close');
                        $(div).remove();
                    }
                }]
            };

            var dialogConfig = $.extend(true, {}, defaults, config)
            $(div).dialog(dialogConfig);
            $(div).data('filterValue', '');

            var treeConfig = $.extend(config.items[0], {
                checkbox: true,
                loadFilter: function (data, parent) {
                    var filterValue = $(div).data('filterValue');
                    if ($(div).data('filterValue')) {
                        return $.map(data, function (item) {
                            if (item.text.indexOf(filterValue) >= 0) {
                                return item;
                            }
                        });
                    }
                    return data;
                },
                onSelect: function (node) {
                    var nodes = $('#selectNode').tree('getChecked');
                    var flag = false;
                    $.each(nodes, function (index, item) {
                        if (item == node) {
                            flag = true;
                        }
                    })
                    if (flag) {
                        $("#selectNode").tree('uncheck', node.target);
                    }
                    else {
                        $("#selectNode").tree('check', node.target);
                    }
                },
                onCheck: function (node, checked) {
                    if (checked && config.items[0].singleSelect) {
                        var nodes = $('#selectNode').tree('getChecked');
                        $.each(nodes, function (index, item) {
                            if (item != node) {
                                $("#selectNode").tree('uncheck', item.target);
                            }
                        })
                    }
                }
            });

            $("#selectNode").mytree(treeConfig);

            var searchBtn = $('<input></input>');
            var tr = $(div).prev().find('tr');
            var td = $('<td></td>');
            tr.append('<td style="width:130px;"></td>');
            tr.append(td);
            td.append(searchBtn);
            searchBtn.searchbox({
                searcher: function (value, name) {
                    $(div).data('filterValue', value);
                    $("#selectNode").tree('reload');
                },
                width: 120
            });
        },

        //打开子表格，用于1对多关系表格
        OpenChildGrid: function (moduleName, modelName, parentValue, parentKey, title) {
            var defaultValues = {};
            defaultValues[parentKey] = parentValue;

            commonhelper.openWindowInWorkArea(window.RootDirectory + '/' + moduleName + '/' + modelName + '/Index?' + parentKey + '=' + parentValue, {
                title: title || modelName,
                filters: [{ left: '(', property: parentKey, relation: '=', value: parentValue, right: ')' }],
                defaultValues: defaultValues,
                parentID: parentValue
            });
        },

        /// <summary>
        //从datagrid中1行帮助函数
        /// </summary>
        SingleSelectGrid: function (target, callback, key, isNeedConfirm) {
            /// <param name="target">datagrid对象</param>
            /// <param name="callback">回调函数</param>
            /// <param name="key">主键标识</param>
            /// <param name="isNeedConfirm">是否弹出确认提示框</param>
            var rows = $(target).datagrid("getSelections");
            if (!rows.length) {
                $.messager.alert("提示", "请选择1条记录！", "info");
                return;
            }
            else if (rows.length > 1) {
                $.messager.alert("提示", "请选择1条记录，您已选中" + rows.length + "条！", "info");
                return;
            }

            var fun = function () {
                if (callback) {
                    if (typeof (key) == "undefined") {
                        key = $(target).datagrid('options').idField;
                    }

                    var ids = $.map(rows, function (row) {
                        return row[key] || row["ID"];
                    });

                    callback(ids[0], rows[0]);
                }
            };

            if (isNeedConfirm) {
                $.messager.confirm("确认", "您确定执行此操作吗?", function (r) {
                    if (r) {
                        fun();
                    }
                });

                return;
            }

            fun();
        },

        /// <summary>
        /// 从datagrid中多选行帮助函数
        /// </summary>
        MultiSelectGrid: function (target, callback, isNeedConfirm, key, tip) {
            /// <param name="target">datagrid对象</param>
            /// <param name="callback">回调函数</param>
            /// <param name="isNeedConfirm">是否需要确认</param>
            /// <param name="key">主键属性名</param>
            var rows = $(target).datagrid("getSelections");
            if (!rows.length) {
                $.messager.alert("提示", "请选择一条或多条数据", "info");

                return;
            }

            var fun = function () {
                if (callback) {
                    if (typeof (key) == "undefined") {
                        key = $(target).datagrid('options').idField;
                    }

                    var ids = $.map(rows, function (row) {
                        return row[key] || row["ID"];
                    });

                    callback(ids, rows);
                }
            };

            if (isNeedConfirm) {
                $.messager.confirm("确认", tip || "您确定执行此操作吗?", function (r) {
                    if (r) {
                        fun();
                    }
                });

                return;
            }

            fun();
        },

        /// <summary>
        /// 从datagrid中删除选中行帮助函数
        /// </summary>
        RemoveDatagridSelected: function (target, onRemoveing, removeRows, key, onRevoced) {
            /// <param name="target">datagrid对象</param>
            /// <param name="onRemoveing">Js删除前回调函数</param>
            /// <param name="removeRows">是否使用js显式的从表格中删除行数据</param>
            /// <param name="key">主键属性名</param>
            /// <param name="onRevoced">Js删除后回调函数</param>
            var rows = $(target).datagrid("getSelections");
            if (!rows.length) {
                $.messager.alert("提示", "请选择要删除的数据", "info");

                return;
            }

            $.messager.confirm("提示", "您确定删除吗?", function (v) {
                if (!v) {
                    return;
                }

                if (onRemoveing) {
                    if (typeof (key) == "undefined") {
                        key = $(target).datagrid('options').idField;
                    }

                    var ids = $.map(rows, function (row) {
                        return row[key] || row["ID"];
                    });

                    onRemoveing(ids, rows);
                }

                if (typeof (removeRows) == "undefined") {
                    removeRows = true;
                }

                if (onRevoced) {
                    if (typeof (key) == "undefined") {
                        key = "Id";
                    }

                    var ids = $.map(rows, function (row) {
                        return row[key] || row["ID"];
                    });

                    onRevoced(ids, rows);
                }
            });
        },

        /// <summary>
        /// 从treegrid中单选行帮助函数
        /// </summary>
        SingleSelectTreeGrid: function (target, callback, key, isNeedConfirm) {
            /// <param name="target">treegrid对象</param>
            /// <param name="callback">回调函数</param>
            /// <param name="isNeedConfirm">是否需要确认</param>
            /// <param name="key">主键属性名</param>
            var rows = $(target).treegrid("getSelections");
            if (!rows.length || rows.length > 1) {
                $.messager.alert("提示", "请选择一条数据", "info");

                return;
            }

            var fun = function () {
                if (callback) {
                    if (typeof (key) == "undefined") {
                        key = "Id";
                    }

                    var ids = $.map(rows, function (row) {
                        return row[key] || row["ID"];
                    });

                    callback(ids[0], rows[0]);
                }
            };

            if (isNeedConfirm) {
                $.messager.confirm("确认", "您确定执行此操作吗?", function (r) {
                    if (r) {
                        fun();
                    }
                });

                return;
            }

            fun();
        },

        /// <summary>
        /// 从treegrid中删除选中行帮助函数
        /// </summary>
        RemoveTreeGridSelected: function (target, onRemoveing, key) {
            /// <param name="target">treegrid对象</param>
            /// <param name="onRemoveing">Js删除前回调函数</param>
            /// <param name="removeRows">是否使用js显式的从表格中删除行数据</param>
            /// <param name="key">主键属性名</param>
            /// <param name="onRevoced">Js删除后回调函数</param>
            var rows = $(target).treegrid("getSelections");
            if (!rows.length) {
                $.messager.alert("提示", "请选择要删除的数据", "info");

                return;
            }

            $.messager.confirm("提示", "您确定删除吗?", function (v) {
                if (!v) {
                    return;
                }

                if (onRemoveing) {
                    if (typeof (key) == "undefined") {
                        key = "ID";
                    }
                    var ids = $.map(rows, function (row) {
                        return row[key] || row["ID"];
                    });

                    onRemoveing(ids, rows);
                }
            });
        },

        //ajax请求，自动弹出提示框
        //showMessage为false时，不弹出提示框
        Ajax: function (config) {
            var defaultSuccess = config.success;

            var myconfig = $.extend(config, {
                success: function (result) {
                    $.messager.progress('close');
                    if (config.showMessage !== false) {
                        var message = result.success ? "操作成功" : "操作失败";
                        window.top.$.messager.alert("提示", result.message || message);
                    }
                    defaultSuccess(result);
                }
            });

            $.messager.progress();
            $.ajax(myconfig);
        },
        //生成唯一值
        Guid: function () {
            var S4 = function () {
                return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
            };
            var date = new Date();
            return (date.getFullYear().toString() + date.getMonth().toString() + date.getDate().toString() + "-" + date.getHours().toString() + date.getMinutes().toString() + "-" + date.getMinutes().toString() + "-" + date.getMilliseconds().toString() + "-" + S4() + S4() + S4());
        },
        validateConfig: function (options) {

            var config = {
                errorPlacement: function (error, element) {
                    element.parent().after(error);
                    element.parent().css("border-color", "#FF0000");
                }, success: function (node) {
                    $(node).siblings("span").css("border-color", "#95B8E7");
                }, focusCleanup: true
            }
            return $.extend(config, options);
        },
        ViewPictures: function (files) {
            if (typeof files == "string") {
                files = files.split(',');
            }

            $.each(files, function (index, url) {
                window.open(url, '_blank');
            })
            return;

            var dataSource = [];
            var description = [];
            $.each(files, function (index, file) {
                var newmini = file.substr(file.lastIndexOf("."));
                if (newmini == ".JPG" || newmini == ".jpg" || newmini == ".JPEG" || newmini == ".jpeg" || newmini == ".png" || newmini == ".gif" || newmini == ".bmp") {
                    dataSource.push(file);
                    description.push('');
                }
            });

            var controlHtml = "";

            window.top.$.fn.prettyPhoto({
                social_tools: false,
                show_title: false,
                slideshow: 3000,
                autoplay_slideshow: false,
                opacity: 0.70,
                theme: 'pp_default',
                modal: true,
                overlay_gallery: false,
                changepicturecallback: window.top.setZoom,
                callback: window.top.closeZoom,
                social_tools: false,
                image_markup: '<div style="width:99.99999%;height:99.99999%"><img id="fullResImage" src="{path}" /></div>',
                fixed_size: false,
                responsive: false,
                responsive_maintain_ratio: true,
                max_WIDTH: '',
                max_HEIGHT: '',
                allow_expand: false
            });
            window.top.$.prettyPhoto.open(dataSource, [], description);
        },
        Download: function (url) {
            var newmini = url.substr(url.lastIndexOf(".")).toLocaleLowerCase();
            if (newmini == ".jpg" || newmini == ".jpeg" || newmini == ".png" || newmini == ".gif" || newmini == ".bmp") {
                frm = document.createElement("IFRAME");

                frm.style.display = "none";
                document.body.appendChild(frm);
                frm.contentWindow.location.href = RootDirectory + url;

                var setInt = setInterval(function () {
                    try {
                        if (frm.contentWindow.document.readyState == "complete") {
                            frm.contentWindow.document.execCommand("SaveAs");
                            clearInterval(setInt);
                        }
                    }
                    catch (ex) {
                        $.messager.alert("提示", "请使用IE浏览器进行下载");
                        clearInterval(setInt);
                    }
                }, 1000)
            }
            else {
                window.open(RootDirectory + url);
            }
        },
        dateFormatter: function (value, row, index) {
            if (!value) {
                return "";
            }
            try {
                return value.substr(0, 10);
            }
            catch (ex) {
                return value;
            }
        },
        datetimeFormatter: function (value, row, index) {
            if (!value) {
                return "";
            }
            try {
                return value.substr(0, 16);
            }
            catch (ex) {
                return value;
            }
        },

        ShowDetailXM: function (targetTabs, xmxbUrl) {
            commonhelper.addTab(targetTabs, "项目详情", xmxbUrl);
        },
        boolFormatter: function (value, row, index) {
            try {
                return value == 1 ? '是' : '否';
            }
            catch (ex) {
                return value;
            }
        },
        OpenUploadPanel: function (parentId, recordId, parentGrid) {
            if (typeof (parentGrid) == "string") {
                parentGrid = $(parentGrid);
            }
            commonhelper.openWindowInWorkArea(RootDirectory + '/Workflow/Attachment/UploadPanel', {
                title: '上传文件',
                parentId: parentId,
                recordId: recordId,
                parentGrid: parentGrid,
                parentGridType: 'datagrid'
            });
        },
        OpenSaoMiaoPanel: function (applicationUrl, recordId, parentGrid, title) {
            var url = applicationUrl + "/SaoMiao/Index?url=" + applicationUrl + "/SaoMiao/Handler&recordId=" + recordId;
            commonhelper.openWindowInWorkArea(url, {
                title: title || '扫描文件',
                width: 850,
                height: 600,
                mycallback: function () {
                    if (parentGrid) {
                        try {
                            window.$(parentGrid).datagrid('reload');
                        }
                        catch (ex) {

                        }
                    }
                }
            });
        },
        formatState: function (value, row) {
            return value == 1 ? "是" : "否";
        },
        getQueryString: function (name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        },
        //获取根目录
        getRootPath: function () {
            //获取当前网址
            var curWwwPath = window.document.location.href;
            //获取主机地址之后的目录，如： uimcardprj/share/meun.jsp
            var pathName = window.document.location.pathname;

            var pos = curWwwPath.lastIndexOf(pathName);
            //获取主机地址
            var localhostPaht = curWwwPath.substring(0, pos);

            //获取带"/"的项目名，如：/uimcardprj
            var projectName = pathName.substring(0, pathName.substr(1).indexOf('/') + 1);

            return (localhostPaht + projectName);
        },
        formatImage: function (value, row, index) {
            var rootPath = commonhelper.getRootPath();
            return row.TZBH == "" ? "<img src='" + rootPath + "/Content/Images/custom/img-mytz.png' width='16px' height='16px'/>" : "<img src='" + rootPath + "/Content/Images/custom/img-cztz.png' width='16px' height='16px'/>";
        },
        formatMJ: function (value, row, index) {
            if (value) {
                return value + "平方米";
            }
        },
        formatJE: function (value, row, index) {
            if (value) {
                return value + "万元";
            }
        },
        getUrlParam: function (name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var paramStr = window.location.search.substr(1);
            if (paramStr.charAt(paramStr.length - 1) == "#") {
                paramStr = paramStr.substr(0, paramStr.length - 1);
            }
            var r = paramStr.match(reg);
            if (r != null) return decodeURI(r[2]); return null;//解决中文乱码    
        },
        getUrlParams: function () {
            var vars = {}, hash;
            var paramStr = window.location.search.substr(1);
            if (paramStr.charAt(paramStr.length - 1) == "#") {
                paramStr = paramStr.substr(0, paramStr.length - 1);
            }
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).replace('#', '').split('&');
            for (var i = 0; i < hashes.length; i++) {
                hash = hashes[i].split('=');
               // vars.push(hash[0]);
                vars[hash[0]] = hash[1];
            }
            return vars;
        },
        reloadOtherTabGrids: function () {
            var win = commonhelper.getWorkAreaWindow();
            $.each(arguments, function (index, item) {
                for (var i = 0; i < win.parent.frames.length; i++) {
                    try {
                        var frame = win.parent.frames[i];
                        var target = frame.$("#" + item);
                        if (target.length > 0) {
                            target.datagrid('reload');
                        }
                    }
                    catch (e) {

                    }
                }
            })
        },
        sjzdFormatter: function (zdbm) {
            var data = [];
            $.ajax({
                url: window.applicationPath + '/SJZD/GetDataByCode',
                data: { zdbm: zdbm },
                async: false,
                success: function (result) {
                    data = result;
                }
            });
            return function (val) {
                var mc = $.map(data, function (item) {
                    if (item.SZ == val) {
                        return item.Name;
                    }
                    return null;
                })[0];
                
                return mc;
            };
        },
        //格式化创建人名称
        numberFormatter: function (value, row) {
            var value = (value || "").toString();
            var p = /(\d+)(\d{3})/;
            while (p.test(value)) {
                value = value.replace(p, "$1,$2");
            }
            return value;
        },
        sqrFormatter: function (val) {
            if (!val) {
                return "";
            }
            var result = "";
            $.ajax({
                url: window.RootDirectory + '/SQR/GetById',
                data: { Id: val },
                async: false,
                success: function (record) {
                    result = record.SQRMC;
                }
            });
            return result;
        },
        dlrFormatter: function (val) {
            if (!val) {
                return "";
            }
            var result = "";
            $.ajax({
                url: window.RootDirectory + '/DLR/GetById',
                data: { Id: val },
                async: false,
                success: function (record) {
                    result = record.DLRMC;
                }
            });
            return result;
        },
        zblbFormatter: function (val) {
            if (!val) {
                return "";
            }
            var result = "";
            $.ajax({
                type: 'POST',
                url: window.RootDirectory + '/ZBTJ/GetZBLBByID',
                data: { Id: val },
                async: false,
                success: function (record) {
                    if (record) {
                        result = record.LBMC;
                    }
                }
            });
            return result;
        },
        sjlxFormatter: function (val) {
            if (!val) {
                return "";
            }
            var data = { 1: '原件正本', 2: '正本复印件', 3: '原件副本', 4: '副本复印件', 5: '手稿', 99: '其它' };
            return data[val];
        },
        FlowStateFormatter: function (val) {
            try {
                var data = { 0: '空白', 1: '草稿', 2: '运行中', 3: '已完成', 4: '挂起', 5: '退回', 6: '移交' };
                return data[val];
            }
            catch (e) {
                return value;
            }
        },
        fixed2Formatter: function (value, row, index) {
            if (value) { return value.toFixed(2); }
            return value;
        },
        getDictionaryFormatter: function (dicName, value) {
            return sys_data[dicName][value];
        },
        //合并两个json数据
        mergeJsonObject: function (jsonVal1, jsonbVal2) {
            var resultJsonObject = [];
            if (jsonVal1) {
                var jsonbject1 = JSON.parse(jsonVal1);
                for (var attr in jsonbject1) {
                    resultJsonObject.push(jsonbject1[attr]);
                }
            }
            if (jsonbVal2) {
                var jsonbject2 = JSON.parse(jsonbVal2);
                for (var attr in jsonbject2) {
                    resultJsonObject.push(jsonbject2[attr]);
                }
            }
            return JSON.stringify(resultJsonObject);
        },
        viewFile: function (filepath, obj) {
            var controlContainer = $("<div></div>");
            var container = $('<div><div/>').insertAfter(controlContainer);
            var newmini = filepath.substr(filepath.lastIndexOf(".")).toLocaleLowerCase();

            var controlHtml = "";
            if (newmini == ".pdf") {
                window.open(filepath);
                return;
            }
            if (newmini == ".jpg" || newmini == ".png" || newmini == ".gif" || newmini == ".bmp") {
                commonhelper.ViewPictures(filepath);
                return;
            }
            else {
                $.messager.alert("提示", "此文件不支持预览！");
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
        }
    }
})(jQuery);
