CKEDITOR.plugins.add('invoxmd', {

    lang: 'es',

    init: function(editor) {

        var cssId = 'invox-medical-css';
        if (!document.getElementById(cssId)) {
            var head = document.getElementsByTagName('head')[0];
            var link = document.createElement('link');
            link.id = cssId;
            link.rel = 'stylesheet';
            link.type = 'text/css';
            link.href = this.path + 'css/style.css';
            link.media = 'all';
            head.appendChild(link);
        }

        var plugin = this,
            iconsPath = plugin.path + 'icons/',
            i18n = editor.lang[plugin.name],
            toolbarGroup = 'invoxmd_group',
            statusBar = i18n.STATUS_BAR;


        toolbarPosition = {};

        toolbarPosition[i18n.TOGGLE_DICTATION_LABEL] = ',1';
        toolbarPosition[i18n.ITN_LABEL] = ',2';
        //macro
        //dictionary
        toolbarPosition[i18n.TRAINING_LABEL] = ',5';
        toolbarPosition[i18n.MICCONFIG_LABEL] = ',6';
        toolbarPosition[i18n.ACCEPT_TEXT_LABEL] = ',7';
        toolbarPosition[i18n.STATUS_BAR_LABEL] = ',8';
        //about
        toolbarPosition[i18n.HELP_LABEL] = ',9';

        // -- GUI

        var Style = {
            ERROR: function(e) {
                e.css("color", "#E74C3C").css("font-weight", "bold");
            },
            INFO: function(e) {
                e.css("color", "#3498DB").css("font-weight", "bold");
            },
            SUCCESS: function(e) {
                e.css("color", "#2ECC71").css("font-weight", "bold");
            },
            LOG: function(e) {
                e.css("color", "#17202A").css("font-weight", "normal");
            },
            VUMETER: function(e, activity) {
                e.css('color', (activity > 70 ? '#E74C3C' : '#2ECC71'))
            }
        };


        var icons = {
            MIC_PAUSED_ICON: "MicrophonePaused.png",
            MIC_MUTED_ICON: "MicrophoneMuted.png",
            MIC_RUNNING_ICON: "MicrophoneRunning.png",
            HELP_ICON: "Help.png",
            SEND_ICON: "Save.png",
            MICCONFIG_ICON: 'micconfig.png',
            TRAINING_ICON: 'training.png',
            ITNS_ICON: "itns.png",
            EXPORT_ICON: 'export2.png'
        }

        var ChangeMicIcon = function(icon) {
            var ico = iconsPath + (icon || MIC_MUTED_ICON);
            jQuery('.cke_button__toggledictation_icon')
                .css('background-position', '0 0')
                .css('background-image', 'url(' + ico + ')')
                .css('background-repeat', 'no-repeat');
        }

        //GUI

        // --- EXPORT
        if (typeof editor.urlToExport === 'string') {
            var command_export = 'invoxmd_Export';
            editor.addCommand(command_export, new CKEDITOR.command(editor, {
                exec: function(editor) {
                    Invox.SendTextTo(editor.name, editor.urlToExport);
                }
            }));

            editor.ui.addButton("Export", {
                label: "Exportar",
                command: command_export,
                icon: iconsPath + icons.EXPORT_ICON,
                toolbar: 'invoxmd_group,7'
            });
        }

        //EXPORT

        // --- MICCONFIG
        var command_MicConfig = 'invoxmd_MicConfig';
        editor.addCommand(command_MicConfig, new CKEDITOR.dialogCommand('invoxmd_MicConfigDialog'));
        editor.ui.addButton(i18n.MICCONFIG_LABEL, {
            label: i18n.MICCONFIG_LABEL,
            command: command_MicConfig,
            icon: iconsPath + icons.MICCONFIG_ICON,
            toolbar: toolbarGroup + toolbarPosition[i18n.MICCONFIG_LABEL]
        });
        CKEDITOR.dialog.add('invoxmd_MicConfigDialog', this.path + 'dialogs/invoxmd_MicConfigDialog.js');
        // MICCONFIG

        // --- TRAINER
        var command_Training = 'invoxmd_Training';
        editor.addCommand(command_Training, new CKEDITOR.dialogCommand('invoxmd_TrainingDialog'));

        var command_Training_CheckMicrophone = 'invoxmd_Training_CheckMicrophone';
        editor.addCommand(command_Training_CheckMicrophone, {
            exec: function() {
                var session = invoxmd.GetCurrentSession();
                var audioSource = session.getAudioSource();
                if (audioSource.MicrophoneIsConfigured) {
                    editor.execCommand(command_Training);
                } else {
                    editor.execCommand(command_MicConfig);
                }
            }
        });


        editor.ui.addButton(i18n.TRAINING_LABEL, {
            label: i18n.TRAINING_LABEL,
            command: command_Training_CheckMicrophone,
            icon: iconsPath + icons.TRAINING_ICON,
            toolbar: toolbarGroup + toolbarPosition[i18n.TRAINING_LABEL]
        });
        CKEDITOR.dialog.add('invoxmd_TrainingDialog', this.path + 'dialogs/invoxmd_TrainingDialog.js');

        //

        // ---  ITN 
        var command_ITN = 'invoxmd_ITN';
        editor.addCommand(command_ITN, new CKEDITOR.dialogCommand('invoxmd_ITNDialog'));
        editor.ui.addButton(i18n.ITN_LABEL, {
            label: i18n.ITN_LABEL,
            command: command_ITN,
            icon: iconsPath + icons.ITNS_ICON,
            toolbar: toolbarGroup + toolbarPosition[i18n.ITN_LABEL]
        });
        CKEDITOR.dialog.add('invoxmd_ITNDialog', this.path + 'dialogs/invoxmd_ITNDialog.js');
        // ITN

        // --- Button Send (External Editor)

        if (!editor.isInternal) {
            editor.addCommand('AcceptTextFromExternalEditor', {
                exec: function(editor) {
                    imdCommands[invoxmd.commandId.ACCEPT_TEXT](editor, null);
                }
            });

            editor.ui.addButton(i18n.ACCEPT_TEXT_LABEL, {
                label: i18n.ACCEPT_TEXT_LABEL,
                command: 'AcceptTextFromExternalEditor',
                icon: iconsPath + icons.SEND_ICON,
                toolbar: toolbarGroup + toolbarPosition[i18n.ACCEPT_TEXT_LABEL]
            });
        }
        // Button Send (External Editor)



        // --- Button Toggle Dictation
        editor.addCommand('ToggleDictation', {
            exec: function(editor) {
                if (audioSource.getAccessAllowed()) {
                    if (!imdSession.SessionVolume && !imdSession.UseAgent) {
                        if (typeof(imdSession.Recognizer.MicConfigEventHandler) === 'function') {
                            imdSession.Recognizer.MicConfigEventHandler();
                        } else {
                            window.console.log('[error]: No previous volume has been recovered. Audio setup required, but session.Recognizer.MicConfigEventHandler is not implemented.');
                        }
                    } else if (imdSession.Recognizer.CurrentScope == invoxmd.dictationScope.PAUSED) {
                        imdSession.Recognizer.setScope(invoxmd.dictationScope.RUNNING);
                        if (!imdSession.UseAgent) {
                            if (imdSession.SessionVolume != null) {
                                audioSource.setVolume(imdSession.SessionVolume);
                                window.console.log("[info]: Set audioSource.setVolume(" + imdSession.SessionVolume + ") from session value");
                            } else {
                                audioSource.setVolume(imdSession.DefaultVolume);
                                window.console.log("[info]: Set audioSource.setVolume(" + imdSession.DefaultVolume + ") from default value");
                            }
                        }
                    } else {
                        imdSession.Recognizer.setScope(invoxmd.dictationScope.PAUSED);
                    }
                }
            },
            editorFocus: false
        });

        editor.ui.addButton('ToggleDictation', {
            label: i18n.TOGGLE_DICTATION_LABEL,
            command: 'ToggleDictation',
            icon: iconsPath + icons.MIC_MUTED_ICON,
            toolbar: toolbarGroup + toolbarPosition[i18n.TOGGLE_DICTATION_LABEL]
        });

        // Button Toggle Dictation

        // --- Spelling Words
        var spellingtoast = null;
        var spellingWords = ['antonio', 'burgos', 'carmen', 'chocolate', 'dolores', 'españa', 'francia', 'granada', 'historia', 'inés', 'josé', 'kilo',
            'lorenzo', 'madrid', 'navarrá', 'ñoño', 'oviedo', 'parís', 'queso', 'ramón', 'sábado', 'toledo', 'ulises', 'valencia', 'washington', 'xilófono', 'yegua', 'zaragoza'
        ];
        editor.addCommand('ShowSpellingWords', {
            exec: function(editor) {
                toastr.clear();
                var options = {
                    'closeButton': true, 'debug': false, 'newestOnTop': false, 'progressBar': false,
                    'positionClass': 'toast-bottom-full-width', 'preventDuplicates': true, 'onclick': null, 'showDuration': 0,
                    'hideDuration': 0, 'timeOut': 0, 'extendedTimeOut': 0, 'showEasing': 'swing',
                    'hideEasing': 'linear', 'showMethod': 'fadeIn', 'hideMethod': 'fadeOut', 'tapToDismiss': false
                };
                var toastrDescription = (function(spellingWords) {
                    var description = '';
                    for (var i = 0; spellingWords[i]; i++) {
                        var currentWord = spellingWords[i],
                            firstLetter = currentWord.charAt(0),
                            remainingWord = currentWord.slice(1);
                        description += '<b style="font-size:20px">' + firstLetter.toUpperCase() + '</b >' + remainingWord + ' ';
                    }
                    return description;
                })(spellingWords);
                spellingtoast = toastr.info(toastrDescription, 'Lista de palabras', options);
            },
            editorFocus: false
        });


        editor.addCommand('HideSpellingWords', {
            exec: function(editor) {
                if (spellingtoast) {
                    toastr.clear(this.spellingtoast);
                    spellingtoast = null;
                }
            },
            editorFocus: false
        });

        // Spelling Words


        // --- Help 
        editor.ui.addButton('Help', {
            label: i18n.HELP_LABEL,
            command: 'Help',
            icon: iconsPath + icons.HELP_ICON,
            toolbar: toolbarGroup + toolbarPosition[i18n.HELP_LABEL]
        });

        editor.addCommand("Help", {
            exec: function(editor) {
                window.open(plugin.path + "/help/help.html");
            },
            editorFocus: false
        });

        // Help


        // --- STATUS BAR


        editor.ui.addButton('estadosesion', {
            label: i18n.STATUS_BAR_LABEL,
            toolbar: toolbarGroup + toolbarPosition[i18n.STATUS_BAR_LABEL],
            command: "ActivityToNow"
        });

        editor.addCommand("ActivityToNow", {
            exec: function(editor) {
                invoxmdWE.SetActivityToNow();
            }
        });

        var ChangeStatusBar = function(editor, text, style) {
            var lbl = (text || '').replace(/\n/g, '↵');
            jQuery('.cke_button__estadosesion_icon').css('display', 'none').parent();
            jQuery('.cke_button__estadosesion').css("border", "1px solid rgba(63, 51, 51, 0.12)");
            var elem = jQuery('.cke_button__estadosesion_label').css('white-space', 'pre-line').text(lbl).css('display', 'inline');
            if (typeof style == "function") {
                style(elem)
            }

        }

        editor.addCommand("ChangeStatusBar_Login", {
            exec: function(editor, user) {
                ChangeStatusBar(editor, statusBar.LOGIN.replace(':USER:', user), Style.INFO);
            },
            editorFocus: false
        });

        editor.addCommand("ChangeStatusBar_Connecting", {
            exec: function(editor, host) {
                ChangeStatusBar(editor, statusBar.CONNECTING.replace(':HOST:', host), Style.INFO);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_NotAccess", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.NOT_ACCESS, Style.ERROR);
                $('.invox-microphone').removeClass('invox-microphone-running');
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_DownloadingResources", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.DOWNLOADING_RESOURCES, Style.INFO);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_Listening", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.LISTENING, Style.INFO);
                ChangeMicIcon(icons.MIC_RUNNING_ICON);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_Paused", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.PAUSED, Style.INFO);
                ChangeMicIcon(icons.MIC_PAUSED_ICON);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_PhoneticTranscription", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.PHONETIC_TRANSCRIPTION, Style.INFO);
                toastr['success']('¡Hable ahora!');
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_Correction", {
            exec: function(editor, word) {
                ChangeStatusBar(editor, statusBar.CORRECTION, Style.SUCCESS);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_Spelling", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.SPELLING, Style.INFO);
                ChangeMicIcon(icons.MIC_RUNNING_ICON);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_FlashWaiting", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.FLASH_WAITING, Style.ERROR);
                ChangeMicIcon(icons.MIC_MUTED_ICON);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_AgentWaiting", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.AGENT_WAITING, Style.ERROR);
                ChangeMicIcon(icons.MIC_MUTED_ICON);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_InvalidCredentials", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.INVALID_CREDENTIALS, Style.ERROR);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_ConcurrentLicense", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.CONCURRENT_LICENSE, Style.ERROR);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_Error", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.ERROR, Style.ERROR);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_Reconection", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.RECONECTION, Style.ERROR);
                ChangeMicIcon(icons.MIC_MUTED_ICON);
            },
            editorFocus: false
        });

        var MAX_CHARACTERS_STATUSBAR = 80;
        editor.addCommand("ChangeStatusBar_PartialHypothesis", {
            exec: function(editor, partial) {
                var partialH = statusBar.PARTIAL_HYPOTHESIS.replace(':PARTIAL:', partial.slice(-MAX_CHARACTERS_STATUSBAR));
                ChangeStatusBar(editor, partialH, Style.LOG);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_AcceptedHypothesis", {
            exec: function(editor, accepted) {
                var acceptedH = statusBar.ACCEPTED_HYPOTHESIS.replace(':ACCEPTED:',
                    (accepted.length < MAX_CHARACTERS_STATUSBAR ?
                        accepted :
                        (accepted.substr(0, MAX_CHARACTERS_STATUSBAR / 2) + "[...]" + accepted.slice(-(MAX_CHARACTERS_STATUSBAR / 2 - 5)))
                    ));
                ChangeStatusBar(editor, acceptedH, Style.SUCCESS);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_RejectedHypothesis", {
            exec: function(editor, rejected) {
                ChangeStatusBar(editor, statusBar.REJECTED_HYPOTHESIS.replace(':REJECTED:', rejected), Style.ERROR);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_CommandExecuted", {
            exec: function(editor, command) {
                ChangeStatusBar(editor, statusBar.COMMAND_EXECUTED.replace(':COMMAND:', command), Style.SUCCESS);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_Macro", {
            exec: function(editor, macroname) {
                ChangeStatusBar(editor, statusBar.MACRO.replace(':MACRONAME:', macroname), Style.SUCCESS);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_FlashError", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.FLASH_ERROR, Style.ERROR);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_SendingResources", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.SENDING_RESOURCES, Style.INFO);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_InvalidSession", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.INVALID_SESSION, Style.ERROR);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_SuccessSession", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.SUCCESS_SESSION, Style.INFO);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_NetLatencyError", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.NET_LATENCY_ERROR, Style.ERROR);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_NetConnectionLost", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.NET_CONNECTION_LOST, Style.ERROR);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_RecognizerError", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.RECOGNIZER_ERROR, Style.ERROR);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_WebsocketClosed", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.WEBSOCKET_CLOSED, Style.ERROR);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_LDAPInvalidUser", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.LDAP_INVALID_USER, Style.ERROR);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_LDAPNoSpecialty", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.LDAP_NO_SPECIALTY, Style.ERROR);
            },
            editorFocus: false
        });
        editor.addCommand("ChangeStatusBar_LicenseNotValid", {
            exec: function(editor) {
                ChangeStatusBar(editor, statusBar.LICENSE_NOT_VALID, Style.ERROR);
            }
        });
        //STATUS BAR


        // --- VUMETER

        editor.addCommand("UpdateMicActivity", {
            exec: function(editor) {
                if (audioSource.getAccessAllowed()) {
                    var level = audioSource.getLevel() / 100,
                        activity = Math.round(level * 1000) / 1000, // 3 decimals
                        dbValue = activity == 0 ? -60 : Math.LOG10E * Math.log(activity) * 20, //[-60..0]
                        width = -(dbValue - (-60)) * 100 / (-60);

                    jQuery('.invox-vumeter-bar').stop(true);
                    jQuery('.invox-vumeter-bar').animate({
                        'width': width + '%'
                    }, 'fast');
                    jQuery('.cke_button__toggledictation_label').text('|||||||||||||||||||');
                    jQuery('.cke_button__toggledictation_label').stop(true);
                    var MAX_WIDTH_LBL = 70;
                    jQuery('.cke_button__toggledictation_label').animate({
                        'width': Math.min(width, MAX_WIDTH_LBL) + '%'
                    }, 'fast');
                    var clipping = activity > 70;
                    jQuery('.invox-vumeter-bar').toggleClass('invox-bg-success', !clipping);
                    jQuery('.invox-vumeter-bar').toggleClass('invox-bg-error', clipping);
                    jQuery('.cke_button__toggledictation_label').toggleClass('invox-text-success', !clipping);
                    jQuery('.cke_button__toggledictation_label').toggleClass('invox-text-error', clipping);
                }
            },
            editorFocus: false
        });

        //VUMETER
    }
});