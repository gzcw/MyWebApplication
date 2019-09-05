
function SQR_GridConfig(grid, param) {
    param = param || {};
    if (!mygrid) {
        mygrid = grid || $("#SQR_grid");
    }
    var events = {
        Create: param.Create || function () {
            pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/SQR/Form', {
                frame: true,
                title: '新增',
                parentGrid: mygrid
            });
        },
        Update: param.Update || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id) {
                pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/SQR/Form/' + id, {
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
                    url: RootDirectory + '/Workflow/SQR/Delete',
                    data: { ids: ids },
                    traditional: true,
                    success: function (result) {
                        $.messager.progress('close');
                        mygrid.datagrid('clearSelections');
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
        toolBar.splice(0, 0, {
            iconCls: 'icon-ok',
            text: '确定',
            hidden: true,
            handler: this.Select
        });
        toolBar.splice(1, 0, '-');
    }

    var config = {
        url: RootDirectory + '/Workflow/SQR/GetPaged',
        fit: true,
        border: false,
        pagination: true,
        rownumbers: true,
        checkbox: true,
        striped: true,
        columns: [[
            { field: 'ck', checkbox: true },
			{ field: 'ID', hidden: true },
			                { field: 'BSID', title: 'BSID', hidden: true }
			, { field: 'SQRMC', title: '申请人名称', hidden: false }
			, { field: 'SQRLX', title: '申请人类型', hidden: true }
			, { field: 'SQRZJLX', title: '申请人证件类型', hidden: false, formatter: pageCommonJS.getDictionaryFormatter("ZJLX") }
			, { field: 'SQRZJH', title: '申请人证件号', hidden: false }
			, { field: 'ZGBM', title: '主管部门', hidden: false }
			, { field: 'ZGBMDM', title: '主管部门代码', hidden: false }
			, { field: 'JGDM', title: '机构代码', hidden: true }
			, { field: 'DWXZ', title: '单位性质', hidden: false }
			//, { field: 'FRDBXM', title: '法人代表姓名', hidden: true }
			//, { field: 'FRDBZJLX', title: '法人代表证件类型', hidden: true }
			//, { field: 'FRDBZJH', title: '法人代表证件号', hidden: true }
			//, { field: 'FRDBDHHM', title: '法人代表电话号码', hidden: true }
			//, { field: 'FRZW', title: '法人职务', hidden: true }
			//, { field: 'SJHM', title: '法人手机号码', hidden: true }
			, { field: 'LXR', title: '联系人', hidden: false }
			, { field: 'LXDH', title: '联系电话', hidden: false }
			, { field: 'CZHM', title: '传真号码', hidden: true }
			, { field: 'EMAIL', title: '电子邮件', hidden: false }
			//, { field: 'TXDZ', title: '通讯地址', hidden: true }
			//, { field: 'YZBM', title: '邮政编码', hidden: true }
			//, { field: 'NYHKBS', title: '农业人口标识', hidden: true }
			//, { field: 'ZXBS', title: '注销标识', hidden: true }
			//, { field: 'KHYH', title: '开户银行', hidden: true }
			//, { field: 'YHZH', title: '银行账号', hidden: true }
			//, { field: 'ZCZJ', title: '注册资金', hidden: true }
			//, { field: 'ZJLY', title: '资金来源', hidden: true }
			//, { field: 'ISDELETE', title: '是否已删除', hidden: true }
			//, { field: 'ISSHARE', title: '是否共享', hidden: true }
			//, { field: 'ISVALID', title: '是否有效', hidden: true }
			//, { field: 'ISCONFIG', title: '是否可配置', hidden: true }
			//, { field: 'CREATEPERSONID', title: '创建人ID', hidden: true }
			//, { field: 'CREATEDATE', title: '创建日期', hidden: true }
			//, { field: 'MODIFYPERSONID', title: '修改人ID', hidden: true }
			//, { field: 'MODIFYDATE', title: '修改日期', hidden: true }
			//, { field: 'DATAORIGIN', title: '数据来源', hidden: true }
			//, { field: 'ORGANIZATIONID', title: '组织机构部门', hidden: false }
			//, { field: 'PREVIOUSID', title: '历史数据ID', hidden: true }
			//, { field: 'GSZZBH', title: '工商执照编号', hidden: true }
			, { field: 'SORTORDER', title: '排序号', hidden: false, flex: 1 }
        ]]
        //,
        //toolbar: toolBar
    };
    $.extend(this, config, true)
};
