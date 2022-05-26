function updateToggle(status) {
    status = $.trim(status);
    let button = $(".toggle");

    if (status === "true") {
        button.text("LED IS ON")
    } else {
        button.text("LED IS OFF")
    }
}

function removeSomee() {
    $("center").each(function () {
        if ($(this).html() === '<a href="http://somee.com">Web hosting by Somee.com</a>') {
            $(this).next().remove();
            $(this).next().next().remove();
            $(this).next().next().next().remove();
            $(this).remove();

            return false;
        }
    });
}

function main() {
    $(document).ready(function () {
        removeSomee();
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
    });
}

main();