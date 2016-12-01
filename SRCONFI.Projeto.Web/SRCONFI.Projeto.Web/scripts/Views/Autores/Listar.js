(function () {

    $(document).ready(function () {



        $('#btnAbrirModalIncluir').click(function () {
            btnAbrirModalInserir_click();
        });

        $('#btnAbrirModalEditar').click(function () {
            var id = $('#tableAutores tr.clickable-row.active').attr('data-row-id');

            if (parseInt(id) > 0)
                btnAbrirModalEditar_click(id);
            else
                alertSistema(3, "Por favor, selecione uma linha da tabela!");

        });


        $('#btnExcluirAutores').click(function () {
            var id = $('#tableAutores tr.clickable-row.active').attr('data-row-id');

            if (parseInt(id) > 0)
                btnExcluirAutor_click(id);
            else
                alertSistema(3, 'Por favor, selecione uma linha da tabela!');

        });



    });


    function btnExcluirAutor_click(id) {
        confirmDialog('Excluir Autor!',
                      'Deseja Realmente Excluir esse autor?',
                      excluirAutor,
                      id);
    }

    function excluirAutor(id) {
        $.post($("#hdnCaminhoExcluirAutor").val(), { id: id }, function (data) {
            if (data.erro) {

            } else {
                atualizarTableAutores();
                alertSistema(1, data.mensagem);
            }
        });
    }

    function btnAbrirModalEditar_click(id) {
        var urlModal = $("#hdnCaminhoModalEditarAutor").val();
        var urlEditar = $("#hdnCaminhoEditarAutor").val() + '?id=' + id;

        abrirModal(urlModal, urlEditar);
    }

    function btnAbrirModalInserir_click() {
        var urlModal = $("#hdnCaminhoModalInserirAutor").val();
        var urlInserir = $("#hdnCaminhoInserirAutor").val();

        abrirModal(urlModal, urlInserir);
    }



})();

function atualizarTableAutores() {
    var urlListar = $("#hdnCaminhoAtualizarTableAutores").val();
    $("#ConteudoTableListarAutores").load(urlListar);
}
