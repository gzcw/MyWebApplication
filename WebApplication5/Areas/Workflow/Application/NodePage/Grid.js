//-------------------------------------------------------------------
//【节点页签】Grid
//-------------------------------------------------------------------
function NodePage_GridConfig(grid, param) {
    param = param || {};
    if (!mygrid) {
        mygrid = grid || $("#NodePage_grid");
    }
    var events = {
        Create: param.Create || function () {
            pageCommonJS.openWindowInWorkArea(window.RootDirectory + '/Workflow/NodePage/Form', {
                frame: true,
                title: '新增',
                parentGrid: mygrid
            });
        },
        Update: param.Update || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id) {
                pageCommonJS.openWindowInWorkArea(window.RootDirectory + '/Workflow/NodePage/Form/' + id, {
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
                    url: window.RootDirectory + '/Workflow/NodePage/Delete',
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
        Select: param.Select || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id) {
                if (window.selectCallback) {
                    window.selectCallback(id);
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

    var config = {
        url: window.RootDirectory + '/Workflow/NodePage/GetPaged',
        fit: true,
        border: false,
        pagination: true,
        rownumbers: true,
        checkbox: true,
        striped: true,
        columns: [[
            { field: 'ck', checkbox: true },
			{ field: 'ID', hidden: true },
			                { field: 'NODE_ID', title: '节点', hidden: true }
			, { field: 'NODENAME', title: '节点', hidden: false }
			, { field: 'PAGENAME', title: '页签', hidden: false }
			, { field: 'PAGE_ID', title: '页签', hidden: true }
			, {
			    field: 'PERMISSION', title: '权限', hidden: false, formatter: function (value, row) {
			        if (value == 1) {
			            return "读写";
			        }
			        if (value == 0) {
			            return "只读";
			        }
			        return value;
			    }
			}
			, { field: 'PARAMS', title: '自定义参数', hidden: false }
			, { field: 'SORTNUMBER', title: '排序号', hidden: false }
        ]]
        //,
        //toolbar: [{
        //    iconCls: 'icon-add',
        //    text: '新增',
        //    handler: this.Create
        //}, '-', {
        //    iconCls: 'icon-edit',
        //    text: '修改',
        //    handler: this.Update
        //}, '-', {
        //    iconCls: 'icon-remove',
        //    text: '删除',
        //    handler: this.Delete
        //}]
    };
    $.extend(this, config, true)
};
