window.onload = function () {
    GetMenuSaleReport();
};
function GetProductSaleReport() {
    $.ajax({
        url: "/Admin/Reports/ProductSalesReport",
        type: "get",
        success: function (response) {
            $("#totalNumberOfSales").html(response);
        }
    })
}

function GetMenuSaleReport() {
    $.ajax({
        url: "/Admin/Reports/MenuSalesReport",
        type: "get",
        success: function (response) {
            $("#totalNumberOfSales").html(response);
        }
    })
}