(function () {

    $(document).ready(function () {

        $("#tableUsuarios").on("click", ".clickable-row", function (event) {
            $(this).addClass('active').siblings().removeClass('active');
        });

        $('#btnIncluir').click(function () {
            var urlModal = $("#hdnCaminhoModalInserirUsuario").val();
            var urlInserir = $("#hdnCaminhoInserirUsuario").val();

            abrirModal(urlModal, urlInserir);
        });
    });


    function abrirModal(urlModal, urlBodyModal) {
        $("#modal").load(urlModal, function () {
            $("#modal .modal-body.first").load(urlBodyModal, function () {
                $("#modal").modal();
            });
        });
    }

})();
