$(document).ready(function () {
    $("#btnIncluirLivros").click(function () {
        inserirLivro();
    });


});



function abrirModalEditar(id) {
    var urlModal = $("#hdnCaminhoModalEditarLivro").val();
    var urlEditar = $("#hdnCaminhoEditarLivro").val() + '?id=' + id;

    abrirModal(urlModal, urlEditar);
}

function inserirLivro() {
    var validForm = $('#formInserirLivro').parsley();
    var form = $('#formInserirLivro').serializeObject();

    if (validForm.validate()) {
        $.ajax({
            url: $('#hdnCaminhoInserirLivro').val(),
            type: "POST",
            data: JSON.stringify({ livros: form }),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (!data.erro) {
                    atualizarTableLivros();
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