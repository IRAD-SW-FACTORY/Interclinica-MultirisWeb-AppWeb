let INVOXHomeScriptPath = (function () {
    var scripts = document.getElementsByTagName("script"),
        thisScript = scripts[scripts.length - 1],
        path = thisScript.src.substring(0, thisScript.src.lastIndexOf('/')) + '/';
    return path;
})();

let HOME = 0;
let INVOXBAR_TEXTAREAS_PAGE = 1;
let COMPONENTS_PAGE = 2;
let INVOXBAR_CKEDITOR4_TEXTAREA_PAGE = 3;
let CKEDITOR4_SINGLE_EDITOR_PAGE = 4;
let CKEDITOR4_TEXTAREA_PAGE = 5;

let Pages = {}
Pages[HOME] = {
    TITLE: INVOX.productName + ' - SDK Integration Examples',
};
Pages[INVOXBAR_TEXTAREAS_PAGE] = {
    TITLE: 'MultiRisWeb',
    SUBTITLE: '',
    DESCRIPTION: '',
    LINK: '',
    CARD_GROUP: 1,
};
Pages[COMPONENTS_PAGE] = {
    TITLE: INVOX.productName + ' Components',
    SUBTITLE: '',
    DESCRIPTION: 'On this page you will find all the ' + INVOX.productName + ' components. You can see how they work and play with them.',
    LINK: './invox-components',
    CARD_GROUP: 1,
};
Pages[INVOXBAR_CKEDITOR4_TEXTAREA_PAGE] = {
    TITLE: INVOX.productName + ' Bar Integration',
    SUBTITLE: 'with CKEditor 4',
    DESCRIPTION: 'On this page you can see how to integrate CKEditor 4 as an alternative text editor and how to change the focus between each write destination.',
    LINK: './invox-bar-textarea_and_ckeditor4',
    CARD_GROUP: 2,
};
Pages[CKEDITOR4_SINGLE_EDITOR_PAGE] = {
    TITLE: INVOX.productName + ' Components into CKEditor 4',
    SUBTITLE: '',
    DESCRIPTION: 'On this page you will find how to integrate all the ' + INVOX.productName + ' components into CKEditor 4.',
    LINK: './invox-ckeditor4',
    CARD_GROUP: 2,
};
Pages[CKEDITOR4_TEXTAREA_PAGE] = {
    TITLE: INVOX.productName + ' Components into CKEditor 4',
    SUBTITLE: 'with another text editor',
    DESCRIPTION: 'On this page you will find all the ' + INVOX.productName + ' components integrated into CKEditor 4 and how to switch the focus between each write destination.',
    LINK: './invox-ckeditor4-multiple_editors',
    CARD_GROUP: 2,
};


let InitHomeInformation = function () {

    (function SetProductNameInHomeCardsTitles() {
        let ids = document.getElementsByClassName('invox-home-group-title');
        for (var i = 0; i < ids.length; i++) {
            ids[i].innerHTML = ids[i].innerHTML.replace(':INVOX_PRODUCTNAME:', INVOX.productName);
        }
    })();

    InitPageInformation(HOME);
    CreatePageReferences();
}

