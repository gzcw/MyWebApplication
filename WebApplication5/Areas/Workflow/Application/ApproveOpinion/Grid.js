
function ApproveOpinion_GridConfig(grid,param) {
    param=param||{};
    if (!mygrid) {
        mygrid = grid || $("#ApproveOpinion_grid");
    }
    var events = {
        Create: param.Create || function () {
            pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/ApproveOpinion/Form', {
                frame: true,
                title: '新增',
                parentGrid: mygrid
            });
        },
        Update: param.Update || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id) {
                pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/ApproveOpinion/Form/' + id, {
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
                    url: RootDirectory + '/Workflow/ApproveOpinion/Delete',
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
        }
    };
    $.extend(this, events);

    var config = {
        url: RootDirectory + '/Workflow/ApproveOpinion/GetPaged',
        fit: true,
        border: false,
        pagination: true,
        rownumbers: true,
        checkbox: true,
        columns: [[
            { field: 'ck', checkbox: true },
			{ field: 'ID', hidden: true },
			                { field: 'Approver', title: '审批人', hidden: false }
			,                { field: 'Department', title: 'Department', hidden: false }
			,                { field: 'Opinion', title: 'Opinion', hidden: false }
			,                { field: 'Node_id', title: '流程节点', hidden: false }
			,                { field: 'Station', title: 'Station', hidden: false }
			,                { field: 'Nodename', title: '节点', hidden: false }
			,                { field: 'Work_id', title: 'Work_id', hidden: false }
			,                { field: 'Createtime', title: 'Createtime', hidden: false }
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
