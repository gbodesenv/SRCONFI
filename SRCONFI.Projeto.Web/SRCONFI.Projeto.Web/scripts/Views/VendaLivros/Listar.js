$(document).ready(function () {
    $("#btnGravarVendaLivros").click(function () {
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

function btnGravarVendaLivros() {
    var validForm = $('#formVendaLivros').parsley();
    var form = $('#formVendaLivros').serializeObject();

    console.log(form);
    if (validForm.validate()) {
        var livroID = $("#livroID").val();
        var caminho = $("#vendaID").val() == "" ? $('#hdnInserirVendaLivros').val() : $('#hdnEditarVendaLivros').val();
        form.totalVenda = $('#totalVenda').val().replace('.', '');
        //form.ValorTotalEntrada = $('#ValorTotalEntrada').val().replace('.', '');

        console.log(livroID);
        console.log(caminho);
        $.ajax({
            url: caminho,
            type: "POST",
            data: JSON.stringify({ vendaLivro: form, idLivro: livroID }),
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
    var unitario = $('#txtVlrUnitario').val();
    var quantidade = $('#txtQuantidade').val();
    var desconto = $('#valorDesconto').val();
    var total = $('#totalVenda');

    if (unitario == "")
        unitario = 0;
    if (quantidade == "")
        quantidade = 0;
    if (desconto == "")
        desconto = 0;

    var calc = parseFloat(parseFloat(unitario) * parseInt(quantidade));

    if (desconto != 0)
        desconto = (parseFloat(parseFloat(desconto) / 100)) * calc;

    calc = calc - desconto;

    total.val(calc);
}