$(document).ready(GetMenuList())

function GetProductList(id) {
    $.ajax({
        url: "/Product/ProductList/" + id,
        type: "get",
        success: function (response) {
            $("#productList").html(response)
            $("#menuList").html("")
        }
    })
}

function GetMenuList() {
    $.ajax({
        url: "/Product/MenuList",
        type: "get",
        success: function (response) {
            $("#productList").html("")
            $("#menuList").html(response)
        }
    })
}

