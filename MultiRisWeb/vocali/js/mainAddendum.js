
const IDWriterTargetName1 = 'txtAddendum';

let invoxbar = undefined;


let invoxCKEditor = undefined;

window.addEventListener('load', function (event) {
    InitPageInformation(INVOXBAR_TEXTAREAS_PAGE);

    const loginForm = document.querySelector("invox-login-form");
    loginForm.setAttribute("host", CONFIG.remoteDictationServiceHost);
    loginForm.setAttribute("port", CONFIG.remoteDictationServicePort);
    loginForm.setAttribute("use-remote-service", CONFIG.useRemoteDictationService);
    loginForm.setAttribute("username", CONFIG.defaultLogin);
    loginForm.setAttribute("password", CONFIG.defaultPassword);
    loginForm.onClickLogin = Login;
    loginForm.onClickLogout = Logout;

    invoxbar = INVOXMDComponent_Bar.create("invox-bar");
    invoxbar.show();
   
    invoxCKEditor = new INVOXCKEditor(IDWriterTargetName1, INVOX);
   
    invoxCKEditor.editor.config.height = 150;
        
    EventHandler();
    SwitchLockTargetByFocus();
    document.getElementById("btnLogin").click();    
});

function Login(credentials, connectionConfig) {

    var usuario = GetUserVocali();

    credentials.user = usuario.username;
    credentials.password = usuario.password_vocali;

    connectionConfig.host = "multiris.irad.cl";
    connectionConfig.port = "8443";
    connectionConfig.useDictationService = false;


    return new Promise((resolve, reject) => {
        invoxbar.login(credentials, connectionConfig)
            .catch(e => {
                e && ShowMessage(INVOX.MessageType.ERROR, e);
                ShowLicenseOrAgentInstructions();
                reject(e);
            });
    })
}

function Logout() {
    invoxbar.logout()
}


function EventHandler() {
    document.addEventListener(INVOX.eventTypeReport.LOGIN_ERROR, e => {
        ShowMessage(INVOX.MessageType.ERROR, e.detail);
    });
    document.addEventListener(INVOX.eventTypeReport.LOGIN_SUCCESS, e => {
        const editorInstance = document.getElementById(IDWriterTargetName1)
        ChangeFocusToTextArea(editorInstance);
    });
    document.addEventListener(INVOX.eventTypeReport.NOT_CUSTOMIZED_COMPONENTS, e => {
        ShowMessage(INVOX.MessageType.WARNING, e.detail);
    });
}

function GetUserVocali() {
    var usuario;
    $.ajax({
        type: "GET",
        url: "../Examen/Informar.aspx/ObtenerUsuarioVocali",
        contentType: "application/json; charset=utf-8",       
        datatype: "json",
        async: false,
        success: function (data) {
           
            usuario = data.d;
        },
        error: function () {

        }
    });

    return usuario;
}

