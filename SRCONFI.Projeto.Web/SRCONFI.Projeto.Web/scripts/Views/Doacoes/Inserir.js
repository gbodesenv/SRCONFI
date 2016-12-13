$(document).ready(function () {
    $("#btnIncluirDoacoes").click(function () {
        inserirDoacoes();
    });

    maskFormat();

    $("#Endereco_numero").formatter({
        'pattern': '{{9999}}',
        'persistent': true
    });
});

function abrirModalEditar(id) {
    var urlModal = $("#hdnCaminhoModalEditarDoacoes").val();
    var urlEditar = $("#hdnCaminhoEditarDoacoes").val() + '?id=' + id;

    abrirModal(urlModal, urlEditar);
}

function inserirDoacoes() {
    var validForm = $('#formInserirDoacoes').parsley();
    var form = $('#formInserirDoacoes').serializeObject();

    if (validForm.validate()) {
        $.ajax({
            url: $('#hdnCaminhoInserirDoacoes').val(),
            type: "POST",
            data: JSON.stringify({ doacoes: form }),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (!data.erro) {
                    atualizarTableDoacoes();
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