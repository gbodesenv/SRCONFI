$(document).ready(function () {
    $("#btnGravarEntradaLivro").click(function () {
        btnGravarEntradaLivro();
    });

    $("#btnSearchLivro").click(function () {
        abrirModalPesquisarLivro();
    });

    

    maskFormat();

    $(".input-integer").formatter({
        'pattern': '{{9999}}',
        'persistent': true
    });
});


function btnGravarEntradaLivro() {
    var validForm = $('#formInserirEntradasLivros').parsley();
    var form = $('#formInserirEntradasLivros').serializeObject();

    if (validForm.validate()) {
        $.ajax({
            url: $('#hdnGravarEntradaLivro').val(),
            type: "POST",
            data: JSON.stringify({ entradaLivro: form }),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (!data.erro) {
                    carregarEditar(data.id);                    
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

function carregarEditar(id) {
    var urlEditar = $("#hdnCaminhoEditarEntradasLivros").val() + '?id=' + id;
    $("#ConteudoListarEntradaLivro").load(urlEditar);
}

function abrirModalPesquisarLivro() {
    var urlModal = $("#hdnCaminhoModalPesquisarLivros").val();
    var urlEditar = $("#hdnCaminhoPesquisarLivros").val();

    abrirModal(urlModal, urlEditar);
}