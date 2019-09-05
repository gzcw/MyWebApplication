
//初始化权限
function initPermission() {
    var permission = commonhelper.getUrlParam('permission');

    if (permission && permission == 0) {
        var editFieldStr = commonhelper.getUrlParam('editFields');
        var editFields = "";
        if (editFieldStr) {
            editFields = decodeURIComponent(editFieldStr);
        }
        $('.textbox-f').each(function (index, item) {
            var name = $(item).attr('textboxname');
            if (editFields && $.inArray(name, editFields.split(',')) >= 0) {
                $(item).textbox('readonly', false);
                return true;
            }
            var textbox_permission = $(item).textbox('options').permission;
            if (textbox_permission != 0) {

                $(item).textbox('readonly', true);
            }
        });

        $('.l-btn.l-btn-small').each(function (index, item) {
            var id = $(item).attr('id');
            if (editFields && $.inArray(id, editFields.split(',')) >= 0) {
                $(item).linkbutton('enable');
                return true;
            }
            var btn_permission = $(item).linkbutton('options').permission;

            if (btn_permission !== 0) {
                $(item).linkbutton('disable');
            }
        });
    }
    else if (permission && permission == 1) {
        var readOnlyFieldStr = commonhelper.getUrlParam('readOnlyFields');
        if (!readOnlyFieldStr) {
            return;
        }

        var readOnlyFields = decodeURIComponent(editFieldStr);

        $('.textbox-f').each(function (index, item) {
            var name = $(item).attr('textboxname');
            if (readOnlyFields && $.inArray(name, readOnlyFields.split(',')) >= 0) {
                try {
                    $(item).textbox('disable');
                }
                catch (e) { }
            }
        });
        $('.validatebox-text').each(function (index, item) {
            var name = $(item).attr('name');
            if (readOnlyFields && $.inArray(name, readOnlyFields.split(',')) >= 0) {
                try {
                    $(item).attr('readOnly', 'readOnly');
                }
                catch (e) { }
            }
        });
    }
}