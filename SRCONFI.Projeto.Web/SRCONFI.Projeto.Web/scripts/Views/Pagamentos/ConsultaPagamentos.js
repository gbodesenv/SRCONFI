$(document).ready(function () {
    $('#btnRetificarPagamento').click(function () {
        var id = $('#tablePagamentos tr.clickable-row.active').attr('data-row-id');

        if (parseInt(id) > 0)
            carregarEditar(id);
        else
            alertSistema(3, "Por favor, selecione uma linha da tabela!");

    });

});


function carregarEditar(id) {
    var urlEditar = $("#hdnCaminhoRetificarPagamento").val() + '?id=' + id;
    window.location.href = urlEditar;
}