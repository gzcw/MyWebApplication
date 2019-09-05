//-------------------------------------------------------------------
//【FLOW】Grid
//-------------------------------------------------------------------
function FLOW_GridConfig(grid,param) {
    param=param||{};
   
    var mygrid = grid || $("#FLOW_grid");
    var events = {
        Create: param.Create || function () {
            pageCommonJS.openWindowInWorkArea(RootDirectory+'/FLOW/Form', {
                frame: true,
                title: '新增',
                parentGrid: mygrid,
                defaultValues: param.defaultValues
            });
        },
        Update: param.Update || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id) {
                pageCommonJS.openWindowInWorkArea(RootDirectory+'/FLOW/Form/' + id, {
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
                    url: RootDirectory+'/FLOW/Delete',
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
        url: RootDirectory+'/FLOW/GetPaged',
        fit: true,
        border: false,
        pagination: true,
        rownumbers: true,
        checkbox: true,
        columns: [[
            { field: 'ck', checkbox: true },
			{ field: 'ID', hidden: true },
			                { field: 'NO', title: "编号 - 主键", hidden: true }
			,                { field: 'NAME', title: "名称", hidden: false }
			,                { field: 'FK_FLOWSORT', title: "流程类别", hidden: false }
			,                { field: 'FLOWRUNWAY', title: "", hidden: false }
			,                { field: 'RUNOBJ', title: "运行内容", hidden: false }
			,                { field: 'NOTE', title: "备注", hidden: false }
			,                { field: 'RUNSQL', title: "", hidden: false }
			,                { field: 'NUMOFBILL', title: "", hidden: false }
			,                { field: 'NUMOFDTL', title: "", hidden: false }
			,                { field: 'FLOWAPPTYPE', title: "", hidden: false }
			,                { field: 'ISCANSTART', title: "", hidden: false }
			,                { field: 'AVGDAY', title: "", hidden: false }
			,                { field: 'ISFULLSA', title: "", hidden: false }
			,                { field: 'ISMD5', title: "", hidden: false }
			,                { field: 'IDX', title: "顺序号(可以用于流程队列审核模式)", hidden: false }
			,                { field: 'TIMELINEROLE', title: "", hidden: false }
			,                { field: 'PARAS', title: "参数", hidden: false }
			,                { field: 'PTABLE', title: "物理表", hidden: false }
			,                { field: 'DATASTOREMODEL', title: "", hidden: false }
			,                { field: 'TITLEROLE', title: "", hidden: false }
			,                { field: 'FLOWMARK', title: "", hidden: false }
			,                { field: 'FLOWEVENTENTITY', title: "", hidden: false }
			,                { field: 'HISTORYFIELDS', title: "", hidden: false }
			,                { field: 'ISGUESTFLOW', title: "", hidden: false }
			,                { field: 'BILLNOFORMAT', title: "", hidden: false }
			,                { field: 'FLOWNOTEEXP', title: "", hidden: false }
			,                { field: 'DRCTRLTYPE', title: "", hidden: false }
			,                { field: 'STARTLIMITROLE', title: "", hidden: false }
			,                { field: 'STARTLIMITPARA', title: "", hidden: false }
			,                { field: 'STARTLIMITALERT', title: "", hidden: false }
			,                { field: 'STARTLIMITWHEN', title: "", hidden: false }
			,                { field: 'STARTGUIDEWAY', title: "", hidden: false }
			,                { field: 'STARTGUIDEPARA1', title: "导航Url", hidden: false }
			,                { field: 'STARTGUIDEPARA2', title: "", hidden: false }
			,                { field: 'STARTGUIDEPARA3', title: "", hidden: false }
			,                { field: 'ISRESETDATA', title: "", hidden: false }
			,                { field: 'ISLOADPRIDATA', title: "", hidden: false }
			,                { field: 'CFLOWWAY', title: "", hidden: false }
			,                { field: 'CFLOWPARA', title: "", hidden: false }
			,                { field: 'ISBATCHSTART', title: "", hidden: false }
			,                { field: 'BATCHSTARTFIELDS', title: "", hidden: false }
			,                { field: 'ISAUTOSENDSUBFLOWOVER', title: "", hidden: false }
			,                { field: 'VER', title: "", hidden: false }
			,                { field: 'DESIGNERNO', title: "", hidden: false }
			,                { field: 'DESIGNERNAME', title: "", hidden: false }
						        ]]
    };
    $.extend(true, this, config, param)
};
