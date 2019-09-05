//-------------------------------------------------------------------
//【SJDSQRRLT】Grid
//-------------------------------------------------------------------
function SJDSQRRLT_EditGridConfig(grid, param) {
    param = param || {};

    var mygrid = grid || $("#SJDSQRRLT_grid");

    mygrid.qlrjsFormatter = function (value, row, index) {
        var result = value;
        if (mygrid.Data) {
            $.each(mygrid.Data, function (index, item) {
                if (value == item.CODE) {
                    result = item.NAME;
                    return false;
                }
            });
        }
        result = pageCommonJS.getDictionaryFormatter("QLRLX")(value);
        return result;
    };

    mygrid.endEdit = function (rowIndex, rowData, changes) {
        var combobox = mygrid.mydatagrid("getEditor", { index: rowIndex, field: 'SQRJS' });
        if (combobox) {
            var data = $(combobox.target).combobox("getData");
            mygrid.Data = data;
        }
    }
    var config = {
        url: RootDirectory + '/Workflow/SJDSQRRLT/GetPaged',
        fit: false,
        fitColumns: false,
        width: 700,
        height: 200,
        border: true,
        striped: true,
        columns: [[
                {
                    field: 'SQRID', title: '申请人', width: 140, formatter: pageCommonJS.sqrFormatter, editor: {
                        type: 'sqrselectwindow',
                        options: {
                            width: 140,
                            onSelect: function (row) {
                                var oldRow = sqrgrid.datagrid('getRows')[sqrgrid.editIndex];
                                var newRow = $.extend(oldRow, { SQRID: row.ID, SQRZJLX: row.SQRZJLX, SQRZJH: row.SQRZJH });
                                sqrgrid.datagrid('updateRow', {
                                    index: sqrgrid.editIndex,
                                    row: newRow
                                });

                                //setTimeout(function () {
                                //    sqrgrid.datagrid('beginEdit', 0);
                                //}, 1000)
                            }
                        }
                    }
                },
                { field: 'SQRZJLX', title: '申请人证件类型', width: 95, formatter: pageCommonJS.getDictionaryFormatter("ZJLX") },
                { field: 'SQRZJH', title: '申请人证件号', width: 150 },
                { field: 'SQRJS', title: '申请人角色', width: 100, formatter: mygrid.qlrjsFormatter, editor: { type: 'dictionarycombobox', options: { KEY: 'QLRLX' } } },
                {
                    field: 'DLRID', title: '代理人', width: 140, formatter: pageCommonJS.dlrFormatter, editor: {
                        type: 'dlrselectwindow',
                        options: {
                            required: false,
                            width: 140,
                            onSelect: function (row) {
                                var oldRow = sqrgrid.datagrid('getRows')[sqrgrid.editIndex];
                                var newRow = $.extend(oldRow, { DLRID: row.ID, DLRZJLX: row.DLRZJLX, DLRZJH: row.DLRZJH });
                                sqrgrid.datagrid('updateRow', {
                                    index: sqrgrid.editIndex,
                                    row: newRow
                                });
                            }
                        }
                    }
                },
                { field: 'DLRZJLX', title: '代理人证件类型', width: 95, formatter: pageCommonJS.getDictionaryFormatter("ZJLX") },
                { field: 'DLRZJH', title: '代理人证件号', width: 150 }
        ]],
        onEndEdit: mygrid.endEdit
    };
    $.extend(true, this, config, param)


};
