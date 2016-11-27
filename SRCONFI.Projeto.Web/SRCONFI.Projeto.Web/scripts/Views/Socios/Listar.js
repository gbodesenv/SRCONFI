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


        $('#btnExcluirSocio').click(function () {
            var id = $('#tableSocios tr.clickable-row.active').attr('data-row-id');

            if (parseInt(id) > 0)
                btnExcluirSocio_click(id);
            else
                alertSistema(3, 'Por favor, selecione uma linha da tabela!');

        });



    });


    function btnExcluirSocio_click(id) {
        confirmDialog('Excluir Sócio!',
                      'Deseja Realmente Excluir esse sócio?',
                      excluirSocio,
                      id);
    }
    function excluirSocio(id) {
        $.post($("#hdnCaminhoExcluirSocio").val(), { id: id }, function (data) {
            if (data.erro) {
            } else {
                atualizarTableSocios();
                alertSistema(1, data.mensagem);
            }
        });
    }

    function btnAbrirModalEditar_click(id) {
        var urlModal = $("#hdnCaminhoModalEditarSocio").val();
        var urlEditar = $("#hdnCaminhoEditarSocio").val() + '?id=' + id;

        abrirModal(urlModal, urlEditar);
    }

    function btnAbrirModalInserir_click() {
        var urlModal = $("#hdnCaminhoModalInserirSocio").val();
        var urlInserir = $("#hdnCaminhoInserirSocio").val();

        abrirModal(urlModal, urlInserir);
    }



})();

function atualizarTableSocios() {
    var urlListar = $("#hdnCaminhoAtualizarTableSocio").val();
    $("#ConteudoTableListarSocios").load(urlListar);
}