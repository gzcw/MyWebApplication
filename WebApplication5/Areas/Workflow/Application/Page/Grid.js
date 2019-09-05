//-------------------------------------------------------------------
//【流程页签】Grid
//-------------------------------------------------------------------
function Page_GridConfig(grid, param) {
    param = param || {};
    if (!mygrid) {
        mygrid = grid || $("#Page_grid");
    }
    var events = {
        Create: param.Create || function (defaultValues) {
            pageCommonJS.openWindowInWorkArea(window.RootDirectory + '/Workflow/Page/Form', {
                frame: true,
                title: '新增',
                parentGrid: mygrid,
                defaultValues: defaultValues
            });
        },
        Update: param.Update || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id) {
                pageCommonJS.openWindowInWorkArea(window.RootDirectory + '/Workflow/Page/Form/' + id, {
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
                    url: window.RootDirectory + '/Workflow/Page/Delete',
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
        url: window.RootDirectory + '/Workflow/Page/GetPaged',
        fit: true,
        border: false,
        pagination: true,
        rownumbers: true,
        checkbox: true,
        striped: true,
        columns: [[
            { field: 'ck', checkbox: true },
			{ field: 'ID', hidden: true },
			                { field: 'NAME', title: '页签名称', hidden: false }
			, { field: 'URL', title: '地址', hidden: false }
			, { field: 'SORTNUMBER', title: '排序号', hidden: false }
			, { field: 'FK_FLOW', title: '流程', hidden: true }
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
