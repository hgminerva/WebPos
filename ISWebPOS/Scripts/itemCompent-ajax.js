


(function () {
    if (localStorage.getItem("units") != null) {
        loadUnits();
    }
    if (localStorage.getItem("items") != null) {
        loadItems();
    }
})();


function loadUnits() {
    $.ajax({
        url: '/api/unit/list/',
        type: 'GET',
        contentType: "application/json;charset=utf-8",
        cache: false,
        success: function (data, status, xhr) {
            localStorage.setItem("units", JSON.stringify(data));
        }
    });
}
function loadItems() {
    $.ajax({
        url: '/api/item/list/',
        cache : false,
        type: 'GET',
        contentType: "application/json;charset=utf-8",
        success: function (data, status, xhr) {
            
        }
    });
}