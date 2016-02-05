
/*
*   GLOBAL VARIABLES
*
*/

var err = "";
var isDisabled = true;


function setCookie(name, value, daysToLive) {
    var cookie = name + "=" + encodeURIComponent(value);
    if (typeof daysToLive === "number")
        cookie += "; max-age=" + (daysToLive * 60 * 60 * 24);
    document.cookie = cookie;
}

function loadUnits() {
    $.ajax({
        url: '/api/unit/list/',
        type: 'GET',
        contentType: "application/json;charset=utf-8",
        cache: false,
        success: function (result, status, xhr) {
            updateUnits(result);
        }
    });
}

function updateUnits(data) {
    var html = "";

    if (data != null || data != undefined) {

        $.each(data, function (index, value) {
            html += "<option value='" + data[index]["Id"] + "'>" + data[index]["Unit"] + "</option>";
        });
    }
    $('#unit').append(html);
}

function loadSupplier() {
    $.ajax({
        url: '/api/supplier/list/',
        type: 'GET',
        cache: false,
        contentType: "application/json;charset=utf-8",
        success: function (result, status, xhr) {
            updateSupplier(result);
        }
    });
}

function updateSupplier(result) {
    var html = "";

    if (result != null || result != undefined) {

        $.each(result, function (index, value) {
            html += "<option value='" + result[index]["Id"] + "'>" + result[index]["Supplier"] + "</option>";
        });
        $('#supplier').append(html);
    }
}

function getItem(id) {
    var islocked;
    $('#loadingModal').modal('show');
    $.ajax({
        url: '/api/item/search/' + id,
        type: 'GET',
        cache: false,
        contentType: 'application/json; charset=utf-8',
        success: function (result, status, xhr) {

            if (result != null || result != undefined) {
                $('#loadingModal').modal('hide');
            }
            updateFields(result);
        }
    });
    return islocked;
}
function updateFields(result) {

    if(result[0]["isLocked"] == true) {
        $('.dis').prop('disabled', true);
    }
    $('#itemCode').val(result[0]["ItemCode"]);
    $('#barCode').val(result[0]["BarCode"]);
    $('#itemDescription').val(result[0]["ItemDescription"]);
    $('#alias').val(result[0]["Alias"]);
    $('#unit').val(result[0]["UnitId"]);
    $('#cost').val(result[0]["Cost"]);
    $('#category').val(result[0]["Category"]);
    $('#markup').val(result[0]["MarkUp"]);
    $('#price').val(result[0]["Price"]);
    if (result[0]["IsInventory"] == 1) {
        $('#inventory').prop('checked', true);
    } else {
        $('#inventory').prop('checked', false);
    }
    if (result[0]["IsPackage"] == 1) {
        $('#package').prop('checked', true);
    } else {
        $('#package').prop('checked', false);
    }
    $('#onhandqty').val(result[0]["OnhandQuantity"]);
}

function editItem(id) {

    var ITEMDATA = validateFields();
    $('.dis').prop('disabled', true);
    $.ajax({
        url: '/api/item/update/' + id,
        type: 'PUT',
        dataType: 'json',
        data: ITEMDATA,
        contentType: "application/json;charset=utf-8",
        cache: false,
        statusCode: {
            200: function () {
                $('#msg-txt').css("color", "#66a3ff");
                $('#msg-txt').append("<h4>Item edited</h4>");
                $('#btn-close').text('Ok');
                $('#close').removeClass('btn btn-warning').addClass('btn btn-success');
                $('#warning').modal('show');
            },
            404: function () {
                $('#msg-txt').css("color", "#66a3ff");
                $('#msg-txt').append("<h4>Edit Failed</h4>");
                $('#btn-close').text('Close');
                $('#close').removeClass('btn btn-warning').addClass('btn btn-success');
                $('#warning').modal('show');
            },
            400: function () {
                $('#msg-txt').css("color", "#66a3ff");
                $('#msg-txt').append("<h4>Edit failed");
                $('#btn-close').text('Close');
                $('#close').removeClass('btn btn-warning').addClass('btn btn-success');
                $('#warning').modal('show');
            }
        }
    });
}

function addItem() {

    var ITEMDATA = validateFields();

    $('.dis').prop('disabled', true);
    $.ajax({
        url: '/api/item/add/',
        type: 'POST',
        data: ITEMDATA,
        contentType: "application/json;charset=utf-8",
        cache: false,
        success: function (data, status, xhr) {
            $('#msg-txt').css("color", "#66a3ff");
            $('#msg-txt').append("<h4>Item successfuly added</h4>");
            $('#msg-btn').removeClass('btn btn-warning').addClass('btn btn-success');
            $('#loadingModal').modal('show');
        }
    });
}

function validateFields() {
    var ITEMDATA = {};


    if ($('#barCode').val() == '' || $('#barCode').val() == undefined) {
        err += "Barcode is required <br />";

    } else {
        ITEMDATA.BarCode = $('#barCode').val();
    }
    if ($('#itemDescription').val() == "") {
        err += "Item description is required <br />";
    } else {
        ITEMDATA.ItemDescription = $('#itemDescription').val();
    }
    if ($('#alias').val() == "") {
        err += "Alias is required <br />";
    } else {
        ITEMDATA.Alias = $('#alias').val();
    }
    if ($('#category').val() == "") {
        err += "Category is required <br />";
    } else {
        ITEMDATA.Category = $('#category').val();
    }

    if ($('#cost').val() == "") {
        err += "Cost is required <br />";
    } else {
        ITEMDATA.Cost = $('#cost').val();
    }
    if ($('#markup').val() == "") {
        err += "Markup is required <br />";
    } else {
        ITEMDATA.MarkUp = $('#markup').val();
    }
    if ($('#price').val() == "") {
        err += "Price is required <br />";
    } else {
        ITEMDATA.Price = $('#price').val();
    }
    if ($('#onhandqty').val() == "") {
        err += "On hand quantity is required <br />";
    } else {
        ITEMDATA.OnhandQuantity = $('#onhandqty').val();
    }
    if ($('#inventory').prop('checked') == true) {
        ITEMDATA.IsIventory = 1
    } else {
        ITEMDATA.IsInventory = 0;
    }
    ITEMDATA.ExpiryDate = $('#expdate').val();
    ITEMDATA.ItemCode = $('#itemCode').val();
    ITEMDATA.GenericName = "Test-Geeneric name";
    ITEMDATA.SalesAccountId = 159;
    ITEMDATA.AssetAccountId = 74;
    ITEMDATA.CostAccountId = 238;
    ITEMDATA.InTaxId = 4;
    ITEMDATA.OutTaxId = 4;
    ITEMDATA.ImagePath = "C:\Sample\Path";
    ITEMDATA.ReOrderQuantity = 150;

    ITEMDATA.DefaultKitchenReport = "Test-DefaultKitchereport";
    if ($('#package').prop('checked') == true) {
        ITEMDATA.isPackage = 1;
    } else {
        ITEMDATA.isPackage = 0;
    }
    ITEMDATA.DefaultSupplierID = 23;
    ITEMDATA.UnitId = $('#unit').val();
    return JSON.stringify(ITEMDATA);
}

function error() {
    if (err != "") {
        return err;
    }
    return true;
}