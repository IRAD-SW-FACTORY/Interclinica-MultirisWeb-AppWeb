CKEDITOR.dialog.add('invoxmd_AboutDialog', function (editor) {

    //IE POLYFILL
    if (!String.format) {
        String.format = function (format) {
            var args = Array.prototype.slice.call(arguments, 1);
            return format.replace(/{(\d+)}/g, function (match, number) {
                return typeof args[number] != 'undefined'
                    ? args[number]
                    : match
                    ;
            });
        };
    }


    function onShowDialog() {
        var yearGeneration = "2020";
        var url = String.format("https://www.{0}.com", invoxmd.PRODUCTNAME.toLowerCase().replace(" ","")); //ESTO ES HARDCODED
        var htmlval = String.format(
            '<h3>'+invoxmd.PRODUCTNAME+' Web Editor</h3>' +
            '<h5>Version: <strong>{0}</strong></h5>' +
            (Invox.GetAgentVersion() && '<h5>'+invoxmd.PRODUCTNAME+' Agent Version: <strong>{1}</strong></h5>') +
            '<h6>Commit: {4}</a></h6>' +
            '<h5>CKEditor Version: <strong>{2}</strong></h5>' +
            '<h6><a href="{5}">{5} </a></h6>' +
            '<h6>© {3} <a href=http://www.vocali.net/> Vócali Sistemas Inteligentes SL</a></h6>'
            , invoxmd.version
            , Invox.GetAgentVersion()
            , CKEDITOR.version
            , yearGeneration
            , invoxmd.commit
            , url
        );
        var document = this.getElement().getDocument();
        var element = document.getById('aboutInvoxDialog');
        if (element) {
            element.setHtml('<div style="white-space: nowrap; height: auto!important;">' + htmlval + '</div>');
        }
        this.getElement().removeClass('cke_reset_all');
    }
    return {

        title: 'Acerca de',
        minWidht: 700,
        minHeight: 0,
        resizable: CKEDITOR.DIALOG_RESIZE_NONE,
        buttons: [],
        contents:
        [
            {
                elements:
                [
                    {
                        type: 'hbox',
                        widths: ["20%", "80%"],
                        children:
                        [
                            {
                                id: 'body',
                                type: 'html',
                                html: '<center><img src="' + CKEDITOR.plugins.getPath('invoxmd_About') + 'dialogs/invox.png" align="center" alt="invox"></center>'
                            },
                            {
                                id: 'body',
                                type: 'html',
                                html: '<span id="aboutInvoxDialog"></span>'
                            }
                        ]
                    }
                ]
            }
        ],

        onShow: onShowDialog
    }
});