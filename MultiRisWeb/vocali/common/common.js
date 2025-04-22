

//#region UI Effects Management

let ClassWriterTargetFocusDictationOFF = 'invox-focus-textarea'; 
let ClassWriterTargetFocusDictationON = 'invox-focus-dictation-textarea'; 
let ClassWriterTargetFocused = ClassWriterTargetFocusDictationOFF; 

let SetWriterFocusClass = function (_class) {
    ClassWriterTargetFocused = _class;
}

let ChangeWriterColorFocus = function (classToAdd, classToRemove) {
    if (INVOX.GetCurrentSession().State == INVOX.sessionState.DISCONNECTED) {
        return;
    }

    try {
        SetWriterFocusClass(classToAdd);
        let currentWriter = INVOX.GetWriterTarget();
        let id = null;
        if (IsCKEditorWriter(currentWriter)) {
            id = currentWriter.container.getId();
        } else {
            id = currentWriter.id;
        }
        let HTMLWriterTarget = document.getElementById(id);
        HTMLWriterTarget.classList.remove(classToRemove);
        HTMLWriterTarget.classList.add(classToAdd);
    } catch(e) {
        ShowMessage(INVOX.MessageType.ERROR, e);
    }  


    function IsCKEditorWriter(writer) {
        return !(writer.tagName && writer.tagName == "TEXTAREA");
    }
}



let LockClosed = true;
let SwitchLockTargetByFocus = function () {
    LockClosed = !LockClosed;
    (function SwitchLockIcon() {
        let HTMLLockIcon = document.getElementById("invox-lock-icon");
        let HTMLLockButton = document.getElementById("invox-switch-lock-btn");
        let HTMLLockText = document.getElementById("invox-switch-lock-btn-text");

        if (!HTMLLockIcon) {
            return;
        }
        if (LockClosed) {
            //set lock icon
            HTMLLockIcon.classList.remove('bi-unlock-fill');
            HTMLLockIcon.classList.add('bi-lock-fill');
            HTMLLockButton.classList.add('invox-switch-lock-focus-btn');
            HTMLLockButton.title = "When is locked the writer target only writes in the focused area."
            HTMLLockText.innerText = "Locked writer target";
            return;
        }
        // set unlock icon
        HTMLLockIcon.classList.remove('bi-lock-fill');
        HTMLLockIcon.classList.add('bi-unlock-fill');
        HTMLLockButton.classList.remove('invox-switch-lock-focus-btn');
        HTMLLockButton.title = "You can now change the writing focus by clicking on the text areas."
        HTMLLockText.innerText = "Writer target by focus";
    })();
}

//#endregion

//#region Writers Management
const MAX_CHARS = 100;
let CopyToClipboard = function() {
    try {
        let text = INVOX.GetText(),
            slicedText = sliceText(text);
        let writerTarget = INVOX.GetWriterTarget();
        let bodyContent = `<small>From: ${writerTarget.id} </small> <br> <small>Copied: ${slicedText}</small>`;
        navigator.clipboard.writeText(text)
        .then(() => ShowMessage(INVOX.MessageType.SUCCESS, "Copy to clipboard", {body: bodyContent}))
        .catch(() => ShowMessage(INVOX.MessageType.ERROR, "Unable to write to clipboard"));
    } catch(e) {
        ShowMessage(INVOX.MessageType.ERROR, e);
    }

    function sliceText (text) {
        if (text.length > MAX_CHARS + 3) {
            return text.slice(0, 100) + "...";
        }
        return text;
    }
}

let SwitchTextAreas = function () {
    let target1 = document.getElementById(IDWriterTargetName1);
    let target2 = document.getElementById(IDWriterTargetName2);
    if (target1.classList.contains(ClassWriterTargetFocused)) {
        ChangeFocusToTextArea(target2);
    } else {
        ChangeFocusToTextArea(target1);
    }
}

