CKEDITOR.dialog.add('invoxmd_DictionaryDialog', function (editor) {

    var currentScope, currentWords = [];
    var dialog, elSelectword, elWordname,
        elTranscript, elShareword, elButton_rec;

    var i18n = editor.lang.invoxmd_Dictionary.DICTIONARY_DIALOG;

    var hideGlobalsOptions = imdSession.User.Role.Level != 3 && imdSession.User.Role.Level != 4; // CORPORATE & SALES, only for presentation.
    function restoreRecognizer() {
        imdSession.Recognizer.setScope(currentScope);
    }
    var isIE8 = (navigator.appVersion.indexOf("MSIE 8") >= 0);
    function checkIE8() {
        if (isIE8) {
            var buttonMica = jQuery('#' + elButton_rec.domId);
            if (buttonMica) {
                var buttonMicspan = buttonMica.attr('aria-labelledby');
                if (buttonMicspan) {
                    jQuery('#' + buttonMicspan).text(i18n.ADD_PRONUNCIATION_TOOLTIP);
                }
            }
        }
    }

    function getSelectedWordIndex() {
        var index = elSelectword.getInputElement().$.selectedIndex;
        return index;
    }

    function getIndexByWordname(wordname) {
        var index = -1, i = 0;
        while (currentWords[i] && currentWords[i].Text.toLowerCase() != wordname.toLowerCase())
            i++;
        if (currentWords[i] && currentWords[i].Text.toLowerCase() == wordname.toLowerCase())
            index = i;
        return index;
    }

    var onShowSelectWord = function () {
        imdSession.Dictionary.getWords();
    }
    var onChangeSelectWord = function () {
        var selectedIndex = getSelectedWordIndex(),
            word = currentWords[selectedIndex];
        if (word) {
            var transcript = '';
            if (word.Pronunciations && word.Pronunciations[0] && word.Pronunciations[0].Symbol) {
                transcript = word.Pronunciations[0].Symbol;
            }
            elWordname.setValue(word.Text);
            elTranscript.setValue(transcript);
            elShareword.setValue(word.Shared);
        }
    }

    var onClickRec = function () {
        if (imdSession.Recognizer.CurrentScope == invoxmd.dictationScope.PHONETIC_TRANSCRIPTION) {
            toastr['info']('Ya se está esperando a que dicte una pronunciación');
            return;
        }
        imdSession.Recognizer.PhoneticEventHandler = function (msg) {
            elTranscript.setValue(msg.Transcription.toString());
            this.setScope(invoxmd.dictationScope.NONE);
        }
        imdSession.Recognizer.setScope(invoxmd.dictationScope.PHONETIC_TRANSCRIPTION);
        toastr['info']('Espere un instante y el sistema le indicará el momento exacto en el que puede comenzar a hablar.');
    }

    var onClickSave = function () {
        var selectedIndex = getSelectedWordIndex(),
            word = currentWords[selectedIndex],
            wordname = elWordname.getValue(),
            indexWordname = getIndexByWordname(wordname);
        if (wordname == '') {
            toastr['error']('No ha seleccionado o añadido una nueva palabra para poder insertarla al diccionario.');
        } else if (indexWordname != -1 && indexWordname != selectedIndex) {
            toastr['error']('La palabra "' + wordname + '" ya se encuentra en el diccionario.');
        } else {
            var shareWord = elShareword.getValue(),
                transcript = elTranscript.getValue(),
                pronunciation_array = (transcript != '' && transcript != i18n.NEW_WORD_PRONUNCIATION) ? [new invoxmd.Pronunciation(transcript, 0)] : null,
                newWord = new invoxmd.Word(wordname, pronunciation_array, shareWord);
            if (!word) {
                imdSession.Dictionary.addWord(newWord);
            } else {
                imdSession.Dictionary.replaceWord(word, newWord);
            }
        }
    }

    var onClickDelete = function () {
        var selectedIndex = getSelectedWordIndex(),
            word = currentWords[selectedIndex];
        if (word) {
            imdSession.Dictionary.removeWord(word);
        } else {
            toastr['error']('No ha seleccionado una palabra de la lista para eliminar.');
        }
    }
    var onClickNew = function () {
        elSelectword.setValue('');
        elWordname.setValue(i18n.NEW_WORD_NAME);
        elTranscript.setValue(i18n.NEW_WORD_PRONUNCIATION);
        elShareword.setValue(false);
    }

    var onCancelDialog = function (editor) {
        enDialogo = false;
        restoreRecognizer();
    }
    var onClickExit = function (editor) {
        onCancelDialog(editor);
        dialog.hide();
    }

    var onShowDialog = function () {

        dialog = CKEDITOR.dialog.getCurrent();
        elSelectword = dialog.getContentElement('addword', 'selectwords');
        elWordname = dialog.getContentElement('addword', 'wordname');
        elTranscript = dialog.getContentElement('addword', 'transcript');
        elShareword = dialog.getContentElement('addword', 'shareWord');
        elButton_rec = dialog.getContentElement('addword', 'button_rec');


        if(hideGlobalsOptions){
            jQuery('#'+elShareword.domId).hide();
        }

        elTranscript.disable();
        currentScope = imdSession.Recognizer.CurrentScope || invoxmd.dictationScope.PAUSED;
        imdSession.Recognizer.setScope(invoxmd.dictationScope.NONE);
        enDialogo = true;


        imdSession.ActionHandlerTable[invoxmd.wsMessage.DICTIONARY_GET_WORDS] = function (response, session) {
            elSelectword.clear();
            elWordname.setValue('');
            elTranscript.setValue('');
            elShareword.setValue(false);

            if (response.ExceptionType == invoxmd.exceptionType.NONE) {
                currentWords = response.Words;
                for (var i = 0; currentWords[i]; i++) {
                    elSelectword.add(currentWords[i].Text)
                }
            } else {
                window.console.log('[error]: Dictionary Get Words error: ', response);
                toastr['error']('Se ha producido un error y no se han podido leer las palabras del diccionario personal del usuario.');
            }
        }
        imdSession.ActionHandlerTable[invoxmd.wsMessage.DICTIONARY_REPLACE_WORD] = function (response, session) {
            if (response.ExceptionType == invoxmd.exceptionType.NONE && response.Value == true) {
                i18n.REPLACE_SUCCESS && toastr['success'](i18n.REPLACE_SUCCESS);
            } else {
                window.console.log('[error]: Dictionary Replace Word error: ', response);
                i18n.REPLACE_WARNING && toastr['error'](i18n.REPLACE_WARNING);
            }
            session.Dictionary.getWords();
        }

        imdSession.ActionHandlerTable[invoxmd.wsMessage.DICTIONARY_ADD_WORD] = function (response, session) {
            if (response.ExceptionType == invoxmd.exceptionType.NONE && response.Value == true) {
                i18n.ADD_SUCCESS && toastr['success'](i18n.ADD_SUCCESS);
            } else {
                window.console.log('[error]: Dictionary Add Word error: ', response);

                i18n.ADD_WARNING && toastr['error'](i18n.ADD_WARNING);
            }
            session.Dictionary.getWords();
        }

        imdSession.ActionHandlerTable[invoxmd.wsMessage.DICTIONARY_REMOVE_WORD] = function (response, session) {
            if (response.ExceptionType == invoxmd.exceptionType.NONE && response.Value == true) {
                i18n.REMOVE_SUCCESS && toastr['success'](i18n.REMOVE_SUCCESS);
                onClickNew();
            } else {
                window.console.log('[error]: Dictionary Remove Word error: ', response);
                i18n.REMOVE_WARNING && toastr['error'](i18n.REMOVE_WARNING);
            }
            session.Dictionary.getWords();
        }
    }

    return {

        title: i18n.DIALOG_TITLE,
        minHeight: 0,
        resizable: CKEDITOR.DIALOG_RESIZE_NONE,

        buttons: [

            {
                id: 'dictionary-btn-exit',
                type: 'button',
                label: i18n.EXIT_BUTTON_LABEL,
                title: i18n.EXIT_BUTTON_TOOLTIP,
                onClick: onClickExit
            }
        ],

        contents:
            [
                {
                    id: 'addword',
                    elements:
                        [
                            {
                                type: 'hbox',
                                widths: ["50%", "50%"],
                                children:
                                    [
                                        {   //select
                                            id: 'selectwords',
                                            type: 'select',
                                            label: i18n.SELECT_LABEL,
                                            title: i18n.SELECT_TOOLTIP,
                                            size: 15,
                                            style: 'height: 20em; width: 100%',
                                            //  style: 'height: auto !important ; width: 18em;',
                                            items: [['']],
                                            onShow: onShowSelectWord,
                                            onChange: onChangeSelectWord
                                        },
                                        {
                                            type: 'vbox',
                                            expand: true,
                                            children:
                                                [
                                                    {   //wordname
                                                        id: 'wordname',
                                                        type: 'text',
                                                        label: i18n.NAME_LABEL,
                                                        title: i18n.NAME_TOOLTIP,
                                                        'default': ''
                                                    },
                                                    {   //transcrip   
                                                        type: "hbox",
                                                        style: "vertical-align: bottom;",
                                                        widths: ["75%", "25%"],
                                                        children:
                                                            [
                                                                {
                                                                    id: 'transcript',
                                                                    label: i18n.PRONUNCIATION_LABEL,
                                                                    title: i18n.PRONUNCIATION_TOOLTIP,
                                                                    type: 'text',
                                                                    'default': ''
                                                                },
                                                                {
                                                                    id: 'button_rec',
                                                                    type: 'button',
                                                                    label: i18n.ADD_PRONUNCIATION_LABEL,
                                                                    title: i18n.ADD_PRONUNCIATION_TOOLTIP,
                                                                    style: 'margin-top: 1.2em; margin-left: 1em',
                                                                    onClick: onClickRec,
                                                                    onShow: checkIE8
                                                                }
                                                            ]
                                                    }, 
                                                    {
                                                        id: 'shareWord',
                                                        type: 'checkbox',
                                                        label: i18n.SHARE_CHECKBOX_LABEL,
                                                        title: i18n.SHARE_CHECKBOX_TOOLTIP,
                                                        checked: false
                                                    } 

                                                ]
                                        }
                                    ]
                            },
                            {   //buttons new save delete
                                type: "hbox",
                                style: 'width: auto; margin-right: 0px;',
                                widths: ["0%", '0%', '0%'], //auto
                                children:
                                    [

                                        {
                                            id: 'dictionary-btn-new',
                                            type: 'button',
                                            label: i18n.NEW_BUTTON_LABEL,
                                            title: i18n.NEW_BUTTON_TOOLTIP,
                                            onClick: onClickNew
                                        },
                                        {
                                            id: 'button_save',
                                            type: 'button',
                                            label: i18n.SAVE_BUTTON_LABEL,
                                            title: i18n.SAVE_BUTTON_TOOLTIP,

                                            onClick: onClickSave
                                        },
                                        {
                                            id: 'button_delete',
                                            type: 'button',
                                            label: i18n.DELETE_BUTTON_LABEL,
                                            title: i18n.DELETE_BUTTON_TOOLTIP,

                                            onClick: onClickDelete
                                        }
                                    ]
                            }
                        ]
                }
            ],

        onCancel: onCancelDialog,
        onShow: onShowDialog
    };
});