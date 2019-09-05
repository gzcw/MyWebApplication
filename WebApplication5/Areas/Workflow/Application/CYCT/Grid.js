//-------------------------------------------------------------------
//【CYCT】Grid
//-------------------------------------------------------------------
function CYCT_GridConfig(grid, param) {
    param = param || {};
    if (!mygrid) {
        mygrid = grid || $("#CYCT_grid");
    }
    var events = {
        Create: param.Create || function () {
            pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/CYCT/Form', {
                frame: true,
                title: '新增',
                parentGrid: mygrid
            });
        },
        Update: param.Update || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id, row) {
                pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/CYCT/Form/' + id, {
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
                    url: RootDirectory + '/Workflow/CYCT/Delete',
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
        url: RootDirectory + '/Workflow/CYCT/GetPaged',
        fit: true,
        border: false,
        pagination: true,
        rownumbers: true,
        checkbox: true,
        striped: true,
        columns: [[
            { field: 'ck', checkbox: true }
			, { field: 'CTMC', title: '词条名称', hidden: false }
			, { field: 'CTNR', title: '词条内容', hidden: false }
			, { field: 'CREATOR', title: '创建用户', hidden: false }
        ]]
    };
    $.extend(this, config, true)
};