let SwitchCkeditorTextarea = function() {
    try {
        let ckeditor = CKEDITOR.instances[IDWriterTargetName1];
        let textarea = document.getElementById(IDWriterTargetName2);
        if (textarea.classList.contains(ClassWriterTargetFocused)) {
            ChangeFocusToCkeditor(ckeditor);
        } else {
            ChangeFocusToTextArea(textarea);
        }
    } catch(e) {
        ShowMessage(INVOX.MessageType.ERROR, e);
    }  
}

let OnClickCKEditor = function (ckeditor) {
    if (LockClosed) {
        return;
    }
    ChangeFocusToCkeditor(ckeditor);
}

let ChangeFocusToCkeditor = function(ckeditor) {
    try {
        INVOX.SetTextWriter(INVOX_CKEditorv4_TextWriter); //invox-ckeditor-textwriter.js
        INVOX.SetWriterTarget(ckeditor);
        SetWriterTargetFocus(ckeditor.container.getId());
    } catch(e) {
        ShowMessage(INVOX.MessageType.ERROR, e);
    }  
}

let OnClickTextArea = function (id) {
    if (LockClosed) {
        return;
    }
    const editorInstance = document.getElementById(id);
    ChangeFocusToTextArea(editorInstance);
}

let ChangeFocusToTextArea = function(editorInstance) {
    try {
        INVOX.SetTextWriter(INVOX.TextAreaTextWriter);
        INVOX.SetWriterTarget(editorInstance);
        SetWriterTargetFocus(editorInstance.id);
    } catch(e) {
        ShowMessage(INVOX.MessageType.ERROR, e);
    }  
}

let SetWriterTargetFocus = function (id) {
    let list = document.querySelectorAll(`.${ClassWriterTargetFocused}`);
    list.forEach(function (el) {
        el.classList.remove(ClassWriterTargetFocused);
    });
    document.getElementById(id).classList.add(ClassWriterTargetFocused);
}

//#endregion

//#region Show message: error, warning, info, success

