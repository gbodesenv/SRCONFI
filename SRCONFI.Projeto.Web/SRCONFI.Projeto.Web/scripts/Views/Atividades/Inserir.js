$(document).ready(function () {
    $("#btnIncluirAtividades").click(function () {
        inserirAtividades();
    });

    maskFormat();

    $("#Endereco_numero").formatter({
        'pattern': '{{9999}}',
        'persistent': true
    });
});

function abrirModalEditar(id) {
    var urlModal = $("#hdnCaminhoModalEditarAtividades").val();
    var urlEditar = $("#hdnCaminhoEditarAtividades").val() + '?id=' + id;

    abrirModal(urlModal, urlEditar);
}

function inserirAtividades() {
    var validForm = $('#formInserirAtividades').parsley();
    var form = $('#formInserirAtividades').serializeObject();

    if (validForm.validate()) {
        $.ajax({
            url: $('#hdnCaminhoInserirAtividades').val(),
            type: "POST",
            data: JSON.stringify({ atividades: form }),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (!data.erro) {
                    atualizarTableAtividades();
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