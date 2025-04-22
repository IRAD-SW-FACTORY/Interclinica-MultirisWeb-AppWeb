try {

    CKEDITOR.plugins.setLang('invoxmd_Dictionary', 'es', {


        DICTIONARY_LABEL: 'Diccionario',
        DICTIONARY_DIALOG: {

            DIALOG_TITLE: 'Diccionario',
            EXIT_BUTTON_LABEL: 'Salir',
            EXIT_BUTTON_TOOLTIP: '',

            SELECT_LABEL: 'Palabras del diccionario:',
            SELECT_TOOLTIP: '',
            NAME_LABEL: 'Palabra',
            NAME_TOOLTIP: '',
            PRONUNCIATION_LABEL: 'Pronunciación',
            PRONUNCIATION_TOOLTIP: '',

            ADD_PRONUNCIATION_LABEL: '🎤',
            ADD_PRONUNCIATION_TOOLTIP: 'Añadir pronunciación',

            SHARE_CHECKBOX_LABEL: 'Compartir',
            SHARE_CHECKBOX_TOOLTIP: '',
            NEW_BUTTON_LABEL: 'Nueva',
            NEW_BUTTON_TOOLTIP: '',
            SAVE_BUTTON_LABEL: 'Guardar',
            SAVE_BUTTON_TOOLTIP: '',
            DELETE_BUTTON_LABEL: 'Eliminar',
            DELETE_BUTTON_TOOLTIP: '',

            NEW_WORD_NAME: 'Nueva Palabra',
            NEW_WORD_PRONUNCIATION: '',

            //toast
            ADD_SUCCESS: 'Se ha añadido correctamente la nueva palabra al diccionario.',
            ADD_WARNING: 'Se ha producido un error al intentar añadir la nueva palabra al diccionario. Compruebe que la palabra no tiene espacios.',

            REPLACE_SUCCESS: 'Se ha actualizado correctamente la palabra en el diccionario.',
            REPLACE_WARNING: 'Se ha producido un error y la palabra no se ha podido actualizar. Compruebe que la palabra no tiene espacios.',

            REMOVE_SUCCESS: 'Se ha borrado correctamente la palabra del diccionario.',
            REMOVE_WARNING: 'Se ha producido un error al intentar borrar la palabra del diccionario.'


        }
    });

} catch (err) {
    window.console && window.console.log("[warn] No ha conseguido cargar el fichero de lenguaje para el plugin invoxmd_Dictionary" + err);
}