let INVOXToast = function () {

    this.DEFAULT_DELAY = 6000;
    this.DEFAULT_AUTOHIDE = true;
    this.container = {}
    let self = this;

    function create(msg, color, icon) {
        let html = createElement();
        setMessageColor(html, color);
        setMessageIcon(html, icon);
        setMessageContent(html, msg);
        return html;

        function createElement(){
            let templateElement = document.querySelector('[invox-toast="stack"]');
            let HTMLToast = templateElement.cloneNode(true);
            HTMLToast.classList.remove('invox-hide');
            HTMLToast.style.backgroundColor = "transparent";
            setCloseButtonAction(HTMLToast);
            return HTMLToast;
    
            function setCloseButtonAction(selfToast) {
                let HTMLCloseBtn = selfToast.getElementsByClassName('btn-close')[0];
                HTMLCloseBtn.onclick = () => remove(selfToast);
            };
        };
        function setMessageColor(selfToast, backgroundColor) {
            let HTMLToastHeader = selfToast.getElementsByClassName('toast-header')[0];
            HTMLToastHeader.style.backgroundColor = backgroundColor;
        };    
        function setMessageIcon(selfToast, icon) {
            let HTMLToastIcon = selfToast.getElementsByClassName('invox-toast-icon')[0];
            HTMLToastIcon.classList.add(icon);
        };
        function setMessageContent (selfToast, msg) {
            let HTMLToastMessage = selfToast.getElementsByClassName('invox-toast-message')[0];
            HTMLToastMessage.innerText = msg;
        };
    }
    function setBody(selfToast, body){
        let HTMLBody = selfToast.getElementsByClassName('toast-body')[0];
        if (HTMLBody) {
            HTMLBody.remove();
        }

        adaptHeader();

        HTMLBodyContainer = createBodyContainer();
        body instanceof HTMLElement ? HTMLBodyContainer.appendChild(body) : HTMLBodyContainer.innerHTML = body;
        selfToast.appendChild(HTMLBodyContainer);

        function createBodyContainer() {
            let HTMLBodyContainer = document.createElement('div');
            HTMLBodyContainer.setAttribute('class', 'toast-body');
            return HTMLBodyContainer;
        }
        function adaptHeader () {
            selfToast.style.backgroundColor = "white";
            let HTMLHeader = selfToast.getElementsByClassName('toast-header')[0];
            HTMLHeader.classList.remove('invox-toast-border-rounded');
        }
    }
    function remove(selfToast) {
        if (self.container[selfToast]) {
            clearTimeout(self.container[selfToast]);
            delete self.container[selfToast];
        }
        selfToast.remove();
    }
    function removeAfter(selfToast, delay) {
        // remove from DOM
        self.container[selfToast] = setTimeout(() => remove(selfToast), delay)
    }
    function show(selfToast, config) {

        config.delay = config.delay || self.DEFAULT_DELAY;
        config.autohide = config.autohide != undefined ? config.autohide : self.DEFAULT_AUTOHIDE;

        let parentContainer = document.getElementById('invox-toast-stack-container');
        parentContainer.append(selfToast);
        let toast = new bootstrap.Toast(selfToast, { autohide: config.autohide, delay: config.delay });
        toast.show();

        if (config.autohide) {
            removeAfter(selfToast, config.delay);
        }
    };

    this.error = function(msg, config = {delay: this.DEFAULT_DELAY, autohide: this.DEFAULT_AUTOHIDE, body: ''}) {
        let html = create(msg, '#ff6060', 'bi-exclamation-octagon');
        config.body && setBody(html, config.body);
        show(html, config);
        console.error(msg);
    };
    this.info = function(msg, config = {delay: this.DEFAULT_DELAY, autohide: this.DEFAULT_AUTOHIDE, body: ''}) {
        let html = create(msg, '#8b9ddd', 'bi-exclamation-circle');
        config.body && setBody(html, config.body);
        show(html, config);
        console.info(msg);
    };
    this.success = function(msg, config = {delay: this.DEFAULT_DELAY, autohide: this.DEFAULT_AUTOHIDE, body: ''}) {
        let html = create(msg, '#66cb80', 'bi-check-circle');
        config.body && setBody(html, config.body);
        show(html, config);
        console.info(msg);
    };
    this.warn = function(msg, config = {delay: this.DEFAULT_DELAY, autohide: this.DEFAULT_AUTOHIDE, body: ''}) {
        let html = create(msg, '#e1be5d', 'bi-exclamation-triangle');
        config.body && setBody(html, config.body);
        show(html, config);
        console.warn(msg);
    };
}

let invoxToast = undefined;
const invoxToastType = {};
let ShowMessage = function(msgType, msg, config = {body: '', autohide: true}) {
    if (!invoxToast || typeof invoxToast != INVOXToast) {
        invoxToast = new INVOXToast();
        invoxToastType[INVOX.MessageType.ERROR] = () => invoxToast.error(msg, {autohide: config.autohide, body: config.body})
        invoxToastType[INVOX.MessageType.INFO] = () => invoxToast.info(msg, {autohide: config.autohide, body: config.body})
        invoxToastType[INVOX.MessageType.SUCCESS] = () => invoxToast.success(msg, {autohide: config.autohide, body: config.body})
        invoxToastType[INVOX.MessageType.WARNING] = () => invoxToast.warn(msg, {autohide: config.autohide, body: config.body})
    }
    invoxToastType[msgType]();
}

//#endregion


//#region Certificate or agent installation

