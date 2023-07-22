function GetProductDetail() {
    $.ajax({
        url: "/Product/ProductDetail",
        type: "get",
        success: function (response) {
            $("#productDetail").html(response)
        }
    })
}

