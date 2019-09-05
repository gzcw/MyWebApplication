//-------------------------------------------------------------------
//【FLOWSORT】Grid
//-------------------------------------------------------------------
function FLOWSORT_GridConfig(grid,param) {
    param=param||{};
   
    var mygrid = grid || $("#FLOWSORT_grid");
    var events = {
        Create: param.Create || function () {
            pageCommonJS.openWindowInWorkArea(RootDirectory+'/FLOWSORT/Form', {
                frame: true,
                title: '新增',
                parentGrid: mygrid,
                defaultValues: param.defaultValues
            });
        },
        Update: param.Update || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id) {
                pageCommonJS.openWindowInWorkArea(RootDirectory+'/FLOWSORT/Form/' + id, {
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
                    url: RootDirectory+'/FLOWSORT/Delete',
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
        url: RootDirectory+'/FLOWSORT/GetPaged',
        fit: true,
        border: false,
        pagination: true,
        rownumbers: true,
        checkbox: true,
        columns: [[
            { field: 'ck', checkbox: true },
			{ field: 'ID', hidden: true },
			                { field: 'NO', title: "编号 - 主键", hidden: false }
			,                { field: 'NAME', title: "名称", hidden: false }
			,                { field: 'PARENTNO', title: "父节点No", hidden: false }
			,                { field: 'TREENO', title: "树编号", hidden: false }
			,                { field: 'IDX', title: "顺序号(可以用于流程队列审核模式)", hidden: false }
			,                { field: 'ISDIR', title: "是否目录", hidden: false }
						        ]]
    };
    $.extend(true, this, config, param)
};
