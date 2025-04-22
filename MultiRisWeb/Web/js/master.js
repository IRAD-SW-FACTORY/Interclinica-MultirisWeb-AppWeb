function prueba() {
    let now = new Date();
    let hora = now.getHours();
    /*            alert(hora);*/

    if (hora >= 8 && hora <= 20) {
        $('#modalInicioPopUpHabil').modal('show');
    }
    else {
        $('#modalInicioPopUpNoHabil').modal('show');
    }   
}

function CargaDatosInactivo() {
    $('#modalCargando').modal('hide');
}

function CargaDatosActivo() {
    $('#modalCargando').modal('show');
}

function LogMeddream(idExamen) {
  

    var data = '{idExamen:' + idExamen + ' }';
   
    $.ajax({
        type: "POST",
        url: "../Examen/Addendum.aspx/LogMeddreamsInsert",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        async: false,
        success: function (arg) {
           
            
        },
        error: function () {

        }
    });
}