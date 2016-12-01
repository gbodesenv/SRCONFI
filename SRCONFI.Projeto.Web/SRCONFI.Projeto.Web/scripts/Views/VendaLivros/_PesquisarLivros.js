(function () {
    $("#btnConfirmarVendaLivros").click(function () {

        var id = $('#tableLivros tr.clickable-row.active').attr('data-row-id');

        if (parseInt(id) > 0)
            confirmarPesquisaLivros(id);
        else
            alertSistema(3, "Por favor, selecione uma linha da tabela!");
    });

})();


function confirmarPesquisaLivros(id) {
    var urlEditar = $("#hdnCaminhoBuscarLivro").val() + '?id=' + id;
    $("#Livro_Pesquisa").load(urlEditar, function () {
        $("#btnFooterCloseModalFirst").click();
    });
}

carregarTableLivros();

function carregarTableLivros() {
    //alert('entrou');
    var urlTableLivros = $("#hdnCaminhoTableLivros").val() + "?id=''l&estoque='true'";
    console.log(urlTableLivros);
    $("#pesquisarLivrosDIV").load(urlTableLivros);
}