//-------------------------------------------------------------------
//【NODESTATION】Grid
//-------------------------------------------------------------------
function NODESTATION_GridConfig(grid,param) {
    param=param||{};
   
    var mygrid = grid || $("#NODESTATION_grid");
    var events = {
        Create: param.Create || function () {
            pageCommonJS.openWindowInWorkArea(RootDirectory+'/NODESTATION/Form', {
                frame: true,
                title: '新增',
                parentGrid: mygrid,
                defaultValues: param.defaultValues
            });
        },
        Update: param.Update || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id) {
                pageCommonJS.openWindowInWorkArea(RootDirectory+'/NODESTATION/Form/' + id, {
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
                    url: RootDirectory+'/NODESTATION/Delete',
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
        url: RootDirectory+'/NODESTATION/GetPaged',
        fit: true,
        border: false,
        pagination: true,
        rownumbers: true,
        checkbox: true,
        columns: [[
            { field: 'ck', checkbox: true },
			{ field: 'ID', hidden: true },
			                { field: 'FK_NODE', title: "节点 - 主键", hidden: true }
			,                { field: 'FK_STATION', title: "岗位", hidden: true }
			,                { field: 'STATIONNAME', title: "岗位", hidden: false }
			,                { field: 'NODENAME', title: "节点", hidden: false }
						        ]]
    };
    $.extend(true, this, config, param)
};
