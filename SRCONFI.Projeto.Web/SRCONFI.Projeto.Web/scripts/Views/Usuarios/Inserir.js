$(document).ready(function () {
    $("#btnIncluirUsuario").click(function () {
        inserirUsuario();
    });

    maskFormat();
});



function abrirModalEditar(id) {
    var urlModal = $("#hdnCaminhoModalEditarUsuario").val();
    var urlEditar = $("#hdnCaminhoEditarUsuario").val() + '?id=' + id;

    abrirModal(urlModal, urlEditar);
}

function inserirUsuario() {
    var validForm = $('#formInserirUsuario').parsley();
    var form = $('#formInserirUsuario').serializeObject();

    if (validForm.validate()) {
        console.log(form);
        form.numeroTelefone = $("#numeroTelefone").unmask().val();
        $.ajax({
            url: $('#hdnCaminhoInserirUsuario').val(),
            type: "POST",
            data: JSON.stringify({ usu: form }),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (!data.erro) {
                    atualizarTableUsuarios();
                    abrirModalEditar(data.id);
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