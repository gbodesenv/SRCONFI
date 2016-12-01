$(document).ready(function () {
    $("#btnIncluirAutores").click(function () {
        inserirAutor();
    });


});



function abrirModalEditar(id) {
    var urlModal = $("#hdnCaminhoModalEditarAutor").val();
    var urlEditar = $("#hdnCaminhoEditarAutor").val() + '?id=' + id;

    abrirModal(urlModal, urlEditar);
}

function inserirAutor() {
    var validForm = $('#formInserirAutor').parsley();
    var form = $('#formInserirAutor').serializeObject();

    if (validForm.validate()) {
        $.ajax({
            url: $('#hdnCaminhoInserirAutor').val(),
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