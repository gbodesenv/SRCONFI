(function () {

    $(document).ready(function () {



        $('#btnAbrirModalIncluir').click(function () {
            btnAbrirModalInserir_click();
        });

        $('#btnAbrirModalEditar').click(function () {
            var id = $('#tableLivros tr.clickable-row.active').attr('data-row-id');

            if (parseInt(id) > 0)
                btnAbrirModalEditar_click(id);
            else
                alertSistema(3, "Por favor, selecione uma linha da tabela!");

        });


        $('#btnExcluirLivro').click(function () {
            var id = $('#tableLivros tr.clickable-row.active').attr('data-row-id');

            if (parseInt(id) > 0)
                btnExcluirLivro_click(id);
            else
                alertSistema(3, 'Por favor, selecione uma linha da tabela!');

        });



    });


    function btnExcluirLivro_click(id) {
        confirmDialog('Excluir Livro!',
                      'Deseja Realmente Excluir esse usuário?',
                      excluirLivro,
                      id);
    }

    function excluirLivro(id) {
        $.post($("#hdnCaminhoExcluirLivro").val(), { id: id }, function (data) {
            if (data.erro) {

            } else {
                atualizarTableLivros();
                alertSistema(1, data.mensagem);
            }
        });
    }

    function btnAbrirModalEditar_click(id) {
        var urlModal = $("#hdnCaminhoModalEditarLivro").val();
        var urlEditar = $("#hdnCaminhoEditarLivro").val() + '?id=' + id;

        abrirModal(urlModal, urlEditar);
    }

    function btnAbrirModalInserir_click() {
        var urlModal = $("#hdnCaminhoModalInserirLivro").val();
        var urlInserir = $("#hdnCaminhoInserirLivro").val();

        abrirModal(urlModal, urlInserir);
    }



})();

function atualizarTableLivros() {
    var urlListar = $("#hdnCaminhoAtualizarTableLivro").val();
    $("#ConteudoTableListarLivros").load(urlListar);
}
