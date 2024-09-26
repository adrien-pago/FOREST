// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.  

/**Change language start*/
$(".selected-btn-lang").on("click", () => {
    console.log("clicked");
    $(".dropdown-container").toggleClass("active");
})

$(".lang-option").each(function () {
    $(this).on("click", () => {
        let selectedOptionImg = $(this).find(".global-flag-style");
        let selectedOptionTxt = $(this).find(".lang-text").text();

        $(".selected-lang-text").text(selectedOptionTxt);
        $(".selected-flag").attr("src", selectedOptionImg.attr("src"));
        $(".selected-flag").attr("id", selectedOptionImg.attr("id"));
        $(".dropdown-container").removeClass("active");

    })
})

/**Change language end*/


$(".user-info-dropdown-btn").on("click", function(e) {
    console.log("clicked");
    e.stopPropagation();
    $(".user-info-container").toggleClass("active");

})


/**New Updates start*/
$(".floating").on("click", function(e) {
    e.stopPropagation();
    $(".release-dropdown").toggleClass("active");
})

$(document).on('click', function (e) {
    const user_info_container = document.querySelector(".user-info-container");
    const user_info_dBtn = document.querySelector(".user-info-dropdown-btn");
    const release = document.querySelector(".release-dropdown");
    const floating_icon = document.querySelector(".floating");

    if (e.target !== null) {
        if ($(".user-info-container").hasClass('active') && !e.target.matches(".user-info-container")) {
            $(".user-info-container").removeClass('active');
            console.log("cliick")
        }


        if (!release?.contains(e.target) && e.target !== floating_icon && $('#dont-show-check').is(':checked')) {
            $(".release-dropdown").removeClass('active');
        }
    }
 

});
$("#dont-show-check").on("change", function () {
    var checked = $(this).is(':checked');
    console.log(checked);
    $.ajax({
        url: hidePatchBoxUrl,
        datatype: 'json',
        traditional: true,
        method: "GET",
        data: { dontShowAgain : checked},
        contentType: 'application/json;charset=utf-8',

        success: function (res) {
            console.log(res);
            if (res) {
                if (checked) {
                    $(".release-dropdown").removeClass('active');
                }
            }
            else {

            }
        },
        error: function (err) {
            console.log(err)
        }
    })
});

/**New Updates end*/


/**Login start*/
$("#togglePassword").on("click", () => {

    $("#togglePassword").toggleClass("fa-eye fa-eye-slash");
    console.log($("#togglePassword"));
    let idPassword = document.getElementById("idPassword");
    const type = idPassword.getAttribute('type') === 'password' ? 'text' : 'password';
    idPassword.setAttribute('type', type);
})


$("#idUser").on("input", () => {
    $(".error-msg-login").css("display", "none");
})

$("#idUser").focusout(() => {
    $(".error-msg-login").css("display", "none");
})

$("#idPassword").on("input", () => {
    $(".error-msg-login").css("display", "none");
})

$("#idPassword").focusout(() => {
    $(".error-msg-login").css("display", "none");
})

/**Login end*/

/**Select products start*/


/**Select products end*/
