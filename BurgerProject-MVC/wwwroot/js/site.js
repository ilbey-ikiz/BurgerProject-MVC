function GetGarnitureList() {
    var garnitureList = $("#garnitureList");
    if ($("#categorySelect").val() == 1)
        garnitureList.show();
    else
        garnitureList.hide();
}

function Validation() {
    if ($("#garnitureList").val() == null) {
        $("#garnitureList").val() == empty;
    }
}


function UserCardCount() {

}