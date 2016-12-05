(function () {
    $("#btnConfirmarPagamentos").click(function () {

        var id = $('#tableSocios tr.clickable-row.active').attr('data-row-id');

        if (parseInt(id) > 0)
            confirmarPesquisaSocio(id);
        else
            alertSistema(3, "Por favor, selecione uma linha da tabela!");
    });

})();


function confirmarPesquisaSocio(id) {
    var urlEditar = $("#hdnCaminhoBuscarSocio").val() + '?id=' + id;
    $("#Socio_Pesquisa").load(urlEditar, function () {
        $("#btnFooterCloseModalFirst").click();
    });
}

carregarTableSocios();

function carregarTableSocios() {
    //alert('entrou');
    var urlTableSocios = $("#hdnCaminhoTableSocios").val();
    $("#pesquisarSociosDIV").load(urlTableSocios);
}