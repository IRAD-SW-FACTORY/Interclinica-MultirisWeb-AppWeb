// ???????????????????????????????????????????????????????
// audioExamen.js — Gestión de audios de examen
// ???????????????????????????????????????????????????????

var audioExamenState = {
    codExamen: '',
    idInstitucion: 0,
    idRisExamen: 0,
    audios: [],
    indiceActual: -1,
    audioElement: null,
    velocidad: 1.0,
    cargando: false
};

var velocidades = [0.5, 0.75, 1.0, 1.25, 1.5, 2.0];

// ??? 1. INICIALIZACIÓN Y PANEL ???

function abrirPanelAudio(codExamen, idInstitucion, idRisExamen) {
    audioExamenState.codExamen = codExamen;
    audioExamenState.idInstitucion = idInstitucion;
    audioExamenState.idRisExamen = idRisExamen;
    audioExamenState.indiceActual = -1;
    audioExamenState.velocidad = 1.0;

    if (audioExamenState.audioElement) {
        audioExamenState.audioElement.pause();
        audioExamenState.audioElement = null;
    }

    var panel = $('#panelAudio');
    panel.removeClass('minimizado');

    // Mostrar temporalmente fuera de vista para medir su alto real
    panel.css({ top: '-9999px', left: '-9999px' });
    panel.show();

    // Posicionar en esquina inferior derecha, asegurando que quede dentro del viewport
    var panelWidth = panel.outerWidth() || 380;
    var panelHeight = panel.outerHeight() || 200;
    var winW = $(window).width();
    var winH = $(window).height();

    var posLeft = winW - panelWidth - 20;
    var posTop = winH - panelHeight - 20;

    if (posLeft < 0) posLeft = 0;
    if (posTop < 0) posTop = 0;

    panel.css({
        top: posTop + 'px',
        left: posLeft + 'px'
    });

    if (!panel.data('ui-draggable'))
        panel.draggable({ handle: '.audio-panel-header', containment: 'window' });

    cargarListaAudios();
}

function cerrarPanelAudio() {
    if (audioExamenState.audioElement) {
        audioExamenState.audioElement.pause();
        audioExamenState.audioElement.removeAttribute('src');
        audioExamenState.audioElement.load();
        audioExamenState.audioElement = null;
    }
    audioExamenState.indiceActual = -1;
    audioExamenState.audios = [];
    $('#panelAudio').hide();
}

function minimizarPanelAudio() {
    $('#panelAudio').toggleClass('minimizado');
}

// ??? 2. CRUD — Comunicación con AudioExamen.aspx ???

function cargarListaAudios() {
    audioExamenState.cargando = true;
    renderizarLoader();

    $.ajax({
        type: "POST",
        url: "AudioExamen.aspx/ListarAudioExamen",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({
            codExamen: audioExamenState.codExamen,
            idInstitucion: audioExamenState.idInstitucion
        }),
        success: function (arg) {
            audioExamenState.cargando = false;
            if (arg.d.Ejecutado) {
                audioExamenState.audios = arg.d.Data;
                audioExamenState.audios.sort(function (a, b) { return a.id_audio - b.id_audio; });
            } else {
                audioExamenState.audios = [];
            }
            renderizarPanel();
        },
        error: function () {
            audioExamenState.cargando = false;
            audioExamenState.audios = [];
            renderizarPanel();
        }
    });
}

function subirAudio(fileInput) {
    var file = fileInput.files[0];
    if (!file) return;

    var formData = new FormData();
    formData.append("audioFile", file);
    formData.append("codExamen", audioExamenState.codExamen);
    formData.append("idInstitucion", audioExamenState.idInstitucion);
    formData.append("idRisExamen", audioExamenState.idRisExamen);

    audioExamenState.cargando = true;
    renderizarLoader();

    $.ajax({
        type: "POST",
        url: "AudioExamen.aspx",
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {
            var parts = response.split("|");
            var codigo = parts[0];

            if (codigo === "200") {
                cargarListaAudios();
            } else {
                audioExamenState.cargando = false;
                renderizarPanel();
                alert(parts[1] || "Error al subir audio.");
            }
        },
        error: function () {
            audioExamenState.cargando = false;
            renderizarPanel();
            alert("Error de conexión al subir audio.");
        }
    });

    fileInput.value = '';
}

