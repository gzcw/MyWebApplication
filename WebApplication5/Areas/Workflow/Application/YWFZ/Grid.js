//-------------------------------------------------------------------
//【YWFZ】Grid
//-------------------------------------------------------------------
function YWFZ_GridConfig(grid, param) {
    param = param || {};
    if (!mygrid) {
        mygrid = grid || $("#YWFZ_grid");
    }
    var events = {
        Create: param.Create || function () {
            pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/YWFZ/Form', {
                frame: true,
                title: '新增',
                parentGrid: mygrid
            });
        },
        Update: param.Update || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id) {
                pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/YWFZ/Form/' + id, {
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
                    url: RootDirectory + '/Workflow/YWFZ/Delete',
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

    var config = {
        url: RootDirectory + '/Workflow/YWFZ/GetPaged',
        fit: true,
        border: false,
        pagination: true,
        rownumbers: true,
        checkbox: true,
        columns: [[
            { field: 'ck', checkbox: true },
			{ field: 'ID', hidden: true },
			                { field: 'FZMC', title: '分组名称', hidden: false }
			, { field: 'FZSM', title: '分组说明', hidden: false }
			, { field: 'IsDelete', title: 'IsDelete', hidden: true }
			, { field: 'IsShare', title: 'IsShare', hidden: true }
			, { field: 'IsValid', title: 'IsValid', hidden: true }
			, { field: 'IsConfig', title: 'IsConfig', hidden: true }
			, { field: 'SORTORDER', title: '排序号', hidden: false }
			, { field: 'CreatePersonID', title: 'CreatePersonID', hidden: true }
			, { field: 'CreateDate', title: 'CreateDate', hidden: true }
			, { field: 'ModifyPersonID', title: 'ModifyPersonID', hidden: true }
			, { field: 'ModifyDate', title: 'ModifyDate', hidden: true }
			, { field: 'DATAORIGIN', title: 'DATAORIGIN', hidden: true }
			, { field: 'ORGANIZATIONID', title: 'ORGANIZATIONID', hidden: true }
        ]]
    };
    $.extend(this, config, true)
};
