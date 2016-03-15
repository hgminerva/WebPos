

function addSupplier() {
    var data = getData();

    if (data != false) {
        $.ajax({
            url: '/api/supplier/add',
            cache: false,
            type: 'POST',
            contentType: "application/json;charset=utf-8",
            data: data,
            success: function (data, status, xhr) {
                message("New supplier added");
                $('.dis').prop('disabled', true);
                $('#lock').prop('disabled', true);
            }
        });
    } else {
        message("Failed to edit supplier");
    }
}
function loadSupplier(id) {
    if (id != null || id != undefined) {
        $.ajax({
            url: '/api/supplier/search/' + id,
            type: 'GET',
            contentType: "application/json;charset=utf-8",
            cache: false,
            success: function (result, status, xhr) {
                updateFields(result);
            }
        });
    }
}
function updateFields(result) {
    if (result != null || result != undefined) {
        $('#supplier').val(result[0]["Supplier"]);
        $('#address').val(result[0]["Address"]);
        $('#telNo').val(result[0]["TelephoneNumber"]);
        $('#celNo').val(result[0]["CelphoneNumber"]);
        $('#foxNo').val(result[0]["FaxNumber"]);
        $('#term').val(result[0]["TermId"]);
        $('#tin').val(result[0]["TIN"]);
        $('#araccount').val(result[0]["AccountId"]);
    }
}
function editSupplier(id) {
    var data = getData();
   
    if (data != false) {
        $.ajax({
            url: '/api/supplier/update/' + id,
            type: 'PUT',
            data: data,
            contentType: "application/json;charset=utf-8",
            cache: false,
            statusCode: {
                200: function () {
                    $('#lock').prop('disabled', true);
                    message("Edit success");
                    $('.dis').prop('disabled', true);
                },
                404: function () {
                    message("Edit Failed");
                },
                400: function () {
                    message("Edit Failed");
                }
            }
        });
    } else {
        message("Edit Failed");
    }
}
function message(msg) {
    $('#msg-txt').css("color", "#66a3ff");
    $('#msg-txt').empty();
    $('#msg-txt').append("<h4>"+ msg + "</h4>");
    $('#btn-close').text('Ok');
    $('#close').removeClass('btn btn-warning').addClass('btn btn-success');
    $('#warning').modal('show');
}
function getData() {

    var data = {};
    err = false;

    if ($('#supplier').val() != "") {
        data.Supplier = $('#supplier').val();
    } else {
        err = true;
        $('#sup-err').show();
    }
    if ($('#address').val() != "") {
        data.Address = $('#address').val();
    } else {
        data.Address = "NA";
    }
    if ($('#telNo').val() != "") {
        data.TelephoneNumber = $('#telNo').val();
    } else {
        data.TelephoneNumber = "NA";
    }
    if ($('#celNo').val() != "") {
        data.CellphoneNumber = $('#celNo').val();
    } else {
        data.CellphoneNumber = "NA";
    }
    if ($('#foxNo').val() != "") {
        data.FaxNumber = $('#foxNo').val();
    } else {
        data.FaxNumber = "NA";
    }
    data.TermId = $('#term');
    if ($('#tin').val() != "") {
        data.TIN = $('#tin').val();
    } else {
        data.TIN = "NA";
    }
    data.TermId = $('#term').val();
    data.AccountId = $('#araccount').val();

    if (err) {
        return false;
    } else {
        return JSON.stringify(data);
    }
}