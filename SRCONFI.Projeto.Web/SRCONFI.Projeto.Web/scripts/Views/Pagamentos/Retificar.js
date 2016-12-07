
$(document).ready(function () {
    $("#btnGravarRetificarPagamento").click(function () {
        btnGravarRetificarPagamento();
    });

    setarMascarasRetificar();
});


function btnGravarRetificarPagamento() {
    var validForm = $('#formPagamentos').parsley();
    var form = $('#formPagamentos').serializeObject();

    if (validForm.validate() ) {
        var caminho = $('#hdnEditarPagamento').val();
        form.valorPag = $('#valorPag').val().replace('.', '');
        //form.socioID_FK = $('#socioID').val();

        $.ajax({
            url: caminho,
            type: "POST",
            data: JSON.stringify({ pagamento: form }),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (!data.erro) {
                    setarMascarasRetificar();
                    //carregarEditar(data.id);
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

function setarMascarasRetificar() {
    $('.numeric-places').mask("#.##0,00", { reverse: true });

    $('mask-date').mask('00/00/0000');

    maskFormat();

}





