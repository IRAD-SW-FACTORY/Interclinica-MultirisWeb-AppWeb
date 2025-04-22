CKEDITOR.plugins.add('invoxmd_Macro',
	{
		lang: 'es',
		init: function (editor) {
			var i18n = editor.lang[this.name];
			editor.addCommand('MacroReady', new CKEDITOR.dialogCommand('invoxmd_MacroDialog'));
			editor.addCommand('Macro', {
				exec: function (editor) {
					if (audioSource.getAccessAllowed())
						editor.execCommand("MacroReady");
				}
			});
			editor.ui.addButton(i18n.MACRO_LABEL,
				{
					label: i18n.MACRO_LABEL,
					command: 'Macro',
					icon: this.path + 'icons/sustituciones.png',
					toolbar: 'invoxmd_group,3'
				});
			CKEDITOR.dialog.add('invoxmd_MacroDialog', this.path + 'dialogs/invoxmd_MacroDialog.js');
		}
	});