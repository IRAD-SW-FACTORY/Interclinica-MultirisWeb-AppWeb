"use strict";
var INVOXMDComponent_Bar = (() => {
  var __defProp = Object.defineProperty;
  var __getOwnPropDesc = Object.getOwnPropertyDescriptor;
  var __getOwnPropNames = Object.getOwnPropertyNames;
  var __hasOwnProp = Object.prototype.hasOwnProperty;
  var __export = (target, all) => {
    for (var name in all)
      __defProp(target, name, { get: all[name], enumerable: true });
  };
  var __copyProps = (to, from, except, desc) => {
    if (from && typeof from === "object" || typeof from === "function") {
      for (let key of __getOwnPropNames(from))
        if (!__hasOwnProp.call(to, key) && key !== except)
          __defProp(to, key, { get: () => from[key], enumerable: !(desc = __getOwnPropDesc(from, key)) || desc.enumerable });
    }
    return to;
  };
  var __toCommonJS = (mod) => __copyProps(__defProp({}, "__esModule", { value: true }), mod);

  // libs/integrations/invox-bar/src/public.ts
  var public_exports = {};
  __export(public_exports, {
    author: () => author,
    commit: () => commit,
    create: () => create,
    license: () => license,
    productName: () => productName,
    version: () => version
  });

  // libs/integrations/common/product.ts
  var productName = "INVOX Medical";
  var version = "2.8.1.4793";
  var commit = "59b15ef8e7a46145751d7dc304be268b46c377db";
  var license = "Commercial Software";
  var author = "Vócali Sistemas Inteligentes";

  // libs/integrations/common/util/domUtility.ts
  var DOMUtility = class {
    static getElement(id) {
      return document.getElementById(id);
    }
    static existsElement(id) {
      const element = DOMUtility.getElement(id);
      return element !== null;
    }
    static removeElement(id) {
      var _a;
      DOMUtility.existsElement(id) && ((_a = DOMUtility.getElement(id)) == null ? void 0 : _a.remove());
    }
  };

  // libs/integrations/common/i18n/i18n.ts
  var i18n = class {
    static getLangResources() {
      const i18n2 = new INVOX.I18nService();
      const lang = INVOX.GetCurrentLang();
      return i18n2.getResources(lang);
    }
  };

  // libs/integrations/common/components/baseComponent.ts
  var BaseComponent = class extends DOMUtility {
    constructor(langResources = void 0) {
      super();
      this._langResources = langResources;
    }
    initComponent() {
    }
    create(containerId) {
    }
    destroy() {
      this.componentWillUnmount();
    }
    componentDidMount() {
    }
    componentWillUnmount() {
    }
    setBehaviour(element) {
    }
    addEvent(element, eventName, callback, useCapure = false) {
      if (element.addEventListener) {
        element.addEventListener(eventName, callback, useCapure);
      } else if (element.attachEvent) {
        element.attachEvent("on" + eventName, callback);
      } else {
        element["on" + eventName] = callback;
      }
    }
    removeEvent(element, eventName, callback) {
      if (element.removeEventListener) {
        element.removeEventListener(eventName, callback);
      }
    }
  };

  // libs/integrations/invox-bar/src/components/layers/baseLayerComponent.ts
  var BaseLayerComponent = class extends BaseComponent {
    setClass(_class) {
      this._class = _class;
    }
    setNextView(nextView) {
      this._nextView = nextView;
    }
    next() {
      this._nextView();
    }
    create(containerId) {
      var _a;
      const viewElement = document.createElement("div");
      viewElement.setAttribute("class", `${this._class} invox-bar__layer`);
      const contentElements = this.createContent();
      contentElements.forEach((element) => viewElement.appendChild(element));
      (_a = DOMUtility.getElement(containerId)) == null ? void 0 : _a.appendChild(viewElement);
    }
    createContent() {
      return [];
    }
  };

  // libs/integrations/invox-bar/src/components/status/statusbar.ts
  var Statusbar = class extends BaseComponent {
    constructor() {
      super(...arguments);
      this.RESTORE_DELAY = 2500;
    }
    setOnErrorCallback(callback) {
      this._onErrorCallback = callback;
      return this;
    }
    setOnMicrophoneConnectedCallback(callback) {
      this._onMicrophoneConnectedCallback = callback;
      return this;
    }
    setOnMicrophoneDisconnectedCallback(callback) {
      this._onMicrophoneDisconnectedCallback = callback;
      return this;
    }
    create() {
      this._statusMessageElement = document.createElement("label");
      this._statusMessageElement.setAttribute("class", "invox-bar__statusbar-message invox-bar__hypothesis-follower");
      const statusbarElement = document.createElement("div");
      statusbarElement.setAttribute("class", "invox-bar__statusbar-container");
      statusbarElement.appendChild(this._statusMessageElement);
      this.customizeStatusbar();
      return statusbarElement;
    }
    customizeStatusbar() {
      INVOX.OnChangeStatusBar((message, type) => this.printStatus(message, type));
      INVOX.OnChangeVisorHypothesis((message, dictationEventType) => !this.isSessionDisconnected() && this.printHypothesis(message));
      INVOX.DeviceActionManager[INVOX.deviceActionId.DEVICE_ADDED] = () => !this.isSessionDisconnected() && this.printMicrophoneConnected();
      INVOX.DeviceActionManager[INVOX.deviceActionId.DEVICE_REMOVED] = () => !this.isSessionDisconnected() && this.printMicrophoneDisconnected();
    }
    isSessionDisconnected() {
      const session = INVOX.GetCurrentSession();
      if (!session) {
        return true;
      }
      return session.isDisconnected();
    }
    // @ts-ignore
    printStatus(message, type = INVOX.StatusMessageTypeEnum.INFO) {
      const tooltip = message;
      if (type === INVOX.StatusMessageTypeEnum.ERROR) {
        INVOX.LogError(`Status error: ${message}`);
        this._onErrorCallback();
        message = this.removeBreakLines(message);
      }
      this._statusMessageElement.innerText = message;
      this._statusMessageElement.title = tooltip;
      this._statusMessageElement.style.fontStyle = "normal";
    }
    printHypothesis(message) {
      const statusMessage = this.keepBreakLines(message);
      this._isHypothesisInStatusbar = true;
      this._statusMessageElement.innerText = statusMessage;
      this._statusMessageElement.title = message;
      this._statusMessageElement.style.fontStyle = "italic";
      this.isTextOverflown(this._statusMessageElement) ? this.enableHypothesisFollower(this._statusMessageElement) : this.disableHypothesisFollower(this._statusMessageElement);
      this.restoreStatusbarMessage();
    }
    printMicrophoneConnected() {
      const message = `Microphone ${INVOX.GetMicrophoneName()} connected`;
      this._statusMessageElement.innerText = message;
      this._statusMessageElement.title = message;
      this._onMicrophoneConnectedCallback();
      this.restoreStatusbarMessage();
    }
    printMicrophoneDisconnected() {
      let message = "Microphone disconnected";
      this._statusMessageElement.innerText = message;
      this._statusMessageElement.title = message;
      this._onMicrophoneDisconnectedCallback();
      setTimeout(() => {
        message = `Microphone ${INVOX.GetMicrophoneName()} connected`;
        this._statusMessageElement.innerText = message;
        this._statusMessageElement.title = message;
        this._onMicrophoneConnectedCallback();
        this.restoreStatusbarMessage();
      }, 1500);
    }
    async restoreStatusbarMessage(timeout = this.RESTORE_DELAY) {
      clearTimeout(this.delayTimeout);
      this.delayTimeout = setTimeout(() => {
        INVOX.UpdateStatusBarToCurrentScope();
        this._statusMessageElement.style.fontStyle = "normal";
        this.disableHypothesisFollower(this._statusMessageElement);
        this._isHypothesisInStatusbar = false;
      }, timeout);
    }
    isTextOverflown(element) {
      return element.scrollHeight > element.clientHeight || element.scrollWidth > element.clientWidth;
    }
    enableHypothesisFollower(element) {
      !element.classList.contains("active") && element.classList.add("active");
    }
    disableHypothesisFollower(element) {
      element.classList.contains("active") && element.classList.remove("active");
    }
    handleStartedAdaptation(message) {
      this.printAdaptationMessage(message);
    }
    handleRejectedAdaptation(message) {
    }
    handleFinishedAdaptation(message) {
      this.printAdaptationMessage(message);
    }
    handleErrorAdaptation(message) {
      this.printAdaptationMessage(message, INVOX.StatusMessageTypeEnum.ERROR);
    }
    // @ts-ignore
    printAdaptationMessage(message, type = INVOX.StatusMessageTypeEnum.INFO) {
      if (this._isHypothesisInStatusbar) {
        return;
      }
      this.printStatus(message, type);
      this.restoreStatusbarMessage();
    }
    removeBreakLines(text) {
      return this.replaceBreakLines(text, "");
    }
    keepBreakLines(text) {
      return this.replaceBreakLines(text, "↲ ");
    }
    replaceBreakLines(text, sustitute) {
      return text.replace(/(\r\n|\n)/g, sustitute);
    }
  };

  // libs/integrations/invox-bar/src/components/buttons/button.ts
  var Button = class extends BaseComponent {
    constructor() {
      super();
      this._tooltip = "";
      this._icon = "";
      this._classList = [];
      this._callback = () => {
      };
      this._classList = ["invox-bar__button"];
    }
    setTooltip(tooltip) {
      this._tooltip = tooltip;
      return this;
    }
    setIcon(icon) {
      this._icon = icon;
      return this;
    }
    addClass(newClass) {
      this._classList.push(newClass);
    }
    setCallback(callback) {
      this._callback = callback;
      return this;
    }
    create() {
      const element = this.createElement();
      this.addEvent(element, "click", () => this.setBehaviour(element));
      return element;
    }
    createElement() {
      const buttonElement = document.createElement("button");
      if (this._classList && this._classList.length > 0) {
        this._classList.forEach((classElement) => buttonElement.classList.add(classElement));
      }
      this._tooltip && (buttonElement.title = this._tooltip);
      this._icon && (buttonElement.innerHTML = this._icon);
      return buttonElement;
    }
    setBehaviour(element) {
      this._callback();
    }
  };

  // libs/integrations/invox-bar/src/components/recognizer/microphoneButton.ts
  var MicrophoneButton = class extends Button {
    constructor() {
      super();
      this.initComponent();
    }
    initComponent() {
      this.addClass("invox-bar__microphone-button");
      this.setCallback(() => this.switchDictation());
    }
    create() {
      this._buttonElement = this.createElement();
      this.addEvent(this._buttonElement, "click", () => this.setBehaviour(this._buttonElement));
      this.changeMicrophoneDisabled();
      return this._buttonElement;
    }
    switchDictation() {
      this.hasMicrophoneAccess() && INVOX.SwitchDictation();
    }
    hasMicrophoneAccess() {
      const session = INVOX.GetCurrentSession();
      const audioStatus = session.getAudioSource().Status;
      return audioStatus !== INVOX.audioStatus.NOT_ACCESS;
    }
    isSessionDisconnected() {
      return INVOX.GetCurrentSession().isDisconnected();
    }
    changeMicrophoneRunning() {
      if (!this.hasMicrophoneAccess()) {
        this.changeMicrophoneDisabled();
        return;
      }
      this._buttonElement.title = `${i18n.getLangResources().MICROPHONE_ACTIONS.LISTENING}: ${INVOX.GetMicrophoneName()}`;
      this._buttonElement.innerHTML = `
            ${'\n        <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-mic-fill invox-bar-icon__mic-on" viewBox="0 0 16 16">\n            <path d="M5 3a3 3 0 0 1 6 0v5a3 3 0 0 1-6 0V3z"/>\n            <path d="M3.5 6.5A.5.5 0 0 1 4 7v1a4 4 0 0 0 8 0V7a.5.5 0 0 1 1 0v1a5 5 0 0 1-4.5 4.975V15h3a.5.5 0 0 1 0 1h-7a.5.5 0 0 1 0-1h3v-2.025A5 5 0 0 1 3 8V7a.5.5 0 0 1 .5-.5z"/>\n        </svg>\n    ' /* MICROPHONE_ON */}
            <span class="invox-bar__microphone-running-effect"></span>
        `;
      this._buttonElement.classList.remove("disabled");
      this._buttonElement.disabled = false;
    }
    changeMicrophonePaused() {
      if (!this.hasMicrophoneAccess() || this.isSessionDisconnected()) {
        this.changeMicrophoneDisabled();
        return;
      }
      this._buttonElement.title = `${i18n.getLangResources().MICROPHONE_ACTIONS.PAUSED}: ${INVOX.GetMicrophoneName()}`;
      this._buttonElement.innerHTML = '\n        <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-mic-fill invox-bar-icon__mic-off" viewBox="0 0 16 16">\n            <path d="M13 8c0 .564-.094 1.107-.266 1.613l-.814-.814A4.02 4.02 0 0 0 12 8V7a.5.5 0 0 1 1 0v1zm-5 4c.818 0 1.578-.245 2.212-.667l.718.719a4.973 4.973 0 0 1-2.43.923V15h3a.5.5 0 0 1 0 1h-7a.5.5 0 0 1 0-1h3v-2.025A5 5 0 0 1 3 8V7a.5.5 0 0 1 1 0v1a4 4 0 0 0 4 4zm3-9v4.879L5.158 2.037A3.001 3.001 0 0 1 11 3z"/>\n            <path d="M9.486 10.607 5 6.12V8a3 3 0 0 0 4.486 2.607zm-7.84-9.253 12 12 .708-.708-12-12-.708.708z"/>\n        </svg>\n    ' /* MICROPHONE_OFF */;
      this._buttonElement.classList.remove("disabled");
      this._buttonElement.disabled = false;
    }
    changeMicrophoneDisabled() {
      this._buttonElement.title = i18n.getLangResources().MICROPHONE_ACTIONS.NOT_ACCESS;
      this._buttonElement.innerHTML = '\n        <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-mic-mute-fill invox-bar-icon__mic-unavailable" viewBox="0 0 16 16">\n            <path d="M13 8c0 .564-.094 1.107-.266 1.613l-.814-.814A4.02 4.02 0 0 0 12 8V7a.5.5 0 0 1 1 0v1zm-5 4c.818 0 1.578-.245 2.212-.667l.718.719a4.973 4.973 0 0 1-2.43.923V15h3a.5.5 0 0 1 0 1h-7a.5.5 0 0 1 0-1h3v-2.025A5 5 0 0 1 3 8V7a.5.5 0 0 1 1 0v1a4 4 0 0 0 4 4zm3-9v4.879L5.158 2.037A3.001 3.001 0 0 1 11 3z"/>\n            <path d="M9.486 10.607 5 6.12V8a3 3 0 0 0 4.486 2.607zm-7.84-9.253 12 12 .708-.708-12-12-.708.708z"/>\n        </svg>\n    ' /* MICROPHONE_DISABLED */;
      this._buttonElement.classList.add("disabled");
      this._buttonElement.disabled = true;
    }
  };

  // libs/integrations/invox-bar/src/components/recognizer/vumeter.ts
  var Vumeter = class extends BaseComponent {
    create() {
      this._innerBarsElement = document.createElement("label");
      this._innerBarsElement.setAttribute("class", "invox-bar__vumeter-bars");
      this._innerBarsElement.innerText = "||||||||||||||||||||||||||||||||";
      const innerBarsCover = document.createElement("div");
      innerBarsCover.setAttribute("class", "invox-bar__vumeter-bars-cover");
      const vumeterElement = document.createElement("div");
      vumeterElement.setAttribute("class", "invox-bar__vumeter-container");
      vumeterElement.appendChild(this._innerBarsElement);
      vumeterElement.appendChild(innerBarsCover);
      this.customizeVumeter(innerBarsCover, vumeterElement);
      return vumeterElement;
    }
    customizeVumeter(barsCoverElement, vumeterElement) {
      INVOX.OnUpdateVumeterMicActivity(function(activity) {
        const percent = `${100 - activity}%`;
        barsCoverElement.style.width = percent;
      });
    }
    setActive() {
      this._innerBarsElement.classList.add("active");
    }
    setInactive() {
      this._innerBarsElement.classList.remove("active");
    }
  };

  // libs/integrations/invox-bar/src/components/recognizer/recognizer.ts
  var Recognizer = class extends BaseComponent {
    create() {
      const recognizerContainerElement = document.createElement("div");
      recognizerContainerElement.setAttribute("class", "invox-bar__recognizer-container");
      this._microphoneButtonElement = new MicrophoneButton();
      this._vumeterElement = new Vumeter();
      recognizerContainerElement.appendChild(this._microphoneButtonElement.create());
      recognizerContainerElement.appendChild(this._vumeterElement.create());
      this.customizeRecognizer();
      return recognizerContainerElement;
    }
    setPaused() {
      this._microphoneButtonElement.changeMicrophonePaused();
      this._vumeterElement.setInactive();
    }
    setRunning() {
      this._microphoneButtonElement.changeMicrophoneRunning();
      this._vumeterElement.setActive();
    }
    setDisabled() {
      this._vumeterElement.setInactive();
      this._microphoneButtonElement.changeMicrophoneDisabled();
    }
    customizeRecognizer() {
      INVOX.OnGrantedAudioSource(() => {
        INVOX.LogInfo("Audio permissions granted");
        this.setPaused();
      });
      INVOX.OnDeniedAudioSource(() => {
        INVOX.LogWarn("Audio permissions denied");
        this.setDisabled();
      });
      INVOX.OnPausedRecognizer(() => {
        INVOX.LogInfo("Dictation paused");
        this.setPaused();
      });
      INVOX.OnRunningRecognizer(() => {
        INVOX.LogInfo("Dictation running...");
        this.setRunning();
      });
      INVOX.OnErrorRecognizer(() => {
        INVOX.LogFatal("An error occurred in the recognizer engine. Dictation is not available");
        this.setDisabled();
      });
    }
  };

  // libs/integrations/invox-bar/src/components/product/productLogo.ts
  var ProductLogo = class extends BaseComponent {
    create() {
      const brandLogoElement = document.createElement("span");
      brandLogoElement.setAttribute("class", "invox-bar__product-brand");
      brandLogoElement.innerHTML = `<label>${INVOX.productName}</label> ${'\n        <svg xmlns="http://www.w3.org/2000/svg" x="0px" y="0px" viewBox="0 0 84.7 84.9" class="invox-dialog-icon__brand">\n            <g>\n                <path d="M49.9,1.8H34.7C16.3,1.8,1.3,16.7,1.3,35.1v15.3c0,18.4,14.9,33.3,33.4,33.3h15.2c18.4,0,33.3-14.9,33.3-33.3V35.1C83.3,16.7,68.3,1.8,49.9,1.8z M68.9,47.7c0,12-9.7,21.7-21.7,21.7h-9.9c-0.9,0-1.8-0.1-2.7-0.2c-3.3,3.3-7.2,5.6-10.6,6.4c2.5-2.2,4.7-4.8,5.9-7.5c-8.4-3-14.4-11-14.4-20.4v-9.9c0-12,9.7-21.7,21.7-21.7h9.9c12,0,21.7,9.7,21.7,21.7V47.7z"/>\n                <path d="M29,45.2v-4.9c0-6,4.8-10.8,10.8-10.8h5c6,0,10.8,4.8,10.8,10.8v4.9c0,6-4.8,10.8-10.8,10.8h-5C33.8,56,29,51.2,29,45.2"/>\n            </g>\n        </svg>\n    ' /* INVOX */}`;
      return brandLogoElement;
    }
  };

  // libs/integrations/invox-bar/src/components/menu/dropdownMenu.ts
  var DropdownMenu = class extends BaseComponent {
    constructor() {
      super();
      this._menuOptionList = [];
    }
    create() {
      const menuElement = this.createMenu();
      const buttonElement = new Button().setIcon('\n        <svg xmlns="http://www.w3.org/2000/svg" x="0px" y="0px" viewBox="0 0 84.7 84.9" class="invox-bar-icon__brand">\n            <g>\n                <path d="M49.9,1.8H34.7C16.3,1.8,1.3,16.7,1.3,35.1v15.3c0,18.4,14.9,33.3,33.4,33.3h15.2c18.4,0,33.3-14.9,33.3-33.3V35.1C83.3,16.7,68.3,1.8,49.9,1.8z M68.9,47.7c0,12-9.7,21.7-21.7,21.7h-9.9c-0.9,0-1.8-0.1-2.7-0.2c-3.3,3.3-7.2,5.6-10.6,6.4c2.5-2.2,4.7-4.8,5.9-7.5c-8.4-3-14.4-11-14.4-20.4v-9.9c0-12,9.7-21.7,21.7-21.7h9.9c12,0,21.7,9.7,21.7,21.7V47.7z"/>\n                <path d="M29,45.2v-4.9c0-6,4.8-10.8,10.8-10.8h5c6,0,10.8,4.8,10.8,10.8v4.9c0,6-4.8,10.8-10.8,10.8h-5C33.8,56,29,51.2,29,45.2"/>\n            </g>\n        </svg>\n    ' /* INVOX */).setCallback(() => this.triggerHoverEffect(buttonElement)).create();
      const dropdownElement = document.createElement("div");
      dropdownElement.setAttribute("class", "invox-bar__dropdown-menu");
      dropdownElement.appendChild(buttonElement);
      dropdownElement.appendChild(menuElement);
      return dropdownElement;
    }
    triggerHoverEffect(menuButtonElement) {
      const mouseoverEvent = new Event("mouseover");
      menuButtonElement.dispatchEvent(mouseoverEvent);
    }
    createMenu() {
      const headerElement = this.createHeader();
      const footerElement = this.createFooter();
      const menuElement = document.createElement("div");
      menuElement.setAttribute("class", "invox-bar__dropdown-menu-content");
      menuElement.appendChild(headerElement);
      this._menuOptionList.forEach((optionElement) => menuElement.appendChild(optionElement));
      menuElement.appendChild(footerElement);
      return menuElement;
    }
    createHeader() {
      const headerElement = document.createElement("div");
      headerElement.setAttribute("class", "invox-bar__dropdown-menu-content-header");
      headerElement.appendChild(new ProductLogo().create());
      return headerElement;
    }
    createFooter() {
      const footerElement = document.createElement("div");
      footerElement.setAttribute("class", "invox-bar__dropdown-menu-content-footer");
      return footerElement;
    }
    createMenuOptionButton(icon, name, callback) {
      const optionElement = document.createElement("button");
      optionElement.setAttribute("class", "invox-bar__dropdown-menu-option");
      optionElement.innerHTML = `${name} ${icon}`;
      this.addEvent(optionElement, "click", callback);
      return optionElement;
    }
    addOption(icon, optionName, callback) {
      const helpButton = this.createMenuOptionButton(icon, optionName, () => callback());
      this._menuOptionList.push(helpButton);
      return this;
    }
  };

  // libs/integrations/invox-bar/src/components/buttons/baseButtonGroup.ts
  var BaseButtonGroup = class extends BaseComponent {
    constructor() {
      super();
      this._buttons = [];
      this.initComponent();
    }
    create() {
      const buttonGroupElement = document.createElement("div");
      buttonGroupElement.setAttribute("class", "invox-bar__button-group");
      this._buttons && this._buttons.forEach((button) => buttonGroupElement.appendChild(button));
      return buttonGroupElement;
    }
    addChild(button) {
      this._buttons.push(button);
    }
    hasAnyButton() {
      return this._buttons && this._buttons.length > 0;
    }
  };

  // libs/integrations/invox-bar/src/components/dialogs/dialogsButtonGroup.ts
  var DialogsButtonGroup = class extends BaseButtonGroup {
    setDictionaryButton(callback) {
      const tooltip = i18n.getLangResources().DICTIONARY_ACTIONS.TITLE;
      const dictionaryButton = this.createButton('\n        <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-journal-bookmark invox-bar-icon__dictionary" viewBox="0 0 16 16">\n            <path fill-rule="evenodd" d="M6 8V1h1v6.117L8.743 6.07a.5.5 0 0 1 .514 0L11 7.117V1h1v7a.5.5 0 0 1-.757.429L9 7.083 6.757 8.43A.5.5 0 0 1 6 8z"/>\n            <path d="M3 0h10a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H3a2 2 0 0 1-2-2v-1h1v1a1 1 0 0 0 1 1h10a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H3a1 1 0 0 0-1 1v1H1V2a2 2 0 0 1 2-2z"/>\n            <path d="M1 5v-.5a.5.5 0 0 1 1 0V5h.5a.5.5 0 0 1 0 1h-2a.5.5 0 0 1 0-1H1zm0 3v-.5a.5.5 0 0 1 1 0V8h.5a.5.5 0 0 1 0 1h-2a.5.5 0 0 1 0-1H1zm0 3v-.5a.5.5 0 0 1 1 0v.5h.5a.5.5 0 0 1 0 1h-2a.5.5 0 0 1 0-1H1z"/>\n        </svg>\n    ' /* DICTIONARY */, tooltip, () => callback());
      this.addChild(dictionaryButton);
    }
    setTemplatesButton(callback) {
      const tooltip = i18n.getLangResources().TEMPLATES_ACTIONS.TITLE;
      const templatesButton = this.createButton('\n        <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-file-medical invox-bar-icon__templates" viewBox="0 0 16 16">\n            <path d="M8.5 4.5a.5.5 0 0 0-1 0v.634l-.549-.317a.5.5 0 1 0-.5.866L7 6l-.549.317a.5.5 0 1 0 .5.866l.549-.317V7.5a.5.5 0 1 0 1 0v-.634l.549.317a.5.5 0 1 0 .5-.866L9 6l.549-.317a.5.5 0 1 0-.5-.866l-.549.317V4.5zM5.5 9a.5.5 0 0 0 0 1h5a.5.5 0 0 0 0-1h-5zm0 2a.5.5 0 0 0 0 1h5a.5.5 0 0 0 0-1h-5z"/>\n            <path d="M2 2a2 2 0 0 1 2-2h8a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H4a2 2 0 0 1-2-2V2zm10-1H4a1 1 0 0 0-1 1v12a1 1 0 0 0 1 1h8a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1z"/>\n        </svg>\n    ' /* TEMPLATES */, tooltip, () => callback());
      this.addChild(templatesButton);
    }
    setTransformationsButton(callback) {
      const tooltip = i18n.getLangResources().TRANSFORMATIONS_ACTIONS.TITLE;
      const transformationsButton = this.createButton('\n        <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-arrow-return-right invox-bar-icon__transformations" viewBox="0 0 16 16">\n            <path fill-rule="evenodd" d="M1.5 1.5A.5.5 0 0 0 1 2v4.8a2.5 2.5 0 0 0 2.5 2.5h9.793l-3.347 3.346a.5.5 0 0 0 .708.708l4.2-4.2a.5.5 0 0 0 0-.708l-4-4a.5.5 0 0 0-.708.708L13.293 8.3H3.5A1.5 1.5 0 0 1 2 6.8V2a.5.5 0 0 0-.5-.5z"/>\n        </svg>\n    ' /* TRANSFORMATIONS */, tooltip, () => callback());
      this.addChild(transformationsButton);
    }
    createButton(icon, tooltip, callback) {
      return new Button().setIcon(icon).setTooltip(tooltip).setCallback(() => callback()).create();
    }
  };

  // libs/integrations/invox-bar/src/components/adaptation-status/adaptationSpinner.ts
  var INVOXAdaptationSpinner = class extends HTMLElement {
    constructor() {
      super();
      this._isAdaptationInProcess = false;
      this._listeners = [];
    }
    static get observedAttributes() {
      return ["on-started-tooltip", "on-finished-tooltip", "on-error-tooltip", "on-rejected-tooltip"];
    }
    setListeners(listeners) {
      this._listeners = listeners;
    }
    connectedCallback() {
      this.render();
    }
    render() {
      this.hidden = true;
      this.innerHTML = `
            <div class="invox-bar__button invox-bar__adaptation-status">
                <span class="invox-loader__spinner">
                    <span class="invox-loader__inner-icon"></span>
                </span>
            </div>
        `;
      INVOX.OnRejectAdaptation((message) => {
        if (this._isAdaptationInProcess) {
          return;
        }
        const feedbackMessage = this.getAttribute("on-rejected-tooltip") || "";
        this._listeners.forEach((element) => {
          element.handleRejectedAdaptation && element.handleRejectedAdaptation(feedbackMessage);
        });
      });
      INVOX.OnStartAdaptation((message) => {
        if (this._isAdaptationInProcess) {
          return;
        }
        const feedbackMessage = this.getAttribute("on-started-tooltip") || "";
        this._listeners.forEach((element) => {
          element.handleStartedAdaptation && element.handleStartedAdaptation(feedbackMessage);
        });
        this._isAdaptationInProcess = true;
        this.setShowAnimation();
        this.title = feedbackMessage;
      });
      INVOX.OnFinishAdaptation((message, adaptationInfo) => {
        const { duration } = adaptationInfo;
        if (duration <= 0) {
          clearTimeout(this._showTimeout);
          this.hideElement();
          this.restartStyles();
          return;
        }
        const feedbackMessage = this.getAttribute("on-finished-tooltip") || "";
        this._listeners.forEach((element) => {
          element.handleFinishedAdaptation && element.handleFinishedAdaptation(feedbackMessage);
        });
        this.title = feedbackMessage;
        this.setFinishedAnimation().then(() => {
          this._isAdaptationInProcess = false;
          this.setHideAnimation();
        });
      });
      INVOX.OnErrorAdaptation((message) => {
        const feedbackMessage = this.getAttribute("on-error-tooltip") || "";
        this._listeners.forEach((element) => {
          element.handleErrorAdaptation && element.handleErrorAdaptation(feedbackMessage);
        });
        this.title = feedbackMessage;
        this.setErrorAnimation().then(() => {
          this._isAdaptationInProcess = false;
          this.setHideAnimation();
        });
      });
    }
    restartStyles() {
      this.title = "";
      const loader = document.querySelector(".invox-loader__spinner");
      loader == null ? void 0 : loader.classList.remove("finished");
      const checkmark = document.querySelector(".invox-loader__inner-icon");
      checkmark == null ? void 0 : checkmark.classList.remove("draw-checkmark");
      const adaptationStatus = document.querySelector(".invox-bar__adaptation-status");
      adaptationStatus == null ? void 0 : adaptationStatus.classList.remove("invox-bar__animation--fadeout");
      adaptationStatus == null ? void 0 : adaptationStatus.classList.remove("finished");
    }
    showElement() {
      this.hidden = false;
    }
    hideElement() {
      this.hidden = true;
    }
    setHideAnimation() {
      this.startHideAnimation().then(() => {
        this.hideElement();
      });
    }
    setShowAnimation() {
      const SECONDS_TO_AVOID_BLINK = 1;
      this._showTimeout = setTimeout(() => {
        this.showElement();
        this.startShowAnimation();
      }, SECONDS_TO_AVOID_BLINK * 1e3);
    }
    startHideAnimation() {
      return new Promise((resolve) => {
        const SECONDS_BEFORE_HIDE_ELEMENT = 2.3;
        const adaptationStatus = document.querySelector(".invox-bar__adaptation-status");
        adaptationStatus == null ? void 0 : adaptationStatus.classList.remove("invox-bar__animation--fadein");
        adaptationStatus == null ? void 0 : adaptationStatus.classList.add("invox-bar__animation--fadeout");
        setTimeout(() => {
          this.restartStyles();
          resolve();
        }, SECONDS_BEFORE_HIDE_ELEMENT * 1e3);
      });
    }
    startShowAnimation() {
      this.classList.add("invox-bar__animation--fadein");
    }
    setFinishedAnimation() {
      return new Promise((resolve) => {
        const SECONDS_TO_KEEP_ANIMATION = 8;
        const adaptationStatus = document.querySelector(".invox-bar__adaptation-status");
        adaptationStatus == null ? void 0 : adaptationStatus.classList.add("finished");
        const loader = document.querySelector(".invox-loader__spinner");
        loader == null ? void 0 : loader.classList.add("finished");
        const checkmark = document.querySelector(".invox-loader__inner-icon");
        checkmark == null ? void 0 : checkmark.classList.add("draw-checkmark");
        setTimeout(() => {
          resolve();
        }, SECONDS_TO_KEEP_ANIMATION * 1e3);
      });
    }
    setErrorAnimation() {
      return new Promise((resolve) => {
        const SECONDS_TO_KEEP_ANIMATION = 8;
        const adaptationStatus = document.querySelector(".invox-bar__adaptation-status");
        adaptationStatus == null ? void 0 : adaptationStatus.classList.add("error");
        const loader = document.querySelector(".invox-loader__spinner");
        loader == null ? void 0 : loader.classList.add("finished");
        const checkmark = document.querySelector(".invox-loader__inner-icon");
        checkmark == null ? void 0 : checkmark.classList.add("draw-exclamation");
        setTimeout(() => {
          resolve();
        }, SECONDS_TO_KEEP_ANIMATION * 1e3);
      });
    }
  };

  // libs/integrations/invox-bar/src/view/views/home.view.ts
  var HomeView = class extends BaseLayerComponent {
    constructor(langResources, viewManager) {
      super(langResources);
      this._viewManager = viewManager;
      this.initComponent();
    }
    initComponent() {
      this.setClass("invox-bar__home-view");
      this.setNextView(() => this._viewManager.printSplashScreenView());
    }
    setDictionaryBuilder(builderCallback) {
      this._dictionaryViewBuilder = builderCallback;
    }
    setTemplatesBuilder(builderCallback) {
      this._templatesViewBuilder = builderCallback;
    }
    setTransformationsBuilder(builderCallback) {
      this._transformationsViewBuilder = builderCallback;
    }
    setAboutViewBuilder(builderCallback) {
      this._aboutViewBuilder = builderCallback;
    }
    setProfileViewBuilder(builderCallback) {
      this._profileViewBuilder = builderCallback;
    }
    createContent() {
      const componentsList = [];
      const recognizer = new Recognizer();
      const statusbar = new Statusbar().setOnErrorCallback(() => recognizer.setDisabled()).setOnMicrophoneConnectedCallback(() => recognizer.setPaused()).setOnMicrophoneDisconnectedCallback(() => recognizer.setDisabled());
      this.buildDictionaryView();
      this.buildTemplatesView();
      this.buildTransformationsView();
      this.buildProfileView();
      this.buildAboutView();
      const dialogButtonsElement = this.createDialogsButtons();
      const adaptationStatusElement = this.createAdaptationStatus([statusbar]);
      const dropdownMenuElement = this.createDropdownMenu();
      componentsList.push(recognizer.create());
      componentsList.push(statusbar.create());
      dialogButtonsElement.hasAnyButton() && componentsList.push(dialogButtonsElement.create());
      componentsList.push(adaptationStatusElement);
      componentsList.push(dropdownMenuElement);
      return componentsList;
    }
    buildDictionaryView() {
      this._dictionaryViewBuilder && (this._dictionaryView = this._dictionaryViewBuilder(this._viewManager.getContainerId()));
    }
    buildTemplatesView() {
      this._templatesViewBuilder && (this._templatesView = this._templatesViewBuilder(this._viewManager.getContainerId()));
    }
    buildTransformationsView() {
      this._transformationsViewBuilder && (this._transformationsView = this._transformationsViewBuilder(this._viewManager.getContainerId()));
    }
    buildProfileView() {
      this._profileViewBuilder && (this._profileView = this._profileViewBuilder(this._viewManager.getContainerId()));
    }
    buildAboutView() {
      this._aboutViewBuilder && (this._aboutView = this._aboutViewBuilder(this._viewManager.getContainerId()));
    }
    createAdaptationStatus(listeners) {
      const langResources = i18n.getLangResources();
      const adaptationStatusElement = document.createElement("invox-adaptation-spinner");
      adaptationStatusElement.setAttribute("on-started-tooltip", langResources.ADAPTATION.STARTED);
      adaptationStatusElement.setAttribute("on-finished-tooltip", langResources.ADAPTATION.FINISHED);
      adaptationStatusElement.setAttribute("on-error-tooltip", langResources.ADAPTATION.ERROR);
      adaptationStatusElement.setAttribute("on-rejected-tooltip", langResources.ADAPTATION.REJECTED);
      adaptationStatusElement.setListeners(listeners);
      return adaptationStatusElement;
    }
    createDialogsButtons() {
      const buttonsGroup = new DialogsButtonGroup();
      this._dictionaryView && buttonsGroup.setDictionaryButton(() => this._dictionaryView.show());
      this._templatesView && buttonsGroup.setTemplatesButton(() => this._templatesView.show());
      this._transformationsView && buttonsGroup.setTransformationsButton(() => this._transformationsView.show());
      return buttonsGroup;
    }
    createDropdownMenu() {
      const langResources = i18n.getLangResources();
      const dropdownMenu = new DropdownMenu();
      if (this._profileView) {
        dropdownMenu.addOption('\n        <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-person-circle invox-bar-icon__profile" viewBox="0 0 16 16">\n            <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0z"/>\n            <path fill-rule="evenodd" d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8zm8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1z"/>\n        </svg>\n    ' /* PROFILE */, langResources.PROFILE_ACTIONS.TITLE, () => this._profileView.show());
      }
      if (this.tryGetUserGuideHelpUrl() !== "") {
        dropdownMenu.addOption('\n        <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-question-circle invox-bar-icon__help" viewBox="0 0 16 16">\n            <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z"/>\n            <path d="M5.255 5.786a.237.237 0 0 0 .241.247h.825c.138 0 .248-.113.266-.25.09-.656.54-1.134 1.342-1.134.686 0 1.314.343 1.314 1.168 0 .635-.374.927-.965 1.371-.673.489-1.206 1.06-1.168 1.987l.003.217a.25.25 0 0 0 .25.246h.811a.25.25 0 0 0 .25-.25v-.105c0-.718.273-.927 1.01-1.486.609-.463 1.244-.977 1.244-2.056 0-1.511-1.276-2.241-2.673-2.241-1.267 0-2.655.59-2.75 2.286zm1.557 5.763c0 .533.425.927 1.01.927.609 0 1.028-.394 1.028-.927 0-.552-.42-.94-1.029-.94-.584 0-1.009.388-1.009.94z"/>\n        </svg>\n    ' /* HELP */, langResources.HELP_ACTIONS.TITLE, () => this.redirectHelpGuide());
      }
      if (INVOX.GetSupportUrl() !== "") {
        dropdownMenu.addOption('\n        <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-headset invox-bar-icon__support" viewBox="0 0 16 16">\n            <path d="M8 1a5 5 0 0 0-5 5v1h1a1 1 0 0 1 1 1v3a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1V6a6 6 0 1 1 12 0v6a2.5 2.5 0 0 1-2.5 2.5H9.366a1 1 0 0 1-.866.5h-1a1 1 0 1 1 0-2h1a1 1 0 0 1 .866.5H11.5A1.5 1.5 0 0 0 13 12h-1a1 1 0 0 1-1-1V8a1 1 0 0 1 1-1h1V6a5 5 0 0 0-5-5z"/>\n        </svg>\n    ' /* SUPPORT */, langResources.SUPPORT_ACTIONS.TITLE, () => this.redirectSupport());
      }
      if (this._aboutView) {
        dropdownMenu.addOption('\n        <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-exclamation-circle invox-bar-icon__about" viewBox="0 0 16 16">\n            <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z"/>\n            <path d="M7.002 11a1 1 0 1 1 2 0 1 1 0 0 1-2 0zM7.1 4.995a.905.905 0 1 1 1.8 0l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 4.995z"/>\n        </svg>\n    ' /* ABOUT */, langResources.ABOUT_ACTIONS.TITLE, () => this._aboutView.show());
      }
      return dropdownMenu.create();
    }
    tryGetUserGuideHelpUrl() {
      try {
        return INVOX.GetUserGuideHelpUrl();
      } catch (error) {
        return "";
      }
    }
    redirectHelpGuide() {
      try {
        INVOX.ShowHelp();
      } catch (error) {
        INVOX.LogError(`Unable to show help. Error: ${error}`);
        INVOX.LogWarn("You can define this behaviour using INVOX.OnShowHelp from the INVOX Medical SDK.");
      }
    }
    redirectSupport() {
      const supportUrl = INVOX.GetSupportUrl();
      window.open(supportUrl, "_blank");
    }
    componentWillUnmount() {
      this._aboutView.remove();
      this._profileView.remove();
      this._dictionaryView.remove();
      this._templatesView.remove();
      this._transformationsView.remove();
    }
  };
  customElements.define("invox-adaptation-spinner", INVOXAdaptationSpinner);

  // libs/integrations/invox-bar/src/view/views/viewContainer.ts
  var ViewContainer = class extends BaseComponent {
    constructor(langResources, viewManager) {
      super(langResources);
      this._viewManager = viewManager;
      this._invoxBarId = "invox-bar-content";
      this._currentView = void 0;
      this._previewsView = void 0;
    }
    getId() {
      return this._invoxBarId;
    }
    create(containerDestinationId) {
      INVOX.LogDebug("Creating INVOX Bar...");
      this.invoxBarElement = document.createElement("div");
      this.invoxBarElement.id = this._invoxBarId;
      this.invoxBarElement.setAttribute("class", "invox-bar__container");
      const containerDestinationElement = DOMUtility.getElement(containerDestinationId);
      containerDestinationElement == null ? void 0 : containerDestinationElement.appendChild(this.invoxBarElement);
      this.componentDidMount();
    }
    remove() {
      DOMUtility.removeElement(this._invoxBarId);
    }
    show() {
      if (!this.invoxBarElement.classList.contains("active")) {
        this.invoxBarElement.classList.add("active");
      }
    }
    hide() {
      if (this.invoxBarElement.classList.contains("active")) {
        this.invoxBarElement.classList.remove("active");
      }
    }
    refresh() {
      if (!this._currentView) {
        return;
      }
      try {
        this.removeContent();
        this._currentView.create(this._invoxBarId);
      } catch (error) {
        INVOX.LogFatal(`An error occurred during view creation. Error: ${error}`);
      }
    }
    nextView() {
      var _a;
      (_a = this._currentView) == null ? void 0 : _a.next();
    }
    setCurrentView(currentView) {
      var _a;
      (_a = this._currentView) == null ? void 0 : _a.destroy();
      this._previewsView = this._currentView;
      this._currentView = currentView;
    }
    componentDidMount() {
    }
    componentWillUnmount() {
    }
    removeContent() {
      DOMUtility.getElement(this._invoxBarId).innerHTML = "";
    }
  };

  // libs/integrations/invox-bar/src/view/views/loading.view.ts
  var LoadingView = class extends BaseLayerComponent {
    constructor(langResources, viewManager) {
      super(langResources);
      this._viewManager = viewManager;
      this.initComponent();
    }
    initComponent() {
      this.setClass("invox-bar__loading-view");
      this.setNextView(() => this._viewManager.printHomeView());
    }
    createContent() {
      this._percentElement = document.createElement("label");
      this._percentElement.setAttribute("class", "invox-bar__progressbar-percent");
      this._percentElement.innerText = "0%";
      this._statusMessageElement = document.createElement("label");
      this._statusMessageElement.setAttribute("class", "invox-bar__progressbar-message");
      this._messageContainerElement = document.createElement("div");
      this._messageContainerElement.setAttribute("class", "invox-bar__progressbar-error");
      this._messageContainerElement.innerHTML = '\n        <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-exclamation-circle-fill invox-bar-icon__error" viewBox="0 0 16 16">\n            <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM8 4a.905.905 0 0 0-.9.995l.35 3.507a.552.552 0 0 0 1.1 0l.35-3.507A.905.905 0 0 0 8 4zm.002 6a1 1 0 1 0 0 2 1 1 0 0 0 0-2z"/>\n        </svg>\n    ' /* ERROR_FILLED */;
      this._messageContainerElement.appendChild(this._statusMessageElement);
      const overlayContentElement = document.createElement("div");
      overlayContentElement.appendChild(this._percentElement);
      overlayContentElement.appendChild(this._messageContainerElement);
      this._progressBarElement = document.createElement("span");
      this._progressBarElement.setAttribute("class", "invox-bar__progressbar-width");
      this.customizeLoading();
      return [overlayContentElement, this._progressBarElement];
    }
    customizeLoading() {
      INVOX.CustomizeComponents(() => {
        INVOX.OnChangeProgressBar((message) => this.updateProgressBar(message));
        INVOX.OnChangeStatusBar((message, type) => this.printStatus(message, type));
        INVOX.OnFinishProgressBar(() => this._viewManager.printNextView());
        INVOX.OnStartedRecognizer(() => INVOX.SetDictationPaused());
      });
    }
    updateProgressBar(message) {
      const percent = +message.Percent <= 100 ? `${+message.Percent}%` : "100%";
      this._percentElement.innerText = percent;
      this._progressBarElement.style.width = percent;
    }
    printStatus(message, type) {
      const tooltip = message;
      if (type === INVOX.StatusMessageTypeEnum.ERROR) {
        INVOX.LogError(`Loading error: ${message}`);
        this.changeStyleToError();
        message = removeBreakLines(message);
      }
      this._statusMessageElement.innerText = message;
      this._statusMessageElement.title = tooltip;
      function removeBreakLines(message2) {
        return message2.replace(/(\r\n|\n)/g, "");
      }
    }
    changeStyleToError() {
      if (!this._messageContainerElement.classList.contains("active")) {
        this._messageContainerElement.classList.add("active");
      }
    }
  };

  // libs/integrations/invox-bar/src/view/views/splashScreen.view.ts
  var SplashScreenView = class extends BaseLayerComponent {
    constructor(langResources, viewManager) {
      super(langResources);
      this._viewManager = viewManager;
      this.initComponent();
    }
    initComponent() {
      this.setClass("invox-bar__splash-screen-view");
      this.setNextView(() => this._viewManager.printLoadingView());
    }
    createContent() {
      return [new ProductLogo().create()];
    }
  };

  // libs/integrations/common/util/moduleUtility.ts
  var ModuleUtility = class {
    static isAnyModuleLoaded() {
      INVOX.LogDebug("Checking dialog modules...");
      return ModuleUtility.isDictionaryModuleLoaded() || ModuleUtility.isTemplateModuleLoaded() || ModuleUtility.isTransformationsModuleLoaded();
    }
    static createDictionaryDialog(containerId) {
      const dictionaryDialogModule = ModuleUtility.getDictionaryModule();
      return dictionaryDialogModule.create(containerId);
    }
    static createTransformationsDialog(containerId) {
      const transformationsDialogModule = ModuleUtility.getTransformationsModule();
      return transformationsDialogModule.create(containerId);
    }
    static createTemplatesDialog(containerId) {
      const templatesDialogModule = ModuleUtility.getTemplatesModule();
      return templatesDialogModule.create(containerId);
    }
    static isDictionaryModuleLoaded() {
      const module = ModuleUtility.getDictionaryModule();
      return ModuleUtility.checkModule(module);
    }
    static isTemplateModuleLoaded() {
      const module = ModuleUtility.getTemplatesModule();
      return ModuleUtility.checkModule(module);
    }
    static isTransformationsModuleLoaded() {
      const module = ModuleUtility.getTransformationsModule();
      return ModuleUtility.checkModule(module);
    }
    static getDictionaryModule() {
      try {
        if (typeof INVOXMDComponent_Dictionary === "undefined" || !INVOXMDComponent_Dictionary) {
          return void 0;
        }
        INVOX.LogDebug("Dictionary module is loaded");
        return INVOXMDComponent_Dictionary;
      } catch (error) {
        INVOX.LogDebug("Dictionary module is not loaded");
        return void 0;
      }
    }
    static getTemplatesModule() {
      try {
        if (typeof INVOXMDComponent_Templates === "undefined" || !INVOXMDComponent_Templates) {
          return void 0;
        }
        INVOX.LogDebug("Templates module is loaded");
        return INVOXMDComponent_Templates;
      } catch (error) {
        INVOX.LogDebug("Templates module is not loaded");
        return void 0;
      }
    }
    static getTransformationsModule() {
      try {
        if (typeof INVOXMDComponent_Transformations === "undefined" || !INVOXMDComponent_Transformations) {
          return void 0;
        }
        INVOX.LogDebug("Transformations module is loaded");
        return INVOXMDComponent_Transformations;
      } catch (error) {
        INVOX.LogDebug("Transformations module is not loaded");
        return void 0;
      }
    }
    static checkModule(module) {
      if (!module) {
        return false;
      }
      if (!(module == null ? void 0 : module.productName) || typeof (module == null ? void 0 : module.productName) !== "string" || !(module == null ? void 0 : module.productName.includes(INVOX.productName))) {
        return false;
      }
      if (!(module == null ? void 0 : module.commit) || typeof (module == null ? void 0 : module.commit) !== "string") {
        return false;
      }
      if (!(module == null ? void 0 : module.version) || typeof (module == null ? void 0 : module.version) !== "string") {
        return false;
      }
      return true;
    }
  };

  // libs/integrations/common/components/baseDialog.ts
  var BaseDialog = class {
    constructor(idCollection, containerId) {
      if (!INVOX || typeof INVOX != "object" || !("version" in INVOX)) {
        throw new Error("The INVOX SDK is undefined. Load INVOX from your index.html.");
      }
      if (!containerId) {
        throw new Error("Container id cannot be null or undefined");
      }
      if (!DOMUtility.existsElement(containerId)) {
        throw new Error(`Container element with id ${containerId} not found`);
      }
      this._idCollection = idCollection;
    }
    show() {
      this._viewManager.show();
    }
    hide() {
      this._viewManager.hide();
    }
  };

  // libs/integrations/invox-bar/src/components/menu/about/view/aboutIdCollection.enum.ts
  var AboutIdCollection = /* @__PURE__ */ ((AboutIdCollection2) => {
    AboutIdCollection2["Dialog"] = "invox-about-dialog";
    AboutIdCollection2["ViewContent"] = "invox-about-view-content";
    return AboutIdCollection2;
  })(AboutIdCollection || {});

  // libs/integrations/common/components/baseViewComponent.ts
  var BaseViewComponent = class extends BaseComponent {
    constructor(langResources) {
      super(langResources);
    }
    create(containerId) {
      const dialogDestinationElement = DOMUtility.getElement(containerId);
      dialogDestinationElement.innerHTML = "";
      const headerElement = this.printHeader();
      const bodyElement = this.printBody();
      const footerElement = this.printFooter();
      dialogDestinationElement && headerElement && dialogDestinationElement.appendChild(headerElement);
      dialogDestinationElement && bodyElement && dialogDestinationElement.appendChild(bodyElement);
      dialogDestinationElement && footerElement && dialogDestinationElement.appendChild(footerElement);
      this.componentDidMount();
    }
    printHeader() {
      return void 0;
    }
    printBody() {
      return void 0;
    }
    printFooter() {
      return void 0;
    }
    componentDidMount() {
    }
  };

  // libs/integrations/invox-bar/src/components/menu/about/view/views/aboutContent.view.ts
  var AboutContentView = class extends BaseViewComponent {
    constructor(langResources, viewManager) {
      super(langResources);
      this._companyName = "Vócali Sistemas Inteligentes SL";
      this._companyPageLink = "https://vocali.net/";
      this._productPageLink = "https://www.invoxmedical.com";
    }
    _CurrentYear() {
      return (/* @__PURE__ */ new Date()).getFullYear();
    }
    createProductLink() {
      const productLinkElement = document.createElement("a");
      productLinkElement.style.alignSelf = "center";
      productLinkElement.href = this._productPageLink;
      productLinkElement.title = this._productPageLink;
      productLinkElement.target = "_blank";
      productLinkElement.innerHTML = '\n        <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 723 768" style="enable-background:new 0 0 723 768;" class="invox-bar-icon__invox-medical" xml:space="preserve">\n            <style type="text/css">\n                .st0{fill:#8FCBB7;}\n                .st1{fill:#83AEDD;}\n                .st2{fill:#FFFFFF;}\n                .st3{fill:url(#SVGID_1_);}\n                .st4{fill:#64605F;}\n            </style>\n            <g>\n                <path class="st0" d="M653.4,190.8c0,97-78.7,175.7-175.7,175.7c-97.1,0-175.7-78.7-175.7-175.7C301.9,93.7,380.6,15,477.6,15C574.7,15,653.4,93.7,653.4,190.8z"/>\n                <path class="st1" d="M653.6,371.6c0,44.6-36.2,80.9-80.8,80.9c-44.6,0-80.8-36.2-80.8-80.9s36.2-80.8,80.8-80.8C617.4,290.7,653.6,326.9,653.6,371.6z"/>\n                <g transform="translate(1 1)">\n                    <path class="st2" d="M502.6,177.4h43.3c5.2,0,8.6-3.5,8.6-8.7c0-5.2-3.4-8.7-8.6-8.7h-43.3c-5.2,0-8.7,3.5-8.7,8.7C494,174,497.4,177.4,502.6,177.4z"/>\n                    <path class="st2" d="M407.4,177.4H468c5.2,0,8.7-3.5,8.7-8.7c0-5.2-3.5-8.7-8.7-8.7h-60.6c-5.2,0-8.7,3.5-8.7,8.7C398.7,174,402.2,177.4,407.4,177.4z"/>\n                    <path class="st2" d="M545.9,203.4h-8.7c-5.2,0-8.6,3.5-8.6,8.6c0,5.2,3.5,8.7,8.6,8.7h8.7c5.2,0,8.6-3.5,8.6-8.7C554.5,206.9,551.1,203.4,545.9,203.4z"/>\n                    <path class="st2" d="M459.3,212.1c0,5.2,3.5,8.6,8.7,8.6h34.6c5.2,0,8.7-3.5,8.7-8.6c0-5.2-3.5-8.7-8.7-8.7H468C462.8,203.4,459.3,206.9,459.3,212.1z"/>\n                    <path class="st2" d="M407.4,220.7h26c5.2,0,8.6-3.5,8.6-8.6c0-5.2-3.5-8.7-8.6-8.7h-26c-5.2,0-8.7,3.5-8.7,8.7C398.7,217.2,402.2,220.7,407.4,220.7z"/>\n                    <path class="st2" d="M545.9,246.7h-26c-5.2,0-8.6,3.5-8.6,8.7c0,5.2,3.5,8.7,8.6,8.7h26c5.2,0,8.6-3.5,8.6-8.7C554.5,250.1,551.1,246.7,545.9,246.7z"/>\n                    <path class="st2" d="M407.4,264h77.9c5.2,0,8.7-3.5,8.7-8.7c0-5.2-3.5-8.7-8.7-8.7h-77.9c-5.2,0-8.7,3.5-8.7,8.7C398.7,260.6,402.2,264,407.4,264z"/>\n                    <path class="st2" d="M398.7,124.1c0,5.2,3.5,8.7,8.7,8.7h26c5.2,0,8.7-3.5,8.7-8.7c0-5.2-3.5-8.7-8.7-8.7h-26C402.2,115.5,398.7,119,398.7,124.1z"/>\n                    <path class="st2" d="M554.6,124.1c0-5.2-3.5-8.7-8.7-8.7H468c-5.2,0-8.7,3.5-8.7,8.7c0,5.2,3.5,8.7,8.7,8.7h77.9C551.1,132.8,554.6,129.3,554.6,124.1z"/>\n                </g>\n                <g>\n                    <g>\n                        <linearGradient id="SVGID_1_" gradientUnits="userSpaceOnUse" x1="4735.5044" y1="-6471.6436" x2="4895.4233" y2="-6663.5464" gradientTransform="matrix(-1 0 0 -1 5002.7773 -6239.2129)">\n                            <stop  offset="0" style="stop-color:#DEDEDE"/>\n                            <stop  offset="1" style="stop-color:#A3A3A3"/>\n                        </linearGradient>\n                        <path class="st3" d="M185.9,454H245c71.7,0,129.7-58.1,129.7-129.7v-59.4c0-71.6-58.1-129.7-129.7-129.7h-59.2c-71.7,0-129.7,58.1-129.7,129.7v59.4C56.1,395.9,114.2,454,185.9,454z M111.9,275.4c0-46.6,37.8-84.3,84.3-84.3h38.5c46.6,0,84.3,37.8,84.3,84.3v38.6c0,46.5-37.8,84.3-84.3,84.3h-38.5c-46.6,0-84.3-37.8-84.3-84.3V275.4z"/>\n                    </g>\n                    <g>\n                        <defs>\n                            <path id="SVGID_2_" d="M111.6,313.9v-38.5c0-46.5,37.7-84.1,84.1-84.1h38.4c46.5,0,84.1,37.7,84.1,84.1v38.5c0,46.5-37.7,84.1-84.1,84.1h-38.4C149.3,398,111.6,360.3,111.6,313.9 M185.4,135.6C114,135.6,56,193.5,56,265v59.2c0,71.5,58,129.5,129.4,129.5h59.1c71.5,0,129.4-58,129.4-129.5V265c0-71.5-58-129.4-129.4-129.4H185.4z"/>\n                        </defs>\n                        <clipPath id="SVGID_3_">\n                            <use xlink:href="#SVGID_2_"  style="overflow:visible;"/>\n                        </clipPath>\n                    </g>\n                    <g>\n                        <defs>\n                            <path id="SVGID_4_" d="M163.8,304.4v-19.3c0-23.3,18.8-42.2,42.1-42.2h19.2c23.2,0,42.1,18.9,42.1,42.2v19.3c0,23.3-18.8,42.3-42.1,42.3h-19.2C182.6,346.7,163.8,327.8,163.8,304.4 M196.2,191c-46.5,0-84.1,37.8-84.1,84.5v38.6c0,36.7,23.3,67.9,55.8,79.6c-4.8,10.6-13.6,20.9-23.2,29.4c13-2.9,28.5-12,41.3-25.1c3.3,0.4,6.8,0.6,10.2,0.6h38.5c46.5,0,84.1-37.8,84.1-84.5v-38.6c0-46.6-37.7-84.5-84.1-84.5H196.2z"/>\n                        </defs>\n                        <use xlink:href="#SVGID_4_"  style="overflow:visible;fill:#6D7CBA;"/>\n                        <clipPath id="SVGID_5_">\n                            <use xlink:href="#SVGID_4_"  style="overflow:visible;"/>\n                        </clipPath>\n                    </g>\n                </g>\n                <g>\n                    <path class="st1" d="M341.3,713.3l-17.8,36h-8.8l-17.7-36v41.5h-14.7v-65.9h19.9l17,36.2l17.1-36.2H356v65.9h-14.7V713.3z"/>\n                    <path class="st1" d="M414.7,747.4c-5.7,5.4-12.4,8.1-20.1,8.1c-7.7,0-14.1-2.4-19.1-7.1c-5-4.7-7.5-11.1-7.5-19.1c0-8,2.6-14.3,7.7-19c5.1-4.7,11.2-7.1,18.1-7.1c7,0,12.9,2.1,17.8,6.3c4.9,4.2,7.3,10,7.3,17.3v7.5h-36.9c0.4,2.8,1.9,5,4.3,6.8c2.4,1.8,5.2,2.6,8.3,2.6c5,0,9.1-1.7,12.3-5L414.7,747.4z M401.2,717.4c-1.9-1.6-4.3-2.5-7.1-2.5c-2.8,0-5.4,0.8-7.7,2.5c-2.3,1.7-3.7,4-4.1,6.9h22.2C404.3,721.3,403.1,719,401.2,717.4z"/>\n                    <path class="st1" d="M449.4,755.5c-6,0-11.3-2.5-16.1-7.6c-4.7-5.1-7.1-11.4-7.1-18.9c0-7.5,2.3-13.7,6.9-18.5c4.6-4.8,10-7.2,16.1-7.2c6.2,0,11.2,2.2,15.1,6.5v-24.9h14.1v69.9h-14.1v-6.7C460.4,753,455.4,755.5,449.4,755.5z M440.5,729.5c0,4.1,1.2,7.4,3.7,10c2.4,2.6,5.3,3.9,8.6,3.9c3.3,0,6-1.3,8.3-3.9c2.3-2.6,3.4-6,3.4-10.1c0-4.1-1.1-7.5-3.4-10.3c-2.3-2.7-5.1-4.1-8.4-4.1c-3.3,0-6.2,1.4-8.6,4.1C441.7,722,440.5,725.4,440.5,729.5z"/>\n                    <path class="st1" d="M493,697.6c-1.6-1.6-2.4-3.6-2.4-5.9c0-2.3,0.8-4.3,2.4-5.9c1.6-1.6,3.6-2.4,5.9-2.4c2.3,0,4.3,0.8,5.9,2.4c1.6,1.6,2.4,3.6,2.4,5.9c0,2.3-0.8,4.3-2.4,5.9c-1.6,1.6-3.6,2.4-5.9,2.4C496.6,700,494.6,699.2,493,697.6z M506,754.8h-14.1v-50.7H506V754.8z"/>\n                    <path class="st1" d="M543.7,743c4.7,0,8.9-2.4,12.7-7.1l8.4,9.4c-6.5,6.8-13.6,10.2-21.2,10.2c-7.6,0-14-2.4-19.3-7.2c-5.2-4.8-7.9-11.1-7.9-18.8s2.7-14.1,8-18.9c5.3-4.9,11.6-7.3,18.9-7.3c3.6,0,7.3,0.8,11.1,2.3c3.7,1.5,7,3.7,9.8,6.7l-7.4,9.6c-1.6-1.9-3.6-3.5-6-4.5c-2.3-1.1-4.7-1.6-7-1.6c-3.7,0-6.9,1.2-9.6,3.6c-2.7,2.4-4,5.8-4,10.1c0,4.3,1.3,7.7,4,10C537,741.8,540.1,743,543.7,743z"/>\n                    <path class="st1" d="M617.3,754.8H604v-6.1c-3.6,4.6-8.2,6.9-13.5,6.9c-5.4,0-9.9-1.6-13.5-4.7c-3.6-3.1-5.5-7.3-5.5-12.4c0-5.2,1.9-9.1,5.7-11.6c3.8-2.6,8.9-3.9,15.5-3.9h10.6v-0.3c0-5.4-2.9-8.1-8.6-8.1c-2.4,0-5,0.5-7.8,1.5c-2.7,1-5,2.2-6.9,3.6l-6.3-9.1c6.7-4.8,14.3-7.3,22.8-7.3c6.2,0,11.2,1.5,15.1,4.6c3.9,3.1,5.8,7.9,5.8,14.6V754.8z M603,735.4V733h-8.9c-5.7,0-8.5,1.8-8.5,5.3c0,1.8,0.7,3.2,2,4.2c1.4,1,3.3,1.5,5.8,1.5c2.5,0,4.7-0.8,6.6-2.3C602.1,740.1,603,738,603,735.4z"/>\n                    <path class="st1" d="M644.3,754.8h-14.1v-69.9h14.1V754.8z"/>\n                </g>\n                <g>\n                    <path class="st4" d="M73.2,511.9h20.9v124H73.2V511.9z"/>\n                    <path class="st4" d="M221.6,511.9h20.9v124h-22.7l-70.3-90.5v90.5h-20.9v-124h20.9l72,92.6V511.9z"/>\n                    <path class="st4" d="M333.5,635.9h-23.4l-49.9-124h23.4l38.2,92.6l38.2-92.6h23.4L333.5,635.9z"/>\n                    <path class="st4" d="M502.8,618.8c-12.5,12.2-28,18.4-46.5,18.4c-18.4,0-33.9-6.1-46.5-18.4C397.3,606.6,391,591.3,391,573c0-18.3,6.3-33.5,18.8-45.8c12.5-12.2,28-18.4,46.5-18.4c18.5,0,34,6.1,46.5,18.4c12.5,12.2,18.8,27.5,18.8,45.8C521.6,591.3,515.3,606.6,502.8,618.8z M487.5,541.2c-8.5-8.8-18.8-13.1-31.1-13.1c-12.3,0-22.7,4.4-31.1,13.1c-8.5,8.8-12.7,19.4-12.7,31.9c0,12.5,4.2,23.1,12.7,31.8c8.5,8.7,18.8,13.1,31.1,13.1c12.3,0,22.7-4.4,31.1-13.1c8.5-8.8,12.7-19.4,12.7-31.8C500.1,560.5,495.9,549.9,487.5,541.2z"/>\n                    <path class="st4" d="M617.1,635.9l-30.5-46.7h-0.9l-30.5,46.7h-26.1l42.6-63.7l-39.6-60.3H558l27.7,41.9h0.9l27.7-41.9h25.9l-39.6,60.3l42.6,63.7H617.1z"/>\n                </g>\n            </g>\n        </svg>\n    ' /* INVOX_MEDICAL */;
      return productLinkElement;
    }
    printBody() {
      const bodyElement = document.createElement("div");
      bodyElement.setAttribute("class", "invox-bar__about-view-body");
      bodyElement.appendChild(this.createProductLink());
      bodyElement.appendChild(this.createProductVersion());
      bodyElement.appendChild(this.createCopyright());
      return bodyElement;
    }
    createProductVersion() {
      const sdkName = "SDK";
      const sdkVersion = INVOX.version;
      const serviceName = this.getServiceName();
      const serviceVersion = this.getServiceVersion();
      const sdkCommit = INVOX.commit;
      const versionsContainerElement = document.createElement("section");
      versionsContainerElement.innerHTML = `
            <small class="invox-bar__about-content-line">
                ${sdkName}
                <strong>${sdkVersion}</strong>
            </small>
            <small class="invox-bar__about-content-line">
                ${serviceName}
                <strong>${serviceVersion}</strong>
            </small>
            <small>${sdkCommit}</small>
        `;
      return versionsContainerElement;
    }
    createCopyright() {
      const copyrightElement = document.createElement("small");
      copyrightElement.setAttribute("class", "invox-bar__about-copyright");
      copyrightElement.innerHTML = `
            <a href="${this._companyPageLink}" title="${this._companyPageLink}" target="_blank">
                ${this._companyName}
            </a>
            &copy; ${this._CurrentYear()} 
        `;
      return copyrightElement;
    }
    getServiceVersion() {
      const currentSession = INVOX.GetCurrentSession();
      return currentSession.UseAgent ? currentSession.AgentVersion : currentSession.SWSVersion;
    }
    getServiceName() {
      const currentSession = INVOX.GetCurrentSession();
      return currentSession.UseAgent ? "Local Dictation Service" : "Remote Dictation Service";
    }
  };

  // libs/integrations/common/components/buttons/baseButton.ts
  var BaseButton = class extends BaseComponent {
    constructor() {
      super();
      this._classList = [];
      this.initComponent();
    }
    setTooltip(tooltip) {
      this._tooltip = tooltip;
      return this;
    }
    setIcon(icon) {
      this._icon = icon;
    }
    setClassList(...classlist) {
      this._classList = this._classList.concat(classlist);
    }
    setLabel(label) {
      this._label = label;
      return this;
    }
    setCallback(callback) {
      this._callback = callback;
      return this;
    }
    create() {
      const element = this.createElement();
      this.addEvent(element, "click", () => this.setBehaviour(element));
      return element;
    }
    createElement() {
      const buttonElement = document.createElement("button");
      if (this._classList && this._classList.length > 0) {
        this._classList.forEach((classElement) => buttonElement.classList.add(classElement));
      }
      this._tooltip && (buttonElement.title = this._tooltip);
      buttonElement.innerHTML = this.createLabel();
      return buttonElement;
    }
    createLabel() {
      let label = "";
      this._icon && (label = this._icon);
      this._label && (label += `<label>${this._label}</label>`);
      return label;
    }
    setBehaviour(element) {
      this._callback();
    }
  };

  // libs/integrations/common/components/buttons/closeIconButton.ts
  var CloseIconButton = class extends BaseButton {
    initComponent() {
      this.setIcon('\n        <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-x-lg invox-dialog-icon__close" viewBox="0 0 16 16">\n            <path d="M2.146 2.854a.5.5 0 1 1 .708-.708L8 7.293l5.146-5.147a.5.5 0 0 1 .708.708L8.707 8l5.147 5.146a.5.5 0 0 1-.708.708L8 8.707l-5.146 5.147a.5.5 0 0 1-.708-.708L7.293 8 2.146 2.854Z"/>\n        </svg>\n    ' /* CLOSE */);
      this.setClassList("invox-base-no-background-button");
    }
  };

  // libs/integrations/common/view/views/basicDialog.view.ts
  var BasicDialogView = class extends BaseViewComponent {
    constructor(langResources, viewManager) {
      super(langResources);
      this._viewManager = viewManager;
      this._dialogId = viewManager.getDialogId();
      this._dialogViewId = viewManager.getDialogViewId();
      this._currentView = void 0;
      this._previousView = void 0;
      this._isResizableDialog = false;
      this.initComponent();
    }
    get _DialogLayerElement() {
      return DOMUtility.getElement(this._dialogId);
    }
    get _DialogElement() {
      const element = this._DialogLayerElement;
      return element == null ? void 0 : element.children["dialog"];
    }
    setCustomClass(extraClass) {
      this._extraClass = extraClass;
    }
    setResizableDialog() {
      this._isResizableDialog = true;
    }
    create(containerId) {
      const dialogElement = document.createElement("aside");
      dialogElement.setAttribute("name", "dialog");
      dialogElement.classList.add("invox-dialog__dialog-container");
      this._extraClass && dialogElement.classList.add(this._extraClass);
      this._isResizableDialog && dialogElement.classList.add("invox-dialog__dialog-container--resizable");
      dialogElement.appendChild(this.printHeader());
      dialogElement.appendChild(this.printBody());
      const dialogLayerElement = document.createElement("div");
      dialogLayerElement.setAttribute("id", this._dialogId);
      dialogLayerElement.setAttribute("class", "invox-dialog__root-layer");
      dialogLayerElement.appendChild(dialogElement);
      const dialogDestinationElement = DOMUtility.getElement(containerId);
      dialogDestinationElement == null ? void 0 : dialogDestinationElement.appendChild(dialogLayerElement);
      this.componentDidMount();
    }
    refresh() {
      if (!this._currentView) {
        return;
      }
      try {
        this._currentView.create(this._dialogViewId);
      } catch (error) {
        INVOX.LogFatal(`An error occurred during view creation. Error: ${error}`);
      }
    }
    setCurrentView(currentView) {
      this._previousView = this._currentView;
      this._currentView = currentView;
    }
    getPreviousView() {
      return this._previousView;
    }
    printHeader() {
      const headerElement = document.createElement("header");
      headerElement.classList.add("invox-dialog__dialog-header");
      headerElement.innerHTML = `
            <div class="invox-dialog__dialog-header-title">
                ${'\n        <svg xmlns="http://www.w3.org/2000/svg" x="0px" y="0px" viewBox="0 0 84.7 84.9" class="invox-dialog-icon__brand">\n            <g>\n                <path d="M49.9,1.8H34.7C16.3,1.8,1.3,16.7,1.3,35.1v15.3c0,18.4,14.9,33.3,33.4,33.3h15.2c18.4,0,33.3-14.9,33.3-33.3V35.1C83.3,16.7,68.3,1.8,49.9,1.8z M68.9,47.7c0,12-9.7,21.7-21.7,21.7h-9.9c-0.9,0-1.8-0.1-2.7-0.2c-3.3,3.3-7.2,5.6-10.6,6.4c2.5-2.2,4.7-4.8,5.9-7.5c-8.4-3-14.4-11-14.4-20.4v-9.9c0-12,9.7-21.7,21.7-21.7h9.9c12,0,21.7,9.7,21.7,21.7V47.7z"/>\n                <path d="M29,45.2v-4.9c0-6,4.8-10.8,10.8-10.8h5c6,0,10.8,4.8,10.8,10.8v4.9c0,6-4.8,10.8-10.8,10.8h-5C33.8,56,29,51.2,29,45.2"/>\n            </g>\n        </svg>\n    ' /* INVOX */}
                <label> ${this._langResources.TITLE} </label>
            </div>
        `;
      const dialogButtons = this.createExtraHeaderButtons();
      dialogButtons.forEach((buttonElement) => headerElement.appendChild(buttonElement));
      const closeDialogButton = new CloseIconButton().setTooltip(this._langResources.CLOSE.TOOLTIP).setCallback(() => this.closeDialog()).create();
      headerElement.appendChild(closeDialogButton);
      return headerElement;
    }
    createExtraHeaderButtons() {
      return [];
    }
    printBody() {
      const mainElement = document.createElement("main");
      mainElement.id = this._dialogViewId;
      mainElement.classList.add("invox-dialog-body-container");
      return mainElement;
    }
    componentDidMount() {
      this._DialogLayerElement.tabIndex = "-1";
      this._DialogLayerElement.focus();
      this.addEvent(this._DialogLayerElement, "keyup", (event) => this.closeDialogByESC(event));
    }
    closeDialogByESC(event) {
      const key = event.key;
      if (key === "Escape") {
        INVOX.LogInfo("Closing dialog by clicking ESC");
        this._viewManager && this._viewManager.hide();
      }
    }
    closeDialog() {
      INVOX.LogInfo("Closing dialog by header button");
      this._viewManager && this._viewManager.hide();
    }
  };

  // libs/integrations/invox-bar/src/components/menu/about/view/aboutViewCreator.ts
  var AboutViewCreator = class {
    get _LangResources() {
      return i18n.getLangResources().ABOUT_ACTIONS;
    }
    createDialog(viewManager) {
      INVOX.LogDebug("Creating About dialog...");
      const dialogElement = new BasicDialogView(this._LangResources, viewManager);
      dialogElement.setCustomClass("invox-bar__about-layer");
      return dialogElement;
    }
    createContent(viewManager) {
      INVOX.LogDebug("Creating About view...");
      return new AboutContentView(this._LangResources, viewManager);
    }
  };

  // libs/integrations/common/view/baseViewManager.ts
  var BaseViewManager = class {
    get _ExistsDialogElement() {
      return DOMUtility.existsElement(this._dialogId);
    }
    get _DialogElement() {
      return DOMUtility.getElement(this._dialogId);
    }
    getDialogId() {
      return this._dialogId;
    }
    getDialogViewId() {
      return this._dialogViewId;
    }
    create() {
      this.printDefaultView();
    }
    show() {
      if (!this._DialogElement.classList.contains("active")) {
        this.refreshCurrentView();
        this._DialogElement.classList.add("active");
        (function lockScroll() {
          document.body.style.position = "sticky";
          document.body.style.overflow = "hidden";
        })();
      }
    }
    hide() {
      if (!this._ExistsDialogElement) {
        INVOX.LogWarning("The dialogue cannot be closed because it does not exist or is already hidden");
        return;
      }
      if (this._DialogElement.classList.contains("active")) {
        this._DialogElement.classList.remove("active");
      }
      (function unlockScroll() {
        document.body.style.position = "";
        document.body.style.overflow = "";
      })();
      this._onCloseDialog && this._onCloseDialog();
    }
    remove() {
      if (!this._ExistsDialogElement) {
        throw new Error("Element cannot be null or undefined");
      }
      this._DialogElement.remove();
    }
    refreshCurrentView() {
      this._dialogElement && this._dialogElement.refresh();
    }
    printDefaultView() {
      throw new Error("Not implemented exception");
    }
    setOnCloseDialog(callback) {
      this._onCloseDialog = callback;
    }
    setView(view) {
      if (!this._ExistsDialogElement) {
        this._dialogElement = this._viewCreator.createDialog(this);
        this._dialogElement.create(this._containerElementId);
      }
      this._dialogElement.setCurrentView(view);
      this._dialogElement.refresh();
    }
  };

  // libs/integrations/invox-bar/src/components/menu/about/view/aboutViewManager.ts
  var AboutViewManager = class extends BaseViewManager {
    constructor(containerElementId) {
      super();
      this._containerElementId = containerElementId;
      this._dialogId = "invox-about-dialog" /* Dialog */;
      this._dialogViewId = "invox-about-view-content" /* ViewContent */;
      this._viewCreator = new AboutViewCreator();
    }
    printDefaultView() {
      this.printContent();
    }
    printContent() {
      const view = this._viewCreator.createContent(this);
      this.setView(view);
    }
  };

  // libs/integrations/invox-bar/src/components/menu/about/main.ts
  var AboutDialog = class extends BaseDialog {
    constructor(containerId) {
      super(AboutIdCollection, containerId);
      this._viewManager = new AboutViewManager(containerId);
      this._viewManager.create();
    }
    static create(containerId) {
      return AboutDialog._instance || (AboutDialog._instance = new AboutDialog(containerId));
    }
    remove() {
      this._viewManager.remove();
      AboutDialog._instance = void 0;
    }
  };

  // libs/integrations/invox-bar/src/components/menu/profile/view/profileIdCollection.enum.ts
  var ProfileIdCollection = /* @__PURE__ */ ((ProfileIdCollection2) => {
    ProfileIdCollection2["Dialog"] = "invox-profile-dialog";
    ProfileIdCollection2["ViewContent"] = "invox-profile-view-content";
    return ProfileIdCollection2;
  })(ProfileIdCollection || {});

  // libs/integrations/invox-bar/src/components/menu/profile/view/views/profileContent.view.ts
  var ProfileContentView = class extends BaseViewComponent {
    constructor(langResources, viewManager) {
      super(langResources);
      const userinfo = INVOX.GetUserInfo();
      this._login = (userinfo == null ? void 0 : userinfo.Login) || "-";
      this._email = (userinfo == null ? void 0 : userinfo.Email) || "-";
      this._fullname = (userinfo == null ? void 0 : userinfo.Name) || "-";
      this._specialty = (userinfo == null ? void 0 : userinfo.Specialty) || "-";
      this._organization = (userinfo == null ? void 0 : userinfo.Organization) || "-";
      this._lastLogin = (userinfo == null ? void 0 : userinfo.LastLogin) || "";
    }
    printBody() {
      const bodyElement = document.createElement("div");
      bodyElement.setAttribute("class", "invox-bar__profile-view-body");
      bodyElement.appendChild(this.createField(this._langResources.LOGIN, this._login));
      bodyElement.appendChild(this.createField(this._langResources.EMAIL, this._email));
      bodyElement.appendChild(this.createField(this._langResources.NAME, this._fullname));
      bodyElement.appendChild(this.createField(this._langResources.SPECIALTY, this._specialty));
      bodyElement.appendChild(this.createField(this._langResources.ORGANIZATION, this._organization));
      bodyElement.appendChild(this.createField(this._langResources.LAST_LOGIN, this.formatLastLogin(this._lastLogin)));
      return bodyElement;
    }
    createField(fieldName, value) {
      const informationContainerElement = document.createElement("div");
      informationContainerElement.setAttribute("class", "invox-bar__profile-field");
      informationContainerElement.innerHTML = `
            <label>
                <small>
                    ${fieldName}
                </small>
            </label>
            <p>${value}</p>
        `;
      return informationContainerElement;
    }
    formatLastLogin(lastLogin) {
      if (lastLogin === "") {
        return "-";
      }
      const options = { year: "numeric", month: "long", day: "numeric", hour: "numeric", minute: "numeric", second: "numeric", timeZoneName: "short" };
      return new Date(lastLogin).toLocaleDateString(INVOX.GetCurrentLang(), options);
    }
  };

  // libs/integrations/invox-bar/src/components/menu/profile/view/profileViewCreator.ts
  var ProfileViewCreator = class {
    get _LangResources() {
      return i18n.getLangResources().PROFILE_ACTIONS;
    }
    createDialog(viewManager) {
      INVOX.LogDebug("Creating Profile dialog...");
      const dialogElement = new BasicDialogView(this._LangResources, viewManager);
      dialogElement.setCustomClass("invox-bar__profile-layer");
      return dialogElement;
    }
    createContent(viewManager) {
      INVOX.LogDebug("Creating Profile view...");
      return new ProfileContentView(this._LangResources, viewManager);
    }
  };

  // libs/integrations/invox-bar/src/components/menu/profile/view/profileViewManager.ts
  var ProfileViewManager = class extends BaseViewManager {
    constructor(containerElementId) {
      super();
      this._containerElementId = containerElementId;
      this._dialogId = "invox-profile-dialog" /* Dialog */;
      this._dialogViewId = "invox-profile-view-content" /* ViewContent */;
      this._viewCreator = new ProfileViewCreator();
    }
    printDefaultView() {
      this.printContent();
    }
    printContent() {
      const view = this._viewCreator.createContent(this);
      this.setView(view);
    }
  };

  // libs/integrations/invox-bar/src/components/menu/profile/main.ts
  var ProfileDialog = class extends BaseDialog {
    constructor(containerId) {
      super(ProfileIdCollection, containerId);
      this._viewManager = new ProfileViewManager(containerId);
      this._viewManager.create();
    }
    static create(containerId) {
      return ProfileDialog._instance || (ProfileDialog._instance = new ProfileDialog(containerId));
    }
    remove() {
      this._viewManager.remove();
      ProfileDialog._instance = void 0;
    }
  };

  // libs/integrations/invox-bar/src/view/viewCreator.ts
  var ViewCreator = class {
    get _LangResources() {
      return i18n.getLangResources().INVOXBAR_ACTIONS;
    }
    createContainer(viewManager) {
      return new ViewContainer(this._LangResources, viewManager);
    }
    createSplashScreenView(viewManager) {
      return new SplashScreenView(this._LangResources, viewManager);
    }
    createLoadingView(viewManager) {
      return new LoadingView(this._LangResources, viewManager);
    }
    createHomeView(viewManager) {
      const homeViewElement = new HomeView(this._LangResources, viewManager);
      if (ModuleUtility.isDictionaryModuleLoaded()) {
        homeViewElement.setDictionaryBuilder(ModuleUtility.createDictionaryDialog);
      }
      if (ModuleUtility.isTemplateModuleLoaded()) {
        homeViewElement.setTemplatesBuilder(ModuleUtility.createTemplatesDialog);
      }
      if (ModuleUtility.isTransformationsModuleLoaded()) {
        homeViewElement.setTransformationsBuilder(ModuleUtility.createTransformationsDialog);
      }
      homeViewElement.setProfileViewBuilder(this.createProfileDialog);
      homeViewElement.setAboutViewBuilder(this.createAboutDialog);
      return homeViewElement;
    }
    createAboutDialog(containerId) {
      try {
        return AboutDialog.create(containerId);
      } catch (error) {
        INVOX.LogError(`Unable to create About dialog. Error: ${error}`);
      }
    }
    createProfileDialog(containerId) {
      try {
        return ProfileDialog.create(containerId);
      } catch (error) {
        INVOX.LogError(`Unable to create Profile dialog. Error: ${error}`);
      }
    }
  };

  // libs/integrations/invox-bar/src/view/viewManager.ts
  var ViewManager = class {
    constructor(containerDestinationId) {
      this._containerDestinationId = containerDestinationId;
      this._viewCreator = new ViewCreator();
    }
    get _ExistsINVOXBarElement() {
      return this._invoxBarElement && DOMUtility.existsElement(this._invoxBarElement.getId());
    }
    getContainerId() {
      return this._invoxBarElement.getId();
    }
    create() {
      this.printSplashScreenView();
    }
    show() {
      this._invoxBarElement.show();
    }
    hide() {
      this._invoxBarElement.hide();
    }
    remove() {
      if (!this._ExistsINVOXBarElement) {
        throw new Error("Element cannot be null or undefined");
      }
      this._invoxBarElement.remove();
    }
    printNextView() {
      this._invoxBarElement.nextView();
    }
    printSplashScreenView() {
      const view = this._viewCreator.createSplashScreenView(this);
      this.setView(view);
      INVOX.LogDebug("Splash Screen view created successfully");
    }
    printLoadingView() {
      const view = this._viewCreator.createLoadingView(this);
      this.setView(view);
      INVOX.LogDebug("Loading view created successfully");
    }
    printHomeView() {
      const view = this._viewCreator.createHomeView(this);
      this.setView(view);
      INVOX.LogDebug("Home view created successfully");
    }
    setView(view) {
      if (!this._ExistsINVOXBarElement) {
        this._invoxBarElement = this._viewCreator.createContainer(this);
        this._invoxBarElement.create(this._containerDestinationId);
      }
      this._invoxBarElement.setCurrentView(view);
      this._invoxBarElement.refresh();
    }
  };

  // libs/integrations/invox-bar/src/main.ts
  var INVOXBarComponent = class {
    constructor(containerId) {
      if (!INVOX || typeof INVOX != "object" || !("version" in INVOX)) {
        throw new Error("The INVOX SDK is undefined. Load INVOX from your index.html.");
      }
      if (!containerId) {
        throw new Error("Destination element id cannot be null or undefined");
      }
      if (!DOMUtility.existsElement(containerId)) {
        throw new Error(`Destination element with id ${containerId} not found`);
      }
      this._viewManager = new ViewManager(containerId);
      this._viewManager.create();
    }
    static create(containerId) {
      return INVOXBarComponent._instance || (INVOXBarComponent._instance = new INVOXBarComponent(containerId));
    }
    show() {
      this._viewManager.show();
    }
    hide() {
      this._viewManager.hide();
    }
    remove() {
      this._viewManager.remove();
      INVOXBarComponent._instance = void 0;
    }
    login(credentials, connectionConfig) {
      this._viewManager.printLoadingView();
      return INVOX.Login(credentials, connectionConfig);
    }
    logout() {
      return new Promise((resolve, reject) => {
        INVOX.Logout().then(() => {
          this._viewManager.printSplashScreenView();
          resolve(true);
        }).catch((error) => {
          reject(error);
        });
      });
    }
  };
  var create = INVOXBarComponent.create;
  return __toCommonJS(public_exports);
})();
