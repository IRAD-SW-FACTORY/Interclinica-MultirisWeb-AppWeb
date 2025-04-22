CKEDITOR.dialog.add("invoxmd_MicConfigDialog", function(editor) {
    var ckeDialog,
        elSentences,
        elFirstWindow,
        elSecondWindow,
        elNext,
        previousVolume,
        i18n = editor.lang.invoxmd.MICCONFIG_DIALOG,
        micConfigStarted,
        micConfigStopped;

    //#region IE POLYFILL

    if (!String.format) {
        String.format = function(format) {
            var args = Array.prototype.slice.call(arguments, 1);
            return format.replace(/{(\d+)}/g, function(match, number) {
                return typeof args[number] != "undefined" ? args[number] : match;
            });
        };
    }

    if (!String.prototype.trim) {
        (function() {
            // Make sure we trim BOM and NBSP
            var rtrim = /^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g;
            String.prototype.trim = function() {
                return this.replace(rtrim, "");
            };
        })();
    }
    //#endregion

    var onShowDialog = function() {
        initGlobalVars();
        showFirstWindow();

        var isIE8 = navigator.appVersion.indexOf("MSIE 8") >= 0;
        if (isIE8) {
            jQuery("#" + elSentences.domId)
                .find("textarea")
                .removeAttr("disabled")
                .attr("readonly", "readonly");
        }

        imdSession.Recognizer.setScope(invoxmd.dictationScope.NONE);
        setSentences();
    };

    function initGlobalVars() {
        ckeDialog = CKEDITOR.dialog.getCurrent();
        elSentences = ckeDialog.getContentElement("micConfig", "mic-config-sentences-container");
        elFirstWindow = ckeDialog.getContentElement("micConfig", "micgain-first-window");
        elSecondWindow = ckeDialog.getContentElement("micConfig", "micgain-second-window");
        elNext = ckeDialog.getButton("micgain-btn-next");
        micConfigStarted = false;
        micConfigStopped = false;
        previousVolume = audioSource.getVolume();
        enDialogo = true;
    }

    function showFirstWindow() {
        elSentences.disable();
        jQuery("#" + elFirstWindow.domId).show();
        jQuery("#" + elSecondWindow.domId).hide();
        jQuery("#" + elNext.domId).show();
        jQuery("#" + elSentences.domId).show();
        elSentences.setValue("");
    }

    function showSecondWindow() {
        jQuery("#" + elFirstWindow.domId).hide();
        jQuery("#" + elSecondWindow.domId).show();
        jQuery("#" + elNext.domId).hide();
    }

    function setSentences() {
        //IF EMPTY ARRAY --> SET DEFAULT SENTENCES
        invoxmd.util.sendMessage(imdSession, invoxmd.wsMessage.MIC_GAIN_SET_SENTENCES, [], function(response) {
            if (response.ExceptionType != invoxmd.exceptionType.NONE) {
                window.console.log("[error]: Mic Gain Set Sentences Error: ", response);
                toastr["error"]("Ha ocurrido un error al iniciar la configuración de micrófono.");
                closeDialog();
            }
        });
    }

    var onClickNext = function() {
        showSecondWindow();
        initMicConfig();
    };

    function initMicConfig() {
        jQuery("#" + elSentences.domId + " textarea").hide();
        jQuery("#" + elSentences.domId).height(150);
        jQuery(".invox-micconfig-sentences-row").remove();

        setSentecesEventHandler();
        startMicConfig();

        function setSentecesEventHandler() {
            imdSession.ActionHandlerTable[invoxmd.wsMessage.CONFIG_SENTENCE_EVENT] = function(response) {
                if (!imdSession.UseAgent) {
                    setWebMicrophoneLevel(response.Volume);
                }
                var hasNextSentence = !!response.NextSentenceTranscripted;
                if (hasNextSentence) {
                    updateViewSentence(response);
                } else {
                    endMicConfig();
                }
            };

            function setWebMicrophoneLevel(volume) {
                audioSource.setVolume(volume);
                invoxmd.log("Modificando volumen a " + volume);
            }

            function updateViewSentence(response) {
                var lastSentenceStatus = response.LastSentenceStatus,
                    newclass = getClassSentenceStatus(lastSentenceStatus);

                jQuery(".invox-micconfig-sentences-row").not(":eq(0)").remove();
                jQuery(".invox-micconfig-sentences-row").addClass("invox-micconfig-sentences-row-disabled");
                jQuery(".invox-micconfig-sentences-row-disabled").fadeOut(3000);
                var row = jQuery(".invox-micconfig-sentences-row.invox-bg-primary");
                row.removeClass("invox-bg-primary");
                row.addClass(newclass);
                jQuery(".invox-bg-success > .invox-micconfig-sentences-badge").text("✔");
                jQuery(".invox-bg-error > .invox-micconfig-sentences-badge").text("✖");
                PrependSentence(response);
            }

            function getClassSentenceStatus(status) {
                var msss = invoxmd.microSetupSentenceStatus,
                    newStatus = "";
                switch (status) {
                    case msss.NONE:
                    case msss.RECOGNIZED:
                    case msss.PARTIALLY_RECOGNIZED:
                        newStatus = "invox-bg-success";
                        break;
                    case msss.NOT_RECOGNIZED:
                    case msss.IGNORED:
                    case msss.ERROR:
                        newStatus = "invox-bg-error";
                        break;
                    default:
                        newStatus = "invox-bg-success";
                }
                return newStatus;
            }

            function PrependSentence(response) {
                var index = response.Index,
                    sentence = response.NextSentenceTranscripted,
                    zeroPadIndex = index < 10 ? "0" + index : index,
                    div = String.format(
                        '<div class="invox-micconfig-sentences-row invox-bg-primary"><div class="invox-micconfig-sentences-badge"></div>{1}</div>',
                        zeroPadIndex,
                        sentence
                    );
                jQuery(div)
                    .hide()
                    .prependTo("#" + elSentences.domId)
                    .fadeIn("slow");
            }
        }

        function startMicConfig() {
            invoxmd.util.sendMessage(imdSession, invoxmd.wsMessage.MIC_GAIN_START, null, function(response) {
                if (response.ExceptionType != invoxmd.exceptionType.NONE) {
                    window.console.log("[error]: Mic Gain Start Error: ", response);
                    toastr["error"]("Ha ocurrido un error al iniciar la configuración de micrófono.");
                    closeDialog();
                } else {
                    micConfigStarted = true;
                }
            });
        }

        function endMicConfig() {
            stopMicConfig(function(response, session) {
                micConfigStopped = true;
                micConfigStarted = false;
                var configError = response.ConfigError || response.ExceptionType != invoxmd.exceptionType.NONE;
                if (configError) {
                    if (response.TooManyConsecutiveErrors) {
                        if (audioSource.MicrophoneIsChecked && audioSource.MicrophoneIsValid) {
                            showErrorPossibleInvalidMicrophone();
                        } else {
                            showErrorChangeMicrophonePort();
                        }
                    } else {
                        showErrorMustBeRepeatMicConfig();
                    }
                    onShowDialog();
                } else {
                    closeDialog();
                }
            });

            function showErrorPossibleInvalidMicrophone() {
                var title = i18n.MAX_RETRIES_TITLE;
                var msg = i18n.MAX_RETRIES_WITH_INVALID_MICROPHONE;
                toastr.error(msg, title);
            }

            function showErrorChangeMicrophonePort() {
                var title = i18n.MAX_RETRIES_TITLE;
                var msg = i18n.MAX_RETRIES;
                toastr.error(msg, title);
            }

            function showErrorMustBeRepeatMicConfig() {
                var title = i18n.REPEAT_TITLE;
                var msg = i18n.REPEAT;
                toastr.error(msg, title);
            }
        }
    }

    function stopMicConfig(callback) {
        invoxmd.util.sendMessage(imdSession, invoxmd.wsMessage.MIC_GAIN_STOP, null, callback);
    }

    function closeDialog() {
        if (ckeDialog) {
            ckeDialog.hide();
        }

        if (micConfigStopped) {
            //MicGainStopped
            if (!imdSession.UseAgent) {
                var volumeSetted = audioSource.getVolume();
                imdSession.SessionVolume = volumeSetted;
                imdSession.MicSettingsRepository.updateWebVolumeIntoDb(volumeSetted);
                var isTrainingRequirerd = imdSession.User.TrainingInfo && imdSession.User.TrainingInfo.TrainingRequired;
                if (isTrainingRequirerd && typeof imdSession.Recognizer.TrainingEventHandler === "function") {
                    setTimeout(imdSession.Recognizer.TrainingEventHandler, 1000);
                }
            } else {
                imdSession.MicSettingsRepository.CheckAudioDevice();
            }

            invoxmdWE.MicConfigRequired = false;
        } else {
            if (micConfigStarted) {
                //Cancel MicGain
                stopMicConfig(); //detener
            }
            restorePreviosVolume();
            invoxmdWE.MicConfigRequired = true;
        }
        imdSession.Recognizer.setScope(invoxmd.dictationScope.PAUSED);
        enDialogo = false;

        function restorePreviosVolume() {
            var DEFAULT_WEB_VALUE = 0.5;
            audioSource.setVolume(previousVolume || DEFAULT_WEB_VALUE);
        }
    }

    return {
        title: i18n.DIALOG_TITLE,
        width: 600,
        minHeight: 0,
        resizable: CKEDITOR.DIALOG_RESIZE_NONE,
        buttons: [{
                id: "micgain-btn-next",
                type: "button",
                label: i18n.NEXT_BUTTON,
                onClick: onClickNext,
            },
            {
                id: "micgain-btn-exit",
                type: "button",
                label: i18n.EXIT_BUTTON,
                onClick: closeDialog,
            },
        ],
        contents: [{
            id: "micConfig",
            elements: [{
                    id: "micgain-first-window",
                    type: "vbox",
                    children: [{
                        type: "html",
                        html: i18n.README,
                        style: "white-space: normal;",
                    }, ],
                },
                {
                    id: "micgain-second-window",
                    type: "vbox",
                    children: [{
                            type: "html",
                            html: '<div id="invox-micconfig-sentences-container">' +
                                '<p class="invox-label">' +
                                i18n.LABEL_SENTENCES +
                                "</p>" +
                                '<div class="invox-vumeter"><div class="invox-vumeter-bar"></div></div>' +
                                "<div class=invox-micconfig-sentences-rows></div>" +
                                "</div>" +
                                "</div>",
                        },
                        {
                            id: "mic-config-sentences-container",
                            type: "textarea",
                            rows: 15,
                            style: "margin: 0% 3%",
                            inputStyle: "white-space: normal",
                        },
                    ],
                },
            ],
        }, ],
        onCancel: closeDialog,
        onShow: onShowDialog,
    };
});