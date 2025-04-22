$(function () {
    CargarProfesional();
    Listar();
});

function CargarProfesional() {

    $("#ddlProfesional").empty();
    $.ajax({
        type: "POST",
        url: "../MaestroFiltro/Buscador.aspx/CargarProfesionales",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (data) {
            var profesionales = data.d.Data;

            $.each(profesionales, function (i, item) {
                $('#ddlProfesional').append('<option value="' + profesionales[i].id_usuario + '">' + profesionales[i].nombre_completo + '</option>');
            });
        }
    });
}


function Listar() {

    $("#tbFiltros").html('');
    var html = '';
    var data = '{idUsuario:' + $("#ddlProfesional").val() + ', idEstado:"' + $("#ddlEstado").val() + '"}';
   
    $.ajax({
        type: "POST",
        url: "../MaestroFiltro/Buscador.aspx/Listar",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        async: false,
        success: function (data) {

            if (data.d.Ejecutado) {
                $.each(data.d.Data, function (id, value) {
                    html += '<tr>' +                        
                        '<td>' + value.Nombre + '</td>' +
                        '<td class="text-center">' + value.Estado + '</td>' +
                        '<td class="text-center">' + value.CantidadUso + '</td>' +
                        '<td class="text-center">' + value.FechaText + '</td>' +
                        '<td class="text-center">' + value.CantidadAsignado + '</td>' +
                        '<td class="text-center"><a href="javascript:Modificar('+ value.IdFiltro +')"><img src="../icon/corregir.png" title = "Modificar Filtro" style = "min-width: 20px" /><a/></td>' +
                        '</tr>';
                });
            } else {
                html += '<tr>' +
                    '<td colspan="6" class="text-center"><label>No existen filtros</label></td>' +
                    '</tr>';
            }
            $("#tbFiltros").html(html);
        }
    });
}

function Modificar(id) {

    location.href = "Mantenedor.aspx?id=" + id;
}