function eliminarAudio(idAudio) {
    if (!confirm("Eliminar este audio?")) return;

    $.ajax({
        type: "POST",
        url: "AudioExamen.aspx/EliminarAudioExamen",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({
            idArchivoAudio: idAudio,
            codExamen: audioExamenState.codExamen,
            idInstitucion: audioExamenState.idInstitucion
        }),
        success: function (arg) {
            if (arg.d.Ejecutado) {
                if (audioExamenState.indiceActual >= 0 &&
                    audioExamenState.audios[audioExamenState.indiceActual] &&
                    audioExamenState.audios[audioExamenState.indiceActual].id_audio === idAudio) {
                    if (audioExamenState.audioElement) {
                        audioExamenState.audioElement.pause();
                        audioExamenState.audioElement = null;
                    }
                    audioExamenState.indiceActual = -1;
                }
                cargarListaAudios();
            } else {
                alert(arg.d.Mensaje || "Error al eliminar audio.");
            }
        },
        error: function () {
            alert("Error de conexión al eliminar audio.");
        }
    });
}

function obtenerYReproducir(indice) {
    if (indice < 0 || indice >= audioExamenState.audios.length) return;

    var audio = audioExamenState.audios[indice];
    audioExamenState.indiceActual = indice;

    if (audioExamenState.audioElement) {
        audioExamenState.audioElement.pause();
        audioExamenState.audioElement.removeAttribute('src');
        audioExamenState.audioElement.load();
        audioExamenState.audioElement = null;
    }

    renderizarPanel();
    renderizarReproductorCargando();

    var src = "AudioStream.ashx?id=" + audio.id_audio +
              "&cod=" + encodeURIComponent(audioExamenState.codExamen) +
              "&inst=" + audioExamenState.idInstitucion;
    crearReproductor(src);
}

// ??? 3. REPRODUCTOR ???

function crearReproductor(src) {
var audioEl = new Audio(src);
audioExamenState.audioElement = audioEl;
audioEl.playbackRate = audioExamenState.velocidad;

audioEl.addEventListener('loadedmetadata', function () {
    renderizarPanel();
});

    audioEl.addEventListener('timeupdate', function () {
        actualizarProgreso();
    });

    audioEl.addEventListener('ended', function () {
        siguienteAudio();
    });

    audioEl.addEventListener('error', function () {
        alert("Error al reproducir audio.");
        renderizarPanel();
    });
}

function toggleReproduccion() {
    var el = audioExamenState.audioElement;
    if (!el) return;

    if (el.paused) el.play();
    else el.pause();

    renderizarBtnPlay();
}

function anteriorAudio() {
    if (audioExamenState.indiceActual > 0)
        obtenerYReproducir(audioExamenState.indiceActual - 1);
}

function siguienteAudio() {
    if (audioExamenState.indiceActual < audioExamenState.audios.length - 1)
        obtenerYReproducir(audioExamenState.indiceActual + 1);
    else {
        if (audioExamenState.audioElement) audioExamenState.audioElement.pause();
        renderizarBtnPlay();
    }
}

function cambiarVelocidad() {
    var idx = velocidades.indexOf(audioExamenState.velocidad);
    idx = (idx + 1) % velocidades.length;
    audioExamenState.velocidad = velocidades[idx];

    if (audioExamenState.audioElement)
        audioExamenState.audioElement.playbackRate = audioExamenState.velocidad;

    $('#audioVelocidad').text(audioExamenState.velocidad + 'x');
}

function cambiarVolumen(valor) {
    if (audioExamenState.audioElement)
        audioExamenState.audioElement.volume = valor;
}

