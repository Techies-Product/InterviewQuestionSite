/// <reference path="jquery-1.10.2.js" />
var strongPasswordRegex = new RegExp('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})');
var emailRegex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
document.addEventListener('DOMContentLoaded', function () {
    deferRegisterLayoutLoading();
});
function deferRegisterLayoutLoading() {
    if (window.jQuery) {
        jQuery = jQuery.noConflict();
        deferRegisterScriptLoad();
    }
    else {
        setTimeout(function () { deferRegisterLayoutLoading() }, 100);
    }
}
function deferRegisterScriptLoad() {
    jQuery("#frmRegister").submit(function () {
        var returnVal = true;
        var _firstName=jQuery("#FirstName").val().trim();
        var _lastName=jQuery("#LastName").val().trim();
        var _password=jQuery("#Password").val().trim();
        var _email = jQuery("#Email").val().trim();
        var _confirmPassword=jQuery("#ConfirmPassword").val().trim();
        if (_firstName.length === 0) {
            returnVal = false;
            jQuery("#errorFirstName").html("Please enter first name");
        }
        if (_lastName.trim().length === 0) {
            returnVal = false;
            jQuery("#errorLastName").html("Please enter last name");
        }
        if (_email.length === 0) {
            returnVal = false;
            jQuery("#errorEmail").html("Please enter email");
        }
        else if (!emailRegex.test(_email)) {
            returnVal =false;
            jQuery("#errorEmail").html("Please enter valid email address");
        }
        if (_password.trim().length === 0) {
            returnVal = false;
            jQuery("#errorPassword").html("Please enter password");
        }
        else if (!strongPasswordRegex.test(_password)) {
            returnVal = false;
            jQuery("#errorPassword").html("Password must contain:<br/>Minimum 8 characters.<br/>1 or more lowercase laters<br/>1 or more uppercase laters<br/>1 or more numbers<br/>1 or more special characters");
        }
        else if (_confirmPassword != _password) {
            returnVal=false;
            jQuery("#errorConfirmPassword").html("Password does not match");
        }
        return returnVal;
    });
    jQuery("#FirstName").keypress(function () {
        jQuery("#errorFirstName").hide();
    });
    jQuery("#LastName").keypress(function () {
        jQuery("#errorLastName").hide();
    });
    jQuery("#Email").keypress(function () {
        jQuery("#errorEmail").hide();
    });
    jQuery("#Password").keypress(function () {
        jQuery("#errorPassword").hide();
    });
    jQuery("#ConfirmPassword").keypress(function () {
        jQuery("#errorConfirmPassword").hide();
    });
}