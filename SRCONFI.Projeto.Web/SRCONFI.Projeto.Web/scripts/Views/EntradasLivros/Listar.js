$(document).ready(function () {
    $("#btnGravarEntradaLivro").click(function () {
        btnGravarEntradaLivro();
    });
       
    maskFormat();

    $('#unitarioLivro').change(function () {
        calcularQuantidadeValor();
    });

    $('#txtQuantidade').change(function () {
        calcularQuantidadeValor();
    });

    $(".numeric-places").numeric({ decimal: ".", negative: false, scale: 3 });
        
});


function btnGravarEntradaLivro() {
    var validForm = $('#formInserirEntradasLivros').parsley();
    var form = $('#formInserirEntradasLivros').serializeObject();

    if (validForm.validate()) {
        var livroID = $("#livroID").val();        
        $.ajax({
            url: $('#hdnGravarEntradaLivro').val(),
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