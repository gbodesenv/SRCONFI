$(document).ready(function () {
    $("#btnEditarLivros").click(function () {
        editarLivro();
    });
});


function editarLivro() {
    var validForm = $('#formEditarLivro').parsley();
    var form = $('#formEditarLivro').serializeObject();

    if (validForm.validate()) {
        $.ajax({
            url: $('#hdnCaminhoSalvarEditarLivro').val(),
            type: "POST",
            data: JSON.stringify({ livros: form }),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (!data.erro) {
                    atualizarTableLivros();
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