try{
CKEDITOR.plugins.setLang('invoxmd_Macro', 'es', {


    MACRO_LABEL: 'Sustituciones',
    MACRO_DIALOG: {

        DIALOG_TITLE: 'Sustituciones',
        EXIT_BUTTON_LABEL: 'Salir',
        EXIT_BUTTON_TOOLTIP: '',

        MACROTAB_TITLE: 'Sustituciones de Texto',

        SELECT_LABEL: 'Sustituciones de texto',
        SELECT_TOOLTIP: '',
        NAME_LABEL: 'Nombre',
        NAME_TOOLTIP: '',
        REPLACEMENT_LABEL: 'Sustitución',
        REPLACEMENT_TOOLTIP: '',
        SHARE_CHECKBOX_LABEL: 'Compartir',
        SHARE_CHECKBOX_TOOLTIP: '',
        NEW_BUTTON_LABEL: 'Nueva sustitución',
        NEW_BUTTON_TOOLTIP: '',
        SAVE_BUTTON_LABEL: 'Guardar',
        SAVE_BUTTON_TOOLTIP: '',
        DELETE_BUTTON_LABEL: 'Eliminar',
        DELETE_BUTTON_TOOLTIP: '',

        NEW_MACRO_NAME: 'Nombre de la sustitución',
        NEW_MACRO_REPLACEMENT: 'Texto a insertar',


        ADD_SUCCESS: 'La sustitución se ha almacenado correctamente',
        ADD_WARNING: 'Se ha producido un error al guardar la sustitución.',

        REPLACE_SUCCESS: 'La sustitución se ha actualizado correctamente.',
        REPLACE_WARNING: 'Se ha producido un error al intentar actualizar la sustitución.',

        REMOVE_SUCCESS: 'Se ha eliminado correctamente la sustitución.',
        REMOVE_WARNING: 'Se ha producido un error al intentar eliminar la sustitución.',


        GMACROTAB_TITLE: 'Sustituciones Globales',
        GSELECT_LABEL: 'Sustituciones globales',
        GSELECT_TOOLTIP: '',
        GNAME_LABEL: 'Nombre',
        GNAME_TOOLTIP: '',
        GREPLACEMENT_LABEL: 'Sustitución',
        GREPLACEMENT_TOOLTIP: ''


    }
});
} catch (err){
    window.console && window.console.log("[warn] No ha conseguido cargar el fichero de lenguaje para el plugin invoxmd_Macro: " + err);
}