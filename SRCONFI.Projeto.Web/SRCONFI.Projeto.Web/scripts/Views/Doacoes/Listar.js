(function () {

    $(document).ready(function () {



        $('#btnAbrirModalIncluir').click(function () {
            btnAbrirModalInserir_click();
        });

        $('#btnAbrirModalEditar').click(function () {
            var id = $('#tableDoacoes tr.clickable-row.active').attr('data-row-id');

            if (parseInt(id) > 0)
                btnAbrirModalEditar_click(id);
            else
                alertSistema(3, "Por favor, selecione uma linha da tabela!");

        });


        $('#btnExcluirDoacoes').click(function () {
            var id = $('#tableDoacoes tr.clickable-row.active').attr('data-row-id');

            if (parseInt(id) > 0)
                btnExcluirDoacoes_click(id);
            else
                alertSistema(3, 'Por favor, selecione uma linha da tabela!');

        });



    });


    function btnExcluirDoacoes_click(id) {
        confirmDialog('Excluir Doacoes!',
                      'Deseja Realmente Excluir essa Doação?',
                      excluirDoacoes,
                      id);
    }
    function excluirDoacoes(id) {
        $.post($("#hdnCaminhoExcluirDoacoes").val(), { id: id }, function (data) {
            if (data.erro) {
            } else {
                atualizarTableDoacoes();
                alertSistema(1, data.mensagem);
            }
        });
    }

    function btnAbrirModalEditar_click(id) {
        var urlModal = $("#hdnCaminhoModalEditarDoacoes").val();
        var urlEditar = $("#hdnCaminhoEditarDoacoes").val() + '?id=' + id;

        abrirModal(urlModal, urlEditar);
    }

    function btnAbrirModalInserir_click() {
        var urlModal = $("#hdnCaminhoModalInserirDoacoes").val();
        var urlInserir = $("#hdnCaminhoInserirDoacoes").val();

        abrirModal(urlModal, urlInserir);
    }



})();

function atualizarTableDoacoes() {
    var urlListar = $("#hdnCaminhoAtualizarTableDoacoes").val();
    $("#ConteudoTableListarDoacoes").load(urlListar);
}