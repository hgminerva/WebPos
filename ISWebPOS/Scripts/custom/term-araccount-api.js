
function loadTerm() {
    $.ajax({
        url: '/api/term/list',
        type: 'GET',
        contentType: "application/json;charset=utf-8",
        cache: false,
        success: function (result, status, xhr) {
            updateTerm(result);
        }
    });
}

function updateTerm(data) {
    var html;
    if (data != null || data != undefined) {
        $.each(data, function (index, value) {
            html += "<option value='" + data[index]["Id"] + "'>" + data[index]["Term"] + "</option>";
        });
        $('#term').append(html);
    }
}

function loadARAcount() {
    $.ajax({
        url: '/api/account/list',
        type: 'GET',
        contentType: "application/json;charset=utf-8",
        cache: false,
        success: function (result, status, xhr) {
            updateAR_Account(result);
        }
    });
}
function updateAR_Account(data) {
    var html;
    if (data != null || data != undefined) {
        $.each(data, function (index, value) {
            html += "<option value='" + data[index]["Id"] + "'>" + data[index]["Account"] + "</option>";
        });
        $('#araccount').append(html);
    }
}
