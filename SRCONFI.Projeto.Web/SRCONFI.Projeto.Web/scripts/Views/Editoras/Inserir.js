$(document).ready(function () {
    $("#btnIncluirEditoras").click(function () {
        inserirEditora();
    });


});



function abrirModalEditar(id) {
    var urlModal = $("#hdnCaminhoModalEditarEditora").val();
    var urlEditar = $("#hdnCaminhoEditarEditora").val() + '?id=' + id;

    abrirModal(urlModal, urlEditar);
}

function inserirEditora() {
    var validForm = $('#formInserirEditora').parsley();
    var form = $('#formInserirEditora').serializeObject();

    if (validForm.validate()) {
        $.ajax({
            url: $('#hdnCaminhoInserirEditora').val(),
            type: "POST",
            data: JSON.stringify({ editora: form }),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (!data.erro) {
                    atualizarTableEditoras();
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