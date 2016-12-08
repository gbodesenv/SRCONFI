$(document).ready(function () {
    $("#btnEditarSocios").click(function () {
        editarSocio();
    });

    $("#Endereco_numero").formatter({
        'pattern': '{{9999}}',
        'persistent': true
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


function setarCampoIdade() {
    $("#idadeCalculo").val(_calculateAge($('#DadosComplementares_dataNascSocio').datepicker("getDate")));
}

function _calculateAge(birthday) { // birthday is a date
    var ageDifMs = Date.now() - birthday.getTime();
    var ageDate = new Date(ageDifMs); // miliseconds from epoch
    return Math.abs(ageDate.getUTCFullYear() - 1970);
}



function editarSocio() {
    
    var validForm = $('#formEditarSocio').parsley();
    var form = $('#formEditarSocio').serializeObject();

    console.log(form);

    if (validForm.validate()) {
        $.ajax({
            url: $('#hdnCaminhoEditarSocio').val(),
            type: "POST",
            data: JSON.stringify({ socios: form }),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (!data.erro) {
                    atualizarTableSocios();
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