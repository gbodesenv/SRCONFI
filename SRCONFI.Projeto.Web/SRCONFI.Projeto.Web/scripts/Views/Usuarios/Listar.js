(function () {

    $(document).ready(function () {

      

        $('#btnAbrirModalIncluir').click(function () {
            btnAbrirModalInserir_click();
        });

        $('#btnAbrirModalEditar').click(function () {
            var id = $('#tableUsuarios tr.clickable-row.active').attr('data-row-id');

            if (parseInt(id) > 0)
                btnAbrirModalEditar_click(id);
            else
                alert('Por favor, selecione uma linha da tabela!');

        });


        $('#btnExcluirUsuario').click(function () {
            var id = $('#tableUsuarios tr.clickable-row.active').attr('data-row-id');

            if (parseInt(id) > 0)
                btnExcluirUsuario_click(id);
            else
                alert('Por favor, selecione uma linha da tabela!');

        });



    });


    function btnExcluirUsuario_click(id) {
        confirmDialog('Excluir Usuário!',
                      'Deseja Realmente Excluir esse usuário?',
                      excluirUsuario,
                      id);
    }

    function excluirUsuario(id) {
        $.post($("#hdnCaminhoExcluirUsuario").val(), { id: id }, function (data) {
            if (data.erro) {

            } else {
                atualizarTableUsuarios();
                alert(data.mensagem);
            }
        });
    }

    function btnAbrirModalEditar_click(id) {
        var urlModal = $("#hdnCaminhoModalEditarUsuario").val();
        var urlEditar = $("#hdnCaminhoEditarUsuario").val() + '?id=' + id;

        abrirModal(urlModal, urlEditar);
    }

    function btnAbrirModalInserir_click() {
        var urlModal = $("#hdnCaminhoModalInserirUsuario").val();
        var urlInserir = $("#hdnCaminhoInserirUsuario").val();

        abrirModal(urlModal, urlInserir);
    }

    function atualizarTableUsuarios() {
        var urlListar = $("#hdnCaminhoAtualizarTableUsuario").val();
        $("#ConteudoTableListarUsuario").load(urlListar);
    }

})();
