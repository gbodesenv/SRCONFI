(function () {

    $(document).ready(function () {



        $('#btnAbrirModalIncluir').click(function () {
            btnAbrirModalInserir_click();
        });

        $('#btnAbrirModalEditar').click(function () {
            var id = $('#tableSocios tr.clickable-row.active').attr('data-row-id');

            if (parseInt(id) > 0)
                btnAbrirModalEditar_click(id);
            else
                alertSistema(3, "Por favor, selecione uma linha da tabela!");

        });


        $('#btnExcluirSocios').click(function () {
            var id = $('#tableSocios tr.clickable-row.active').attr('data-row-id');

            if (parseInt(id) > 0)
                btnExcluirSocios_click(id);
            else
                alertSistema(3, 'Por favor, selecione uma linha da tabela!');

        });



    });


    function btnExcluirSocios_click(id) {
        confirmDialog('Excluir Usuário!',
                      'Deseja Realmente Excluir esse usuário?',
                      excluirSocios,
                      id);
    }

    function excluirSocios(id) {
        $.post($("#hdnCaminhoExcluirSocios").val(), { id: id }, function (data) {
            if (data.erro) {

            } else {
                atualizarTableSocios();
                alertSistema(1, data.mensagem);
            }
        });
    }

    function btnAbrirModalEditar_click(id) {
        var urlModal = $("#hdnCaminhoModalEditarSocios").val();
        var urlEditar = $("#hdnCaminhoEditarSocios").val() + '?id=' + id;

        abrirModal(urlModal, urlEditar);
    }

    function btnAbrirModalInserir_click() {
        var urlModal = $("#hdnCaminhoModalInserirSocios").val();
        var urlInserir = $("#hdnCaminhoInserirSocios").val();

        abrirModal(urlModal, urlInserir);
    }



})();

function atualizarTableSocios() {
    var urlListar = $("#hdnCaminhoAtualizarTableSocios").val();
    $("#ConteudoTableListarSocios").load(urlListar);
}
