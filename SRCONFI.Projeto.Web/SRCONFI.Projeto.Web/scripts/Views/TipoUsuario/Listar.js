(function () {

    $(document).ready(function () {



        $('#btnAbrirModalIncluir').click(function () {
            btnAbrirModalInserir_click();
        });

        $('#btnAbrirModalEditar').click(function () {
            var id = $('#tableTipoUsuario tr.clickable-row.active').attr('data-row-id');

            if (parseInt(id) > 0)
                btnAbrirModalEditar_click(id);
            else
                alertSistema(3, "Por favor, selecione uma linha da tabela!");

        });


        $('#btnExcluirTipoUsuario').click(function () {
            var id = $('#tableTipoUsuario tr.clickable-row.active').attr('data-row-id');

            if (parseInt(id) > 0)
                btnExcluirTipoUsuario_click(id);
            else
                alertSistema(3, 'Por favor, selecione uma linha da tabela!');

        });



    });


    function btnExcluirTipoUsuario_click(id) {
        confirmDialog('Excluir Tipo de Usuário!',
                      'Deseja Realmente Excluir esse tipo de usuário?',
                      excluirTipoUsuario,
                      id);
    }

    function excluirTipoUsuario(id) {
        $.post($("#hdnCaminhoExcluirTipoUsuario").val(), { id: id }, function (data) {
            if (data.erro) {

            } else {
                atualizarTableTipoUsuario();
                alertSistema(1, data.mensagem);
            }
        });
    }

    function btnAbrirModalEditar_click(id) {
        var urlModal = $("#hdnCaminhoModalEditarTipoUsuario").val();
        var urlEditar = $("#hdnCaminhoEditarTipoUsuario").val() + '?id=' + id;

        abrirModal(urlModal, urlEditar);
    }

    function btnAbrirModalInserir_click() {
        var urlModal = $("#hdnCaminhoModalInserirTipoUsuario").val();
        var urlInserir = $("#hdnCaminhoInserirTipoUsuario").val();

        abrirModal(urlModal, urlInserir);
    }



})();

function atualizarTableTipoUsuario() {
    var urlListar = $("#hdnCaminhoAtualizarTableTipoUsuario").val();
    $("#ConteudoTableListarTipoUsuario").load(urlListar);
}
