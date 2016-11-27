﻿$(document).ready(function () {
    $("#btnIncluirSocios").click(function () {
        inserirSocio();
    });

    maskFormat();

    $("#Endereco_numero").formatter({
        'pattern': '{{9999}}',
        'persistent': true
    });
});

function abrirModalEditar(id) {
    var urlModal = $("#hdnCaminhoModalEditarSocio").val();
    var urlEditar = $("#hdnCaminhoEditarSocio").val() + '?id=' + id;

    abrirModal(urlModal, urlEditar);
}

function inserirSocio() {
    var validForm = $('#formInserirSocio').parsley();
    var form = $('#formInserirSocio').serializeObject();

    if (validForm.validate()) {
        $.ajax({
            url: $('#hdnCaminhoInserirSocio').val(),
            type: "POST",
            data: JSON.stringify({ socios: form }),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (!data.erro) {
                    atualizarTableSocios();
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