$(document).ready(function () {
    $("#btnEditarEditoras").click(function () {
        editarEditora();
    });
});


function editarEditora() {
    var validForm = $('#formEditarEditora').parsley();
    var form = $('#formEditarEditora').serializeObject();

    if (validForm.validate()) {
        $.ajax({
            url: $('#hdnCaminhoSalvarEditarEditora').val(),
            type: "POST",
            data: JSON.stringify({ editora: form }),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (!data.erro) {
                    atualizarTableEditoras();
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