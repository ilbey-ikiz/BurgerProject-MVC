function EditAddress(addressId) {
    var textarea = document.getElementById("myAddress-" + addressId);
    textarea.removeAttribute("readonly");
}

function FocusChange(addressID) {
    var textarea = document.getElementById("myAddress-" + addressID);
    $.ajax({
        url: "/UserSettings/UpdateAddress/" + addressID,
        type: "post",
        data: { description: textarea.value },
        success: function (response) {
            textarea.setAttribute("readonly", "readonly");
        }
    });
}



function DeleteAddress(id) {
    var div = document.getElementById("myDiv-" + id);
    var textarea = document.getElementById("myAddress-" + id);
    var confirmed = confirm("Are you sure you want to delete this address?");

    if (confirmed) {

        $.ajax({
            url: "/UserSettings/DeleteAddress/" + id,
            type: "get",
            success: function (response) {
                while (div.firstChild) {
                    div.firstChild.remove();
                }
                div.remove();
                textarea.remove();
            },
            error: function (xhr, status, error) {
                console.error("Error deleting address:", error);
            }
        });
    }
}


function saveChanges(id) {
    var newAddress = document.querySelector("#newAddress").value;

    $.ajax({
        url: "/UserSettings/AddAddress/" + id,
        type: "post",
        data: { newAddress: newAddress },
        success: function (response) {
            var address = response;

            var addressesContainer = document.querySelector('.form-outline.mb-4');
            var newAddressElement = document.createElement('div');
            newAddressElement.innerHTML = `
                <div class="d-flex justify-content-between" id="myDiv-${address[0]}">
                    <div>
                        <label class="form-label" for="form7example7">Address:</label>
                    </div>
                    <div>
                        <a onclick="EditAddress('${address[0]}')"><img src="/ProductsImages/668310.png" style="height:20px; cursor:pointer;"></a>
                        <a onclick="DeleteAddress('${address[0]}')"><img src="/ProductsImages/3311484.png" style="height:20px; cursor:pointer;"></a>
                    </div>
                </div>
                <textarea class="form-control" id="myAddress-${address[0]}" onblur="FocusChange('${address[0]}')" rows="4" readonly>${address[1]}</textarea>
            `;
            addressesContainer.appendChild(newAddressElement);

            document.querySelector("#newAddress").value = "";
        }
    });
}







