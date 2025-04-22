/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here.
    // For complete reference see:
    // http://docs.ckeditor.com/#!/api/CKEDITOR.config

    config.skin = 'office2013';
    //config.height = '100%';
    config.width = '100%';
    config.resize_minHeight = 150;
    config.resize_minWidth = 150;
    config.resize_dir = 'both';
    config.toolbarCanCollapse = true;
    //config.toolbarStartupExpanded = true;
   // config.removePlugins = 'elementspath'; // Quitamos contenido de la barra de estado.
    config.dialog_noConfirmCancel = true;
    config.enterMode = CKEDITOR.ENTER_P;

    // The toolbar groups arrangement, optimized for two toolbar rows.
    config.toolbarGroups = [
        { name: 'invox-toolbar' },
        '/',
        { name: 'basicstyles', groups: ['basicstyles'] },
        { name: 'list', groups: ['NumberedList', "BulletedList"] },
        { name: 'align', groups: ['JustifyLeft', 'JustifyCenter', 'JustifyRight'] },
        { name: 'styles' },
        { name: 'colors' },
        { name: 'undo' },
        { name: 'insert', groups: ["Table", "HorizontalRule"] },
        { name: 'texttransform' }        
    ];

    // Remove some buttons provided by the standard plugins, which are
    // not needed in the Standard(s) toolbar.
    //config.removeButtons = 'Styles,Format,SpecialChar,Superscript,Subscript';
    config.removeButtons = 'Styles,SpecialChar,Superscript,Subscript';

    // Set the most common block elements.
    config.format_tags = 'p;h1;h2;h3;pre';

    // Simplify the dialog windows.
    config.removeDialogTabs = 'image:advanced;link:advanced';
    config.invoxRunningBlinkingColor = 'red';
};
