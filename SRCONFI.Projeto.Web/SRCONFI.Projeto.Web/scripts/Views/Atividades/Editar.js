$(document).ready(function () {
    $("#btnEditarAtividades").click(function () {
        editarAtividades();
    });

    maskFormat();

    $("#Endereco_numero").formatter({
        'pattern': '{{9999}}',
        'persistent': true
    });

});


function editarAtividades() {

    var validForm = $('#formEditarAtividades').parsley();
    var form = $('#formEditarAtividades').serializeObject();

    console.log(form);

    if (validForm.validate()) {
        $.ajax({
            url: $('#hdnCaminhoEditarAtividades').val(),
            type: "POST",
            data: JSON.stringify({ socios: form }),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (!data.erro) {
                    atualizarTableAtividades();
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