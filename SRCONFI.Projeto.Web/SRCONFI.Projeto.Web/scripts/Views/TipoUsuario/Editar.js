$(document).ready(function () {
    $("#btnEditarTipoUsuario").click(function () {
        editarTipoUsuario();
    });
});


function editarTipoUsuario() {
    var validForm = $('#formEditarTipoUsuario').parsley();
    var form = $('#formEditarTipoUsuario').serializeObject();

    if (validForm.validate()) {
        $.ajax({
            url: $('#hdnCaminhoSalvarEditarTipoUsuario').val(),
            type: "POST",
            data: JSON.stringify({ obj: form }),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (!data.erro) {
                    atualizarTableTipoUsuario();
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