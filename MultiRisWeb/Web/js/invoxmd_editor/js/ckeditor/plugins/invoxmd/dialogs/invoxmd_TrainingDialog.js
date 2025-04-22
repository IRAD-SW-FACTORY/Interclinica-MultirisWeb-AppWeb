CKEDITOR.dialog.add("invoxmd_TrainingDialog", function (editor) {
	var currentScope,
		dialog,
		trainerStarted = false,
		i18n = editor.lang.invoxmd.TRAINING_DIALOG,
		wsMsg = invoxmd.wsMessage;

	function exitDialog() {
		if (trainerStarted) {
			enDialogo = false;
			imdSession.Trainer.stop();
			imdSession.Recognizer.start(audioSource);
			imdSession.updateProfile();
			trainerStarted = false;
		}
	}
	return {
		title: i18n.DIALOG_TITLE,
		resizable: CKEDITOR.DIALOG_RESIZE_NONE,
		minHeight: 300,
		minWidth: 500,
		buttons: [
			{
				id: "training-btn-resume",
				type: "button",
				label: i18n.RESUME_BUTTON_LABEL,
				title: i18n.RESUME_BUTTON_TITLE,
				className: "invox-bg-warning",
				onClick: function () {
					var btnPause = dialog.getButton("training-btn-pause");
					jQuery("#" + btnPause.domId).show();
					jQuery("#" + this.domId).hide();
					jQuery(".invox-training-sentences-row").removeClass("invox-bg-disabled");
					imdSession.Trainer.resume();
				},
				onShow: function () {
					jQuery("#" + this.domId).hide();
				},
			},
			{
				id: "training-btn-pause",
				type: "button",
				label: i18n.PAUSE_BUTTON_LABEL,
				title: i18n.PAUSE_BUTTON_TITLE,
				onClick: function () {
					var btnResume = dialog.getButton("training-btn-resume");
					jQuery("#" + btnResume.domId).show();
					jQuery("#" + this.domId).hide();
					jQuery(".invox-training-sentences-row").addClass("invox-bg-disabled");
					imdSession.Trainer.pause();
				},
				onShow: function () {
					jQuery("#" + this.domId).hide();
				},
			},
			{
				id: "training-btn-next",
				type: "button",
				label: i18n.NEXT_BUTTON_LABEL,
				title: i18n.NEXT_BUTTON_TITLE,
				onClick: function () {
					var info = dialog.getContentElement("training-dialog", "training-readme"),
						train = dialog.getContentElement("training-dialog", "training-sentences"),
						btnPause = dialog.getButton("training-btn-pause");
					jQuery("#" + btnPause.domId).show();
					jQuery("#" + train.domId).show();
					jQuery("#" + info.domId).hide();
					jQuery("#" + this.domId).hide();
					trainerStarted = true;
					imdSession.Recognizer.setScope(invoxmd.dictationScope.PAUSED);
					imdSession.Recognizer.stop();
					imdSession.Trainer.start(audioSource);
				},
				onShow: function () {
					jQuery("#" + this.domId).show();
				},
			},
			{
				id: "training-btn-exit",
				type: "button",
				label: i18n.EXIT_BUTTON_LABEL,
				title: i18n.EXIT_BUTTON_TITLE,
				onClick: function () {
					exitDialog();
					dialog.hide();
				},
			},
		],
		contents: [
			{
				id: "training-dialog",

				elements: [
					{
						id: "training-readme",
						type: "html",
						html: "<div>" + i18n.README + "</div>",
						className: "invox-training-readme-container",
					},
					{
						id: "training-sentences",
						type: "vbox",
						children: [
							{
								id: "fraseentrenamiento",
								type: "html",
								html:
									'<div id="invox-training-sentences-container">' +
									"<p class=invox-label>" +
									i18n.LABEL_SENTENCES +
									"</p>" +
									"<div class=invox-progress>" +
									'<div class="invox-progress-bar invox-bg-info"></div>' +
									"</div>" +
									'<div class="invox-vumeter"><div class="invox-vumeter-bar"></div></div>' +
									"<div class=invox-training-sentences-rows></div>" +
									"</div>",
							},
						],
					},
				],
			},
		],

		onCancel: function () {
			exitDialog();
		},
		onShow: function () {
			dialog = CKEDITOR.dialog.getCurrent();
			var INIT_WIDTH_PERCENT = 10;
			enDialogo = true;
			currentScope = imdSession.Recognizer.CurrentScope || invoxmd.dictationScope.PAUSED;
			var info = this.getContentElement("training-dialog", "training-readme"),
				train = this.getContentElement("training-dialog", "training-sentences");
			jQuery("#" + train.domId).hide();
			jQuery("#" + info.domId).show();
			jQuery(".invox-training-sentences-rows").contents().remove();
			var container = jQuery("#invox-training-sentences-container");
			container
				.find(".invox-progress-bar")
				.css("width", INIT_WIDTH_PERCENT + "%")
				.text("0%");
			var getClassSentenceStatus = function (sentenceStatus) {
				var statusclass = "invox-bg-success";
				switch (sentenceStatus) {
					case invoxmd.TrainingSentenceStatus.NONE:
					case invoxmd.TrainingSentenceStatus.RECOGNIZED:
						statusclass = "invox-bg-success";
						break;
					case invoxmd.TrainingSentenceStatus.NOT_RECOGNIZED:
					case invoxmd.TrainingSentenceStatus.IGNORED:
						statusclass = "invox-bg-error";
						break;
				}
				return statusclass;
			};

			imdSession.Trainer.TrainingSentenceEventHandler = function (evt) {
				var sentence = evt.NextSentenceTranscripted;

				if (sentence) {
					var newclass = getClassSentenceStatus(evt.LastSentenceStatus),
						progress = evt.Index / evt.NumSentences,
						progressWidthPercent = progress * (100 - INIT_WIDTH_PERCENT) + INIT_WIDTH_PERCENT;
					container
						.find(".invox-progress-bar")
						.css("width", progressWidthPercent + "%")
						.text(Math.floor(100 * progress) + "%");
					container
						.find(".invox-training-sentences-row")
						.addClass("invox-training-sentences-row-disabled " + newclass)
						.removeClass("invox-bg-primary")
						.fadeOut(3000)
						.not(":eq(0)")
						.remove();
					container
						.find("." + newclass + " > .invox-training-sentences-badge")
						.text(newclass === "invox-bg-success" ? "✔" : "✖");
					var newrow =
						'<div class="invox-training-sentences-row invox-bg-primary">' +
						'<div class="invox-training-sentences-badge"></div>' +
						sentence +
						"</div>";
					jQuery(newrow).hide().prependTo(container.find(".invox-training-sentences-rows")).fadeIn("slow");

					if (evt.TooManyErrors) {
						showTrainingError();
						exitDialog();
						dialog.hide();
					}
				} else {
					container
						.find(".invox-progress-bar")
						.removeClass("invox-bg-info")
						.addClass("invox-bg-success")
						.css("width", "100%")
						.text("100%");
					container
						.find(".invox-bg-primary")
						.removeClass("invox-bg-primary")
						.addClass("invox-bg-success")
						.text(i18n.TRAIN_FINISH);
				}

				function showTrainingError() {
					toastr.error(i18n.TRAINING_MIC_ERROR_MSG, i18n.TRAINING_MIC_ERROR_TITLE);
				}
			};

			imdSession.ActionHandlerTable[wsMsg.TRAINER_SET_TRAINING_SENTENCES] = function (response, session) {
				if (response.ExceptionType == invoxmd.exceptionType.NONE) {
					session.Trainer.play();
				} else {
					window.console.log("[error]: Trainer Set Training Sentences error: ", response);
					toastr["error"]("No se han podido cargar correctamente las frases de entrenamiento.");
				}
			};

			imdSession.ActionHandlerTable[wsMsg.TRAINER_START] = function (response, session) {
				if (response.ExceptionType == invoxmd.exceptionType.NONE) {
					window.console.log("[log]: TRAINER_START_OK");
					session.Trainer.setTrainingSentences(
						CKEDITOR.getUrl("plugins/invoxmd/xml/frasesEntrenamiento.xml")
					);
				} else {
					window.console.log("[error]: Trainer Start error: ", response);
				}
			};

			imdSession.ActionHandlerTable[wsMsg.TRAINER_STOP] = function (response, session) {
				if (response.ExceptionType == invoxmd.exceptionType.NONE) {
					window.console.log("[log]: TRAINER_STOP_OK");
				} else {
					window.console.log("[error]: Trainer Stop error: ", response);
				}
			};
		},
	};
});
