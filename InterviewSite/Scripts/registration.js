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
            alert("Please Enter First Name");
        }
        if (_lastName.trim().length === 0) {
            returnVal = false;
            alert("Please Enter Last Name");
        }
        if (_email.length === 0) {
            returnVal = false;
            alert("Please Enter Email");
        }
        else if (!emailRegex.test(_email)) {
            returnVal =false;
            alert("Please enter valid email address");
        }
        if (_password.trim().length === 0) {
            returnVal = false;
            alert("Please Enter Password");
        }
        else if (!strongPasswordRegex.test(_password)) {
            returnVal = false;
            alert("Password must be Strong");
        }
        if (_confirmPassword != _password) {
            returnVal=false;
            alert("Password does not match");
        }
        return returnVal;
    });
}