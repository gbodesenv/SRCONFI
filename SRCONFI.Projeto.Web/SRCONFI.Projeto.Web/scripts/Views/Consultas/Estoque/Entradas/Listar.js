(function () {

    $(document).ready(function () {
        

        $('#btnImprimirEstoque').click(function () {
            var id = $('#tableEstoque tr.clickable-row.active').attr('data-row-id');

            if (parseInt(id) > 0)
                btnExcluirAutor_click(id);
            else
                alertSistema(3, 'Por favor, selecione uma linha da tabela!');

        });



    });


    function excluirAutor(id) {
        $.post($("#hdnCaminhoExcluirAutor").val(), { id: id }, function (data) {
            if (data.erro) {

            } else {
                atualizarTableEstoque();
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

function atualizarTableEstoque() {
    var urlListar = $("#hdnCaminhoAtualizarTableEstoque").val();
    $("#ConteudoTableListarEstoque").load(urlListar);
}
