<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaAgenda.aspx.cs" Inherits="MultiRisWeb.Web.Agenda.ListaAgenda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>IRAD</title>
    <link rel="icon" type="image/png" href="./images/favicon.png" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css"
        integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous" />
    <link rel="stylesheet" type="text/css" href="https://uicdn.toast.com/tui.time-picker/latest/tui-time-picker.css" />
    <link rel="stylesheet" type="text/css" href="https://uicdn.toast.com/tui.date-picker/latest/tui-date-picker.css" />
    <link rel="stylesheet" type="text/css" href="dist/tui-calendar.css" />
    <link rel="stylesheet" href="css/multiselect/jquery.multiselect.css" />
    <link rel="stylesheet" type="text/css" href="css/default.css" />
    <link rel="stylesheet" type="text/css" href="css/icons.css" />
    <link id="linkstyle" rel="stylesheet" type="text/css" href="./css/style.css" />
    <script src="http://yui.yahooapis.com/3.18.1/build/yui/yui-min.js"></script>
    <style>
        .nav-agenda {
            background-color: #E67C00 !important;
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
    </style>
    <script type="text/javascript">
        YUI().use('calendar', 'datatype-date', 'cssbutton', function (Y) {
            var calendar = new Y.Calendar({
                contentBox: "#mycalendar",
                width: '340px',
                showPrevMonth: true,
                showNextMonth: true,
                date: new Date()
            }).render();

            var dtdate = Y.DataType.Date;

            calendar.on("selectionChange", function (ev) {

                var newDate = ev.newSelection[0];

                Y.one("#selecteddate").setHTML(dtdate.format(newDate));
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col" style="background-color: #4F5355; max-width: 20%; min-width: 220px; height: 100%;">
                <img src="images/logo_white.png" style="max-height: 60px; margin-left: 15%; margin-top: 20px;">
                <h5 style="font-weight: bold; margin-left: 25%; letter-spacing: -1px; color: white !important;">INTELLI
				RIS/PACS</h5>

                <div id="filtros" style="margin-left: 10%;">
                    <!-- FILTROS -->
                    <div id="menu" style="padding-left: 0px;">

                        <div id="demo" class="yui3-skin-sam yui3-g">
                            <div id="leftcolumn" class="yui3-u">
                                <div id="mycalendar" style="width: 60%; background: #F39555; color: white"></div>
                            </div>
                            <div id="rightcolumn" class="yui3-u">
                                <div id="links" style="padding-left: 20px;">
                                </div>
                            </div>
                        </div>
                    </div>
                    <a class="accordion" data-toggle="collapse" href="#multiCollapseExample1" role="button"
                        aria-expanded="false" aria-controls="multiCollapseExample1">TIPO AGENDA</a>
                    <div class="col">
                        <select name="selecttipo_agenda" id="selecttipo_agenda" style="width: 100% !important;"
                            multiple="multiple" size="5">
                            <option value="a1">Médica</option>
                            <option value="a2">Radiológica</option>
                        </select>
                    </div>
                    <a class="accordion" data-toggle="collapse" href="#multiCollapseExample2" role="button"
                        aria-expanded="false" aria-controls="multiCollapseExample1">MODALIDAD</a>
                    <div class="col">
                        <form>
                            <select name="selectModalidad" id="selectModalidad" style="width: 100%;" multiple="multiple"
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
                            <select name="selectProfesional" id="selectProfesional" style="width: 100%;" multiple="multiple"
                                size="7">

                                <option value="1">Arraño Leonardo</option>
                                <option value="2">Atrullenque Alvaro</option>
                                <option value="3">Avendaño Francisco</option>
                                <option value="4">Avila Jaramillo Marcelo</option>
                                <option value="5">Bazaes Castillo Rodrigo</option>
                                <option value="6">Beddings Ignacio</option>
                                <option value="7">Bravo Sebastian</option>
                                <option value="8">Castro Rehbein Julio</option>
                                <option value="9">Chiang Francisco</option>
                                <option value="10">Claro Jorge</option>
                                <option value="11">Contreras Olea Oscar</option>
                                <option value="12">Correa Sergio</option>
                                <option value="13">Gallardo Eduardo</option>
                                <option value="14">Gonzalez Javic</option>
                                <option value="15">Gonzalez Raul</option>
                                <option value="16">Guerrero Abril Jose</option>
                                <option value="17">irad irad irad</option>
                                <option value="18">Kratc Botero Renata</option>
                                <option value="19">Lira Luis</option>
                                <option value="20">Manterola Pablo</option>
                                <option value="21">Medina Suniaga Helimenia</option>
                                <option value="22">Miranda Pavez Marcos</option>
                                <option value="23">Otarola Barrera Alvaro</option>
                                <option value="24">Prado Elizabeth</option>
                                <option value="25">Riquelme Carlos</option>
                                <option value="26">Rodriguez Walter</option>
                                <option value="27">Rojas Esteban</option>
                                <option value="28">Rojas Raul</option>
                                <option value="29">Rosales Febres Josefina</option>
                                <option value="30">Sanchez Hernandez Ingrid</option>
                                <option value="31">Sepulveda Aguilar Ilson Alexis</option>
                                <option value="32">Torres I</option>
                                <option value="33">Urbina Jesus</option>
                                <option value="34">Valenzuela Oriana</option>
                                <option value="35">Velasquez Carolina</option>
                                <option value="36">Wong Carlos</option>
                                <option value="37">Zerega Mario</option>

                            </select>
                        </form>
                    </div>

                    <a class="accordion" data-toggle="collapse" href="#multiCollapseExample2" role="button"
                        aria-expanded="false" aria-controls="multiCollapseExample1">ESPECIALIDAD</a>
                    <div class="col">
                        <form>
                            <select name="selectEspecialidad" id="selectEspecialidad" style="width: 100%;"
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

                    <a class="accordion" data-toggle="collapse" href="#multiCollapseExample1" role="button"
                        aria-expanded="false" aria-controls="multiCollapseExample1">ESTADO AGENDA</a>
                    <div class="col">
                        <form>
                            <select name="selectestado_agenda" id="selectestado_agenda" style="width: 100%;"
                                multiple="multiple" size="5">
                                <!-- <optgroup label="Tipo Agenda"></optgroup> -->
                                <option value="0">Nuevo</option>
                                <option value="1">En Proceso</option>
                                <option value="2">Pagado</option>
                                <option value="3">Finalizado</option>
                                <option value="4">Anulado</option>
                                <!-- </optgroup> -->
                            </select>
                        </form>
                    </div>
                    <!-- FILTROS -->
                </div>

            </div>
            <div class="col">
                <div class="row">
                    <div class="col">
                        <!-- BARRA SUPERIOR -->
                        <div id="nav-barrasuperior">
                            <div id="nav-agenda" class="boton-nav">
                                <div class="nav-seleccionado-background">
                                    <!--   <div class="nav-no-seleccionado-detalle">
            <img src="images/calendario.svg" class="nav-icono">
        </div> -->
                                    <p class="nav-titulo">AGENDA Y ADMISIÓN</p>

                                    <div class="nav-seleccionado-detalle">
                                        <img src="images/calendario.svg" class="nav-icono">
                                    </div>
                                </div>
                            </div>

                            <div id="nav-caja" class="boton-nav">
                                <div class="nav-no-seleccionado-background">
                                    <p class="nav-titulo">VENTA Y CAJA</p>

                                    <div class="nav-no-seleccionado-detalle">
                                        <img src="images/caja.svg" class="nav-icono">
                                    </div>
                                </div>
                            </div>

                            <div id="nav-examenes" class="boton-nav">
                                <div class="nav-no-seleccionado-background">
                                    <p class="nav-titulo">CONSULTA EXÁMENES</p>

                                    <div class="nav-no-seleccionado-detalle">
                                        <img src="images/examenes.svg" class="nav-icono">
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="col col-lg-3" style="margin-right: 50px;">
                        <div class="dropdown show">
                            <a class="btn btn-secondary dropdown-toggle" style="min-width: 300px; max-height: 30px;"
                                href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true"
                                aria-expanded="false">
                                <p>
                                    <img src="images/user.png"
                                        style="height: 15px; display: inline-block;">&nbsp&nbspAngélica Llanos | Secretaria
                                </p>
                            </a>
                            <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                                <a class="dropdown-item" href="#" onclick="changeCSS('./css/style_claro.css', 0);">
                                    <img
                                        src="images/tema.png" style="height: 15px; display: inline-block;">
                                    <p style="display: inline-block;">&nbsp&nbspCambiar tema</p>
                                </a>
                                <a class="dropdown-item" href="#">
                                    <img src="images/cerrar.png"
                                        style="height: 15px; display: inline-block;">
                                    <p style="display: inline-block; font-weight: bold;">&nbsp&nbspCerrar sesión</p>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="dark-top-calendar-bar">
                    <div class="nav-calendar-left">
                        <a href="#" class="btn btn-agendar" data-toggle="modal" data-target="#modalAgendarHora">
                            <img src="images/calendario.svg" />
                            <span>AGENDAR</span>
                        </a>
                        <button class="btn btn-agendar">
                            <span>INGRESAR ADMISIÓN</span>
                        </button>
                        <button class="btn btn-agendar">
                            <span>BLOQUEAR HORARIO</span>
                        </button>
                    </div>
                    <div class="nav-calendar-right">
                        <a class="select-temporalidad selected" role="menuitem" data-action="toggle-daily">
                            <div id="nav-dia" class="boton-nav">
                                <div class="temporalidad-seleccionado-background">
                                    <p class="temporalidad-titulo" style="margin-top: 15px !important;">DÍA</p>
                                    <div class="temporalidad-seleccionado-detalle" style="width: 40px !important;">
                                    </div>
                                </div>
                            </div>
                        </a>
                        <a class="select-temporalidad" role="menuitem" data-action="toggle-weekly">
                            <div id="nav-semana" class="boton-nav">
                                <div class="temporalidad-no-seleccionado-background"
                                    style="width: 80px !important; height: 30px;">
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
                                    <p class="temporalidad-titulo" style="margin-top: 15px !important;">MES</p>
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
                                        <option value="0">Seleccione...</option>
                                        <option value="NI">No informado</option>
                                        <option value="F">Femenino</option>
                                        <option value="M">Masculino</option>
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
                                        <option value="0">Seleccione...</option>
                                        <option value="1">PARTICULAR</option>
                                        <option value="2">FONASA</option>
                                        <option value="3">COLMENA</option>
                                        <option value="4">CRUZ BLANCA</option>
                                        <option value="5">CONSALUD</option>
                                        <option value="6">CRUZ DEL NORTE</option>
                                        <option value="7">ISALUD</option>
                                        <option value="8">FUNDACION</option>
                                        <option value="9">MAS VIDA</option>
                                        <option value="10">BANMEDICA</option>
                                        <option value="11">VIDA TRES</option>
                                        <option value="12">ACHS</option>
                                        <option value="13">MUTUAL</option>
                                        <option value="14">IST</option>
                                        <option value="15">EJERCITO</option>
                                        <option value="16">CAPREDENA</option>
                                        <option value="17">FACH</option>
                                        <option value="18">DIPRECA</option>
                                        <option value="19">MEDIMEL</option>
                                        <option value="20">GES CHUQUICAMATA</option>
                                        <option value="21">GES CRUZ BLANCA</option>
                                        <option value="22">GES MAS VIDA</option>
                                        <option value="23">GES COLMENA</option>
                                        <option value="24">GES FONASA</option>
                                        <option value="25">GES BANMEDICA</option>
                                        <option value="26">GES CONSALUD</option>
                                        <option value="27">CODELCO</option>
                                        <option value="28">SANOFI</option>
                                        <option value="29">NOVO</option>
                                        <option value="30">ARMADA</option>
                                        <option value="31">CDA</option>
                                        <option value="32">GES VIDA TRES</option>
                                        <option value="33">GES CRUZ DEL NORTE</option>
                                        <option value="34">COMISIÓN MÉDICA</option>
                                    </select>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6"></div>
                                    <div class="col-sm-6" style="padding-left: 4px;">
                                        <button class="btn btn-formulario">$ Consultar Precios</button>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="input-container">
                                    <label for="">Tipo agenda</label>
                                    <select name="tipoAgenda" id="tipoAgenda" class="form-control">
                                        <option value="0">Seleccione...</option>
                                        <option value="1">Médica</option>
                                        <option value="2">Radiología</option>
                                    </select>
                                </div>
                                <div class="input-container">
                                    <label for="">Modalidad</label>
                                    <select name="modalidad" id="modalidad" class="form-control">
                                        <option value="0">Seleccione...</option>
                                        <option value="CR">Radiografía computarizada</option>
                                        <option value="CT">Tomografía computarizada</option>
                                        <option value="DX">Radiografía digital</option>
                                        <option value="MG">Mamografía</option>
                                        <option value="MR">Resonancia magnética</option>
                                        <option value="US">Ultrasonido</option>
                                        <option value="XA">Angiografía de Rayos-X</option>
                                    </select>
                                </div>
                                <div class="input-container">
                                    <label for="">Duración</label>
                                    <select name="duracion" id="duracion" class="form-control">
                                        <option value="0">Seleccione...</option>
                                        <option value="15">15 min</option>
                                        <option value="30">30 min</option>
                                        <option value="60">60 min</option>
                                        <option value="90">90 min</option>
                                        <option value="120">120 min</option>
                                        <option value="150">150 min</option>
                                        <option value="180">180 min</option>
                                    </select>
                                </div>
                                <div class="input-container">
                                    <label for="">Médico</label>
                                    <select name="medico" id="medico" class="form-control">
                                        <option value="0">Seleccione...</option>
                                        <option value="2101">Agustin Brante (Neurólogo)</option>
                                        <option value="2076">Alejandro Avendaño (Traumatólogo)</option>
                                        <option value="2079">Amanda  Valenzuela (Nutricionista)</option>
                                        <option value="2225">Andrés Montenegro (Dermatólogo)</option>
                                        <option value="2199">Angel Padrón (Internista)</option>
                                        <option value="2106">Angelica Montecinos (Psicóloga)</option>
                                        <option value="2172">Arnoldo Briceño (Traumatólogo)</option>
                                        <option value="2100">Axel Araya (Neurólogo)</option>
                                        <option value="2191">Baldo  Espinoza (Urólogo)</option>
                                        <option value="2092">Bernarda  Avalos (Enfermera)</option>
                                        <option value="2060">Bio + Cal + Holter + ME</option>
                                        <option value="2098">Carlos Ñancupil (Neurólogo)</option>
                                        <option value="2168">Carmen Rojas (Reumatóloga)</option>
                                        <option value="2062">Cristian Aguirre</option>
                                        <option value="2054">Cristian  Tabilo (Diabetólogo-ADULTO)</option>
                                        <option value="2105">Daniela Gonzalez (Fonoaudióloga)</option>
                                        <option value="2201">David Barraza (Kinesiologo)</option>
                                        <option value="2206">David  Coronel (Cirugía cabeza y cuello)</option>
                                        <option value="19">Eduardo Mendez</option>
                                        <option value="2111">EEG + EMT + TL</option>
                                        <option value="2167">ElectroCardiograma</option>
                                        <option value="2138">Electromiografía De Arco</option>
                                        <option value="2175">German Herrera (Médico General)</option>
                                        <option value="2133">Gislaine Lam (Neuróloga)</option>
                                        <option value="2048">Gloria Bustos M. (Nutrióloga-ADULTO)</option>
                                        <option value="2204">Isabel Diaz</option>
                                        <option value="2222">Ivan  Remolina (Reumatólogo)</option>
                                        <option value="2080">Ivan Galleguillos (Traumatólogo)</option>
                                        <option value="2071">Javier Farias G. (Traumatólogo)</option>
                                        <option value="2156">Juan Amado Péndola (Traumatólogo)</option>
                                        <option value="2149">Juan Antonio Anelli C. (Traumatólogo)</option>
                                        <option value="2132">Julio Caamaño (Nefrólogo)</option>
                                        <option value="2104">Karla Villegas (Reumatóloga)</option>
                                        <option value="2197">Lorenzo Ramírez (Cirujano General)</option>
                                        <option value="2061">Macarena Barahona (Kinesiologa)</option>
                                        <option value="2058">Marcelo Zamorano (Cirujano Digestivo)</option>
                                        <option value="2136">Margarita Enberg (Infectologa)</option>
                                        <option value="2180">Maria Jose Mendez (Médico General)</option>
                                        <option value="2200">María José Zeballos (Neuróloga)</option>
                                        <option value="2143">Mariano  Perez (Traumatólogo)</option>
                                        <option value="2196">Mary Rodriguez (Gastroenterologa)</option>
                                        <option value="2055">Mauricio Dacuña (Cardiólogo)</option>
                                        <option value="2214">Maximiliano Hormazábal (Traumatólogo)</option>
                                        <option value="2137">Micke De Arco E. (Neurólogo)</option>
                                        <option value="2090">Náyade Collío (Pediatra)</option>
                                        <option value="2181">Neida  Melendez (Psiquiatra)</option>
                                        <option value="2208">Ondas de Choque Urológica</option>
                                        <option value="2221">Oscar  Vargas (Otorrino)</option>
                                        <option value="2077">Paola Madrid (Nutricionista)</option>
                                        <option value="2202">PLANTILLAS</option>
                                        <option value="2131">Polisomnografía Pol</option>
                                        <option value="2212">Procedimientos dermatológicos</option>
                                        <option value="2218">Ricardo Vacarezza E (Hematólogo)</option>
                                        <option value="2103">Ricardo Soto (Neurocirujano)</option>
                                        <option value="2069">Roxana Fuentes (Psicóloga)</option>
                                        <option value="2056">Vicente Carrasco (Psiquiatra)</option>
                                        <option value="2082">Victor Olivares (Neurología Pediátrica)</option>
                                        <option value="2050">Víctor García Jara (Endocrinólogo)</option>
                                        <option value="2107">Viviana Tobar</option>
                                        <option value="2209">Viviana Gomez (Dermatólogo)</option>
                                        <option value="2210">Walter Araos (Traumatólogo)</option>
                                        <option value="2155">Yhurka  Yañez Navarrete (Psicóloga)</option>
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
                                        <button id="btn-ver-orden-medica" class="btn btn-formulario">
                                            $ Ver orden médica
										adjunta</button>
                                    </div>
                                    <div class="col-sm-3"></div>
                                </div>
                            </div>

                            <div class="col-sm-12 btns-form">
                                <button id="btn-agendar" class="btn btn-formulario-sub float-right">AGENDAR HORA</button>
                                <button id="btn-ingresar" class="btn btn-formulario-sub float-right">
                                    INGRESAR
								ADMISIÓN</button>
                                <button id="btn-cancelar" class="btn btn-formulario-cancel float-right">CANCELAR</button>
                            </div>

                        </div>
                        <div style="height: 20px; background-color: #372F60; margin-bottom: -15px;"></div>
                    </div>
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

        <script src="./js/default.js"></script>
        <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
        <script src="./js/multiselect/jquery.multiselect.js"></script>
    </form>
</body>
</html>
