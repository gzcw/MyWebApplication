//-------------------------------------------------------------------
//    【办文案】Grid
//-------------------------------------------------------------------
function BWA_GridConfig(grid, param) {
    param = param || {};
    if (!mygrid) {
        mygrid = grid || $("#BWA_grid");
    }
    var events = {
        Create: param.Create || function () {
            pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/BWA/Form', {
                frame: true,
                title: '新增',
                parentGrid: mygrid
            });
        },
        Update: param.Update || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id) {
                pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/BWA/Form/' + id, {
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
                    url: RootDirectory + '/Workflow/BWA/Delete',
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
    var columns = [];

    if (param.isDBX) {
        columns = [
                  { field: 'ID', hidden: true },
                   { field: 'SLBH', title: '业务编号', hidden: false }
                 , { field: 'TJH', title: '图号', hidden: true }
                 , { field: 'SQRMC', title: '申请人', hidden: true }
                 , { field: 'YWRMC', title: '义务人', hidden: true }
                 , { field: 'SJRQ', title: '收件时间', hidden: true, formatter: pageCommonJS.DateFormatter }
                 , { field: 'SJR', title: '发起用户', hidden: false }
                 , { field: 'RDT', title: '发起时间', hidden: false, formatter: pageCommonJS.DateFormatter }
                 , { field: 'JBR', title: '经办人', hidden: true }
                 , { field: 'CDT', title: '反馈时间', hidden: true, formatter: pageCommonJS.DateFormatter }
                 , { field: 'SLXQ', title: '受理限期', hidden: true }
                 , { field: 'SHJHWCRQ', title: '计划完成时间', hidden: true, formatter: pageCommonJS.DateFormatter }
                 , { field: 'YWFZ', title: '业务分组', hidden: true }
                 , { field: 'ZL', title: '呈批内容', hidden: false }
                 , { field: 'BWLXMC', title: '业务名称', hidden: false }
                 , { field: 'NODENAME', title: '当前环节', hidden: false, flex: 1 }
                 , { field: 'REGISTERDATE', title: '立案时间', hidden: true }
                 , { field: 'BZ', title: '备注', hidden: true }
                 , { field: 'BWLXID', title: 'BWLXID', hidden: true }
                 , { field: 'FK_FLOW', hidden: true }
                 , { field: 'FLOWNAME', hidden: true }
                 , { field: 'WORKID', hidden: true }
                 , { field: 'FK_NODE', hidden: true }
                 , { field: 'FID', hidden: true }
        ];
    }
    else if (param.isZBX) {
        columns = [
                  { field: 'ID', hidden: true },
                   { field: 'SLBH', title: '业务编号', hidden: false }
                 , { field: 'TJH', title: '图号', hidden: true }
                 , { field: 'SQRMC', title: '申请人', hidden: true }
                 , { field: 'YWRMC', title: '义务人', hidden: true }
                 , { field: 'PJJBR', title: '派件人', hidden: false }
                 , { field: 'JBR', title: '经办人', hidden: true }
                 , { field: 'RDT', title: '发起时间', hidden: false, formatter: pageCommonJS.DateFormatter }
                 , { field: 'SJR', title: '发起用户', hidden: false }
                 , { field: 'ZL', title: '呈批内容', hidden: false, flex: 1 }
                 , { field: 'WFSTATE', title: '状态', hidden: false, formatter: pageCommonJS.FlowStateFormatter }
                 , { field: 'CDT', title: '送达时间', hidden: true, formatter: pageCommonJS.DateFormatter }
                 , { field: 'NODENAME', title: '当前环节', hidden: false }
                 , { field: 'SHJHWCRQ', title: '计划完成时间', hidden: true, formatter: pageCommonJS.DateFormatter }
                 , { field: 'YWFZ', title: '业务分组', hidden: true }
                 , { field: 'BWLXMC', title: '业务名称', hidden: false }
                 , { field: 'SLQX', title: '受理期限', hidden: true }
                 , { field: 'REGISTERDATE', title: '立案时间', hidden: true }
                 , { field: 'BZ', title: '备注', hidden: true }
                 , { field: 'BWLXID', title: 'BWLXID', hidden: true }
                 , { field: 'FK_FLOW', hidden: true }
                 , { field: 'FLOWNAME', hidden: true }
                 , { field: 'WORKID', hidden: true }
                 , { field: 'FK_NODE', hidden: true }
                 , { field: 'FID', hidden: true }
        ];
    }
    else if (param.isYWCX) {

        columns = [
                  { field: 'ID', hidden: true },
                   { field: 'SLBH', title: '业务编号', hidden: false }
                 , { field: 'TJH', title: '图号', hidden: true }
                 , { field: 'SQRMC', title: '申请人', hidden: true }
                 , { field: 'YWRMC', title: '义务人', hidden: true }
                 , { field: 'SJRQ', title: '发起时间', hidden: false, formatter: pageCommonJS.DateFormatter }
                 , { field: 'SJR', title: '发起用户', hidden: false }
                 , { field: 'JBR', title: '在办人', hidden: false }
                 , { field: 'ZL', title: '呈批内容', hidden: false, flex: 1 }
                 , { field: 'BWLXMC', title: '业务名称', hidden: false }
                 , { field: 'HJZT', title: '环节状态', hidden: false }
                 , { field: 'SLQX', title: '受理期限', hidden: true }
                 , { field: 'NODENAME', title: '当前环节', hidden: false }
                 , { field: 'ORGANIZATIONNAME', title: '承办部门', hidden: false }
                 , { field: 'RDT', title: '环节开始时间', hidden: true, formatter: pageCommonJS.DateFormatter }
                 , { field: 'CDT', title: '环节结束时间', hidden: true, formatter: pageCommonJS.DateFormatter }
                 , { field: 'SHJHWCRQ', title: '计划完成时间', hidden: true, formatter: pageCommonJS.DateFormatter }
                 , { field: 'YWFZ', title: '业务分组', hidden: true }
                 , { field: 'REGISTERDATE', title: '立案时间', hidden: true }
                 , { field: 'BZ', title: '备注', hidden: true }
                 , { field: 'BWLXID', title: 'BWLXID', hidden: true }
                 , { field: 'FK_FLOW', hidden: true }
                 , { field: 'FLOWNAME', hidden: true }
                 , { field: 'WORKID', hidden: true }
                 , { field: 'FK_NODE', hidden: true }
                 , { field: 'FID', hidden: true }
                 , { field: 'WFSTATE', hidden: true }
        ];
    }
    else if (param.isYWCX_YB) {
        columns = [
                  { field: 'ID', hidden: true },
                   { field: 'SLBH', title: '业务编号', hidden: false }
                 , { field: 'SJRQ', title: '发起时间', hidden: false, formatter: pageCommonJS.DateFormatter }
                 , { field: 'SJR', title: '发起用户', hidden: false }
                 , { field: 'ZBR', title: '在办人', hidden: false }
                 , { field: 'SQRMC', title: '申请人', hidden: true }
                 , { field: 'YWRMC', title: '义务人', hidden: true }
                 , { field: 'JBR', title: '经办人', hidden: true }
                 , { field: 'RDT', title: '环节开始', hidden: true, formatter: pageCommonJS.DateFormatter }
                 , { field: 'SDT', title: '受理限期', hidden: true, formatter: pageCommonJS.DateFormatter }
                 , { field: 'SHJHWCRQ', title: '计划完成时间', hidden: true, formatter: pageCommonJS.DateFormatter }
                 , { field: 'FK_NODETEXT', title: '办理环节', hidden: true }
                 , { field: 'ZL', title: '呈批内容', hidden: false, flex: 1 }
                 , { field: 'HJZT', title: '环节状态', hidden: false, formatter: pageCommonJS.hjztFormatter }
                 , { field: 'YWFZ', title: '业务分组', hidden: true }
                 , { field: 'BWLXMC', title: '业务名称', hidden: false }
                 , { field: 'NODENAME', title: '当前环节', hidden: false }
                 , { field: 'CDT', title: '办结时间', hidden: true, formatter: pageCommonJS.DateFormatter }
                 , { field: 'REGISTERDATE', title: '立案时间', hidden: true }
                 , { field: 'BZ', title: '备注', hidden: true }
                 , { field: 'BWLXID', title: 'BWLXID', hidden: true }
                 , { field: 'FK_FLOW', hidden: true }
                 , { field: 'FLOWNAME', hidden: true }
                 , { field: 'WORKID', hidden: true }
                 , { field: 'FK_NODE', hidden: true }
                 , { field: 'FID', hidden: true }
                 , { field: 'WFSTATE', hidden: true }
        ];
    }
    else {
        columns = [
                 { field: 'ID', hidden: true },
                  { field: 'SLBH', title: '业务编号', hidden: false }
                , { field: 'SQRMC', title: '申请人', hidden: true }
                , { field: 'TJH', title: '图号', hidden: true }
                , { field: 'RDT', title: '记录时间', hidden: true, formatter: pageCommonJS.DateFormatter }
                , { field: 'JBR', title: '经办人', hidden: true }
                , { field: 'CDT', title: '环节结束时间', hidden: true, formatter: pageCommonJS.DateFormatter }
                , { field: 'SDT', title: '受理限期', hidden: true, formatter: pageCommonJS.DateFormatter }
                , { field: 'ZL', title: '呈批内容', hidden: false }
                , { field: 'SHJHWCRQ', title: '计划完成时间', hidden: true, formatter: pageCommonJS.DateFormatter }
                , { field: 'SJR', title: '发起用户', hidden: false }
                , { field: 'SJRQ', title: '发起时间', hidden: false, formatter: pageCommonJS.DateFormatter }
                , { field: 'YWFZ', title: '业务分组', hidden: false }
                , { field: 'BWLXMC', title: '业务名称', hidden: false, flex: 1 }
                , { field: 'NODENAME', title: '当前节点名称', hidden: false }
                , { field: 'REGISTERDATE', title: '立案时间', hidden: true }
                , { field: 'BZ', title: '备注', hidden: true }
                , { field: 'BWLXID', title: 'BWLXID', hidden: true }
                , { field: 'FK_FLOW', hidden: true }
                , { field: 'FLOWNAME', hidden: true }
                , { field: 'WORKID', hidden: true }
                , { field: 'FK_NODE', hidden: true }
                , { field: 'FID', hidden: true }
        ];
    }

    var config = {
        url: RootDirectory + '/Workflow/BWA/GetPaged',
        fit: true,
        border: false,
        pagination: true,
        rownumbers: true,
        checkbox: true,
        striped: true,
        columns: [columns],
        fitColumns: true,
        frozenColumns: [[{ field: 'ck', checkbox: true }]],
        rowStyler: function (index, row) {
            if (row.WFSTATE == "4") {
                return 'color:gray;'; // 返回内联样式	
            }
            else if (row.SLQX && row.SLQX < 5) {
                return 'color:red;'; // 返回内联样式	
            }
        }

    };
    $.extend(this, config, param)
};
