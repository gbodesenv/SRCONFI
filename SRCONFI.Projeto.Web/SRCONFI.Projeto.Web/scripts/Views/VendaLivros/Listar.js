$(document).ready(function () {
    $("#btnGravarEntradaLivro").click(function () {
        btnGravarVendaLivros();
    });

    $('#txtVlrUnitario').change(function () {
        calcularQuantidadeValor();
    });

    $('#txtQuantidade').change(function () {
        calcularQuantidadeValor();
    });

    $('#valorDesconto').change(function () {
        calcularQuantidadeValor();
    });



    setarMascaras();
});


function setarMascaras() {
    $('.numeric-places').mask("#.##0,00", { reverse: true });

    $('.mask-date').mask('00/00/0000');

    $('.integer-mask-place').mask('00000000');

    maskFormat();

}

function validarPesquisaLivro() {
    var retorno = true;
    if ($("#livroID").val() == "" || parseInt($("#livroID").val()) < 1) {
        retorno = false;
        alertSistema(2, "Por Favor, selecionar um livro para prosseguir na venda!");       
    }

    return retorno;
}

function btnGravarVendaLivros() {
    var validForm = $('#formVendaLivros').parsley();
    var form = $('#formVendaLivros').serializeObject();



    if (validForm.validate() && validarPesquisaLivro()) {
        var estoqueID = $("#Estoque_estoqueID").val();
        var quantidadeVendida = $("#txtQuantidade").val();;
        var caminho = $("#vendaID").val() == "" ? $('#hdnInserirVendaLivros').val() : $('#hdnEditarVendaLivros').val();
        form.totalVenda = $('#totalVenda').val().replace('.', ',');

        $.ajax({
            url: caminho,
            type: "POST",
            data: JSON.stringify({ vendaLivro: form, idEstoque: estoqueID, quantidadeVendida: quantidadeVendida }),
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
    var urlEditar = $("#hdnCaminhoEditarVendaLivros").val() + '?id=' + id;
    $("#ConteudoListarVendaLivros").load(urlEditar);
}

function calcularQuantidadeValor() {
    var unitario = $('#txtVlrUnitario').val().replace('.', '').replace(',', '.');
    var quantidade = $('#txtQuantidade').val();
    var desconto = $('#valorDesconto').val().replace('.', '').replace(',', '.');
    var total = $('#totalVenda');

    if (unitario == "")
        unitario = 0;
    else
        unitario = parseFloat(unitario).toFixed(2);

    if (quantidade == "")
        quantidade = 0;
    else
        parseInt(quantidade);

    var calc = unitario * quantidade;

    if (desconto == "")
        desconto = 0;
    else
        desconto = (parseFloat(desconto).toFixed(2) / 100.00) * calc;

    calc = calc - desconto;

    total.val(calc);

    $('.numeric-places').mask("#.##0,00", { reverse: true });
}