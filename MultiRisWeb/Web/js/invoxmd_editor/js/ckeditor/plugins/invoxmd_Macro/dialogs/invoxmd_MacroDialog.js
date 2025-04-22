CKEDITOR.dialog.add('invoxmd_MacroDialog', function (editor) {

    var currentMacros = [], currentGMacros = [], currentScope,
        dialog, elSelectMacro, elSelectGlobalMacro, elMacroValue, elGlobalMacroValue,
        elMacroDefinition, elGlobalMacroDefinition, elShareMacro;

    var i18n = editor.lang.invoxmd_Macro.MACRO_DIALOG;

    var hideGlobalsOptions = imdSession.User.Role.Level != 3 && imdSession.User.Role.Level != 4; // CORPORATE & SALES, only for presentation.

    function getSelectedMacroIndex(el) {
        var index = elSelectMacro.getInputElement().$.selectedIndex;
        return index;
    }
    function getSelectedGlobalMacroIndex() {
        var index = elSelectGlobalMacro.getInputElement().$.selectedIndex;
        return index;
    }

    function getIndexByName(macros, macroname) {
        var index = -1, i = 0;
        while (macros[i] && macros[i].Name.toLowerCase() != macroname.toLowerCase())
            i++;
        if (macros[i] && macros[i].Name.toLowerCase() == macroname.toLowerCase())
            index = i;
        return index;
    }

    function restoreRecognizer() {
        imdSession.Recognizer.setScope(currentScope);
    }

    var onShowSelectMacro = function () {
        imdSession.Macros.getMacros();
    }
    var onShowSelectGlobalMacro = function () {
        imdSession.Macros.getGlobalMacros();
    }
    var onChangeSelectMacro = function (editor) {
        var selectedIndex = getSelectedMacroIndex();
        macro = currentMacros[selectedIndex];
        if (macro) {
            elMacroValue.setValue(macro.Name);
            elMacroDefinition.setValue(macro.Replacement);
            elShareMacro.setValue(macro.Shared);
        }
    }
    var onClickSaveMacro = function (editor) {
        var macroName = invoxmd.Formatter.CleanText(elMacroValue.getValue()),
            macroReplacement = invoxmd.Formatter.CleanText(elMacroDefinition.getValue());
        if (macroName == '') {
            toastr['error']('No ha seleccionado o añadido una nueva sustitución para poder guardarla.');
        } else if (macroReplacement == '') {
            toastr['error']('No ha rellenado la definición de la sustitución.');
        } else {
            var selectedIndex = getSelectedMacroIndex(),
                macro = currentMacros[selectedIndex],
                indexMacroName = getIndexByName(currentMacros, macroName);
            if (indexMacroName != -1 && selectedIndex != indexMacroName) {
                toastr['error']('Ya existe una sustitución con el nombre "' + macroName + '".');
            } else {
                var shareMacro = elShareMacro.getValue(),
                    currentMacro = new invoxmd.Macro(macroName, macroReplacement, shareMacro, invoxmd.macroType.TEXT);
                if (!macro) {
                    imdSession.Macros.addMacro(currentMacro);
                } else {
                    imdSession.Macros.replaceMacro(macro, currentMacro);
                }
            }
        }
    }

    var onClickDeleteMacro = function (editor) {
        var selectedIndex = getSelectedMacroIndex(),
            macro = currentMacros[selectedIndex];
        if (macro) {
            imdSession.Macros.removeMacro(macro);
        } else {
            toastr['error']('No ha seleccionado una sustitución para eliminar.');
        }
    }
    var onClickNewMacro = function (editor) {
        elSelectMacro.setValue('');
        elMacroValue.setValue(i18n.NEW_MACRO_NAME);
        elMacroDefinition.setValue(i18n.NEW_MACRO_REPLACEMENT);
        elShareMacro.setValue(false);
    }

    var onChangeSelectGlobalMacro = function (editor) {
        var selectedIndex = getSelectedGlobalMacroIndex(),
            gmacro = currentGMacros[selectedIndex];

        if (gmacro) {
            elGlobalMacroValue.setValue(gmacro.Name);
            elGlobalMacroDefinition.setValue(gmacro.Replacement);
        }
    }
    var onClickCancel = function (editor) {
        enDialogo = false;
        restoreRecognizer();
    }
    var onClickExit = function (editor) {
        onClickCancel(editor);
        CKEDITOR.dialog.getCurrent().hide();
    }
    var onShowDialog = function () {
        enDialogo = true;
        currentScope = imdSession.Recognizer.CurrentScope || invoxmd.dictationScope.PAUSED;
        imdSession.Recognizer.setScope(invoxmd.dictationScope.NONE);

        dialog = CKEDITOR.dialog.getCurrent();
        elSelectMacro = dialog.getContentElement('tab1', 'selectMacro');
        elMacroValue = dialog.getContentElement('tab1', 'macroValue');
        elMacroDefinition = dialog.getContentElement('tab1', 'macroDefinition');
        elShareMacro = dialog.getContentElement('tab1', 'shareMacro');
        elSelectGlobalMacro = dialog.getContentElement('tab2', 'selectGlobalMacro');
        elGlobalMacroValue = dialog.getContentElement('tab2', 'globalMacroValue');
        elGlobalMacroDefinition = dialog.getContentElement('tab2', 'globalMacroDefinition');
        elGlobalMacroValue.disable()
        elGlobalMacroDefinition.disable();


        var heightSelect = jQuery('#' + dialog.getContentElement('tab1', 'macroValue').domId).parent().parent().parent().height() *0.9;


        jQuery('#' + elSelectMacro.domId + ' select')[0].size = 50;
        jQuery('#' + elSelectGlobalMacro.domId + ' select')[0].size = 50;
        jQuery('#' + elSelectMacro.domId + ' select').height(heightSelect);
        jQuery('#' + elSelectGlobalMacro.domId + ' select').height(heightSelect);

        if (hideGlobalsOptions) {
            jQuery('#' + elShareMacro.domId).hide();
            jQuery(dialog.parts.tabs.$.children[1]).hide(); //tab2
        }


        imdSession.ActionHandlerTable[invoxmd.wsMessage.MACROS_GET_MACROS] = function (response, session) {

            elSelectMacro.clear();
            elMacroValue.setValue('');
            elMacroDefinition.setValue('');
            elShareMacro.setValue(false);

            if (response.ExceptionType == invoxmd.exceptionType.NONE) {
                var r = response.Macros; currentMacros = [];
                for (var i = 0; i < r.length; i++)
                    if (r[i].Subtype == invoxmd.macroType.TEXT) {
                        elSelectMacro.add(r[i].Name);
                        currentMacros.push(r[i]);
                    }
            } else {
                window.console.log('[error]: Macros Get Macros error: ', response);
                toastr['error']('Se ha producido un error al leer las sustituciones de texto.');
            }
        }

        imdSession.ActionHandlerTable[invoxmd.wsMessage.MACROS_GET_GLOBAL_MACROS] = function (response, session) {

            elSelectGlobalMacro.clear();
            elGlobalMacroValue.setValue('');
            elGlobalMacroDefinition.setValue('');
            if (response.ExceptionType == invoxmd.exceptionType.NONE) {
                var r = response.Macros; currentGMacros = [];
                for (var i = 0; i < r.length; i++)
                    if (r[i].Subtype == invoxmd.macroType.TEXT) {
                        elSelectGlobalMacro.add(r[i].Name);
                        currentGMacros.push(r[i]);
                    }
            } else {
                window.console.log('[error]: Macros Get Global Macros error: ', response);
                toastr['error']('Se ha producido un error al leer las sustituciones globales.');
            }
        }

        imdSession.ActionHandlerTable[invoxmd.wsMessage.MACROS_REPLACE_MACRO] = function (response, session) {
            if (response.ExceptionType == invoxmd.exceptionType.NONE && response.Value == true) {
                i18n.REPLACE_SUCCESS && toastr['success'](i18n.REPLACE_SUCCESS);
            } else {
                window.console.log('[error]: Macros Replace Macro error: ', response);
                i18n.REPLACE_WARNING && toastr['error'](i18n.REPLACE_WARNING);
            }
            session.Macros.getMacros();
            session.Macros.getGlobalMacros();
        }

        imdSession.ActionHandlerTable[invoxmd.wsMessage.MACROS_ADD_MACRO] = function (response, session) {
            if (response.ExceptionType == invoxmd.exceptionType.NONE && response.Value == true) {
                i18n.ADD_SUCCESS && toastr['success'](i18n.ADD_SUCCESS);
            } else {
                window.console.log('[error]: Macros Add Macro error: ', response);
                i18n.ADD_WARNING && toastr['error'](i18n.ADD_WARNING);
            }
            session.Macros.getMacros();
            session.Macros.getGlobalMacros();
        }

        imdSession.ActionHandlerTable[invoxmd.wsMessage.MACROS_REMOVE_MACRO] = function (response, session) {
            if (response.ExceptionType == invoxmd.exceptionType.NONE && response.Value == true) {
                i18n.REMOVE_SUCCESS && toastr['success'](i18n.REMOVE_SUCCESS);
            } else {
                window.console.log('[error]: Macros Remove Macro error: ', response);
                i18n.REMOVE_WARNING && toastr['error'](i18n.REMOVE_WARNING);
            }
            session.Macros.getMacros();
            session.Macros.getGlobalMacros();
        }
    }

    return {
        title: i18n.DIALOG_TITLE,
        minWidth: 600,
        minHeight: 0,
        resizable: CKEDITOR.DIALOG_RESIZE_NONE,
        buttons: [

            {
                id: 'macro-btn-exit',
                type: "button",
                label: i18n.EXIT_BUTTON_LABEL,
                title: i18n.EXIT_BUTTON_TOOLTIP,
                onClick: onClickExit
            }
        ],
        contents: [
            {
                id: 'tab1',
                label: i18n.MACROTAB_TITLE,
                elements: [
                    {
                        type: "hbox",
                        widths: ["40%", "60%"],
                        children: [
                            {
                                id: "selectMacro",
                                type: "select",
                                label: i18n.SELECT_LABEL,
                                title: i18n.SELECT_TOOLTIP,
                                size: 5,
                                style: ' width: 100%',

                                items: [
                                    [
                                        ''
                                    ]
                                ],
                                onShow: onShowSelectMacro,
                                onChange: onChangeSelectMacro
                            },
                            {
                                id: 'macro-tab1-group2',
                                type: 'vbox',
                                children: [
                                    {
                                        id: 'macroValue',
                                        type: 'text',
                                        label: i18n.NAME_LABEL,
                                        title: i18n.NAME_TOOLTIP,
                                        style: 'white-space: normal;',
                                        'default': ''
                                    },
                                    {
                                        id: "macroDefinition",
                                        type: "textarea",
                                        label: i18n.REPLACEMENT_LABEL,
                                        title: i18n.REPLACEMENT_TOOLTIP,
                                        rows: 12,
                                        inputStyle: 'white-space: pre-line ;width: 100%!important; word-wrap:break-word;',
                                        'default': ''
                                    },
                                    {
                                        id: 'shareMacro',
                                        type: 'checkbox',
                                        label: i18n.SHARE_CHECKBOX_LABEL,
                                        title: i18n.SHARE_CHECKBOX_TOOLTIP,
                                        checked: false
                                    }

                                ]
                            }
                        ]
                    },
                    {   //buttons new, save, delete
                        type: "hbox",
                        style: 'width: auto; margin-right: 0px;',
                        widths: ["0%", '0%', '0%'], //auto
                        children: [

                            {
                                id: 'macro-btn-new',
                                type: "button",
                                label: i18n.NEW_BUTTON_LABEL,
                                title: i18n.NEW_BUTTON_TOOLTIP,
                                onClick: onClickNewMacro
                            },
                            {
                                id: 'saveMacro',
                                type: 'button',
                                label: i18n.SAVE_BUTTON_LABEL,
                                title: i18n.SAVE_BUTTON_TOOLTIP,
                                onClick: onClickSaveMacro
                            },
                            {
                                id: 'deleteMacro',
                                type: 'button',
                                label: i18n.DELETE_BUTTON_LABEL,
                                title: i18n.DELETE_BUTTON_TOOLTIP,
                                onClick: onClickDeleteMacro
                            }
                        ]
                    }
                ]
            },
            {
                id: 'tab2',
                label: i18n.GMACROTAB_TITLE,
                elements: [
                    {
                        type: "hbox",
                        widths: ["40%", "60%"],
                        children: [
                            {
                                id: "selectGlobalMacro",
                                type: "select",
                                label: i18n.GSELECT_LABEL,
                                title: i18n.GSELECT_TOOLTIP,
                                size: 5,
                                style: 'width: 100%',
                                items: [
                                    [
                                        ''
                                    ]
                                ],
                                onShow: onShowSelectGlobalMacro,
                                onChange: onChangeSelectGlobalMacro
                            },
                            {
                                type: 'vbox',
                                id: 'macro-tab2-group2',
                                children: [
                                    {
                                        id: 'globalMacroValue',
                                        type: 'text',
                                        label: i18n.GNAME_LABEL,
                                        title: i18n.GNAME_TOOLTIP,
                                        style: 'white-space: normal;',
                                        'default': ''
                                    },
                                    {
                                        id: "globalMacroDefinition",
                                        type: "textarea",
                                        label: i18n.GREPLACEMENT_LABEL,
                                        title: i18n.GREPLACEMENT_TOOLTIP,
                                        rows: 12,
                                        inputStyle: 'white-space: pre-line; height: auto!important;width: 100%!important; word-wrap:break-word;',
                                        'default': ''
                                    }
                                ]
                            }
                        ]
                    }
                ]

            }
        ],
        onCancel: onClickCancel,
        onShow: onShowDialog
    }
}
)