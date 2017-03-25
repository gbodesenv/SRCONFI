$(document).ready(function () {
    $("#btnIncluirSocios").click(function () {
        inserirSocio();
    });

    $('#DadosComplementares_dataNascSocio').change(function () {
        var data = $(this).datepicker("getDate");
        if (data != "" && data != undefined)
            $("#idadeCalculo").val(_calculateAge(data));
    });


    $('.mask-date').change(function () {
        $(this).mask('00/00/0000');        
    });

    setarMascaras();

});


function setarMascaras() {
    $('.numeric-places').mask("#.##0,00", { reverse: true });

    $('.mask-date').mask('00/00/0000');

    maskFormat();

}

function _calculateAge(birthday) { // birthday is a date
    var ageDifMs = Date.now() - birthday.getTime();
    var ageDate = new Date(ageDifMs); // miliseconds from epoch
    return Math.abs(ageDate.getUTCFullYear() - 1970);
}


function abrirModalEditar(id) {
    var urlModal = $("#hdnCaminhoModalEditarSocio").val();
    var urlEditar = $("#hdnCaminhoEditarSocio").val() + '?id=' + id;

    abrirModal(urlModal, urlEditar);
}

function inserirSocio() {
    var validForm = $('#formInserirSocio').parsley();
    var form = $('#formInserirSocio').serializeObject();

    if (validForm.validate()) {
        $.ajax({
            url: $('#hdnCaminhoInserirSocio').val(),
            type: "POST",
            data: JSON.stringify({ socios: form }),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (!data.erro) {
                    atualizarTableSocios();
                    abrirModalEditar(data.id);
                    alertSistema(1, data.mensagem);
                }
                else {
                    alertSistema(2, data.mensagem);
                }

            },
            error: function (response) {
                var r = jQuery.parseJSON(response.responseText);
                alert("Message: " + r.Message);
                alert("StackTrace: " + r.StackTrace);
                alert("ExceptionType: " + r.ExceptionType);
            }
        });
    }
}