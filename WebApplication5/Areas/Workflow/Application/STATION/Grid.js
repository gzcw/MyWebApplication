//-------------------------------------------------------------------
//【STATION】Grid
//-------------------------------------------------------------------
function STATION_GridConfig(grid, param) {
    param = param || {};

    var mygrid = grid || $("#STATION_grid");
    var events = {
        Create: param.Create || function () {
            pageCommonJS.openWindowInWorkArea(RootDirectory + '/STATION/Form', {
                frame: true,
                title: '新增',
                parentGrid: mygrid,
                defaultValues: param.defaultValues
            });
        },
        Update: param.Update || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id) {
                pageCommonJS.openWindowInWorkArea(RootDirectory + '/STATION/Form/' + id, {
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
                    url: RootDirectory + '/STATION/Delete',
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
            pageCommonJS.MultiSelectGrid(mygrid, function (ids, rows) {
                if (window.selectCallback) {
                    window.selectCallback(ids, rows);
                    window.easyWindow.window('close')
                }
            }, false, "NO");
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
        url: RootDirectory + '/STATION/GetPaged',
        fit: true,
        border: false,
        pagination: true,
        rownumbers: true,
        checkbox: true,
        idField:'NO',
        columns: [[
            { field: 'ck', checkbox: true },
			{ field: 'NO', hidden: true },
			                { field: 'NAME', title: "岗位", hidden: false }
        ]]
    };
    $.extend(true, this, config, param)
};
