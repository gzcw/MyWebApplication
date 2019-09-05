//-------------------------------------------------------------------
//【TJXX】Grid
//-------------------------------------------------------------------
function TJXX_GridConfig(grid,param) {
    param=param||{};
    if (!mygrid) {
        mygrid = grid || $("#TJXX_grid");
    }
    var events = {
        Create: param.Create || function () {
            pageCommonJS.openWindowInWorkArea(RootDirectory+'/Workflow/TJXX/Form', {
                frame: true,
                title: '新增',
                parentGrid: mygrid
            });
        },
        Update: param.Update || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id) {
                pageCommonJS.openWindowInWorkArea(RootDirectory+'/Workflow/TJXX/Form/' + id, {
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
                    url: RootDirectory+'/Workflow/TJXX/Delete',
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
        url: RootDirectory+'/Workflow/TJXX/GetPaged',
        fit: true,
        border: false,
        pagination: true,
        rownumbers: true,
        checkbox: true,
        columns: [[
            { field: 'ck', checkbox: true },
			{ field: 'ID', hidden: true },
			                { field: 'BWAID', title: 'BWAID', hidden: false }
			,                { field: 'SLBH', title: '受理编号', hidden: false }
			,                { field: 'YWFZ', title: '业务分组', hidden: false }
			,                { field: 'YWLX', title: '业务类型', hidden: false }
			,                { field: 'TJYY', title: '退件原因', hidden: false }
			,                { field: 'CREATORID', title: '创建人ID', hidden: true }
			,                { field: 'CREATETIME', title: '创建时间', hidden: true }
						        ]]
    };
    $.extend(this, config, true)
};
