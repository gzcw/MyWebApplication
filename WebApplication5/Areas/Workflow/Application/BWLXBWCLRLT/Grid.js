
function BWLXBWCLRLT_GridConfig(grid, param) {
    param = param || {};
    if (!mygrid) {
        mygrid = grid || $("#BWLXBWCLRLT_grid");
    }

    var events = {
        Create: param.Create || function () {

            pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/BWCL/IndexPage?id=' + filters[0].value /*'/Workflow/BWLXBWCLRLT/Form'*/, {
                frame: true,
                title: '新增',
                parentGrid: mygrid,
                defaultValues: param.defaultValues
            });
        },
        Update: param.Update || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id) {
                pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/BWLXBWCLRLT/Form/' + id, {
                    frame: true,
                    title: '修改',
                    parentGrid: mygrid,
                    formId: id,
                    defaultValues: param.defaultValues
                });
            });
        },
        Delete: param.Delete || function () {
            pageCommonJS.RemoveDatagridSelected(mygrid, function (ids, rows) {
                $.messager.progress();
                $.ajax({
                    url: RootDirectory + '/Workflow/BWLXBWCLRLT/Delete',
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

    var toolBar = [{
        iconCls: 'icon-add',
        text: '新增',
        handler: this.Create
    }, '-', {
        iconCls: 'icon-edit',
        text: '修改',
        handler: this.Update
    }, '-', {
        iconCls: 'icon-remove',
        text: '删除',
        handler: this.Delete
    }]
    if (param.showSelection) {
        toolBar.push('-');
        toolBar.push({
            iconCls: 'icon-ok',
            text: '选择',
            hidden: true,
            handler: this.Select
        });
    }

    var config = {
        url: RootDirectory + '/Workflow/BWLXBWCLRLT/GetPaged',
        fit: true,
        border: false,
        pagination: true,
        rownumbers: true,
        checkbox: true,
        striped: true,
        columns: [[
            { field: 'ck', checkbox: true },
			{ field: 'ID', hidden: true },
			                { field: 'BWLXMC', title: '办文类型', hidden: true }
			, { field: 'BWLXID', title: '办文类型', hidden: true }
			, { field: 'CLMC', title: '材料名称', hidden: false, width: 250 }
			, { field: 'BWCLID', title: '办文材料', hidden: true }
			//, { field: 'YJFS', title: '原件份数', hidden: false }
			//, { field: 'FYJFS', title: '复印件份数', hidden: false }
			, { field: 'CLYS', title: '材料页数', hidden: false }
			, { field: 'ISCONFIG', title: 'ISCONFIG', hidden: true }
			, { field: 'DATAORIGIN', title: 'DATAORIGIN', hidden: true }
			, { field: 'BBCLBS', title: '必备材料标识', hidden: true }
        ]]
        //,
        //toolbar: toolBar
    };
    $.extend(this, config, true)
};