let ShowLicenseOrAgentInstructions = function () {

    let {title, instructions, buttonName, url} = WasConnectedByAgent() ? GetDownloadAgentInstructions() : GetInstallCertificateInstructions();
    let HTMLBody = CreateInstructions(instructions, buttonName, url);

    ShowMessage(INVOX.MessageType.ERROR, title,{ body: HTMLBody, autohide: false});

    function CreateInstructions(instructions, buttonName, url) {
        let HTMLText = document.createElement('small');
        HTMLText.setAttribute('class', 'invox-toast-description');
        HTMLText.innerText = instructions;

        let HTMLButtonLink = document.createElement('button');
        HTMLButtonLink.setAttribute('type', 'button');
        HTMLButtonLink.setAttribute('class', 'btn invox-installation-dependency-btn');
        HTMLButtonLink.innerText = buttonName;
        HTMLButtonLink.onclick = () => window.open(url, '_blank');

        let HTMLBody = document.createElement('div');
        HTMLBody.setAttribute('class', 'd-flex flex-column');
        HTMLBody.appendChild(HTMLText);
        HTMLBody.appendChild(HTMLButtonLink);
        return HTMLBody;
    }
}

let CERTIFICATE_STEPS_BY_NAVIGATOR = {};
CERTIFICATE_STEPS_BY_NAVIGATOR['Chrome'] = "1. Open the link by clicking :BUTTON_NAME:.\n2. Click on Advanced configuration.\n3. Click on Go to ... (not secure).";
CERTIFICATE_STEPS_BY_NAVIGATOR['Firefox'] = "1. Open the link by clicking :BUTTON_NAME:.\n2. Click on Advanced.\n3. Click on Accept the Risk and Continue.";
CERTIFICATE_STEPS_BY_NAVIGATOR['Opera'] = "1. Open the link by clicking :BUTTON_NAME:.\n2. Click on Help me understand.\n3. Click on Go to ... (not secure).";
CERTIFICATE_STEPS_BY_NAVIGATOR['Internet Explorer'] = "1. Open the link by clicking :BUTTON_NAME:.\n2. Click on More information.\n3. Click on Continue on the website (not recommended).";
CERTIFICATE_STEPS_BY_NAVIGATOR['Default'] = "1. Open the link by clicking :BUTTON_NAME:.\n2. Click on Advanced configuration.\n3. Click on Go to ... (not secure).";

let INSTRUCTIONS = {
    DESCRIPTION : "Check that the dictation service is running.\nIf it is not, follow the instructions below for installation:\n\n",
    CERTIFICATE_STEPS: CERTIFICATE_STEPS_BY_NAVIGATOR,
    AGENT_STEPS: "1. Click on :BUTTON_NAME:.\n2. Download and run the installer.\n3. Please, try login again."
};

function WasConnectedByAgent() {
    const loginForm = document.querySelector("invox-login-form");
    return loginForm.getAttribute("use-remote-service") === "false";
}

function GetInstallCertificateInstructions() {

    const loginForm = document.querySelector("invox-login-form");
    let host = loginForm.getAttribute("host"),
        port = loginForm.getAttribute("port");

    let title = "Check " + INVOX.productName + " Certificate";
    let buttonName = "Install " + INVOX.productName + " Certificate";
    let url = `https://${host}:${port}`;
    let instructions = INSTRUCTIONS.DESCRIPTION.replace(':DEPENDENCY_TYPE:', 'certificate');
    let steps = INSTRUCTIONS.CERTIFICATE_STEPS[INVOX.webNavigator];
    instructions += steps != undefined ? steps : INSTRUCTIONS.CERTIFICATE_STEPS['Default'];
    instructions = instructions.replace(':BUTTON_NAME:', buttonName);

    return {title, instructions, buttonName, url};
}

function GetDownloadAgentInstructions() {
    let title = "Unable to connect to Local Dictation Service";
    let buttonName = "Download Local Dictation Service";
    let instructions = INSTRUCTIONS.DESCRIPTION + INSTRUCTIONS.AGENT_STEPS;
    instructions = instructions.replace(':BUTTON_NAME:', buttonName);
    let url = CONFIG?.downloadAgentURL;
    return {title, instructions, buttonName, url};
}

//#endregion