function seekAudio(e) {
    var el = audioExamenState.audioElement;
    if (!el || !el.duration) return;

    var container = $(e.currentTarget);
    var pos = (e.pageX - container.offset().left) / container.width();
    el.currentTime = pos * el.duration;
}

function actualizarProgreso() {
    var el = audioExamenState.audioElement;
    if (!el || !el.duration) return;

    var pct = (el.currentTime / el.duration) * 100;
    $('#audioProgreso').css('width', pct + '%');
    $('#audioTiempoActual').text(formatearDuracion(el.currentTime));
    $('#audioTiempoTotal').text(formatearDuracion(el.duration));
}

function renderizarBtnPlay() {
    var el = audioExamenState.audioElement;
    if (!el) return;
    $('#audioBtnPlay').html(el.paused ? '&#9654;' : '&#10074;&#10074;');
}

// ??? 4. RENDERIZADO UI ???

function renderizarLoader() {
    $('#audioListaContenido').html(
        '<div class="audio-loader">' +
        '<img src="../img/cargando.gif" />Cargando...' +
        '</div>'
    );
    $('#audioReproductor').html('');
}

function renderizarReproductorCargando() {
    $('#audioReproductor').html(
        '<div class="audio-reproductor">' +
        '<div class="audio-loader">' +
        '<img src="../img/cargando.gif" />Cargando audio...' +
        '</div>' +
        '</div>'
    );
}

function renderizarPanel() {
    renderizarListaAudios();

    if (audioExamenState.indiceActual >= 0 && audioExamenState.audioElement)
        renderizarReproductor();
    else
        renderizarReproductorDeshabilitado();

    renderizarContadorUpload();
    ajustarPosicionPanel();
}

function renderizarListaAudios() {
    var audios = audioExamenState.audios;
    var html = '';

    if (audios.length === 0) {
        html = '<div class="audio-lista-vacia">No hay audios para este examen.</div>';
    } else {
        for (var i = 0; i < audios.length; i++) {
            var a = audios[i];
            var activo = i === audioExamenState.indiceActual ? ' activo' : '';
            var icono = i === audioExamenState.indiceActual && audioExamenState.audioElement && !audioExamenState.audioElement.paused ? '&#9654;' : '&#9835;';

            html += '<div class="audio-item' + activo + '" onclick="obtenerYReproducir(' + i + ')">';
            html += '<div class="audio-item-icono">' + icono + '</div>';
            html += '<div class="audio-item-info">';
            html += '<div class="audio-item-nombre" title="' + escapeHtml(a.nombre_original) + '">' + (i + 1) + '. ' + escapeHtml(a.nombre_original) + '</div>';
            html += '<div class="audio-item-meta">' + formatearTamano(a.tamano_bytes) + ' &bull; ' + a.username + ' &bull; ' + a.fecha_creacion + '</div>';
            html += '</div>';
            html += '<button type="button" class="audio-item-eliminar" onclick="event.stopPropagation();eliminarAudio(' + a.id_audio + ')" title="Eliminar">&times;</button>';
            html += '</div>';
        }
    }

    $('#audioListaContenido').html(html);
}

