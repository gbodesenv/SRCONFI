﻿$(document).ready(function () {
    $("#btnIncluirUsuario").click(function () {
        inserirUsuario();
    });
});



function abrirModalEditar(id) {
    var urlModal = $("#hdnCaminhoModalEditarUsuario").val();
    var urlEditar = $("#hdnCaminhoEditarUsuario").val() + '?id=' + id;
    
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
            if (!data.erro) {                
                atualizarTableUsuarios();
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