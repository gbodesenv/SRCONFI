$(document).ready(function () {
    $("#btnCloseModalFirst").click(function () {
        closeModal();
    });

    $("#btnFooterCloseModalFirst").click(function () {
        closeModal();
    });

});

function closeModal() {    
    $("#modal.first").modal('hide');
}
