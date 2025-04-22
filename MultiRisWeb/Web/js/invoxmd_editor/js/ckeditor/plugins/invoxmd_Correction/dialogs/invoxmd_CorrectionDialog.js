CKEDITOR.dialog.add('invoxmd_CorrectionDialog', function (editor) {

    var currentWordsDictionary = [],
        currentAlternates = [],
        dialog, elButton_rec, elSelectAlternates, elTranscript, elWordname;

    var isIE8 = (navigator.appVersion.indexOf("MSIE 8") >= 0);

    function checkIE8() {
        if (isIE8) {
            var buttonMica = jQuery('#' + elButton_rec.domId);
            if (buttonMica) {
                var buttonMicspan = buttonMica.attr('aria-labelledby');
                if (buttonMicspan) {
                    jQuery('#' + buttonMicspan).text("Grabar pronunciación");
                }
            }
        }
    }

    function restoreRecognizer() {
        imdSession.Recognizer.setScope(invoxmd.dictationScope.RUNNING);
    }

    function restoreCaretPositionAndUnselect() {
        dialog.previousPosition && ckeditorTextHelper.setSelectionRange(editor, dialog.previousPosition);
        imdCommands[invoxmd.commandId.UNSELECT](editor);
    }

    function getSelectedIndex() {
        var index = elSelectAlternates.getInputElement().$.selectedIndex;
        return index;
    }

    function getIndexByWordname(wordname) {
        var index = -1,
            i = 0;
        var wordnameLower = wordname.toLowerCase();
        while (currentWordsDictionary[i] && currentWordsDictionary[i].Text.toLowerCase() != wordnameLower)
            i++;
        if (currentWordsDictionary[i] && currentWordsDictionary[i].Text.toLowerCase() == wordnameLower)
            index = i;
        return index;
    }

    function trainAlternate(alternateNumber) {
        if (imdSession.AgentVersion) {
            toastr['success']('Entrenando la corrección, espere unos segundos, la ventana se cerrará al terminar.');
            elButton_rec.disable();
            elSelectAlternates.disable();
            elTranscript.disable();
            elWordname.disable();
            imdSession.Trainer.trainAlternate(alternateNumber);
        } else {
            window.console.log('[warn]: Training after correction is not supported in this release of the agent and/or server');
            onExit(false);
        }
    }

    var onChangeSelectAlternate = function () {
        var selectedIndex = getSelectedIndex();
        alternate = currentAlternates[selectedIndex];
        newText = invoxmd.Formatter.adaptTextFromTextSelected(alternate.Text, dialog.textSelected);
        editor.insertText(newText);
        trainAlternate(selectedIndex + 1);
    }

    var onClickRec = function () {

        imdSession.Recognizer.PhoneticEventHandler = function (msg) {
            elTranscript.setValue(msg.Transcription.toString());
            imdSession.Recognizer.setScope(invoxmd.dictationScope.PAUSED);
        }
        imdSession.Recognizer.setScope(invoxmd.dictationScope.PHONETIC_TRANSCRIPTION);
        toastr['info']('Espere un instante y el sistema le indicará el momento exacto en el que puede comenzar a hablar.');
    }

    var onClickSave = function () {
        var wordname = elWordname.getValue();
        if (wordname == '') {
            toastr['error']('No ha seleccionado o añadido una nueva palabra para poder insertarla al diccionario.');
        } else if (getIndexByWordname(wordname) != -1) {
            toastr['error']('La palabra "' + wordname + '" ya se encuentra en el diccionario.');
        } else {
            var transcript = elTranscript.getValue(),
                pronunciation_array = (transcript != '') ? [new invoxmd.Pronunciation(transcript, 0)] : null,
                newWord = new invoxmd.Word(wordname, pronunciation_array, false);
            imdSession.Dictionary.addWord(newWord);
            var newText = invoxmd.Formatter.adaptTextFromTextSelected(wordname, dialog.textSelected);
            editor.insertText(newText);
            onExit(false);
        }
    }

    var onExit = function (restoreGrammar) {
        enDialogo = false;
        restoreRecognizer();
        if (restoreGrammar) {
            imdSession.RecognizerEngine.addCommandGrammar(invoxmdWE.EditorGrammar);
        }
        restoreCaretPositionAndUnselect();
        dialog.hide();
    }

    var onShowDialog = function () {
        enDialogo = true;
        dialog = CKEDITOR.dialog.getCurrent();
        elSelectAlternates = dialog.getContentElement('acceptWord', 'selectAlternates');
        elWordname = dialog.getContentElement('acceptWord', 'wordname');
        elTranscript = dialog.getContentElement('acceptWord', 'transcript');
        elButton_rec = dialog.getContentElement('acceptWord', 'button_rec');
        elSelectAlternates.clear();

        elButton_rec.enable();
        elSelectAlternates.enable();
        elTranscript.enable();
        elWordname.enable();

        elTranscript.disable();
        dialog.parts.title.$.innerHTML = 'Corrigiendo: \'' + dialog.textSelected + '\'';

        imdSession.ActionHandlerTable[invoxmd.wsMessage.DICTIONARY_ADD_WORD] = function (response, session) {
            if (response.ExceptionType == invoxmd.exceptionType.NONE && response.Value == true) {
                toastr['success']('Se ha añadido correctamente la nueva palabra al diccionario.');
            } else {
                window.console.log('[error]: Dictionary Add Word error: ', response);
                toastr['error']('Se ha producido un error al añadir la nueva palabra al diccionario.');
            }
        }

        imdSession.ActionHandlerTable[invoxmd.wsMessage.TRAINER_TRAIN_ALTERNATE] = function (response, session) {
            if (response.ExceptionType == invoxmd.exceptionType.NONE) {
                toastr['success']('Se ha entrenado la corrección.');
            } else {
                window.console.log('[error]: Trainer Trainer Alternate error: ', response);
                toastr['warning']('Se ha excedido el tiempo de entrenamiento.');
            }
            onExit(true);
        }


        imdSession.Recognizer.EndCorrectionEventHandler = function (msg) {
            if (msg.Canceled) {
                onExit(false);
            } else if (msg.AlternateNumber > 0 && msg.AlternateNumber <= currentAlternates.length) {
                elSelectAlternates.getInputElement().$.selectedIndex = msg.AlternateNumber - 1;
                var alternate = currentAlternates[msg.AlternateNumber - 1],
                    newText = invoxmd.Formatter.adaptTextFromTextSelected(alternate.Text, dialog.textSelected);
                editor.insertText(newText);
                trainAlternate(msg.AlternateNumber);
            }
        }

        imdSession.Recognizer.NewCorrectionEventHandler = function (msg) {
            elSelectAlternates.clear();
            currentAlternates = msg.Alternates;
            audio = msg.Audio;
            for (var i = 0; i < currentAlternates.length; i++) {
                elSelectAlternates.add("ACEPTAR " + (i + 1) + ": " + currentAlternates[i].Text);
            }
        }

        imdSession.ActionHandlerTable[invoxmd.wsMessage.RECOGNIZER_GET_RECOGNITION_DETAIL] = function (response, session) {
            if (response.ExceptionType == invoxmd.exceptionType.NONE) {
                elSelectAlternates.clear();
                if(!response.Detail){
                    return;
                }
                currentAlternates = response.Detail.Hypothesis;
                audio = response.Detail.Audio;
                for (var i = 0; i < currentAlternates.length; i++) {
                    elSelectAlternates.add("ACEPTAR " + (i + 1) + ": " + currentAlternates[i].Text);
                }
            } else {
                window.console.log('[error]: Recognizer Get Recognition Detail error: ', response);
            }
        }

        imdSession.ActionHandlerTable[invoxmd.wsMessage.DICTIONARY_GET_WORDS] = function (response, session) {
            if (response.ExceptionType == invoxmd.exceptionType.NONE) {
                currentWordsDictionary = response.Words;
            } else {
                window.console.log('[error]: Dictionary Get Words error: ', response);
                toastr['error']('Se ha producido un error y no se han podido leer las palabras del diccionario personal del usuario.');
            }
        }

        imdSession.Dictionary.getWords();
        imdSession.Recognizer.getRecognitionDetail(dialog.textSelected);
        imdSession.Recognizer.setScope(invoxmd.dictationScope.CORRECTION);
    }
    return {

        title: 'Corrigiendo',
        minWidth: 400,
        minHeight: 0,
        resizable: CKEDITOR.DIALOG_RESIZE_NONE,

        buttons: [
            CKEDITOR.dialog.cancelButton
        ],

        contents: [{
            id: 'acceptWord',
            label: 'Acepte una palabra de la lista',
            title: 'Acepte una palabra de la lista',

            elements: [{
                    id: 'selectAlternates',
                    type: 'select',
                    label: 'Acepte una palabra de la lista:',
                    size: 10,
                    style: 'height: auto !important ; width:50em',
                    items: [
                        ['']
                    ],

                    onChange: onChangeSelectAlternate
                },
                {
                    id: 'information',
                    type: 'html',
                    html: 'O añada una nueva al diccionario',
                    style: 'white-space: normal;'
                },

                {
                    type: "hbox",
                    widths: ["20%", '80%'],
                    children: [{
                            type: "html",
                            html: "Palabra"
                        },
                        {
                            id: 'wordname',
                            type: 'text',
                            'default': ''
                        }
                    ]
                },
                {
                    type: 'hbox',
                    widths: ['20%', '75%', '5%'],
                    children: [{
                            type: "html",
                            html: "Pronunciación"
                        },
                        {
                            id: 'transcript',
                            type: 'text',
                            'default': ''
                        },
                        {
                            id: 'button_rec',
                            type: 'button',
                            label: "🎤",
                            title: "Grabar pronunciación",
                            // style: "border: none;", // Comentado para que se vea mejor el botón en IE8 (XP).
                            onClick: onClickRec,
                            onShow: checkIE8
                        }
                    ]
                },
                {
                    id: 'button_saveword',
                    type: 'button',
                    label: 'Añadir al diccionario',

                    onClick: onClickSave
                }
            ]
        }],
        onCancel: onExit,
        onShow: onShowDialog
    };
});