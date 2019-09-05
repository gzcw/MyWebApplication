//-------------------------------------------------------------------
//【BWLX】Grid
//-------------------------------------------------------------------
function BWLX_GridConfig(grid, param) {
    param = param || {};
    if (!mygrid) {
        mygrid = grid || $("#BWLX_grid");
    }
    var events = {
        Create: param.Create || function () {
            pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/BWLX/Form', {
                frame: true,
                title: '新增',
                parentGrid: mygrid
            });
        },
        Update: param.Update || function () {
            pageCommonJS.SingleSelectGrid(mygrid, function (id, row) {
                if (!row.YWFZID) {
                    pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/YWFZ/Form/' + id, {
                        frame: true,
                        title: '修改',
                        parentGrid: mygrid,
                        formId: id
                    });
                    return;
                }
                pageCommonJS.openWindowInWorkArea(RootDirectory + '/Workflow/BWLX/Form/' + id, {
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
                if (!rows[0].YWFZID) {
                    $.ajax({
                        url: RootDirectory + '/Workflow/YWFZ/Delete',
                        data: { ids: ids },
                        traditional: true,
                        success: function (result) {
                            $.messager.progress('close');
                            if (result.success) {
                                mygrid.treegrid('reload');
                            }
                            else {
                                $.messager.alert("提示", result.Message);
                            }
                        }
                    });
                }
                else {
                    $.ajax({
                        url: RootDirectory + '/Workflow/BWLX/Delete',
                        data: { ids: ids },
                        traditional: true,
                        success: function (result) {
                            $.messager.progress('close');
                            if (result.success) {
                                mygrid.treegrid('reload');
                            }
                            else {
                                $.messager.alert("提示", result.Message);
                            }
                        }
                    });
                }
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
                mygrid.treegrid('load', mygrid.queryParams);
            }
            else {
                mygrid.treegrid('reload');
            }
        }
    };
    $.extend(this, events);

    var config = {
        url: RootDirectory + '/Workflow/BWLX/GetPaged',
        fit: true,
        border: false,
        pagination: true,
        rownumbers: true,
        checkbox: true,
        striped: true,
        columns: [[
            { field: 'ck', checkbox: true }
			//{ field: 'ID', hidden: true },
			//{ field: 'YWFZID', title: '业务分组', hidden: true }
			//, { field: 'YWFZ', title: '业务分组', hidden: true }
			, { field: 'BWLXMC', title: '办文类型', hidden: false}
			, { field: 'BWLXSM', title: '办文类型说明', hidden: false }
			, { field: 'JHWCTS', title: '计划完成天数', hidden: false }
			, {
			    field: 'SFSJ', title: '是否收件', formatter: function (value, row, index) {
			        return value == 0 ? "否" : "是";
			    }, hidden: false, width: 80, fixed: true
			}
			, {
			    field: 'SFGD', title: '是否归档', formatter: function (value, row, index) {
			        return value == 0 ? "否" : "是";
			    }, hidden: false, width: 80, fixed: true
			}
			//, { field: 'DAFLID', title: '档案分类', hidden: true }
			//, { field: 'DATAORIGIN', title: 'DATAORIGIN', hidden: true }
			//, { field: 'ISDELETE', title: 'ISDELETE', hidden: true }
			//, { field: 'ISSHARE', title: 'ISSHARE', hidden: true }
			//, { field: 'ISVALID', title: 'ISVALID', hidden: true }
			//, { field: 'ISCONFIG', title: 'ISCONFIG', hidden: true }
			, { field: 'SORTORDER', title: '排序号', hidden: false, width: 60, fixed: true }
			//, { field: 'ORGANIZATIONID', title: 'ORGANIZATIONID', hidden: true }
			//, { field: 'CREATEPERSONID', title: 'CREATEPERSONID', hidden: true }
			//, { field: 'CREATEDate', title: 'CREATEDate', hidden: true }
			//, { field: 'MODIFYPERSONID', title: 'MODIFYPERSONID', hidden: true }
			//, { field: 'MODIFYDATE', title: 'MODIFYDATE', hidden: true }
			//, { field: 'BHID', title: '编号ID', hidden: true }
            , {
                field: 'BWCL',width: 80, fixed: true, title: '办文材料', formatter: function (value, row, index) {
                    if (!row.YWFZID) {
                        return "";
                    }
                    return "<a href='#' onclick=pageCommonJS.OpenChildGrid('Workflow','BWLXBWCLRLT','" + row['ID'] + "','BWLXID','【" + row["BWLXMC"] + "】办文材料')>办文材料</a>";
                }
            }
            , {
                field: 'DYQD', width: 80, fixed: true, title: '打印清单', formatter: function (value, row, index) {
                    if (!row.YWFZID) {
                        return "";
                    }
                    return "<a href='#' onclick=pageCommonJS.OpenChildGrid('Workflow','DYQD','" + row['ID'] + "','BWLX_ID','打印清单配置')>打印清单</a>";
                }
            }
        ]]
    };
    $.extend(this, config, true)
};
