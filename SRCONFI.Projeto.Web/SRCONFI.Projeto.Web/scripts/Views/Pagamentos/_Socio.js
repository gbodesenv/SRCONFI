$(document).ready(function () {

    $("#btnSearchSocios").click(function () {
        abrirModalPesquisarSocio();
    });
});


function abrirModalPesquisarSocio() {
    var urlModal = $("#hdnCaminhoModalPesquisarSocios").val();
    var urlEditar = $("#hdnCaminhoPesquisarSocios").val();

    abrirModal(urlModal, urlEditar);
}