let CreatePageReferences = function() {
    Object.keys(Pages).forEach(function(pagename){
        if (pagename != HOME) {
            let page = Pages[pagename];
            let HTMLHomeContent = document.getElementById('invox-content-group-'+ page.CARD_GROUP);
            let HTMLPageReference = CreateHTMLCard(page.TITLE, page.SUBTITLE, page.DESCRIPTION, page.LINK);
            HTMLHomeContent.appendChild(HTMLPageReference);
        }
    });

    function CreateHTMLCard (title, subtitle, description, link) {
        let HTMLTitle = CreateCardTitle(title + ' ' + subtitle);
        let HTMLSeparator = CreateSeparator();
        let HTMLDescription = CreateCardDescription(description);
    
        let HTMLCardBody = CreateCardBody(HTMLTitle, HTMLSeparator, HTMLDescription);
        let HTMLFooterLink = CreateFooterLink(link);
    
        return CreateCard(HTMLCardBody, HTMLFooterLink);
    
        function CreateCard(body, link) {
            let HTMLCard = document.createElement('div');
            HTMLCard.setAttribute('class', 'card invox-home-card h-100');
            HTMLCard.appendChild(body);
            HTMLCard.appendChild(link);
    
            let HTMLCol = document.createElement('div');
            HTMLCol.setAttribute('class', 'col');
            HTMLCol.appendChild(HTMLCard); 
            return HTMLCol;
        }
    
        function CreateCardTitle(title) {
            let HTMLTitle = document.createElement('h5');
            HTMLTitle.setAttribute('class', 'card-title invox-home-card-title');
            HTMLTitle.innerText = !title.reference ? title : title.text;
            return HTMLTitle;
        }
    
        function CreateSeparator() {
            let HTMLSeparator = document.createElement('hr');
            HTMLSeparator.setAttribute('style', 'background-color: #c6c6c6');
            return HTMLSeparator;
        }
    
        function CreateCardDescription(description) {
            let HTMLDescription = document.createElement('p');
            HTMLDescription.setAttribute('class', 'card-text invox-home-card-description');
            HTMLDescription.innerText = description;
            return HTMLDescription;
        }
    
        function CreateCardBody(title, separator, description) {
            let HTMLCardBody = document.createElement('div');
            HTMLCardBody.setAttribute('class', 'card-body');
            HTMLCardBody.appendChild(title);
            HTMLCardBody.appendChild(separator);
            HTMLCardBody.appendChild(description);
            return HTMLCardBody;
        }
    
        function CreateFooterLink(link) {
    
            let HTMLFooterIcon = document.createElement('i');
            HTMLFooterIcon.setAttribute('class', 'bi bi-arrow-right');
            HTMLFooterIcon.setAttribute('style', 'margin-left: 10px;');
    
            let HTMLFooterLink = document.createElement('a');
            HTMLFooterLink.setAttribute('class', 'card-footer invox-home-link-btn invox-link shadow-none');
            HTMLFooterLink.innerText = 'Open example';
            HTMLFooterLink.href = link;
    
            HTMLFooterLink.appendChild(HTMLFooterIcon);
            return HTMLFooterLink;
        }
    
    }
}

let InitPageInformation = function (pagename){
    (function SetProductNameAndVersion () {
        let HTMLProductVersionID = document.getElementById("invox-product-version");
        let HTMLProductCommitID = document.getElementById("invox-product-commit");
        if (!HTMLProductCommitID || !HTMLProductVersionID || !INVOX) {
            return;
        }
        HTMLProductVersionID.innerText = `v${INVOX.version}`;
        HTMLProductCommitID.innerText = INVOX.commit;
    })();
    (function SetDocumentTitle() {
        let title = Pages[pagename].TITLE;
        if (Pages[pagename].SUBTITLE) {
            title = title + ' ' + Pages[pagename].SUBTITLE;
        }
        document.title = title; 
    })();
    if (pagename === HOME) {
        return;
    }
    (function SetContentMainTitle() {
        let HTMLTitle = document.getElementById('invox-page-title');
        let HTMLSubTitle = document.getElementById('invox-page-subtitle');
        if (!HTMLTitle || !HTMLSubTitle) {
            return;
        }
        HTMLTitle.innerText = Pages[pagename].TITLE;
        HTMLSubTitle.innerText = Pages[pagename].SUBTITLE;
    })();
    (function SetConnectionDefaultValues () {

        let HTMLLoginInput = document.getElementById('invox-user-input');
        let HTMLPasswordInput = document.getElementById('invox-password-input');

        HTMLLoginInput && (HTMLLoginInput.value = CONFIG?.defaultLogin || "");
        HTMLPasswordInput && (HTMLPasswordInput.value = CONFIG?.defaultPassword || "");

        let HTMLHostInput = document.getElementById('invox-host-input');
        let HTMLPortInput = document.getElementById('invox-port-input');
        let HTMLDictationServiceCheckbox = document.getElementById('invox-useDS-check');

        HTMLHostInput && (HTMLHostInput.value = CONFIG?.remoteDictationServiceHost || "localhost");
        HTMLPortInput && (HTMLPortInput.value = CONFIG?.remoteDictationServicePort || 8443);
        HTMLDictationServiceCheckbox && (HTMLDictationServiceCheckbox.checked = CONFIG?.useRemoteDictationService || false);

    })(CONFIG?.remoteDictationServiceHost, CONFIG?.remoteDictationServicePort, CONFIG?.useRemoteDictationService);
}

