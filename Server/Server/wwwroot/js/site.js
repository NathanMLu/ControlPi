function updateToggle(status) {
    status = $.trim(status);
    let button = $(".toggle");
    
    if (status === "true") {
        button.text("LED IS ON")
    } else {
        button.text("LED IS OFF")
    }
}

function main() {
    let button = $(".toggle");

    button.click(function () {
        // Ajax request
        $.ajax({
            url: "/api/toggleled/",
            type: "POST",
            success: function (data) {
                // console.log("Success: " + data);
                updateToggle(data);
            },
            error: function (data) {
                console.log("Error: " + data);
            }
        });
    });
}

main();