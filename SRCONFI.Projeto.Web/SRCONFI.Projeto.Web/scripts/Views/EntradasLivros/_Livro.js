$(document).ready(function () {

    $("#btnSearchLivro").click(function () {
        abrirModalPesquisarLivro();
    });
});


function abrirModalPesquisarLivro() {
    var urlModal = $("#hdnCaminhoModalPesquisarLivros").val();
    var urlEditar = $("#hdnCaminhoPesquisarLivros").val();

    abrirModal(urlModal, urlEditar);
}