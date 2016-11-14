﻿$(document).ready(function () {
    $("#btnEditarUsuario").click(function () {
        editarUsuario();
    });
});


function editarUsuario() {

    var form = $('#formEditarUsuario').serializeObject();
    $.ajax({
        url: $('#hdnCaminhoSalvarEditarUsuario').val(),
        type: "POST",
        data: JSON.stringify({ usu: form }),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            if (!data.erro) {
                atualizarTableUsuarios();
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