
function SJCLMX_GridConfig(grid, param) {
    param = param || {};
    var mygrid = $("#SJCLMX_Grid");

    var events = {
        Create: param.Create || function () {
            pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/SJCLMX/Form', {
                frame: true,
                title: '新增',
                parentGrid: mygrid
            });
        },
        Update: param.Update || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id) {
                pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/SJCLMX/Form/' + id, {
                    frame: true,
                    title: '修改',
                    parentGrid: mygrid,
                    formId: id
                });
            });
        },
        Delete: param.Delete || function () {
            pageCommonJS.RemoveDatagridSelected(mygrid, function (ids, rows) {
                $.messager.progress();
                $.ajax({
                    url: RootDirectory + '/Workflow/SJCLMX/Delete',
                    data: { ids: ids },
                    traditional: true,
                    success: function (result) {
                        $.messager.progress('close');
                        if (result.success) {
                            mygrid.datagrid('reload');
                        }
                        else {
                            $.messager.alert("提示", result.message || "删除失败");
                        }
                    }
                });
            });
        },
        Refresh: param.Refresh || function () {
            mygrid.datagrid('clearSelections');
            if (mygrid.queryParams) {
                mygrid.datagrid('load', mygrid.queryParams);
            }
            else {
                mygrid.datagrid('reload');
            }
        },
        Detail: param.Refresh || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id) {
                pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/SJCLMX/Form?permission=0&id=' + id, {
                    frame: true,
                    title: '查看',
                    parentGrid: mygrid,
                    formId: id
                });
            });
        },
        MultiSelectGrid: param.MultiSelectGrid || function (sflyzmwj) {
            pageCommonJS.MultiSelectGrid(mygrid, function (ids, rows) {
                $.ajax({
                    url: RootDirectory + '/Workflow/SJCLMX/UpdateRows',
                    data: { ids: ids, sflyzmwj: sflyzmwj },
                    traditional: true,
                    success: function (result) {
                        if (result.success) {
                            mygrid.datagrid('reload');
                        }
                        else {
                            $.messager.alert("提示", result.message || "更新失败");
                        }
                    }
                });
            })
        },
        UpdateSFLYZMWJValue: param.UpdateSFLYZMWJValue || function (rows, value) {
            $.each(rows, function (index, row) {
                row.SFLYZMWJ = value;
                var rowIndex = mygrid.datagrid('getRowIndex', row);
                mygrid.datagrid('updateRow', {
                    index: rowIndex,
                    row: row
                });
            });
        },
        SetSJDToZMWJ: param.SetSJDToZMWJ || function () {
            var rows = mygrid.datagrid('getChecked');
            if (rows.length == 0) {
                $.messager.alert("操作提示", "请选择要标记为来源证明文件的记录！");
                return;
            }
            //events.UpdateSFLYZMWJValue(rows, 1);
            events.MultiSelectGrid(1);
        },
        CancelSJDToZMWJ: param.CancelSJDToZMWJ || function () {
            var rows = mygrid.datagrid('getChecked');
            if (rows.length == 0) {
                $.messager.alert("操作提示", "请选择要取消标记为来源证明文件的记录！");
                return;
            }
            //events.UpdateSFLYZMWJValue(rows, 0);
            events.MultiSelectGrid(0);
        },
        CreateModule: function () {
            var rows = mygrid.datagrid('getRows');
            if (rows.length == 0) {
                $.messager.alert('提示', '办文材料不能空');
                return false;
            }
            $("#module").dialog({
                title: '另存为模板',
                width: 400,
                height: 200,
                closed: false,
                modal: true,
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-save',
                    handler: function () {
                        $.ajax({
                            url: RootDirectory + '/Workflow/SJCLMX/SaveModule',
                            data: { records: JSON.stringify(rows), moduleName: $('#moduleName').val() },
                            traditional: true,
                            type: 'post',
                            success: function (result) {
                                if (result.success) {
                                    window.top.$.messager.alert("提示", "保存成功");
                                    $("#module").dialog('close');
                                }
                                else {
                                    window.top.$.messager.alert("提示", result.msg || "保存失败");
                                }
                            }
                        });
                    }
                }, {
                    text: '关闭',
                    iconCls: 'icon-close',
                    handler: function () { $("#module").dialog('close') }
                }]
            });
        },
        SelectModule: function () {
            $("#selectModuleName").combobox({
                url: RootDirectory + '/Workflow/SJCLMX/GetModuleNameByCurrentUser',
                valueField: 'BWCLID',
                textField: 'BWCLID'
            });
            $("#selectModule").dialog({
                title: '选择模板',
                width: 400,
                height: 200,
                closed: false,
                modal: true,
                buttons: [{
                    text: '确定',
                    iconCls: 'icon-save',
                    handler: function () {
                        var moduleName = $('#selectModuleName').combobox('getValue');
                        if (moduleName == undefined || moduleName == "") {
                            $.messager.alert("提示", '请选择模板！');
                            return false;
                        }
                        $.ajax({
                            url: RootDirectory + '/Workflow/SJCLMX/CreateByModuleName',
                            data: { moduleName: moduleName, sjdID: param.SJDID },
                            type: 'post',
                            success: function (result) {
                                if (result.success) {
                                    $.messager.alert("提示", "操作成功");
                                    mygrid.datagrid('reload');
                                    $("#selectModule").dialog('close');
                                }
                                else {
                                    $.messager.alert("提示", result.msg || "操作失败");
                                }
                            }
                        });
                    }
                }, {
                    text: '删除模板',
                    iconCls: 'icon-remove',
                    handler: function () {
                        var moduleName = $('#selectModuleName').combobox('getValue');
                        if (!moduleName) {
                            $.messager.alert('提示', '请选择要删除的模板！');
                            return;
                        }
                        $.messager.confirm('提示', '确定删除模板【' + moduleName + '】吗？', function (r) {
                            if (r) {
                                $.ajax({
                                    url: RootDirectory + '/Workflow/SJCLMX/DeleteModule',
                                    data: { moduleName: moduleName },
                                    type: 'post',
                                    success: function (result) {
                                        if (result.success) {
                                            $.messager.alert("提示", "删除成功");
                                            $("#selectModuleName").combobox('clear');
                                            $("#selectModuleName").combobox('reload');
                                        }
                                        else {
                                            $.messager.alert("提示", result.msg || "操作失败");
                                        }
                                    }
                                });
                            }
                        });
                    }
                }, {
                    text: '关闭',
                    iconCls: 'icon-clear',
                    handler: function () { $("#selectModule").dialog('close') }
                }]
            });
        }
    };
    $.extend(this, events);

    var config = {
        url: RootDirectory + '/Workflow/SJCLMX/GetData',
        fit: true,
        border: false,
        pagination: true,
        rownumbers: true,
        checkbox: true,
        idField:'ID',
        striped: true,
        width: 'auto',
        columns: [[
            { field: 'ck', checkbox: true },
			{ field: 'ID', hidden: true },
			{ field: 'FILESPATH', hidden: true },
			                { field: 'BWCLID', title: '办文材料ID', hidden: true }
			, { field: 'SJDID', title: '签收单ID', hidden: true }
			, { field: 'WJDLID', title: '文件材料ID', hidden: true }
			, { field: 'CLMC', title: '材料名称', width: 300 }
			//, { field: 'CLBH', title: '材料编号', width: 60 }
			, { field: 'SJLX', title: '收件类型', width: 90, formatter: pageCommonJS.sjlxFormatter }
			, { field: 'SJSL', title: '收件数量', width:70 }
			//, { field: 'CLYS', title: '材料页数', width: 60 }
			, { field: 'YJBS', title: '移交标识', hidden: true }
			, { field: 'FJLJ', title: '扫描件路径', hidden: true }
			, { field: 'DataOrigin', title: 'DataOrigin', hidden: true }
            , { field: 'ATTACHMENTCOUNT', title: '已上传附件数', width: 100 }
			//, { field: 'SH', title: '序号', width: 50 }
			, { field: 'CLLYBS', title: '材料来源标识', hidden: true }
            , { field: 'SFLYZMWJ', title: '是否来源证明文件', hidden: true, width: 100, formatter: function (value) { return value == 1 ? '是' : '否' } }
            , {
                field: 'upload', align: 'left', title: '上传', width: 60, formatter: function (value, row, index) {
                    if (row.Isdirectory) {
                        return "";
                    }
                    return '<a href="#" onclick="pageCommonJS.OpenUploadPanel(\'\',\'' + row.ID + '\',\'#SJCLMX_Grid\')">上传</a>';
                }
            }
            //, {
            //    field: 'saomiao', align: 'left', title: '扫描', width: 60, formatter: function (value, row, index) {
            //        if (row.Isdirectory) {
            //            return "";
            //        }

            //        var applicationUrl = param.applicationUrl;
            //        return '<a href="#" onclick="pageCommonJS.OpenSaoMiaoPanel(\'' + applicationUrl + '\',\'' + row["ID"] + '\',\'#SJCLMX_Grid\')">扫描</a>';
            //    }
            //}
			, {
			    field: 'operation', align: 'left', title: '预览', width: 50, formatter: function (value, row, index) {
			        if (row.Isdirectory) {
			            return "";
			        }
			        if (row.ATTACHMENTCOUNT > 0) {
			            return '<a href="#" onclick="pageCommonJS.ViewPictures(\'' + row.FILESPATH + '\')">预览</a>';
			        }
			        return "——";
			    }
			}
        ]],
        toolbar: [{
            iconCls: 'icon-add',
            text: '新增',
            id: 'bwcl_add',
            handler: this.Create
        }, '-', {
            iconCls: 'icon-edit',
            text: '修改',
            id: 'bwcl_update',
            handler: this.Update
        }, '-', {
            iconCls: 'icon-remove',
            text: '删除',
            id: 'bwcl_delete',
            handler: this.Delete
        }, '-', {
            iconCls: 'icon-reload',
            text: '刷新',
            id: 'bwcl_refresh',
            permission: 0,
            handler: this.Refresh
        }, '-', {
            iconCls: 'icon-search',
            text: '查看',
            permission: 0,
            handler: this.Detail
        },
        //'-', {
        //    iconCls: 'icon-edit',
        //    text: '标记为来源证明文件',
        //    id: 'bwcl_bjlywj',
        //    handler: this.SetSJDToZMWJ
        //}, '-', {
        //    iconCls: 'icon-edit',
        //    text: '取消标记为来源证明文件',
        //    id: 'bwcl_qxbjlywj',
        //    handler: this.CancelSJDToZMWJ
        //},
        '-', {
            iconCls: 'icon-edit',
            text: '另存为模板',
            id: 'bwcl_lcwmb',
            handler: this.CreateModule
        }, '-', {
            iconCls: 'icon-edit',
            text: '选择模板',
            id: 'bwcl_xzmb',
            handler: this.SelectModule
        }]
    };
    $.extend(true, this, param, config)
};
