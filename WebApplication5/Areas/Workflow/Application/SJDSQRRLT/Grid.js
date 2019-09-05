//-------------------------------------------------------------------
//【SJDSQRRLT】Grid
//-------------------------------------------------------------------
function SJDSQRRLT_GridConfig(grid,param) {
    param=param||{};
   
    var mygrid = grid || $("#SJDSQRRLT_grid");
    var events = {
        Create: param.Create || function () {
            pageCommonJS.openWindowInWorkArea(RootDirectory+'/Workflow/SJDSQRRLT/Form', {
                frame: true,
                title: '新增',
                parentGrid: mygrid,
                defaultValues: param.defaultValues
            });
        },
        Update: param.Update || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id) {
                pageCommonJS.openWindowInWorkArea(RootDirectory+'/Workflow/SJDSQRRLT/Form/' + id, {
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
                    url: RootDirectory+'/Workflow/SJDSQRRLT/Delete',
                    data: { ids: ids },
                    traditional: true,
                    success: function (result) {
                        $.messager.progress('close');
                        if (result.success) {
						    mygrid.datagrid('clearSelections');
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
            pageCommonJS.SingleSelectGrid(mygrid, function (id,row) {
                if (window.selectCallback) {
                    window.selectCallback(id,row);
                    window.easyWindow.window('close')
                }
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
        }
    };
    $.extend(this, events);

    var config = {
        url: RootDirectory+'/Workflow/SJDSQRRLT/GetPaged',
        fit: true,
        border: false,
        pagination: true,
        rownumbers: true,
        checkbox: true,
        columns: [[
            { field: 'ck', checkbox: true },
			{ field: 'ID', hidden: true },
			                { field: 'SQRID', title: "申请人ID", hidden: false }
			,                { field: 'SJDID', title: "一般用办文案ID", hidden: false }
			,                { field: 'SQRJS', title: "申请人角色", hidden: false }
			,                { field: 'DLRID', title: "代理人ID", hidden: false }
			,                { field: 'SQRMC', title: "申请人名称", hidden: false }
			,                { field: 'SQRZJLX', title: "申请人证件类型", hidden: false }
			,                { field: 'SQRZJH', title: "申请人证件号", hidden: false }
			,                { field: 'DLRMC', title: "代理人姓名", hidden: false }
			,                { field: 'DLRZJLX', title: "", hidden: false }
			,                { field: 'DLRZJH', title: "", hidden: false }
						        ]]
    };
    $.extend(true, this, config, param)
};
