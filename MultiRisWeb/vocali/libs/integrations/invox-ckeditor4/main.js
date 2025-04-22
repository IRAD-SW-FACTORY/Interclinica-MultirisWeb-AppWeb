let INVOXCKEditor = function (id, core) {

	let INVOXToolbarState = {
        CKEDITOR_READY: 0,
		LOGGED_OUT: 1,
		LOGGED_IN: 2,
	};

	this.Id = id;
    this.editorId = `cke_${id}`
	this.INVOXCore = core;
    this.State = INVOXToolbarState.LOGGED_OUT;
    this.TOOLBAR = "invox-toolbar"; //added in ckeditor/config.js
    this.editor = CKEDITOR.replace(id);
	let self = this;

    //#region Element creation
    this.editor.on("focus", function (e) {
        OnClickCKEditor(e.editor);
    });
    this.editor.on("instanceReady", function(e) {
        UpdateState(INVOXToolbarState.CKEDITOR_READY);  
        
        try {
            self.dictionaryComponent = INVOXMDComponent_Dictionary.create(self.editorId);
            self.templatesComponent = INVOXMDComponent_Templates.create(self.editorId);
            self.transformationsComponent = INVOXMDComponent_Transformations.create(self.editorId);
        }catch (e) {
            console.error(e.message)
        }

    });

    let css = {
        HIDE: "invox-hide",
        PROGRESS: "invox-progress-login",
        VUMETER: "invox-vumeter",
        MICROPHONE: "invox-microphone",
        MICROPHONE_PAUSED: "invox-microphone-paused",
        MICROPHONE_RUNNING: "invox-microphone-running",
        MICROPHONE_MUTED: "invox-microphone-muted",
        TEXTBAR: "invox-textbar",
        STATUS_BAR: "invox-status-bar",
        MESSAGE_INFO: "invox-status-info",
        MESSAGE_ERROR: "invox-status-error",
        MESSAGE_SUCCESS: "invox-status-success",
        MESSAGE_WARNING: "invox-status-warning",
        DICTATION_BAR: "invox-dictation-bar",
        DICTATION_PARTIAL: "invox-dictation-partial",
        DICTATION_ACCEPTED: "invox-dictation-accepted",
        DICTATION_REJECTED: "invox-dictation-rejected",
        DICTATION_COMMAND: "invox-dictation-command",       
        DICTATION_MACRO: "invox-dictation-macro",
        MODAL_BUTTON: "invox-modal-button",
        ADAPTATION_STARTED: "invox-status-info",
        ADAPTATION_REJECTED: "invox-status-info",
        ADAPTATION_FINISHED: "invox-status-info",
        ADAPTATION_ERROR: "invox-status-error"
    };

    let progressElements = null;
    function getProgressElements() {
        return progressElements || (progressElements = Array.from(document.getElementsByClassName(css.PROGRESS)));
    }
    let vumeterElements = null;
    function getVUMeterElements() {
        return vumeterElements || (vumeterElements = Array.from(document.getElementsByClassName(css.VUMETER)));
    }
    let microphoneElements = null;
    function getMicrophoneElements() {
        return microphoneElements || (microphoneElements = Array.from(document.getElementsByClassName(css.MICROPHONE)));
    }
    let textbarElements = null;
    function getTextbarElements() {
        return textbarElements || (textbarElements = Array.from(document.getElementsByClassName(css.TEXTBAR)));
    }
    let modalButtonsElements = null;
    function getModalElements() {
        return modalButtonsElements || (modalButtonsElements = Array.from(document.getElementsByClassName(css.MODAL_BUTTON)));
    }

    function getLangResources() {
        const i18n = new INVOX.I18nService();
        const lang = INVOX.GetCurrentLang();
        return i18n.getResources(lang);
    }

    (function CreateINVOXToolbar() {
        //#region Recognizer 
        let switchDictationCommand = "invox-switch-dictation";

        self.editor.addCommand(switchDictationCommand, new CKEDITOR.command(self.editor, {
            exec: function() {
                try {
                    self.INVOXCore.SwitchDictation()
                } catch (e) {
                    ShowMessage(INVOX.MessageType.ERROR, e);
                }
            }
        }));
        self.editor.ui.addButton("invox-microphone-btn", {
            toolbar: self.TOOLBAR + ",0",
            command: switchDictationCommand,
            className: css.MICROPHONE + " " + css.HIDE,
            label: getLangResources().MICROPHONE_ACTIONS.PAUSED
        });
        //#endregion

        //#region Login Progress Bar
        self.editor.ui.addButton("invox-progress-login", {
            className: css.PROGRESS,
            toolbar: self.TOOLBAR + ",1",
            label: ""
        });
        //#endregion

        //#region VUMeter
        self.editor.ui.addButton("invox-vumeter", {
            toolbar: self.TOOLBAR + ",2",
            className: css.VUMETER + " " + css.HIDE,
            label: ""
        });
        //#endregion

        //#region Quick Integrations (Dictionary, Templates, Transformations)
        const showDictionary = "invox-show-dictionary";
        self.editor.addCommand(showDictionary, new CKEDITOR.command(self.editor, {
            exec: function() {
                try {
                    self.dictionaryComponent.show();
                } catch (e) {
                    ShowMessage(INVOX.MessageType.ERROR, e);
                }
            }
        }));
        self.editor.ui.addButton("invox-dictionary-btn", {
            toolbar: self.TOOLBAR + ",3",
            command: showDictionary,
            className: css.MODAL_BUTTON + " " + css.HIDE,
            label: getLangResources().DICTIONARY_ACTIONS.TITLE,
            icon: "../images/dictionary.svg"
        });

        const showTemplates = "invox-show-templates";
        self.editor.addCommand(showTemplates, new CKEDITOR.command(self.editor, {
            exec: function() {
                try {
                    self.templatesComponent.show();
                } catch (e) {
                    ShowMessage(INVOX.MessageType.ERROR, e);
                }
            }
        }));
        self.editor.ui.addButton("invox-templates-btn", {
            toolbar: self.TOOLBAR + ",4",
            command: showTemplates,
            className: css.MODAL_BUTTON + " " + css.HIDE,
            label: getLangResources().TEMPLATES_ACTIONS.TITLE,
            icon: "../images/templates.svg"
        });

        const showTransformations = "invox-show-transformations";
        self.editor.addCommand(showTransformations, new CKEDITOR.command(self.editor, {
            exec: function() {
                try {
                    self.transformationsComponent.show();
                } catch (e) {
                    ShowMessage(INVOX.MessageType.ERROR, e);
                }
            }
        }));
        self.editor.ui.addButton("invox-transformations-btn", {
            toolbar: self.TOOLBAR + ",5",
            command: showTransformations,
            label: getLangResources().TRANSFORMATIONS_ACTIONS.TITLE,
            className: css.MODAL_BUTTON + " " + css.HIDE,
            icon: "../images/transformations.svg"
        });
        //#region  (StatusBar and VisorHypothesis)
        self.editor.ui.addButton("invox-textbar", {
            toolbar: self.TOOLBAR + ",6",
            className: css.TEXTBAR,
            label: "Log in to start " + self.INVOXCore.productName,
        });
        //#endregion
    })();

    //#endregion

    //#region Public functions
	this.Login = function (credentials, connectionConfig) {
		self.INVOXCore.CustomizeComponents(CustomizeComponentsBehaviour);
		return self.INVOXCore.Login(credentials, connectionConfig);
	};

	this.Logout = function () {
        self.INVOXCore.Logout()
        .then(() => UpdateState(INVOXToolbarState.LOGGED_OUT))
        .catch((e) => console.error(e) );
	};

    //#endregion

    //#region Customizing components
    function CustomizeComponentsBehaviour () {

		//#region Audio permissions
		
		/**
		 * Override the public function that is executed when audio source is granted 
		 * @constructor
		 * @param {function} function - Function that overrides the default behaviour
		 */
         self.INVOXCore.OnGrantedAudioSource(function () {
            getMicrophoneElements().forEach(element => {
                element.title = getLangResources().MICROPHONE_ACTIONS.PAUSED
            });
			UpdateMicrophoneIcon(css.MICROPHONE_PAUSED);
		});

		/**
		 * Override the public function that is executed when audio source is denied 
		 * @constructor
		 * @param {function} function - Function that overrides the default behaviour
		 */
		self.INVOXCore.OnDeniedAudioSource(function () {
            self.INVOXCore.SetDictationPaused();
            getMicrophoneElements().forEach(element => {
                element.title = getLangResources().MICROPHONE_ACTIONS.NOT_ACCESS
            });
            UpdateMicrophoneIcon(css.MICROPHONE_MUTED);
		});

		//#endregion

        //#region Login Progress Bar

        /**
         * Override the public function for customizing the progress bar
         * @constructor
         * @param {function} function - Function that overrides the default behaviour
         * @param {object} function.msg - Loading status message {Percent, PercentStep, Description}
         */
        self.INVOXCore.OnChangeProgressBar(function (msg) {
            let percent = `${msg.Percent}%`;
            getProgressElements().forEach(function (e) {
                let lbl = e.children[1];
                lbl.style.width = lbl.innerText = percent;
                lbl.classList.remove(css.HIDE);
            });
        });

        /**
         * Override the public function for customizing the load finished event
         * @constructor
         * @param {function} function - Function that overrides the default behaviour
         */
        self.INVOXCore.OnFinishProgressBar(function () { 
            /* do nothing */ 
        });

        //#endregion

        //#region Recognizer   

        /**
         * Override the public function for customizing the recognizer when is started
         * @constructor
         * @param {function} function - Function that overrides the default behaviour
         */
        self.INVOXCore.OnStartedRecognizer(function () {
            self.INVOXCore.SetDictationPaused();
            UpdateState(INVOXToolbarState.LOGGED_IN);
        });

        /**
         * Override the public function for customizing the recognizer when is paused
         * @constructor
         * @param {function} function - Function that overrides the default behaviour
         */
        self.INVOXCore.OnPausedRecognizer(function () {
            UpdateMicrophoneIcon(css.MICROPHONE_PAUSED);
            getMicrophoneElements().forEach(element => {
                element.title = getLangResources().MICROPHONE_ACTIONS.PAUSED
            });
            ChangeWriterColorFocus(ClassWriterTargetFocusDictationOFF, ClassWriterTargetFocusDictationON);
        });

        /**
         * Override the public function for customizing the recognizer when is running
         * @constructor
         * @param {function} function - Function that overrides the default behaviour
         */
        self.INVOXCore.OnRunningRecognizer(function () {
            UpdateMicrophoneIcon(css.MICROPHONE_RUNNING);
                      getMicrophoneElements().forEach(element => {
                element.title = getLangResources().MICROPHONE_ACTIONS.LISTENING
            });
            ChangeWriterColorFocus(ClassWriterTargetFocusDictationON, ClassWriterTargetFocusDictationOFF);
        });

        /**
		 * Override the public function for customizing the recognizer when triggered an error
		 * @constructor
		 * @param {function} function - Function that overrides the default behaviour
		 */
		self.INVOXCore.OnErrorRecognizer(function () {
			/* do nothing */
		});
        //#endregion

        //#region VUMeter
        
        /**
		 * Override the public function for customizing the vumeter updater
		 * @constructor
		 * @param {function} function - Function that overrides the default behaviour
		 * @param {number} function.activity - Percentage of vumeter activity
		 */
        self.INVOXCore.OnUpdateVumeterMicActivity(function (activity) {
            getVUMeterElements().forEach(function (e) {
                e.children[1].style.width = `${activity}%`
            });
        });
        //#endregion

        //#region  Status Bar

        /**
         * Override the public function for customizing the status bar
         * @constructor
         * @param {function} function - Function that overrides the default behaviour
         * @param {string} function.msg - Status message
         * @param {object} function.type - Type of message (info, error, warning, success)
         */
        self.INVOXCore.OnChangeStatusBar(function (msg, type) {
            let _class = css.STATUS_BAR + " " + getClassByType(type);
            UpdateTextBar(msg, _class);

            function getClassByType(type) {
                switch (type) {
                    case self.INVOXCore.MessageType.INFO: return css.MESSAGE_INFO;
                    case self.INVOXCore.MessageType.SUCCESS: return css.MESSAGE_SUCCESS;
                    case self.INVOXCore.MessageType.ERROR: return css.MESSAGE_ERROR;
                    case self.INVOXCore.MessageType.WARNING: return css.MESSAGE_WARNING;
                }
            }
        })
        //#endregion

        //#region Visor Hypothesis

        let isHypothesisInStatusbar = false;
        let timeout = 0;
        const MAX_TIME_SHOWING_HYPOTHESIS = 3000;
        const MAX_TIME_SHOWING_ADAPTATION_MESSAGE = 4000;

        /**
         * Override the public functions for customizing the hypothesis viewer
         * @constructor
         * @param {function} function - Function that overrides the default behaviour
         * @param {string} function.msg - Hypothesis message
         * @param {Enumerator} function.dictationEventType - Type of hyphotesis
         */
        self.INVOXCore.OnChangeVisorHypothesis(function (msg, dictationEventType) {
            clearTimeout(timeout);
            timeout = setTimeout(() => {
                self.INVOXCore.UpdateStatusBarToCurrentScope();
                isHypothesisInStatusbar = false;
            }, MAX_TIME_SHOWING_HYPOTHESIS);

            const _class = css.DICTATION_BAR + " " + getClassByDictationEventType(dictationEventType);
            isHypothesisInStatusbar = true;
            UpdateTextBar(msg, _class);

            function getClassByDictationEventType(type) {
                switch (type) {
                    case self.INVOXCore.dictationEventType.ACCEPTED: return css.DICTATION_ACCEPTED;
                    case self.INVOXCore.dictationEventType.PARTIAL: return css.DICTATION_PARTIAL;
                    case self.INVOXCore.dictationEventType.REJECTED: return css.DICTATION_REJECTED;
                    case self.INVOXCore.dictationEventType.COMMAND: return css.DICTATION_PARTIAL;
                    case self.INVOXCore.dictationEventType.MACRO: return css.DICTATION_PARTIAL;
                }
            }
        });

        //#endregion


        //#region Adaptation Events

        /**
         * Override the public functions to provide feedback about adaptation events 
         * @constructor
         * @param {function} function - Function that overrides the default behaviour
         * @param {string} function.message - Message about rejected adaptation
         */
        INVOX.OnRejectAdaptation(function() {
            if (isHypothesisInStatusbar) {
                return;
            }
            const message = getLangResources().ADAPTATION.REJECTED;
            const _class = `${css.DICTATION_BAR} ${css.ADAPTATION_REJECTED}`;
            showAdaptationMessage(message, _class);
        })

        /**
         * Override the public functions to provide feedback about adaptation events 
         * @constructor
         * @param {function} function - Function that overrides the default behaviour
         * @param {string} function.message - Message about started adaptation
         */    
        INVOX.OnStartAdaptation(function() {
            if (isHypothesisInStatusbar) {
                return;
            }
            const message = getLangResources().ADAPTATION.STARTED;
            const _class = `${css.DICTATION_BAR} ${css.ADAPTATION_STARTED}`;
            showAdaptationMessage(message, _class);
        })

        /**
         * Override the public functions to provide feedback about adaptation events 
         * @constructor
         * @param {function} function - Function that overrides the default behaviour
         * @param {string} function.message - Message about finish adaptation
         * @param {object} function.adaptationInfo - Information about the adaptation process
         */    
        INVOX.OnFinishAdaptation(function() {
            if (isHypothesisInStatusbar) {
                return;
            }
            const message = getLangResources().ADAPTATION.FINISHED;
            const _class = `${css.DICTATION_BAR} ${css.ADAPTATION_FINISHED}`;
            showAdaptationMessage(message, _class);
        })

        /**
         * Override the public functions to provide feedback about adaptation events 
         * @constructor
         * @param {function} function - Function that overrides the default behaviour
         * @param {string} function.message - Message about started adaptation
         * @param {string} function.error - Error message
         */    
        INVOX.OnErrorAdaptation(function() {
            if (isHypothesisInStatusbar) {
                return;
            }
            const message = getLangResources().ADAPTATION.ERROR;
            const _class = `${css.DICTATION_BAR} ${css.ADAPTATION_ERROR}`;
            showAdaptationMessage(message, _class);
        })

        function showAdaptationMessage(message, _class) {
            clearTimeout(timeout);
            timeout = setTimeout(() => {
                self.INVOXCore.UpdateStatusBarToCurrentScope();
            }, MAX_TIME_SHOWING_ADAPTATION_MESSAGE);
            UpdateTextBar(message, _class);
        }

        //#endregion

    };
    //#endregion

    //#region Auxiliar functions
	let ExecState = {};
	ExecState[INVOXToolbarState.LOGGED_OUT] = function DisableContent() {
        (function ShowClosedMessage() {
            let _class = css.STATUS_BAR + " " + css.MESSAGE_INFO;
            UpdateTextBar("Log in to start " + self.INVOXCore.productName, _class);
        })();
        (function HideVumeter() {
            getVUMeterElements().forEach(function (e) {
                e.classList.add(css.HIDE);
            });
        })();
        (function HideModalButtons() {
            getModalElements().forEach(function (e) {
                e.classList.add(css.HIDE);
            });
        })();
        (function HideMicrophoneButton() {
            getMicrophoneElements().forEach(function (e) {
                e.classList.add(css.HIDE);
            });
        })(); 
        (function RestartProgressBar() {
            let percent = "0%";
            let progressElements = getProgressElements();
            progressElements.forEach(function (e) {
                e.classList.remove(css.HIDE);
                let lbl = e.children[1];
                lbl.style.width = lbl.innerText = percent;
                lbl.classList.add(css.HIDE);
            });
        })();
	};
	ExecState[INVOXToolbarState.LOGGED_IN] = function EnableContent() {
        (function HideProgressBar() {
            getProgressElements().forEach(function (e) {
                e.classList.add(css.HIDE);
            });
        })();
        (function ShowVumeter() {
            getVUMeterElements().forEach(function (e) {
                e.classList.remove(css.HIDE);
            });
        })();
        (function ShowModalButtons() {
            getModalElements().forEach(function (e) {
                e.classList.remove(css.HIDE);
            });
        })();
        (function ShowMicrophoneButton() {
            getMicrophoneElements().forEach(function (e) {
                e.classList.remove(css.HIDE);
            });
        })(); 
	};
	ExecState[INVOXToolbarState.CKEDITOR_READY] = function EnableContent() {
        UpdateMicrophoneIcon(css.MICROPHONE_PAUSED);
	};
	function UpdateState(state) {
		try {
			ExecState[state]();
			this.State = state;
		} catch (e) {
			throw e
		}
	}


    let lastClassUpdate = "NO_EMPTY_CLASS_FOR_FIRST_REMOVE";
    function UpdateTextBar(msg, _class) {
        let lbl = (msg || '').replace(/\n/g, "↵");
        getTextbarElements().forEach(function (e) {
            let child = e.children[1];
            child.innerHTML = lbl;
            child.classList.remove(...lastClassUpdate.split(" "));
            child.classList.add(..._class.split(" "));
        });
        lastClassUpdate = _class;
    }

    let lastIconClassUpdate = "NO_EMPTY_CLASS_FOR_FIRST_REMOVE";
    function UpdateMicrophoneIcon(iconClass) {
        getMicrophoneElements().forEach(function (e) {
            let icon = e.children[0];
            icon.classList.remove(lastIconClassUpdate);
            icon.classList.add(iconClass);
        });
        lastIconClassUpdate = iconClass;
    }
    //#endregion

};