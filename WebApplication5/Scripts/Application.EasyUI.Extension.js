(function ($, undefined) {

    /*============================================================
    combo组件扩展，多选时值以逗号格式分开
    ============================================================*/
    $.fn.combo.defaults.editable = false;

    var _combo_setValues = $.fn.combo.methods.setValues;
    $.extend($.fn.combo.methods, {
        setValues: function (sender, value) {
            _combo_setValues.apply(this, arguments);
            if (sender.combo('options').multiple == true) {
                var val = sender.combo('getValues');
                var combo = sender.data('combo').combo;
                if (combo.find('.textbox-value1').length == 0) {
                    $('<input type="hidden" class="textbox-value1" />').val(val).attr('name', sender.attr('comboname')).appendTo(combo);
                }
                else {
                    combo.find('.textbox-value1').val(val);
                }
                combo.find('.textbox-value').removeAttr('name');
            }
        }
    });

    /*============================================================
    组件默认值设置
    ============================================================*/
    $.extend($.fn.combo.defaults, {
        width: 230
    });
    $.extend($.fn.combobox.defaults, {
        width: 230
    });
    $.extend($.fn.combotree.defaults, {
        width: 230
    });
    $.extend($.fn.datebox.defaults, {
        width: 230
    });
    $.extend($.fn.datetimebox.defaults, {
        width: 230
    });
    $.extend($.fn.textbox.defaults, {
        width: 230
    });
    $.extend($.fn.numberbox.defaults, {
        width: 230,
        groupSeparator: ','
    });
    $.extend($.fn.filebox.defaults, {
        width: 230
    });
    $.extend($.fn.passwordbox.defaults, {
        width: 230
    }); 

    /*============================================================
    下拉框增加删除按钮
    ============================================================*/
    $.extend($.fn.combobox.defaults, {
        icons: [{
            iconCls: 'icon-clear',
            handler: function (e) {
                $(e.data.target).combobox('setValue', []);
            }
        }]
    });

    $.extend($.fn.datebox.defaults, {
        icons: [{
            iconCls: 'icon-clear',
            handler: function (e) {
                $(e.data.target).datebox('clear');
                $(e.data.target).datebox('setValue', null);

            }
        }]
    });

    $.extend($.fn.combotree.defaults, {
        icons: [{
            iconCls: 'icon-clear',
            handler: function (e) {
                $(e.data.target).combotree('clear');
                $(e.data.target).combotree('setValue', null);

            }
        }]
    });
    $.extend($.fn.datagrid.methods, {
        getEditingRowIndexs: function (jq) {
            var rows = $.data(jq[0], "datagrid").panel.find('.datagrid-row-editing');
            var indexs = [];
            rows.each(function (i, row) {
                var index = row.sectionRowIndex;
                if (indexs.indexOf(index) == -1) {
                    indexs.push(index);
                }
            });
            return indexs;
        }
    });
})(jQuery);