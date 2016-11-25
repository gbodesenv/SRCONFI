$(document).ready(function () {
    $("#btnEditarSocios").click(function () {
        editarSocio();
    });
});


function editarSocio() {
    
    var validForm = $('#formEditarSocio').parsley();
    var form = $('#formEditarSocio').serializeObject();

    console.log(form);

    if (validForm.validate()) {
        $.ajax({
            url: $('#hdnCaminhoEditarSocio').val(),
            type: "POST",
            data: JSON.stringify({ socios: form }),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (!data.erro) {
                    atualizarTableSocios();
                    alertSistema(1, data.mensagem);
                }
                else {
                    alertSistema(2, data.mensagem);
                }

            },
            error: function (response) {
                var r = jQuery.parseJSON(response.responseText);
                alert("Message: " + r.Message);
                alert("StackTrace: " + r.StackTrace);
                alert("ExceptionType: " + r.ExceptionType);
            }
        });
    }
}