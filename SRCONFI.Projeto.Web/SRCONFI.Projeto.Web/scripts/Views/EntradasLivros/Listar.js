$(document).ready(function () {
    $("#btnGravarEntradaLivro").click(function () {
        btnGravarEntradaLivro();
    });
       
    $('#unitarioLivro').change(function () {
        calcularQuantidadeValor();
    });

    $('#txtQuantidade').change(function () {
        calcularQuantidadeValor();
    });

    

    setarMascaras();
});


function setarMascaras() {
    $('.numeric-places').mask("#.##0,00", { reverse: true });

    $('mask-date').mask('00/00/0000');

    maskFormat();

}

function btnGravarEntradaLivro() {
    var validForm = $('#formEntradasLivros').parsley();
    var form = $('#formEntradasLivros').serializeObject();

    console.log(form);
    if (validForm.validate()) {
        var livroID = $("#livroID").val();
        var caminho = $("#entradaID").val() == "" ? $('#hdnInserirEntradaLivro').val() : $('#hdnEditarEntradaLivro').val();
        form.unitarioLivro = $('#unitarioLivro').val().replace('.', '');
        form.ValorTotalEntrada = $('#ValorTotalEntrada').val().replace('.', '');
        
        console.log(livroID);
        console.log(caminho);
        $.ajax({
            url: caminho,
            type: "POST",
            data: JSON.stringify({ entradaLivro: form, idLivro: livroID }),
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
    var urlEditar = $("#hdnCaminhoEditarEntradasLivros").val() + '?id=' + id;
    $("#ConteudoListarEntradaLivro").load(urlEditar);
}

function calcularQuantidadeValor() {
    var unitario = $('#unitarioLivro').val();
    var quantidade = $('#txtQuantidade').val(); 
    var total = $('#ValorTotalEntrada');

    if (unitario == "")
        unitario = 0;
    if (quantidade == "")
        quantidade = 0;

    var calc = parseFloat(parseFloat(unitario) * parseInt(quantidade));

    total.val(calc);
}