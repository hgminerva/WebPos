
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

    var itemdata = validateFields();
    $('.dis').prop('disabled', true);
    $.ajax({
        url: '/api/item/update/' + id,
        type: 'PUT',
        dataType: 'json',
        data: itemdata,
        contentType: "application/json;charset=utf-8",
        cache: false,
        statusCode: {
            200: function () {
                message("Edit success");
            },
            404: function () {
                message("Edit failed");
            },
            400: function () {
                message("Edit failed");
            }
        }
    });
}
function message(msg) {
    $('#msg-txt').css("color", "#66a3ff");
    $('#msg-txt').append("<h4>" + msg + "</h4>");
    $('#btn-close').text('Ok');
    $('#close').removeClass('btn btn-warning').addClass('btn btn-success');
    $('#warning').modal('show');
}
function addItem() {

    var itemdata = validateFields();

    $('.dis').prop('disabled', true);
    $.ajax({
        url: '/api/item/add/',
        type: 'POST',
        data: itemdata,
        contentType: "application/json;charset=utf-8",
        cache: false,
        statusCode:{
            200: function(){
                window.location.href = isHost + "/Software/Item";
            },
            400: function () {
                alert("Error");
            },
        }
    });

}
function message(msg) {
    $('#msg-txt').css("color", "#66a3ff");
    $('#msg-txt').append("<h4>" + msg + "</h4>");
    $('#btn-close').text('Ok');
    $('#close').removeClass('btn btn-warning').addClass('btn btn-success');
    $('#warning').modal('show');
}
function validateFields() {
    var itemdata = {};

    if ($('#barCode').val() == '' || $('#barCode').val() == undefined) {
        itemdata.BarCode = "NA"
    } else {
        itemdata.BarCode = $('#barCode').val();
    }
    if ($('#itemDescription').val() == "") {
        itemdata.ItemDescription = "NA";
    } else {
        itemdata.ItemDescription = $('#itemDescription').val();
    }
    if ($('#alias').val() == "") {
        itemdata.Alias = "NA";
    } else {
        itemdata.Alias = $('#alias').val();
    }
    if ($('#category').val() == "") {
        itemdata.Category = "NA";
    } else {
        itemdata.Category = $('#category').val();
    }

    if ($('#cost').val() == "") {
        itemdata.Cost = "NA";
    } else {
        itemdata.Cost = $('#cost').val();
    }
    if ($('#markup').val() == "") {
        itemdata.MarkUp = "NA";
    } else {
        itemdata.MarkUp = $('#markup').val();
    }
    if ($('#price').val() == "") {
        itemdata.Price = "NA";
    } else {
        itemdata.Price = $('#price').val();
    }
    if ($('#onhandqty').val() == "") {
        itemdata.OnhandQuantity = "NA";
    } else {
        itemdata.OnhandQuantity = $('#onhandqty').val();
    }
    if ($('#inventory').prop('checked') == true) {
        itemdata.IsIventory = 1
    } else {
        itemdata.IsInventory = 0;
    }
    itemdata.ExpiryDate = $('#expdate').val();
    itemdata.ItemCode = $('#itemCode').val();
    itemdata.GenericName = "Test-Geeneric name";
    itemdata.SalesAccountId = 159;
    itemdata.AssetAccountId = 74;
    itemdata.CostAccountId = 238;
    itemdata.InTaxId = 4;
    itemdata.OutTaxId = 4;
    itemdata.ImagePath = "C:\Sample\Path";
    itemdata.ReOrderQuantity = 150;

    itemdata.DefaultKitchenReport = "Test-DefaultKitchereport";
    if ($('#package').prop('checked') == true) {
        itemdata.isPackage = 1;
    } else {
        itemdata.isPackage = 0;
    }
    itemdata.DefaultSupplierID = 23;
    itemdata.UnitId = $('#unit').val();

    return JSON.stringify(itemdata);
}
