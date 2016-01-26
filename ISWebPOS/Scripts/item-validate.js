$(document).ready(function () {

    
    $('#itemCode').val(localStorage.getItem("lastCode"));
    var ITEMDATA = {};
    var err = "";
    var rdr = false;
    
    $(':input:first').focus();
    $('.itemdis').prop('disabled', true);


    $('#lock-key').click(function () {


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
        if ($('#expdate').val() == "") {
            err += "Expiry date is requried <br />";
        } else {
            ITEMDATA.ExpiryDate = $('#expdate').val();
        }


        ITEMDATA.ItemCode = "12110755";
        ITEMDATA.GenericName = "Test-Geeneric name";
        ITEMDATA.SalesAccountId = 159;
        ITEMDATA.AssetAccountId = 74;
        ITEMDATA.CostAccountId = 238;
        ITEMDATA.InTaxId = 4;
        ITEMDATA.OutTaxId = 4;
        ITEMDATA.ImagePath = "C:\Sample\Path";
        ITEMDATA.ReOrderQuantity = 150;
        ITEMDATA.DefaultKitchenReport = "Test-DefaultKitchereport";
        ITEMDATA.isPackage = 1;
        ITEMDATA.DefaultSupplierID = 23;
        ITEMDATA.UnitId = 1;
        
        if (err != "") {
            $('#msg-txt').append('<h2>Attention&nbsp;<span class="glyphicon glyphicon-warning-sign" aria-hidden="true">&nbsp;</span></h2>');
            $('#msg-txt').append(err);
            $('#msg-txt').css("color", "red");
            $('#loadingModal').modal("show");
        
            err = "";
        } else {

            $('.dis').prop('disabled', true);
            $.ajax({
                url: '/api/item/add/',
                type : 'POST',
                data: JSON.stringify(ITEMDATA),
                contentType: "application/json;charset=utf-8",
                cache: false,
                success: function (data, status, xhr) {
                    var result = JSON.parse(data);
                    $('#msg-txt').css("color", "#66a3ff");
                    $('#msg-txt').append("<h4>Item successfuly" + result + " added</h4>");
                    $('#msg-btn').removeClass('btn btn-warning').addClass('btn btn-success');
                    $('#loadingModal').modal('show');
                    rdr = true;
                    setCookie(data, 30);
                }
            });
        }
    });
    $('#unlock-key').click(function () {
        $('.dis').prop('disabled', false);
    });

    $('#close').click(function () {
        window.location = "/Software/Dashboard";
    });

    $('#msg-btn').click(function () {
        if (rdr == true) {
            $('#loadingModal').modal("hide");
            $('#msg-txt').html('');
            window.location.href = "/Software/Item";
        } else {
            $('#msg-txt').html('');
            $('#loadingModal').modal("hide");
        }
    });

    loadLastItemCode();

});

function setCookie(name, value, daysToLive) {
    var cookie = name + "=" + encodeURIComponent(value);
    if (typeof daysToLive === "number")
        cookie += "; max-age=" + (daysToLive * 60 * 60 * 24);
    document.cookie = cookie;
}

function loadLastItemCode() {

    $.ajax({
        url: '/api/item/lastitemcode/',
        type: 'GET',
        async: true,
        success: function (data, status, xhr) {
            var result = JSON.parse(data);

            alert(result);
        }
    });
}