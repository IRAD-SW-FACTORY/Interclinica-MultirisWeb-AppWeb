try {
	CKEDITOR.plugins.setLang("invoxmd", "es", {
		TOGGLE_DICTATION_LABEL: "Inciar/Detener Dictado",
		ACCEPT_TEXT_LABEL: "Aceptar Texto ",
		HELP_LABEL: "Ayuda",
		STATUS_BAR_LABEL: "",
		TRAINING_LABEL: "Entrenamiento",
		ITN_LABEL: "Transformaciones de texto",
		MICCONFIG_LABEL: "Configuración del micrófono",

		STATUS_BAR: {
			CONNECTING: "Conectando con :HOST:",
			LOGIN: "Iniciando sesión para el usuario :USER:",
			NOT_ACCESS: "No se ha encontrado micrófono, habilite uno y recargue la página",
			DOWNLOADING_RESOURCES: "Preparando el reconocimiento de voz...",
			LISTENING: "Escuchando...",
			PAUSED: "El dictado se encuentra pausado",
			PHONETIC_TRANSCRIPTION: "Transcripción fonética",
			CORRECTION: "Corrigiendo",
			SPELLING: "Deletreando...",
			FLASH_WAITING: "Esperando acceso al micrófono web",
			AGENT_WAITING: "Esperando conexión",
			INVALID_CREDENTIALS: "Credenciales de usuario inválidas",
			CONCURRENT_LICENSE: "Número de usuarios concurrentes superado",
			ERROR: "Error de conexión, guarde el texto de la página y refresque pulsando F5",
			RECONECTION: "Sesión en otra ventana. Pulse aquí para reconectar",
			PARTIAL_HYPOTHESIS: ":PARTIAL:",
			ACCEPTED_HYPOTHESIS: ":ACCEPTED:",
			REJECTED_HYPOTHESIS: ":REJECTED:",
			COMMAND_EXECUTED: "Comando: :COMMAND:",
			MACRO: 'Sustitución: ":MACRONAME:"',
			FLASH_ERROR: "Error al cargar el componente Flash, revise los permisos de su navegador",
			SENDING_RESOURCES: "Guardando información de usuario",
			INVALID_SESSION: "Su sesión ha sido invalidada. Pulse aquí para reconectar",
			SUCCESS_SESSION: "Sesión iniciada correctamente. Iniciando reconocimiento de voz.",
			NET_LATENCY_ERROR: "La conexión de red con el servidor es inestable",
			NET_CONNECTION_LOST: "Se ha perdido la conexión con el servicio. Pulse aquí para reconectar",
			RECOGNIZER_ERROR: "Error al iniciar el reconocimiento de voz",
			WEBSOCKET_CLOSED: "No se ha podido conectar con el servicio de dictado",
			LDAP_INVALID_USER: "Error validando su usuario en el Directorio Activo del Centro",
			LDAP_NO_SPECIALTY: "Su especialidad no es válida en el Directorio Activo del Centro",
			LICENSE_NOT_VALID: "La licencia no es válida",
		},
		ITN_DIALOG: {
			VALUE_LABEL: "Texto a reemplazar",
			VALUE_TOOLTIP: "",
			REPLACEMENT_LABEL: "Texto resultado",
			REPLACEMENT_TOOLTIP: "",
			SELECT_LABEL: "Transformaciones",
			SELECT_TOOLTIP: "",

			NEW_BUTTON_LABEL: "Nueva",
			NEW_BUTTON_TOOLTIP: "",
			SAVE_BUTTON_LABEL: "Guardar",
			SAVE_BUTTON_TOOLTIP: "",
			DELETE_BUTTON_LABEL: "Eliminar",
			DELETE_BUTTON_TOOLTIP: "",
			EXIT_BUTTON_LABEL: "Salir",
			EXIT_BUTTON_TOOLTIP: "",

			DIALOG_TITLE: "Transformaciones de texto",

			NEW_ITN_VALUE: "Texto a reemplazar",
			NEW_ITN_REPLACEMENT: "Texto reemplazado",

			ADD_SUCCESS: "",
			ADD_WARNING:
				'No se ha podido añadir la transformación ":PATTERN:" , ya existe ya existe una transformación con el mismo texto a reemplazar',
			REPLACE_SUCCESS: 'Se han guardado los cambios en la transformación ":PATTERN:"',
			REPLACE_WARNING:
				'No se ha podido modificar la transformación ":PATTERN:", ya existe una transformación con el mismo texto a reemplazar',
			REMOVE_SUCCESS: 'Se ha eliminado correctamente la transformación ":PATTERN:"',
			REMOVE_WARNING: 'Ha ocurrido un error al intentar eliminar la transformación ":PATTERN:"',
			INCORRECT_FORMAT:
				'No se permite el uso del carácter reservado contrabarra ("\\") en el campo "Texto a reamplazar".',
		},
		TRAINING_DIALOG: {
			DIALOG_TITLE: "Entrenamiento",
			NEXT_BUTTON_LABEL: "Siguiente",
			NEXT_BUTTON_TITLE: "",
			EXIT_BUTTON_LABEL: "Salir",
			EXIT_BUTTON_TITLE: "",
			RESUME_BUTTON_LABEL: "Reanudar",
			RESUME_BUTTON_TITLE: "",
			PAUSE_BUTTON_LABEL: "Pausar",
			PAUSE_BUTTON_TITLE: "",
			README:
				"<p><strong>" +
				invoxmd.PRODUCTNAME +
				"</strong> aprenderá a escucharle leer en voz alta al equipo.</p>" +
				"<p>A continuación se le mostrará una serie de frases para realizar el entrenamiento.</p>" +
				"<p>Lea cada frase en voz alta, sin pausas y en un tono natural y constante.</p>" +
				"<p>Las indicaciones entre corchetes (por ejemplo [PUNTO]), son signos de puntuación que debe leerse tal cual sin corchetes.</p>" +
				"<p>Cuando acabe de leer una frase, el sistema le presentará la siguiente de forma automática.</p>" +
				"<p>Si esto no ocurre, vuelva a leer la frase de nuevo.</p>" +
				"<p>Para comenzar haga clic en el botón <strong>Siguiente</strong> y lea en voz alta para entrenar:</p>",
			LABEL_SENTENCES: "Lea el texto en voz alta para entrenar",
			TRAIN_FINISH: "Enhorabuena, ha completado correctamente el entrenamiento. Pulse salir.",
			TRAINING_MIC_ERROR_TITLE: "¡El entrenamiento no ha podido completarse con éxito!",
			TRAINING_MIC_ERROR_MSG:
				"<p>El audio no está llegando correctamente</p>" +
				"<p>Por favor, repita la configuración del micrófono y vuelva a realizar el entrenamiento en cóndiciones óptimas.</p>",
		},
		MICCONFIG_DIALOG: {
			DIALOG_TITLE: "Configuración del micrófono",
			LABEL_SENTENCES: "Lea el texto con tono y volumen normal",
			MAX_RETRIES_TITLE: invoxmd.PRODUCTNAME + " no ha podido ajustar el micrófono tras varios intentos.",
			MAX_RETRIES:
				"Por favor, conecte el micrófono a otro puerto USB (pruebe los puertos USB traseros en el caso de ser un equipo de escritorio) y reinicie el ordenador. Si el problema persiste, es necesario que sustituya el micrófono.",
			MAX_RETRIES_WITH_INVALID_MICROPHONE:
				"<p> El micrófono que está utilizando no es compatible con " +
				invoxmd.PRODUCTNAME +
				" y no ha sido posible configurarlo. Es posible que el reconocimiento de voz no funcione de forma óptima</p>" +
				"<p>Puede consultar los micrófonos validados por el equipo de " +
				invoxmd.PRODUCTNAME +
				" en el siguiente enlace: </p>" +
				"<a href=https://www.invoxmedical.com/microfonos >https://www.invoxmedical.com/microfonos</a>",
			REPEAT_TITLE: invoxmd.PRODUCTNAME + " no ha podido ajustar el micrófono",
			REPEAT: "Se procede a repetir la calibración del micrófono",
			README:
				"<p><strong>" +
				invoxmd.PRODUCTNAME +
				"</strong> ajustará el volumen del micrófono a partir de su forma de hablar y el ruido ambiente." +
				"<br><br>A continuación se le mostrará un texto que deberá leer en un tono natural y constante y bajo condiciones ambiente habituales." +
				"<br><br>Haga clic en <strong>Siguiente</strong> para comenzar.</p>",
			NEXT_BUTTON: "Siguiente",
			EXIT_BUTTON: "Salir",
		},
	});
} catch (err) {
	window.console &&
		window.console.log("[warn] No ha conseguido cargar el fichero de lenguaje para el plugin invoxmd: " + err);
}
