
carregarTableLivros();



function carregarTableLivros() {
    //alert('entrou');
    var urlTableLivros = $("#hdnCaminhoTableLivros").val();
    $("#pesquisarLivrosDIV").load(urlTableLivros);
}