//-------------------------------------------------------------------
//    【办文材料】Grid
//-------------------------------------------------------------------
function BWCL_GridConfig(grid, param) {
    param = param || {};
    if (!mygrid) {
        mygrid = grid || $("#BWCL_grid");
    }
    var events = {
        Create: param.Create || function () {
            pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/BWCL/Form', {
                frame: true,
                title: '新增',
                parentGrid: mygrid
            });
        },
        Update: param.Update || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id) {
                pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/BWCL/Form/' + id, {
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
                    url: RootDirectory + '/Workflow/BWCL/Delete',
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
            pageCommonJS.MultiSelectGrid(mygrid, function (id, rows) {
                //  if (window.selectCallback) {
                var BWLCId = $('#BWLCID').val();
                    $.ajax({
                       type: 'post',
                        url: RootDirectory + "/Workflow/BWCL/SaveBWCLSet",
                        data: { BWLCID: BWLCId,IDS:id},
                        success: function (result) {
                            if (result.state = true) {
                                window.easyWindow.window('close');
                                if (me.parentGrid) {
                                    me.parentGrid.datagrid('reload');
                                }
                            }                     
                           // $.messager.showMessage.top(result.message);
                        }
                    });
                   // window.selectCallback(id, row);
                   // window.easyWindow.window('close')
               // }
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
        url: RootDirectory + '/Workflow/BWCL/GetPaged',
        fit: true,
        border: false,
        pagination: true,
        rownumbers: true,
        checkbox: true,
        striped: true,
        singleSelect: false,
        columns: [[
            { field: 'ck', checkbox: true },
			{ field: 'ID', hidden: true },
			                { field: 'CLMC', title: '材料名称', hidden: false, width: 300 }
			, { field: 'CLFZ', title: '材料分组', hidden: false }
			, { field: 'CLYS', title: '材料页数', hidden: false }
			, { field: 'SJLX', title: '收件类型', hidden: false, formatter: pageCommonJS.sjlxFormatter }
			//, { field: 'YJFS', title: '原件份数', hidden: false }
			//, { field: 'FYJFS', title: '复印件份数', hidden: false }
			, { field: 'DATAORIGIN', title: 'DATAORIGIN', hidden: true }
			, { field: 'ISDELETE', title: 'ISDELETE', hidden: true }
			, { field: 'ISSHARE', title: 'ISSHARE', hidden: true }
			, { field: 'ISVALID', title: 'ISVALID', hidden: true }
			, { field: 'ISCONFIG', title: 'ISCONFIG', hidden: true }
			, { field: 'SORTORDER', title: 'SORTORDER', hidden: true }
			, { field: 'ORGANIZATIONID', title: 'ORGANIZATIONID', hidden: true }
			, { field: 'CREATEPERSONID', title: 'CREATEPERSONID', hidden: true }
			, { field: 'CREATEDATE', title: 'CREATEDATE', hidden: true }
			, { field: 'MODIFYPERSONID', title: 'MODIFYPERSONID', hidden: true }
			, { field: 'MODIFYDATE', title: 'MODIFYDATE', hidden: true }
			, { field: 'XH', title: '序号', hidden: false }
        ]]
        //,
        //toolbar: toolBar
    };
    $.extend(this, config, true)
};
