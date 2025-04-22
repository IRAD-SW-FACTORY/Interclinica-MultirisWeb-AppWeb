
function CargarTagsUsuario() {
  
    $.ajax({
        type: "GET",
        url: "Informar.aspx/ListarTags",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        async: false,
        success: function (data) {
          
            var tags = data.d.Data;
            var htmlTags = '';
            $('#divTags').html(htmlTags);
            $.each(tags, function (i, item) {
               
                var id = 'idTag' + item.Id;
                htmlTags += '<div class="form-check">' +
                    '<input class="form-check-input" type="checkbox" value="' + item.Id + '" id="'+ id +'">' +
                    '<label class="form-check-label" for="flexCheckDefault">' +
                     item.Nombre +
                    '</label>' +
                    '</div>';
            });

            $('#divTags').html(htmlTags);
        }
    });
   
}


function CargarTagsExamen() {
    var data = '{ codExamen :"' + $("#hddCod").val() + '"}';
    $.ajax({
        type: "POST",
        url: "Informar.aspx/ListarTagsExamen",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: data,
        async: false,
        success: function (data) {
           
            var tags = data.d.Data;
            
            $.each(tags, function (i, item) {
               
                var id = '#idTag' + item.IdTagExamen.toString();               
                $(id).prop("checked", true);
            });            
        }
    });
}

function GetTagsSelected() {
   
    var tags = [];
    $("input[type=checkbox]:checked").each(function () {       
        tags.push($(this).val());
    });

    return tags;
}