﻿$(document).ready(function () {
    $("#btnIncluirUsuario").click(function () {
        inserirUsuario();
    });
});

function abrirModal(urlModal, urlBodyModal) {
    $("#modal").load(urlModal, function () {
        $("#modal .modal-body.first").load(urlBodyModal, function () {
            $("#modal").modal();
        });
    });
}

function abrirModalEditar(id) {
    var urlModal = $("#hdnCaminhoModalEditarUsuario").val();
    var urlEditar = $("#hdnCaminhoEditarUsuario").val() + '?id=' + id;
    console.log(urlEditar);
    abrirModal(urlModal, urlEditar);
}

function inserirUsuario() {

    var form = $('#formInserirUsuario').serializeObject();
    $.ajax({
        url: $('#hdnCaminhoInserirUsuario').val(),
        type: "POST",
        data: JSON.stringify({ usu: form }),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            debugger;
            console.log(data);

            if (!data.erro) {
                var urlListar = $("#hdnCaminhoAtualizarTableUsuario").val();
                $("#ConteudoTableListarUsuario").load(urlListar);

                abrirModalEditar(data.id);
                alert(data.mensagem);
            }
            else {
                alert(data.mensagem);
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