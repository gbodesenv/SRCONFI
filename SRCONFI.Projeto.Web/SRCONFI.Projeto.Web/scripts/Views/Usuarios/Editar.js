$(document).ready(function () {
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
            debugger;
            console.log(data);

            if (!data.erro) {
                var urlListar = $("#hdnCaminhoAtualizarTableUsuario").val();
                $("#ConteudoTableListarUsuario").load(urlListar);

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