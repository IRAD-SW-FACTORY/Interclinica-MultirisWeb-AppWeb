CKEDITOR.plugins.add('invoxmd_Dictionary',
	{
		lang: 'es',
		init: function (editor) {
			var i18n = editor.lang[this.name];
			editor.addCommand('DictionaryReady', new CKEDITOR.dialogCommand('invoxmd_DictionaryDialog'));
			editor.addCommand('Dictionary', {
				exec: function (editor) {
					if (audioSource.getAccessAllowed())
						editor.execCommand("DictionaryReady");
				}
			});
			editor.ui.addButton(i18n.DICTIONARY_LABEL,
				{
					label: i18n.DICTIONARY_LABEL,
					command: 'Dictionary',
					icon: this.path + 'icons/Dictionary.png',
					toolbar: 'invoxmd_group,4'
				});
			CKEDITOR.dialog.add('invoxmd_DictionaryDialog', this.path + 'dialogs/invoxmd_DictionaryDialog.js');
		}
	});