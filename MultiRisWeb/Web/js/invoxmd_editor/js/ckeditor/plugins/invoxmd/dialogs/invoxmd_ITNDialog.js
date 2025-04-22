if (!String.format) {  //IE POLYFILL
    String.format = function (format) {
        var args = Array.prototype.slice.call(arguments, 1);
        return format.replace(/{(\d+)}/g, function (match, number) {
            return typeof args[number] != 'undefined'
                ? args[number]
                : match
                ;
        });
    };
}

CKEDITOR.dialog.add('invoxmd_ITNDialog', function (editor) {


    var itns = [], currentITNSelected, userITNs = imdSession.UserITNs, dummyITN,
        CASE_INSENSITIVE = '(?i)';

    var dialog, i18n = editor.lang.invoxmd.ITN_DIALOG, elem_ITN_Select, elem_ITN_Value, elem_ITN_Replacement, elem_ITN_BtnExit, elem_ITN_BtnSave
        , NOT_INDEX = -1, scopePreviousDialog;



    var UnescapeRegexToString = function (str) { return str.replace(/\\(.)/g, function ($0, $1) { return $1; }); }
    var EscapeStringToRegex = function (str) { return str.replace(/[\/.*+?|[()\]{}\$^-]/g, function ($0) { return '\\' + $0; }); }
    var AddModifierCaseInsensitive = function (str) { return CASE_INSENSITIVE + str; }
    var RemoveModifierCaseInsensitive = function (str) { return str.replace(CASE_INSENSITIVE, ''); }
    var AddBoundaries = function (str) {
        var str2 = RemoveModifierCaseInsensitive(str);
        if (/\W/.exec(str2[0])) { str = '%' + str; }
        if (/\W/.exec(str2.slice(-1))) { str += '%'; }
        return str;
    }
    var RemoveBoundaries = function (str) { return str.replace(/^%/, '').replace(/%$/, ''); }
    var CleanText = function (str) {
        var is251 = (imdSession.AgentVersion.indexOf("2.5.1") == 0 || imdSession.SWSVersion.indexOf("2.5.1") == 0);
        if (is251) {
            var ans = UnescapeRegexToString(str);
            ans = RemoveModifierCaseInsensitive(ans);
            str = RemoveBoundaries(ans);
        }
        return str;
    }
    var DirtyText = function (str) {
        var is251 = (imdSession.AgentVersion.indexOf("2.5.1") == 0 || imdSession.SWSVersion.indexOf("2.5.1") == 0);
        if (is251) {
            var ans = EscapeStringToRegex(str);
            ans = AddModifierCaseInsensitive(ans);
            str = AddBoundaries(ans);
        }
        return str;
    }

    var CheckNoCleanFormatITN = function (itn) {
        return !!(itn.Pattern || "").match(/\\/);
    }

    /*ESTO SERIA PARTE DEL MÓDULO NOTIFY SDK 3.0*/
    var CreateMsg = function (msg, parameters) {
        var message = msg || '';
        if (parameters) {
            var i = 0;
            while (parameters[i]) {
                message = message.replace(parameters[i].searchvalue, parameters[i].newvalue);
                i++;
            }
        }
        return message;
    }
    var NotifyWarning = function (msg) {
        if (msg) { 
            toastr.warning(msg);
        }
    }
    var NotifySuccess = function (msg) {
        if (msg) {
            toastr.success(msg)
        }
    }
    /********************************************/
    var RestoreDictationScope = function () {
        imdSession.Recognizer.setScope(scopePreviousDialog || invoxmd.dictationScope.PAUSED);
    }
    var DisableDictationEvents = function () {
        imdSession.Recognizer.setScope(invoxmd.dictationScope.NONE);
    }
    var DisableEnterValues = function () {
        elem_ITN_Replacement.reset();
        elem_ITN_Value.reset();
        elem_ITN_Replacement.disable();
        elem_ITN_Value.disable();
    }
    var DisableDeleteButtom = function () {
        elem_ITN_BtnExit.disable();
    }
    var EnableDeleteButtom = function () {
        elem_ITN_BtnExit.enable();
    }
    var EnableEnterValues = function () {
        elem_ITN_Value.enable();
        elem_ITN_Replacement.enable();
    }

    var GetSelectedITNIndex = function () {
        return elem_ITN_Select.getInputElement().$.selectedIndex;
    }
    var SelectIndex = function (index) {
        elem_ITN_Select.getInputElement().$.selectedIndex = index;
    }
    var GetITNIndex = function (itn) {
        var index = NOT_INDEX;
        for (var i = 0; index == NOT_INDEX && itns[i]; i++) {
            if (itn.equals(itns[i])) {
                index = i;
            }
        }
        return index;
    }
    var FillFieldsITN = function (itn) {
        var cleanPattern = CleanText(itn.Pattern);
        elem_ITN_Value.setValue(cleanPattern);
        elem_ITN_Replacement.setValue(itn.Substitution);
    }

    var GetITNFromFields = function () {
        var value = invoxmd.Formatter.CleanText(elem_ITN_Value.getValue()),
			replacement = invoxmd.Formatter.CleanText(elem_ITN_Replacement.getValue());

        itn = new invoxmd.UserITN(value, replacement);
        return itn;
    }
    var SelectValueElement = function () {
        elem_ITN_Value.select();
    }
    var AddDummyITN = function () {

        var itn = dummyITN,
            regex = new RegExp('^' + itn.Pattern + '\\s\*\\d\*$'),
            itn2Add,
            i = 0;

        while(itns[i]){
            if(!!regex.exec(itn.Pattern)){
                itn2Add = itns[i];
            }
            i += 1;
        }
        
        (itn2Add ?
            (itn2Add.Pattern = itn2Add.Pattern.replace(/\s*(\d*)$/, function (m, g1) { var n = g1; ++n; return " " + n; })) :
            (itn2Add = itn)
        );
        itn2Add.Pattern = DirtyText(itn2Add.Pattern)
        userITNs.addITN(itn2Add, function (response) {
            itn2Add.Pattern = CleanText(itn2Add.Pattern);
            var parameters = [{ searchvalue: ':PATTERN:', newvalue: itn2Add.Pattern }],
                msg = CreateMsg(response.Value == true ? i18n.ADD_SUCCESS : i18n.ADD_WARNING, parameters);

            if (response.Value == true) {
                UpdateSelectList(function () {
                    var itn_index = GetITNIndex(itn2Add);
                    SelectIndex(itn_index);
                    NotifySuccess(msg);
                    currentITNSelected = itn2Add;
                    FillFieldsITN(currentITNSelected);
                    SelectValueElement();
                });
            }
        });

    }

    var SaveOrUpdateCurrentITN = function (callback) {
        var changes = false, itn = GetITNFromFields();
        if (CheckNoCleanFormatITN(itn)) {
            NotifyWarning(i18n.INCORRECT_FORMAT);
        } else if (currentITNSelected && currentITNSelected.compareTo(itn) != 0) {
            changes = !!(currentITNSelected.Pattern.localeCompare(itn.Pattern));
            itn.Pattern = DirtyText(itn.Pattern);
            currentITNSelected.Pattern = DirtyText(currentITNSelected.Pattern);
            userITNs.replaceITN(currentITNSelected, itn, function (response) {
                itn.Pattern = CleanText(itn.Pattern);
                currentITNSelected.Pattern = CleanText(currentITNSelected.Pattern);
                var parameters = [{ searchvalue: ':PATTERN:', newvalue: itn.Pattern }],
                    msg = CreateMsg(response.Value == true ? i18n.REPLACE_SUCCESS : i18n.REPLACE_WARNING, parameters);
                if (response.Value == true) {
                    NotifySuccess(msg);
                    currentITNSelected = itn;
                } else {
                    NotifyWarning(msg);
                }
                if (callback) {
                    callback(changes)
                }
            });
        } else {
            if (callback) {
                callback(changes)
            }
        }
        return changes;
    }


    var NewITN = function () {
        elem_ITN_BtnSave || SaveOrUpdateCurrentITN();
        AddDummyITN();
        EnableEnterValues();
        EnableDeleteButtom();

    }
    var UpdateSelectList = function (callback) {
        userITNs.getUserITNs(function (response) {
            elem_ITN_Select.clear();
            itns = response.ITNs;
            for (var i = 0; itns[i]; i++) {
                itns[i].Pattern = CleanText(itns[i].Pattern);
                select_item = String.format('{0}', itns[i].Pattern);
                elem_ITN_Select.add(select_item);
            }
            if (callback) {
                callback();
            }
        });
    }
    var DeleteCurrentITN = function () {
        if (currentITNSelected) {
            currentITNSelected.Pattern = DirtyText(currentITNSelected.Pattern);
            userITNs.removeITN(currentITNSelected, function (response) {
                currentITNSelected.Pattern = CleanText(currentITNSelected.Pattern);
                var parameters = [{ searchvalue: ':PATTERN:', newvalue: currentITNSelected.Pattern }],
                    msg = CreateMsg(response.Value == true ? i18n.REMOVE_SUCCESS : i18n.REMOVE_WARNING, parameters);

                if (response.Value == true) {
                    UpdateSelectList();
                    DisableEnterValues();
                    DisableDeleteButtom();
                    NotifySuccess(msg);
                    currentITNSelected = undefined;
                } else {
                    NotifyWarning(msg);
                }
            });

        }
    }

    var ChangeSelectedITN = function () {
        var index = GetSelectedITNIndex(),
            selectedITN = index != NOT_INDEX ? itns[index] : undefined;

        if (!elem_ITN_BtnSave) {
            SaveOrUpdateCurrentITN(
                function (changes) {
                    if (changes) {
                        UpdateSelectList(function () { var i = GetITNIndex(selectedITN); SelectIndex(i); });
                    }
                    currentITNSelected = selectedITN;
                }
            )
        } else {
            currentITNSelected = selectedITN;
        }
        if (selectedITN) {
            EnableEnterValues();
            EnableDeleteButtom();
            FillFieldsITN(selectedITN);
        }

    }
    var OnExitDialog = function () {
        elem_ITN_BtnSave || SaveOrUpdateCurrentITN();
        dialog.hide();
        delete newItn;
        currentITNSelected = undefined;
        RestoreDictationScope();
    }

    var InitGlobalDialogVars = function () {
        dialog = CKEDITOR.dialog.getCurrent();
        elem_ITN_Select = dialog.getContentElement('itn-body', 'itn-select');
        elem_ITN_Value = dialog.getContentElement('itn-body', 'itn-value');
        elem_ITN_Replacement = dialog.getContentElement('itn-body', 'itn-replacement');
        elem_ITN_BtnExit = dialog.getContentElement('itn-body', 'itn-btn-delete');
        elem_ITN_BtnSave = dialog.getContentElement('itn-body', 'itn-btn-save');
        currentITNSelected = undefined;
        dummyITN = new invoxmd.UserITN(i18n.NEW_ITN_VALUE, i18n.NEW_ITN_REPLACEMENT);
        scopePreviousDialog = imdSession.Recognizer.CurrentScope;
    }
    var OnShowDialog = function () {
        InitGlobalDialogVars();
        DisableEnterValues();
        DisableDeleteButtom();
        DisableDictationEvents();
        UpdateSelectList();

    }

    return {
        title: i18n.DIALOG_TITLE,
        minWidth: 600,
        minHeight: 0,
        resizable: CKEDITOR.DIALOG_RESIZE_NONE,
        buttons: [

            {
                id: 'itn-btn-exit',
                type: 'button',
                label: i18n.EXIT_BUTTON_LABEL,
                title: i18n.EXIT_BUTTON_TOOLTIP,
                onClick: OnExitDialog
            }
        ],
        contents: [
            {
                id: 'itn-body',
                elements: [
                    {
                        type: "hbox",
                        widths: ["40%", "60%"],
                        children: [
                            {
                                id: "itn-select",
                                type: "select",
                                label: i18n.SELECT_LABEL,
                                title: i18n.SELECT_TOOLTIP,
                                size: 15,
                                style: 'overflow: auto; height: auto!important;width: 100%!important',
                                items: [
                                    [
                                        ''
                                    ]
                                ],
                                onChange: ChangeSelectedITN
                            },
                            {
                                type: 'vbox',
                                children: [
                                    {
                                        id: "itn-value",
                                        type: "text",
                                        label: i18n.VALUE_LABEL,
                                        title: i18n.VALUE_TOOLTIP,
                                        style: 'white-space: normal;',
                                        'default': ''
                                    },
                                    {
                                        id: "itn-replacement",
                                        type: "text",
                                        title: i18n.REPLACEMENT_TOOLTIP,
                                        label: i18n.REPLACEMENT_LABEL,
                                        style: 'white-space: normal;',
                                        'default': ''
                                    }
                                    
                                ]
                            }
                        ]
                    },
                    {   //buttons new save delete
                        type: 'hbox',
                        style: 'width: auto; margin-right: 0px;',
                        widths: ["0%", '0%', '0%'], //auto
                        children: [
                            {
                                id: 'itn-btn-new',
                                type: 'button',
                                label: i18n.NEW_BUTTON_LABEL,
                                title: i18n.NEW_BUTTON_TOOLTIP,
                                onClick: NewITN
                            },
                            {
                                id: 'itn-btn-save',
                                type: 'button',
                                label: i18n.SAVE_BUTTON_LABEL,
                                title: i18n.SAVE_BUTTON_TOOLTIP,
                                onClick: function () {
                                    SaveOrUpdateCurrentITN(function () {
                                        var itn = GetITNFromFields();
                                        UpdateSelectList(function () {
                                            SelectIndex(GetITNIndex(itn));
                                        })
                                    });
                                }
                            },
                            {
                                id: 'itn-btn-delete',
                                type: 'button',
                                label: i18n.DELETE_BUTTON_LABEL,
                                title: i18n.DELETE_BUTTON_TOOLTIP,
                                onClick: DeleteCurrentITN
                            }

                        ]
                    }
                ]
            },
        ],
        onCancel: OnExitDialog,
        onShow: OnShowDialog
    }
}
)