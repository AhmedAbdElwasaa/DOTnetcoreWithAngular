$(document).ready(function () {
    var theForm = $("#theForm");
    theForm.hide();


    var button = $("#buybutton");
    button.on("click", function () {
        alert("buying car !!");
        console.log("buying car !!");
    });

    var productInfo = $(".product-props li");
    productInfo.on("click", function () {
        console.log("you clicked on " + $(this).text());
    });

    var loginToggle = $("#loginToggle");
    var popupForm = $(".popup-form");
    loginToggle.on("click", function () {
        popupForm.fadeToggle(1000);
    });






});
