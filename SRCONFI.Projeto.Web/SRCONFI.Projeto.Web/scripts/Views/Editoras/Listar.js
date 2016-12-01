(function () {

    $(document).ready(function () {



        $('#btnAbrirModalIncluir').click(function () {
            btnAbrirModalInserir_click();
        });

        $('#btnAbrirModalEditar').click(function () {
            var id = $('#tableEditoras tr.clickable-row.active').attr('data-row-id');

            if (parseInt(id) > 0)
                btnAbrirModalEditar_click(id);
            else
                alertSistema(3, "Por favor, selecione uma linha da tabela!");

        });


        $('#btnExcluirEditoras').click(function () {
            var id = $('#tableEditoras tr.clickable-row.active').attr('data-row-id');

            if (parseInt(id) > 0)
                btnExcluirEditora_click(id);
            else
                alertSistema(3, 'Por favor, selecione uma linha da tabela!');

        });



    });


    function btnExcluirEditora_click(id) {
        confirmDialog('Excluir Editora!',
                      'Deseja Realmente Excluir esse usuário?',
                      excluirEditora,
                      id);
    }

    function excluirEditora(id) {
        $.post($("#hdnCaminhoExcluirEditora").val(), { id: id }, function (data) {
            if (data.erro) {

            } else {
                atualizarTableEditoras();
                alertSistema(1, data.mensagem);
            }
        });
    }

    function btnAbrirModalEditar_click(id) {
        var urlModal = $("#hdnCaminhoModalEditarEditora").val();
        var urlEditar = $("#hdnCaminhoEditarEditora").val() + '?id=' + id;

        abrirModal(urlModal, urlEditar);
    }

    function btnAbrirModalInserir_click() {
        var urlModal = $("#hdnCaminhoModalInserirEditora").val();
        var urlInserir = $("#hdnCaminhoInserirEditora").val();

        abrirModal(urlModal, urlInserir);
    }



})();

function atualizarTableEditoras() {
    var urlListar = $("#hdnCaminhoAtualizarTableEditora").val();
    $("#ConteudoTableListarEditoras").load(urlListar);
}
