
function BH_GridConfig(grid, param) {
    param = param || {};
    if (!mygrid) {
        mygrid = grid || $("#BH_grid");
    }
    var events = {
        Create: param.Create || function () {
            pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/BH/Form', {
                frame: true,
                title: '新增',
                parentGrid: mygrid
            });
        },
        Update: param.Update || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id) {
                pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/BH/Form/' + id, {
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
                    url: RootDirectory + '/Workflow/BH/Delete',
                    data: { ids: ids },
                    traditional: true,
                    success: function (result) {
                        $.messager.progress('close');
                        if (result.success) {
                            mygrid.datagrid('reload');
                        }
                        else {
                            $.messager.alert("提示", result.Message);
                        }
                    }
                });
            });
        },
        Select: param.Select || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id, row) {
                if (window.selectCallback) {
                    window.selectCallback(id, row);
                    window.easyWindow.window('close')
                }
            });
        },
        Refresh: param.Refresh || function () {
            if (mygrid.queryParams) {
                mygrid.datagrid('load', mygrid.queryParams);
            }
            else {
                mygrid.datagrid('reload');
            }
        }
    };
    $.extend(this, events);

    var toolBar = [{
        iconCls: 'icon-add',
        text: '新增',
        handler: this.Create
    }, '-', {
        iconCls: 'icon-edit',
        text: '修改',
        handler: this.Update
    }, '-', {
        iconCls: 'icon-remove',
        text: '删除',
        handler: this.Delete
    }];
    if (param.showSelection) {
        toolBar.push('-');
        toolBar.push({
            iconCls: 'icon-ok',
            text: '选择',
            hidden: true,
            handler: this.Select
        });
    }

    var config = {
        url: RootDirectory + '/Workflow/BH/GetPaged',
        fit: true,
        border: false,
        pagination: true,
        rownumbers: true,
        checkbox: true,
        columns: [[
            { field: 'ck', checkbox: true },
			{ field: 'ID', hidden: true },
			                { field: 'BHMC', title: '编号名称', hidden: false }
			, { field: 'CZFS', title: '重置方式', hidden: true }
			, { field: 'BHBDS', title: '编号表达式', hidden: false }
			, { field: 'LSH', title: '当前流水号', hidden: false }
			, { field: 'BC', title: '流水号步长', hidden: false }
			, { field: 'CD', title: '流水号长度', hidden: false }
			, { field: 'BHSM', title: '编号说明', hidden: false }
			, { field: 'ISDELETE', title: '是否已删除', hidden: true }
			, { field: 'ISSHARE', title: '是否共享', hidden: true }
			, { field: 'ISVALID', title: '是否有效', hidden: true }
			, { field: 'ISCONFIG', title: '是否可配置', hidden: true }
			, { field: 'SORTORDER', title: '排序号', hidden: false }
			, { field: 'CREATEPERSONID', title: '创建人ID', hidden: true }
			, { field: 'CREATEDATE', title: '创建日期', hidden: true }
			, { field: 'MODIFYPERSONID', title: '修改人ID', hidden: true }
			, { field: 'MODIFYDATE', title: '修改日期', hidden: true }
			, { field: 'DATAORIGIN', title: '数据来源', hidden: true }
        ]]
        //,
        //toolbar: toolBar
    };
    $.extend(this, config, true)
};
