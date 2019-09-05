//-------------------------------------------------------------------
//【流程定义】Grid
//-------------------------------------------------------------------
function Definition_GridConfig(grid, param) {
    param = param || {};
    if (!mygrid) {
        mygrid = grid || $("#Definition_grid");
    }
    var events = {
        Create: param.Create || function () {
            pageCommonJS.openWindowInWorkArea(window.RootDirectory + '/Workflow/FLOW/Form', {
                frame: true,
                title: '新增',
                parentGrid: mygrid
            });
        },
        Update: param.Update || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id) {
                pageCommonJS.openWindowInWorkArea(window.RootDirectory + '/Workflow/FLOW/Form/' + id, {
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
                    url: window.RootDirectory + '/Workflow/FLOW/Delete',
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
        url: window.RootDirectory + '/Workflow/FLOW/GetPaged',
        fit: true,
        border: false,
        pagination: true,
        rownumbers: true,
        checkbox: true,
        striped: true,
        columns: [[
            { field: 'ck', checkbox: true },
			{ field: 'ID', hidden: true },
			{ field: 'NAME', title: '流程名称', hidden: false },
            {
                field: 'Page', title: '页签', formatter: function (value, row, index) {
                    if (!row.FK_FLOWSORT) {
                        return "";
                    }
                    return "<a href='#' onclick=pageCommonJS.OpenChildGrid('Workflow','Page','" + row['ID'] + "','FK_FLOW','【" + row["NAME"] + "】页签')>页签</a>";
                }
            },
            {
                field: 'Node', title: '节点', formatter: function (value, row, index) {
                    if (!row.FK_FLOWSORT) {
                        return "";
                    }
                    return "<a href='#' onclick=pageCommonJS.OpenChildGrid('Workflow','Node','" + row['ID'] + "','FK_FLOW','【" + row["NAME"] + "】节点')>节点</a>";
                }
            }
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
