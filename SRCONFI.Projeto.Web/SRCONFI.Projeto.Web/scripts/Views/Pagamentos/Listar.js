$(document).ready(function () {
    $("#btnGravarPagamento").click(function () {
        btnGravarPagamento();
    });

    setarMascaras();
});


function setarMascaras() {
    $('.numeric-places').mask("#.##0,00", { reverse: true });

    $('mask-date').mask('00/00/0000');

    maskFormat();

}

function validarPesquisaSocio() {
    var retorno = true;
    if ($("#socioID").val() == "" || parseInt($("#socioID").val()) < 1) {
        retorno = false;
        alertSistema(2, "Por Favor, selecionar um sócio para prosseguir no pagamento!");
    }

    return retorno;
}

function btnGravarPagamento() {
    var validForm = $('#formPagamentos').parsley();
    var form = $('#formPagamentos').serializeObject();
        
    if (validForm.validate() && validarPesquisaSocio()) {
        var caminho = $("#pagamentoID").val() == "" ? $('#hdnInserirPagamento').val() : $('#hdnEditarPagamento').val();
        form.valorPag = $('#valorPag').val().replace('.', '');
        form.socioID_FK = $('#socioID').val();
        
        $.ajax({
            url: caminho,
            type: "POST",
            data: JSON.stringify({ pagamento: form }),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (!data.erro) {
                    carregarEditar(data.id);
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

function carregarEditar(id) {
    var urlEditar = $("#hdnCaminhoEditarPagamentos").val() + '?id=' + id;
    $("#ConteudoListarPagamento").load(urlEditar);
}
