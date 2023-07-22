
function DeleteProduct(id) {
    if (confirm("Are you sure you want to delete this? "))
        $.ajax({
            url: "/Admin/Products/Delete/" + id,
            type: "get",
            success: function (response) {
                window.location.href = "/Admin/Products/Index";
            }
        })
}

function DeleteMenu(id) {
    if (confirm("Are you sure you want to delete this? "))
        $.ajax({
            url: "/Admin/Menus/Delete/" + id,
            type: "get",
            success: function (response) {
                window.location.href = "/Admin/Menus/Index";
            }
        })
}

function DeleteGarniture(id) {
    if (confirm("Are you sure you want to delete this? "))
        $.ajax({
            url: "/Admin/Garnitures/Delete/" + id,
            type: "get",
            success: function (response) {
                window.location.href = "/Admin/Garnitures/Index";
            }
        })
}


