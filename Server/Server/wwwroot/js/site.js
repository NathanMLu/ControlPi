function updateToggle(status) {
    status = $.trim(status);
    let button = $(".toggle");

    if (status === "true") {
        button.text("LED IS ON")
    } else {
        button.text("LED IS OFF")
    }
}

function SomeeAdsRemover() {
    console.log("removed?");
    $('script[language="JavaScript"]').remove();
    $('script[src="http://ads.mgmt.somee.com/serveimages/ad2/WholeInsert5.js"]').remove();
    $("div[style='opacity: 0.9; z-index: 2147483647; position: fixed; left: 0px; bottom: 0px; height: 65px; right: 0px; display: block; width: 100%; background-color: #202020; margin: 0px; padding: 0px;']").remove();
    $("div[style='margin: 0px; padding: 0px; left: 0px; width: 100%; height: 65px; right: 0px; bottom: 0px; display: block; position: fixed; z-index: 2147483647; opacity: 0.9; background-color: rgb(32, 32, 32);']").remove();
    $("div[onmouseover='S_ssac();']").remove();
    $("center").remove();
    $("div[style='height: 65px;']").remove();
    // $("center").each(function () {
    //     if ($(this).html() === '<a href="http://somee.com">Web hosting by Somee.com</a>') {
    //         
    //         $('script#last-script').nextAll('div').remove(); // last tag before </body>   
    //         $(this).next().remove();
    //         $(this).next().next().remove();
    //         $(this).next().next().next().remove();
    //         $(this).remove();
    //
    //         return false;
    //     }
    // });
}

// function adsRemover() {
//     $('body > div:last-child').remove();
// }

function main() {
    $(document).ready(function () {
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