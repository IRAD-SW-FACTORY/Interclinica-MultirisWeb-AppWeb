CKEDITOR.plugins.add('invoxmd_Correction',
	{
		init: function (editor) {
			editor.addCommand('Correction', new CKEDITOR.dialogCommand('invoxmd_CorrectionDialog'));
			CKEDITOR.dialog.add('invoxmd_CorrectionDialog', this.path + 'dialogs/invoxmd_CorrectionDialog.js');
		}
	});