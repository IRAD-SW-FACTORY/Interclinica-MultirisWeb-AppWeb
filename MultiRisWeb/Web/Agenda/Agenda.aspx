<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Control/Master.Master" AutoEventWireup="true" CodeBehind="Agenda.aspx.cs" Inherits="MultiRisWeb.Web.Agenda.Agenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Amis</title>
    <link rel="icon" type="image/png" href="./images/favicon.png">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css"
        integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="https://uicdn.toast.com/tui.time-picker/latest/tui-time-picker.css">
    <link rel="stylesheet" type="text/css" href="https://uicdn.toast.com/tui.date-picker/latest/tui-date-picker.css">
    <link rel="stylesheet" type="text/css" href="dist/tui-calendar.css">
    <link rel="stylesheet" href="./css/multiselect/jquery.multiselect.css">
    <link rel="stylesheet" type="text/css" href="css/default.css">
    <link rel="stylesheet" type="text/css" href="css/icons.css">
    <link id="linkstyle" rel="stylesheet" type="text/css" href="./css/style.css">
    <script src="http://yui.yahooapis.com/3.18.1/build/yui/yui-min.js"></script>
    <style>
        .nav-agenda {
            background-color: #f39555 !important;
        }
    </style>

    <style>
        .yui3-button {
            margin: 10px 0px 10px 0px;
            color: #fff;
            background-color: #3476b7;
        }

        .yui3-skin-sam .yui3-calendarnav-prevmonth {
            border-right-color: white !important;
        }

        .yui3-skin-sam .yui3-calendarnav-nextmonth {
            border-left-color: white !important;
        }

        .yui3-skin-sam .yui3-calendar-day,
        .yui3-skin-sam .yui3-calendar-prevmonth-day,
        .yui3-skin-sam .yui3-calendar-nextmonth-day {
            padding: 5px;
            border: 1px solid #ccc;
            background: #F39555 !important;
            text-align: center;
        }

        .yui3-skin-sam .yui3-calendar-prevmonth-day,
        .yui3-skin-sam .yui3-calendar-nextmonth-day {
            color: white !important;
        }

        .btn, .btn-formulario{
            border-radius: 4px 4px 4px 4px;
        }

        .findInList{
            visibility:hidden;
        }

        .bg-dark{
            background-color: #404848 !important
        }
    </style>
    <script type="text/javascript">
        YUI().use('calendar', 'datatype-date', 'cssbutton', function (Y) {
            var calendar = new Y.Calendar({
                contentBox: "#mycalendar",
                width: '340px',
                showPrevMonth: true,
                showNextMonth: true,
                date: new Date(),
                startDayOfWeek: 1
            }).render();

            var dtdate = Y.DataType.Date;

            calendar.on("selectionChange", function (ev) {

                var newDate = ev.newSelection[0];

                Y.one("#selecteddate").setHTML(dtdate.format(newDate));
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col" style="background-color: #4F5355; max-width: 16%; min-width: 220px; height: 100%;">
            <div id="filtros" style="margin-left: 10%;">
                <!-- FILTROS -->
                <div id="menu" style="padding-left: 0px; margin-top: 40px;">

                    <div id="demo" class="yui3-skin-sam yui3-g" style="width: 165% !important">
                        <div id="leftcolumn" class="yui3-u">
                            <div id="mycalendar" style="width: 68%; background: #F39555; color: white"></div>
                        </div>
                        <div id="rightcolumn" class="yui3-u">
                            <div id="links" style="padding-left: 20px;">
                            </div>
                        </div>
                    </div>
                    <span style="display: none;" id="renderRange" class="render-range"></span>
                </div>
                <a class="accordion" data-toggle="collapse" href="#multiCollapseExample1" role="button"
                    aria-expanded="false" aria-controls="multiCollapseExample1">TIPO AGENDA</a>
                <div class="col">
                    <select name="selecttipo_agenda" id="selecttipo_agenda" style="width: 95% !important;"
                        multiple="multiple" size="5">
                        <option value="a1">Médica</option>
                        <option value="a2">Radiológica</option>
                    </select>
                </div>

                <a class="accordion" data-toggle="collapse" href="#multiCollapseExample1" role="button"
                    aria-expanded="false" aria-controls="multiCollapseExample1">ESTADO AGENDA</a>
                <div class="col">
                    <form>
                        <select name="selectestado_agenda" id="selectestado_agenda" style="width: 95%;"
                            multiple="multiple" size="5">
                            <!-- <optgroup label="Tipo Agenda"></optgroup> -->
                            <option value="a1">Nuevo</option>
                            <option value="a2">En Proceso</option>
                            <option value="a1">Pagado</option>
                            <option value="a2">Finalizado</option>
                            <option value="a1">Anulado</option>
                            <!-- </optgroup> -->
                        </select>
                    </form>
                </div>


                <a class="accordion" data-toggle="collapse" href="#multiCollapseExample2" role="button"
                    aria-expanded="false" aria-controls="multiCollapseExample1">MODALIDAD</a>
                <div class="col">
                    <form>
                        <select name="selectModalidad" id="selectModalidad" style="width: 95%;" multiple="multiple"
                            size="7">

                            <option value="cr">CR</option>
                            <option value="ct">CT</option>
                            <option value="dx">DX</option>
                            <option value="mg">MG</option>
                            <option value="mr">MR</option>
                            <option value="us">US</option>
                            <option value="xa">XA</option>

                        </select>
                    </form>
                </div>
                <a class="accordion" data-toggle="collapse" href="#multiCollapseExample2" role="button"
                    aria-expanded="false" aria-controls="multiCollapseExample1">PROFESIONAL</a>
                <div class="col">
                    <form>
                        <select name="selectProfesional" id="selectProfesional" style="width: 95%;" multiple="multiple"
                            size="7">

                            <option value="dx">Arraño Leonardo</option>
                            <option value="dx">Atrullenque Alvaro</option>
                            <option value="dx">Avendaño Francisco</option>
                            <option value="dx">Avila Jaramillo Marcelo</option>
                            <option value="dx">Bazaes Castillo Rodrigo</option>
                            <option value="dx">Beddings Ignacio</option>
                            <option value="dx">Bravo Sebastian</option>
                            <option value="dx">Castro Rehbein Julio</option>
                            <option value="dx">Chiang Francisco</option>
                            <option value="dx">Claro Jorge</option>
                            <option value="dx">Contreras Olea Oscar</option>
                            <option value="dx">Correa Sergio</option>
                            <option value="dx">Gallardo Eduardo</option>
                            <option value="dx">Gonzalez Javic</option>
                            <option value="dx">Gonzalez Raul</option>
                            <option value="dx">Guerrero Abril Jose</option>
                            <option value="dx">irad irad irad</option>
                            <option value="dx">Kratc Botero Renata</option>
                            <option value="dx">Lira Luis</option>
                            <option value="dx">Manterola Pablo</option>
                            <option value="dx">Medina Suniaga Helimenia</option>
                            <option value="dx">Miranda Pavez Marcos</option>
                            <option value="dx">Otarola Barrera Alvaro</option>
                            <option value="dx">Prado Elizabeth</option>
                            <option value="dx">Riquelme Carlos</option>
                            <option value="dx">Rodriguez Walter</option>
                            <option value="dx">Rojas Esteban</option>
                            <option value="dx">Rojas Raul</option>
                            <option value="dx">Rosales Febres Josefina</option>
                            <option value="dx">Sanchez Hernandez Ingrid</option>
                            <option value="dx">Sepulveda Aguilar Ilson Alexis</option>
                            <option value="dx">Torres I</option>
                            <option value="dx">Urbina Jesus</option>
                            <option value="dx">Valenzuela Oriana</option>
                            <option value="dx">Velasquez Carolina</option>
                            <option value="dx">Wong Carlos</option>
                            <option value="dx">Zerega Mario</option>

                        </select>
                    </form>
                </div>

                <a class="accordion" data-toggle="collapse" href="#multiCollapseExample2" role="button"
                    aria-expanded="false" aria-controls="multiCollapseExample1">ESPECIALIDAD</a>
                <div class="col">
                    <form>
                        <select name="selectEspecialidad" id="selectEspecialidad" style="width: 95%;"
                            multiple="multiple" size="7">

                            <option value="0">Seleccione Especialidad</option>
                            <option id="23" value="23">Cardio-Cirujano</option>
                            <option id="8" value="8">Cardiólogo</option>
                            <option id="13" value="13">Cirujano Digestivo</option>
                            <option id="18" value="18">Cirujano General</option>
                            <option id="17" value="17">Cirujano Vascular</option>
                            <option id="12" value="12">Dermatólogo</option>
                            <option id="3" value="3">Diabetólogo</option>
                            <option id="6" value="6">Endocrinólogo Adulto</option>
                            <option id="7" value="7">Endocrinólogo Infantil</option>
                            <option id="28" value="28">Enfermera</option>
                            <option id="15" value="15">Fisiatra</option>
                            <option id="27" value="27">Fonoaudiólogo</option>
                            <option id="16" value="16">Hematólogo</option>
                            <option id="26" value="26">Kinesiólogo</option>
                            <option id="14" value="14">Médico General</option>
                            <option id="9" value="9">NeuroCirujano</option>
                            <option id="5" value="5">Neurologo Infantil</option>
                            <option id="4" value="4">Neurólogo Adulto</option>
                            <option id="24" value="24">Nutricionista</option>
                            <option id="1" value="1">Nutrióloga Adulto</option>
                            <option id="2" value="2">Nutrióloga Infantil</option>
                            <option id="19" value="19">Otorrino</option>
                            <option id="10" value="10">Pediatra</option>
                            <option id="25" value="25">Psicologo</option>
                            <option id="11" value="11">Psiquiatra</option>
                            <option id="22" value="22">Reumatologa</option>
                            <option id="20" value="20">Traumatologo Adulto</option>
                            <option id="21" value="21">Traumatologo Infantil</option>
                            <option id="29" value="29">Técnico Paramedico</option>

                        </select>
                    </form>
                </div>
                
                <!-- FILTROS -->
            </div>

        </div>
        <div class="col">
            <div class="row">

                <!-- BARRA SUPERIOR -->

            </div>
            <div class="dark-top-calendar-bar">
                <br />
                <div class="nav-calendar-left">
                    <a href="#" style="width: 130px !important; height: 30px !important;" class="btn btn-agendar temporalidad-seleccionado-detalle" data-toggle="modal" data-target="#modalAgendarHora">
                        <img src="images/calendario.svg">
                        <span style="font-weight: bold !important">AGENDAR</span>
                    </a>
                    <button style="width: 180px !important;  height: 30px !important;" class="btn btn-agendar temporalidad-seleccionado-detalle">
                        <span style="font-weight: bold !important">INGRESAR ADMISIÓN</span>
                    </button>
                    <button class="btn btn-agendar temporalidad-seleccionado-detalle" style="width: 159px !important; height: 30px !important;">
                        <span style="font-weight: bold !important">BLOQUEAR HORARIO</span>
                    </button>
                </div>
                <div class="nav-calendar-right">
                    <a class="select-temporalidad selected" role="menuitem" data-action="toggle-daily">
                        <div id="nav-dia" class="boton-nav">
                            <div class="temporalidad-seleccionado-background">
                                <p class="temporalidad-titulo" style="margin-top: 15px !important; margin-left:30px">DÍA</p>
                                <div class="temporalidad-seleccionado-detalle" style="width: 40px !important;">
                                </div>
                            </div>
                        </div>
                    </a>
                    <a class="select-temporalidad" role="menuitem" data-action="toggle-weekly">
                        <div id="nav-semana" class="boton-nav">
                            <div class="temporalidad-no-seleccionado-background"
                                style="width: 90px !important; height: 30px;">
                                <p class="temporalidad-titulo" style="margin-top: 15px !important;">SEMANA</p>
                                <div class="temporalidad-no-seleccionado-detalle" style="width: 40px !important;">
                                </div>
                            </div>
                        </div>
                    </a>
                    <a class="select-temporalidad" role="menuitem" data-action="toggle-monthly">
                        <div id="nav-mes" class="boton-nav">
                            <div class="temporalidad-no-seleccionado-background"
                                style="width: 80px !important; height: 30px;">
                                <p class="temporalidad-titulo" style="margin-top: 15px !important; margin-left: 27px;">MES</p>
                                <div class="temporalidad-no-seleccionado-detalle" style="width: 40px !important;">
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
            </div>

            <!-- CALENDARIO -->
            <div clas="row">
                <div class="code-html">
                    <br>
                    <br>
                    <div id="calendar" style="top: 120px !important;"></div>
                </div>
            </div>
            <!-- CALENDARIO -->
        </div>
    </div>

    <!-- <Modal Agendar hora> -->
    <div id="modalAgendarHora" class="modal fade dark-modal-agendar" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-body">

                    <div class="col-sm-12 agendar-header">
                        <h3 class="text-left">Agendar Hora</h3>
                    </div>
                    <div class="col-sm-12 agendar-options text-center radio-container">
                        <label class="radio" style="display: inline-block;">
                            Presencial
							<input id="check-presencial" type="radio" name="opt-agendar" checked>
                            <span class="checkmark"></span>
                        </label>
                        <label class="radio" style="display: inline-block;">
                            Web
							<input id="check-web" type="radio" name="opt-agendar">
                            <span class="checkmark"></span>
                        </label>
                    </div>
                    <div class="row formulario">
                        <div class="col-sm-6">

                            <div class="input-container">
                                <label>RUT paciente</label>
                                <input class="form-control" type="text">
                            </div>
                            <div class="input-container">
                                <label for="">Nombres</label>
                                <input class="form-control" type="text">
                            </div>
                            <div class="input-container">
                                <label for="">Apellidos</label>
                                <input class="form-control" type="text">
                            </div>
                            <div class="input-container">
                                <label for="">Sexo</label>
                                <select name="sexo" id="sexo" class="form-control">
                                    <option value="">Seleccione...</option>
                                </select>
                            </div>
                            <div class="input-container">
                                <label for="">Fecha de nac.</label>
                                <input class="form-control" type="date">
                            </div>
                            <div class="input-container">
                                <label for="">Teléfono</label>
                                <input class="form-control" type="text">
                            </div>
                            <div class="input-container">
                                <label for="">E-mail</label>
                                <input class="form-control" type="text">
                            </div>
                            <div class="input-container">
                                <label for="">Dirección</label>
                                <input class="form-control" type="text">
                            </div>
                            <div class="input-container">
                                <label for="">Prestación</label>
                                <select name="prestacion" id="prestacion" class="form-control">
                                </select>
                            </div>
                            <div class="input-container">
                                <label for="">Previsión</label>
                                <select name="prevision" id="prevision" class="form-control">
                                    <option value="">Seleccione...</option>
                                </select>
                            </div>
                            <div class="row">
                                <div class="col-sm-6"></div>
                                <div class="col-sm-6" style="padding-left: 4px;">
                                    <button class="btn btn-formulario" style="border-radius: 4px 4px 4px 4px;">$ Consultar Precios</button>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="input-container">
                                <label for="">Tipo agenda</label>
                                <select name="tipoAgenda" id="tipoAgenda" class="form-control">
                                    <option value="">Seleccione...</option>
                                </select>
                            </div>
                            <div class="input-container">
                                <label for="">Modalidad</label>
                                <select name="modalidad" id="modalidad" class="form-control">
                                    <option value="">Seleccione...</option>
                                </select>
                            </div>
                            <div class="input-container">
                                <label for="">Duración</label>
                                <select name="duracion" id="duracion" class="form-control">
                                    <option value="">Seleccione...</option>
                                </select>
                            </div>
                            <div class="input-container">
                                <label for="">Médico</label>
                                <select name="medico" id="medico" class="form-control">
                                    <option value="">Seleccione...</option>
                                </select>
                            </div>
                            <div class="input-container">
                                <label for="">Próximas horas disponibles</label>
                                <select name="proxHoras" id="proxHoras" class="form-control">
                                    <option value="">Seleccione...</option>
                                </select>
                            </div>
                            <div class="input-container">
                                <label for="">Comentarios</label>
                                <br>
                                <textarea class="form-control" style="width: 100%; height: 11.6em;"></textarea>
                            </div>
                            <div class="row">
                                <div class="col-sm-9">
                                    <button id="btn-ver-orden-medica" class="btn btn-formulario" style="border-radius: 4px 4px 4px 4px;">
                                        $ Ver orden médica
										adjunta</button>
                                </div>
                                <div class="col-sm-3"></div>
                            </div>
                        </div>

                        <div class="col-sm-12 btns-form" style="margin-top: 30px">
                            <button id="btn-agendar" class="btn btn-formulario-sub float-right" style="width: 145px; border-radius: 4px 4px 4px 4px;">AGENDAR HORA</button>
                            <button id="btn-ingresar" style="border-radius: 4px 4px 4px 4px; width: 174px" class="btn btn-formulario-sub float-right">
                                INGRESAR
								ADMISIÓN</button>
                            <button id="btn-cancelar" style="border-radius: 4px 4px 4px 4px; width: 95px" class="btn btn-formulario-cancel float-right" data-dismiss="modal">CANCELAR</button>
                        </div>

                    </div>
                </div>
                    <div style="height: 20px; background-color: #372F60; margin-bottom: -15px;"></div>

            </div>
        </div>
    </div>
    <!-- </Modal Agendar hora> -->


    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"
        integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj"
        crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"
        integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj"
        crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"
        integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo"
        crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"
        integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI"
        crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>
    <script src="https://uicdn.toast.com/tui.code-snippet/v1.5.2/tui-code-snippet.min.js"></script>
    <script src="https://uicdn.toast.com/tui.time-picker/v2.0.3/tui-time-picker.min.js"></script>
    <script src="https://uicdn.toast.com/tui.date-picker/v4.0.3/tui-date-picker.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.20.1/moment.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chance/1.0.13/chance.min.js"></script>
    <script src="dist/tui-calendar.js"></script>
    <script src="js/data/calendars.js"></script>
    <script src="js/data/schedules.js"></script>
    <script type="text/javascript" class="code-js">
        // register templates
        const templates = {
            popupIsAllDay: function () {
                return 'All Day';
            },
            popupStateFree: function () {
                return 'Free';
            },
            popupStateBusy: function () {
                return 'Busy';
            },
            titlePlaceholder: function () {
                return 'Subject';
            },
            locationPlaceholder: function () {
                return 'Location';
            },
            startDatePlaceholder: function () {
                return 'Start date';
            },
            endDatePlaceholder: function () {
                return 'End date';
            },
            popupSave: function () {
                return 'Save';
            },
            popupUpdate: function () {
                return 'Update';
            },
            popupDetailDate: function (isAllDay, start, end) {
                var isSameDate = moment(start).isSame(end);
                var endFormat = (isSameDate ? '' : 'YYYY.MM.DD ') + 'hh:mm a';

                if (isAllDay) {
                    return moment(start).format('YYYY.MM.DD') + (isSameDate ? '' : ' - ' + moment(end).format('YYYY.MM.DD'));
                }

                return (moment(start).format('YYYY.MM.DD hh:mm a') + ' - ' + moment(end).format(endFormat));
            },
            popupDetailLocation: function (schedule) {
                return 'Location : ' + schedule.location;
            },
            popupDetailUser: function (schedule) {
                return 'User : ' + (schedule.attendees || []).join(', ');
            },
            popupDetailState: function (schedule) {
                return 'State : ' + schedule.state || 'Busy';
            },
            popupDetailRepeat: function (schedule) {
                return 'Repeat : ' + schedule.recurrenceRule;
            },
            popupDetailBody: function (schedule) {
                return 'Body : ' + schedule.body;
            },
            popupEdit: function () {
                return 'Edit';
            },
            popupDelete: function () {
                return 'Delete';
            }
        };

        var cal = new tui.Calendar('#calendar', {
            defaultView: 'day',
            template: templates,
            useCreationPopup: false,
            useDetailPopup: true
        });
    </script>

    <script>
        $('a').each(function () {
            $(this).click(function () {
                $('a').removeClass('selected');
                $(this).addClass('selected');
            })
        });
    </script>

    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script>
        $(function () {
            $selecttipo_agenda = $('#selecttipo_agenda');
            $selecttipo_agenda.multiselect();

            $selectModalidad = $('#selectModalidad');
            $selectModalidad.multiselect();

            $selectProfesional = $('#selectProfesional');
            $selectProfesional.multiselect();

            $selectEspecialidad = $('#selectEspecialidad');
            $selectEspecialidad.multiselect();

            $selectestado_agenda = $('#selectestado_agenda');
            $selectestado_agenda.multiselect();
        });
    </script>
    <script>

        $(document).ready(function () {
            $("#btn-ver-orden-medica").hide();
            /* cargar listas desplegables */
            let sexos;
            let prestaciones;
            let previsiones;
            let tiposAgenda;
            let modalidades;
            let duraciones;
            let medicos;

            $.getJSON("select-formulario.json", function (data) {

                // sexos
                sexos = data.sexo;
                $("#sexo").empty()
                $("#sexo").append('<option value="0">Seleccione...</option>')
                $.each(sexos, function (i, sexo) {
                    $("#sexo").append('<option value="' + sexo.cod + '">' + sexo.nombre + '</option>')
                })

                // prestaciones
                prestaciones = data.prestaciones;
                $("#prestacion").empty()
                $("#prestacion").append('<option value="0">Seleccione...</option>')
                $.each(prestaciones, function (i, prestacion) {
                    $("#prestacion").append('<option value="' + prestacion.cod + '">' + prestacion.nombre + '</option>')
                })

                // previsiones
                previsiones = data.previsiones;
                $("#prevision").empty()
                $("#prevision").append('<option value="0">Seleccione...</option>')
                $.each(previsiones, function (i, prevision) {
                    $("#prevision").append('<option value="' + prevision.cod + '">' + prevision.nombre + '</option>')
                })

                // tipos de agenda
                tiposAgenda = data.tipoAgenda;
                $("#tipoAgenda").empty()
                $("#tipoAgenda").append('<option value="0">Seleccione...</option>')
                $.each(tiposAgenda, function (i, tipoAgenda) {
                    $("#tipoAgenda").append('<option value="' + tipoAgenda.cod + '">' + tipoAgenda.nombre + '</option>')
                })

                // modalidades
                modalidades = data.modalidad;
                $("#modalidad").empty()
                $("#modalidad").append('<option value="0">Seleccione...</option>')
                $.each(modalidades, function (i, modalidad) {
                    $("#modalidad").append('<option value="' + modalidad.cod + '">' + modalidad.nombre + '</option>')
                })

                // duraciones
                duraciones = data.duracion;
                $("#duracion").empty()
                $("#duracion").append('<option value="0">Seleccione...</option>')
                $.each(duraciones, function (i, duracion) {
                    $("#duracion").append('<option value="' + duracion.cod + '">' + duracion.nombre + '</option>')
                })

                // medicos
                medicos = data.medicos;
                $("#medico").empty()
                $("#medico").append('<option value="0">Seleccione...</option>')
                $.each(medicos, function (i, medico) {
                    $("#medico").append('<option value="' + medico.cod + '">' + medico.nombre + '</option>')
                })

        $( ".findInList" ).remove();

            });
        })

        /* Cambio tipo agendar hora Presencial/Web */
        $("#check-presencial").change(function () {
            if (this.checked) {
                $("#btn-ingresar").show()
                $("#btn-ver-orden-medica").hide();
            }
        });

        $("#check-web").change(function () {
            if (this.checked) {
                $("#btn-ingresar").hide()
                $("#btn-ver-orden-medica").show();
            }
        });

    </script>
    <script>
        function changeCSS(fileName) {

            document.getElementById("linkstyle").setAttribute('href', fileName);
        }
    </script>

    <script src="js/default.js"></script>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="js/multiselect/jquery.multiselect.js"></script>

    <script>
    </script>

    <style>
        .yui3-skin-sam yui3-g{
            width: 165% !important;
        }

        .bg-dark{
            background-color: #404848 !important
        }
    </style>
</asp:Content>
