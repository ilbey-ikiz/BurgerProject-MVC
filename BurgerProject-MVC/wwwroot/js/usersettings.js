window.onload = function () {
    GetUserInformation();
};

function GetUserInformation() {
        $.ajax({
            url: "/UserSettings/UserInformation",
            type: "get",
            success: function (response) {
                $("#UserSetting").html(response);
            }
        });
    }

function GetUserInChangePassword(id) {
    $.ajax({
        url: "/UserSettings/UserPasswordChange",
        type: "get",
        success: function (response) {
            $("#UserSetting").html(response);
        }
    });
}

function GetUserInChangeAddress(id) {
    $.ajax({
        url: "/UserSettings/UserAddressChange",
        type: "get",
        success: function (response) {
            $("#UserSetting").html(response);
        }
    });
}

function GetUserInOrderHistory(id) {
    $.ajax({
        url: "/UserSettings/OrderHistory",
        type: "get",
        success: function (response) {
            $("#UserSetting").html(response);
        }
    });
}

