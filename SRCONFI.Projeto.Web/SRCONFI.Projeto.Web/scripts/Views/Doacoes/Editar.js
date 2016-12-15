$(document).ready(function () {
    $("#btnEditarDoacoes").click(function () {
        editarDoacoes();
    });

    maskFormat();

    $("#Endereco_numero").formatter({
        'pattern': '{{9999}}',
        'persistent': true
    });

});


function editarDoacoes() {

    var validForm = $('#formEditarDoacoes').parsley();
    var form = $('#formEditarDoacoes').serializeObject();

    console.log(form);

    if (validForm.validate()) {
        $.ajax({
            url: $('#hdnCaminhoEditarDoacoes').val(),
            type: "POST",
            data: JSON.stringify({ doacoes: form }),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (!data.erro) {
                    atualizarTableDoacoes();
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