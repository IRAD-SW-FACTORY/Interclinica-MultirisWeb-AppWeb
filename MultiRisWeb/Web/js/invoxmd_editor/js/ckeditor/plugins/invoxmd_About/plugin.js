CKEDITOR.plugins.add('invoxmd_About',
    {
        init: function (editor) {
            editor.addCommand('About_InvoxMD', new CKEDITOR.dialogCommand('invoxmd_AboutDialog'));
            editor.ui.addButton('About_InvoxMD',
                {
                    label: 'Acerca de',
                    command: 'About_InvoxMD',
                    icon: this.path + 'icons/about.png',
                    toolbar: 'invoxmd_group,10'
                });
            CKEDITOR.dialog.add('invoxmd_AboutDialog', this.path + 'dialogs/invoxmd_AboutDialog.js');
        }
    });