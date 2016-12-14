$(document).ready(function () {
    $("#btnEditarUsuario").click(function () {
        editarUsuario();
    });

    maskFormat();
});


function editarUsuario() {
    var validForm = $('#formEditarUsuario').parsley();
    var form = $('#formEditarUsuario').serializeObject();

    if (validForm.validate()) {
        console.log(form);
        form.numeroTelefone = $("#numeroTelefone").unmask().val();
        console.log($("#numeroTelefone").unmask().val());

        $.ajax({
            url: $('#hdnCaminhoSalvarEditarUsuario').val(),
            type: "POST",
            data: JSON.stringify({ usu: form }),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (!data.erro) {
                    atualizarTableUsuarios();
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