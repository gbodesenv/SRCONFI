$(document).ready(function () {
    $("#btnIncluirTipoUsuario").click(function () {
        inserirTipoUsuario();
    });
});



function abrirModalEditar(id) {
    var urlModal = $("#hdnCaminhoModalEditarTipoUsuario").val();
    var urlEditar = $("#hdnCaminhoEditarTipoUsuario").val() + '?id=' + id;

    abrirModal(urlModal, urlEditar);
}

function inserirTipoUsuario() {
    var validForm = $('#formInserirTipoUsuario').parsley();
    var form = $('#formInserirTipoUsuario').serializeObject();

    if (validForm.validate()) {
        $.ajax({
            url: $('#hdnCaminhoInserirTipoUsuario').val(),
            type: "POST",
            data: JSON.stringify({ obj: form }),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (!data.erro) {
                    atualizarTableTipoUsuario();
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