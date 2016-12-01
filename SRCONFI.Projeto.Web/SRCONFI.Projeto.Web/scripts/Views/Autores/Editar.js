$(document).ready(function () {
    $("#btnEditarAutores").click(function () {
        btnEditarAutores();
    });


});



function abrirModalEditar(id) {
    var urlModal = $("#hdnCaminhoModalEditarAutor").val();
    var urlEditar = $("#hdnCaminhoEditarAutor").val() + '?id=' + id;

    abrirModal(urlModal, urlEditar);
}

function btnEditarAutores() {
    var validForm = $('#formEditarAutores').parsley();
    var form = $('#formEditarAutores').serializeObject();

    if (validForm.validate()) {
        $.ajax({
            url: $('#hdnCaminhoSalvarEditarAutor').val(),
            type: "POST",
            data: JSON.stringify({ autor: form }),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (!data.erro) {
                    atualizarTableAutores();
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