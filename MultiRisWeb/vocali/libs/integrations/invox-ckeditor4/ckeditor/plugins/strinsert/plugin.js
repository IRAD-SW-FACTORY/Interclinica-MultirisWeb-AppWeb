CKEDITOR.config.strinsert_strings =	 [
			{'name': '1',  'value': '0.01'},
			{'name': '2',  'value': '0.02'},
			{'name': '3',  'value': '0.03'},
			{'name': '4',  'value': '0.04'},
			{'name': '5',  'value': '0.05'},
			{'name': '6',  'value': '0.06'},
			{'name': '7',  'value': '0.07'},
			{'name': '8',  'value': '0.08'},
			{'name': '9',  'value': '0.09'},
			{'name': '10', 'value': '0.1'},
			{'name': '15', 'value': '0.15'},
			{'name': '20', 'value': '0.2'},
			{'name': '25', 'value': '0.25'},
			{'name': '30', 'value': '0.3'},
			{'name': '35', 'value': '0.35'},
			{'name': '40', 'value': '0.4'},
			{'name': '45', 'value': '0.45'},
			{'name': '50', 'value': '0.5'},
			{'name': '55', 'value': '0.55'},
			{'name': '60', 'value': '0.6'},
			{'name': '65', 'value': '0.65'},
			{'name': '70', 'value': '0.7'},
			{'name': '75', 'value': '0.75'},
			{'name': '80', 'value': '0.8'},
			{'name': '85', 'value': '0.85'},
			{'name': '90', 'value': '0.9'},
			{'name': '95', 'value': '0.95'},
			{'name': '100', 'value': '1'}
			
		];

/**
 * String to use as the button label.
 */
CKEDITOR.config.strinsert_button_label = 'Volumen';

/**
 * String to use as the button title.
 */
CKEDITOR.config.strinsert_button_title = 'Ajuste volumen';

/**
 * String to use as the button voice label.
 */
CKEDITOR.config.strinsert_button_voice = 'Ajuste volumen';

CKEDITOR.plugins.add('strinsert',
{
	requires : ['richcombo'],
	init : function( editor )
	{
		var config = editor.config;

		// Gets the list of insertable strings from the settings.
		var strings = config.strinsert_strings;

		// add the menu to the editor
		editor.ui.addRichCombo('strinsert',
		{
			label: 		config.strinsert_button_label,
			title: 		config.strinsert_button_title,
			voiceLabel: config.strinsert_button_voice,
			toolbar: 'vocaligroup2,2',
			className: 	'cke_format',
			multiSelect:false,
			panel:
			{
				css: [ editor.config.contentsCss, CKEDITOR.skin.getPath('editor') ],
				voiceLabel: editor.lang.panelVoiceLabel
			},

			init: function()
			{
				var lastgroup = '';
				for(var i=0, len=strings.length; i < len; i++)
				{
					string = strings[i];
					// If there is no value, make a group header using the name.
					if (!string.value) {
						this.startGroup( string.name );
					}
					// If we have a value, we have a string insert row.
					else {
						// If no name provided, use the value for the name.
						if (!string.name) {
							string.name = string.value;
						}
						// If no label provided, use the name for the label.
						if (!string.label) {
							string.label = string.name;
						}
						this.add(string.value, string.name, string.label);
					}
				}
			},

			onClick: function( value )
			{
				window.console.log('[log]: AudioSource.setVolume(' + value + ')');
				audioSource.setVolume(value);
			},

		});
	}
});