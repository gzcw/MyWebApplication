//-------------------------------------------------------------------
//【DLR】Grid
//-------------------------------------------------------------------
function DLR_GridConfig(grid, param) {
    param = param || {};

    var mygrid = grid || $("#DLR_grid");
    var events = {
        Create: param.Create || function () {
            pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/DLR/Form', {
                frame: true,
                title: '新增',
                parentGrid: mygrid,
                defaultValues: param.defaultValues
            });
        },
        Update: param.Update || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id) {
                pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/DLR/Form/' + id, {
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
                    url: RootDirectory + '/Workflow/DLR/Delete',
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
            pageCommonJS.SingleSelectGrid(mygrid, function (id, row) {
                if (window.selectCallback) {
                    window.selectCallback(id, row);
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
        url: RootDirectory + '/Workflow/DLR/GetPaged',
        fit: true,
        border: false,
        pagination: true,
        rownumbers: true,
        checkbox: true,
        columns: [[
            { field: 'ck', checkbox: true },
			{ field: 'ID', hidden: true },
			                { field: 'DLRMC', title: "代理人名称", hidden: false }
			, { field: 'DLRZJLX', title: "代理人证件类型", hidden: false, formatter: pageCommonJS.getDictionaryFormatter("ZJLX") }
			, { field: 'DLRZJH', title: "代理人证件号", hidden: false }
			, { field: 'DLRTXDZ', title: "通信地址", hidden: false }
			, { field: 'DLRYZBM', title: "邮政编码", hidden: false }
			, { field: 'DLRDHHM', title: "代理人电话号码", hidden: false }
			, { field: 'ZGZSHM', title: "资格证书号码", hidden: false }
			, { field: 'SSJG', title: "所属机构", hidden: false }
			, { field: 'JGDM', title: "机构代码，申请代码", hidden: false }
			, { field: 'EMAIL', title: "电子邮件", hidden: false }
			, { field: 'ISDELETE', title: "是否删除", hidden: true }
			, { field: 'ISSHARE', title: "是否共享", hidden: true }
			, { field: 'ISVALID', title: "是否有效", hidden: true }
			, { field: 'ISCONFIG', title: "是否可配置", hidden: true }
			, { field: 'SORTORDER', title: "顺序号", hidden: false }
			, { field: 'CREATEPERSONID', title: "创建人ID", hidden: true }
			, { field: 'CREATEDATE', title: "创建日期", hidden: true }
			, { field: 'MODIFYPERSONID', title: "修改人", hidden: true }
			, { field: 'MODIFYDATE', title: "修改日期", hidden: true }
			, { field: 'DATAORIGIN', title: "", hidden: true }
        ]]
    };
    $.extend(true, this, config, param)
};
