// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#togglePassword").on("click", () => {

    $("#togglePassword").toggleClass("fa-eye fa-eye-slash");
    console.log($("#togglePassword"));
    let idPassword = document.getElementById("passwordId");
    const type = idPassword.getAttribute('type') === 'password' ? 'text' : 'password';
    console.log(type);
    idPassword.setAttribute('type', type);
})

$("#copyPaste").on("click", () => {
    var copyPassword = document.getElementById("passwordId");
    copyPassword.select();
    copyPassword.setSelectionRange(0, 99999);
    navigator.clipboard.writeText(copyPassword.value);

    alert("Copied the text: " + copyPassword.value);
})
/**Login start*/

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