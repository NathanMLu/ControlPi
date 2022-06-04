function updateToggle(status) {
    status = $.trim(status);
    const button = $(".toggle");

    if (status === "true") {
        button.text("LED IS ON")
    } else {
        button.text("LED IS OFF")
    }
}

async function updateUI() {
    setInterval(function () {
        $.ajax({
            url: "/api/ledstatus/",
            type: "POST",
            success: function (data) {
                updateToggle(data);
            },
            error: function (data) {
                console.log(`Error: ${data}`);
            }
        });
    }, 1000);
}

function main() {
    $(document).ready(function () {
        updateUI();
        let button = $(".toggle");
        
        button.click(function () {
            // Ajax request
            $.ajax({
                url: "/api/toggleled/",
                type: "POST",
                success: function (data) {
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