function renderizarReproductor() {
    var a = audioExamenState.audios[audioExamenState.indiceActual];
    if (!a) return;

    var el = audioExamenState.audioElement;
    var playIcon = (el && !el.paused) ? '&#10074;&#10074;' : '&#9654;';
    var vol = el ? el.volume : 1;

    var html = '<div class="audio-reproductor">';
    html += '<div class="audio-reproductor-titulo" title="' + escapeHtml(a.nombre_original) + '">' + escapeHtml(a.nombre_original) + '</div>';
    html += '<div class="audio-barra-progreso-container" onclick="seekAudio(event)">';
    html += '<div class="audio-barra-progreso" id="audioProgreso"></div>';
    html += '</div>';
    html += '<div class="audio-tiempo">';
    html += '<span id="audioTiempoActual">0:00</span>';
    html += '<span id="audioTiempoTotal">0:00</span>';
    html += '</div>';
    html += '<div class="audio-controles">';
    html += '<button type="button" onclick="anteriorAudio()" title="Anterior">&#9198;</button>';
    html += '<button type="button" class="audio-btn-play" id="audioBtnPlay" onclick="toggleReproduccion()">' + playIcon + '</button>';
    html += '<button type="button" onclick="siguienteAudio()" title="Siguiente">&#9197;</button>';
    html += '</div>';
    html += '<div class="audio-controles-secundarios">';
    html += '<button type="button" class="audio-velocidad" id="audioVelocidad" onclick="cambiarVelocidad()" title="Velocidad">' + audioExamenState.velocidad + 'x</button>';
    html += '<div class="audio-volumen-container">';
    html += '<button type="button" onclick="cambiarVolumen(0)">&#128263;</button>';
    html += '<input type="range" class="audio-volumen" min="0" max="1" step="0.05" value="' + vol + '" oninput="cambiarVolumen(parseFloat(this.value))" />';
    html += '<button type="button" onclick="cambiarVolumen(1)">&#128266;</button>';
    html += '</div>';
    html += '</div>';
    html += '</div>';

    $('#audioReproductor').html(html);
}

function renderizarReproductorDeshabilitado() {
    var html = '<div class="audio-reproductor disabled">';
    html += '<div class="audio-reproductor-titulo">Seleccione un audio de la lista</div>';
    html += '<div class="audio-barra-progreso-container">';
    html += '<div class="audio-barra-progreso" id="audioProgreso"></div>';
    html += '</div>';
    html += '<div class="audio-tiempo">';
    html += '<span id="audioTiempoActual">0:00</span>';
    html += '<span id="audioTiempoTotal">0:00</span>';
    html += '</div>';
    html += '<div class="audio-controles">';
    html += '<button type="button" disabled title="Anterior">&#9198;</button>';
    html += '<button type="button" class="audio-btn-play" disabled>&#9654;</button>';
    html += '<button type="button" disabled title="Siguiente">&#9197;</button>';
    html += '</div>';
    html += '<div class="audio-controles-secundarios">';
    html += '<button type="button" class="audio-velocidad" disabled>1x</button>';
    html += '<div class="audio-volumen-container">';
    html += '<button type="button" disabled>&#128263;</button>';
    html += '<input type="range" class="audio-volumen" min="0" max="1" step="0.05" value="1" disabled />';
    html += '<button type="button" disabled>&#128266;</button>';
    html += '</div>';
    html += '</div>';
    html += '</div>';

    $('#audioReproductor').html(html);
}

function renderizarContadorUpload() {
    var count = audioExamenState.audios.length;
    $('#audioContadorUpload').text(count + '/10');
}

// ??? 5. UTILIDADES ???

function ajustarPosicionPanel() {
    var panel = $('#panelAudio');
    if (!panel.is(':visible')) return;

    var winW = $(window).width();
    var winH = $(window).height();
    var panelW = panel.outerWidth();
    var panelH = panel.outerHeight();
    var pos = panel.position();

    var newLeft = pos.left;
    var newTop = pos.top;

    if (newLeft + panelW > winW) newLeft = winW - panelW;
    if (newTop + panelH > winH) newTop = winH - panelH;
    if (newLeft < 0) newLeft = 0;
    if (newTop < 0) newTop = 0;

    if (newLeft !== pos.left || newTop !== pos.top) {
        panel.css({ top: newTop + 'px', left: newLeft + 'px' });
    }
}

function formatearTamano(bytes) {
    if (!bytes || bytes === 0) return '0 B';
    if (bytes < 1024) return bytes + ' B';
    if (bytes < 1048576) return (bytes / 1024).toFixed(1) + ' KB';
    return (bytes / 1048576).toFixed(1) + ' MB';
}

function formatearDuracion(seg) {
    if (!seg || isNaN(seg)) return '0:00';
    var m = Math.floor(seg / 60);
    var s = Math.floor(seg % 60);
    return m + ':' + (s < 10 ? '0' : '') + s;
}

function escapeHtml(text) {
    if (!text) return '';
    return text.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;');
}
