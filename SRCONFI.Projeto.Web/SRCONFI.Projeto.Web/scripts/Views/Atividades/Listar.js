(function () {

    $(document).ready(function () {



        $('#btnAbrirModalIncluir').click(function () {
            btnAbrirModalInserir_click();
        });

        $('#btnAbrirModalEditar').click(function () {
            var id = $('#tableAtividades tr.clickable-row.active').attr('data-row-id');

            if (parseInt(id) > 0)
                btnAbrirModalEditar_click(id);
            else
                alertSistema(3, "Por favor, selecione uma linha da tabela!");

        });


        $('#btnExcluirAtividade').click(function () {
            var id = $('#tableAtividades tr.clickable-row.active').attr('data-row-id');

            if (parseInt(id) > 0)
                btnExcluirAtividade_click(id);
            else
                alertSistema(3, 'Por favor, selecione uma linha da tabela!');

        });



    });


    function btnExcluirAtividade_click(id) {
        confirmDialog('Excluir Atividade!',
                      'Deseja Realmente Excluir esse sócio?',
                      excluirAtividade,
                      id);
    }
    function excluirAtividade(id) {
        $.post($("#hdnCaminhoExcluirAtividade").val(), { id: id }, function (data) {
            if (data.erro) {
            } else {
                atualizarTableAtividades();
                alertSistema(1, data.mensagem);
            }
        });
    }

    function btnAbrirModalEditar_click(id) {
        var urlModal = $("#hdnCaminhoModalEditarAtividade").val();
        var urlEditar = $("#hdnCaminhoEditarAtividade").val() + '?id=' + id;

        abrirModal(urlModal, urlEditar);
    }

    function btnAbrirModalInserir_click() {
        var urlModal = $("#hdnCaminhoModalInserirAtividade").val();
        var urlInserir = $("#hdnCaminhoInserirAtividade").val();

        abrirModal(urlModal, urlInserir);
    }



})();

function atualizarTableAtividades() {
    var urlListar = $("#hdnCaminhoAtualizarTableAtividade").val();
    $("#ConteudoTableListarAtividades").load(urlListar);
}