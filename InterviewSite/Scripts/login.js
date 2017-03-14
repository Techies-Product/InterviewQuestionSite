/// <reference path="jquery-1.10.2.js" />
document.addEventListener('DOMContentLoaded', function () {
    deferLoginLayoutLoading();
});
function deferLoginLayoutLoading() {
    if (window.jQuery) {
        jQuery = jQuery.noConflict();
        deferLoginScriptLoad();
    }
    else {
        setTimeout(function () { deferLoginLayoutLoading() }, 100);
    }
}
function deferLoginScriptLoad() {
    jQuery("#frmLogin").submit(function () {
        var _email = jQuery("#Email").val().trim();
        var _password = jQuery("#Password").val().trim();
        var returnVal=true;
        if (_email.length === 0) {
            returnVal=false;
            jQuery("#errorEmail").html("Please Enter Email / User Name").show();
        }
        if (_password.length === 0) {
            returnVal = false;
            jQuery("#errorPassword").html("Please Enter Password").show();
        }
        return returnVal;
    });
    jQuery("#chkIsRememberMe").change(function () {
        jQuery("#hddIsRememberMe").val((jQuery(this).is(":checked")));
    });
    jQuery("#Email").keypress(function () {
        jQuery("#errorEmail").hide();
    });
    jQuery("#Password").keypress(function () {
        jQuery("#errorPassword").hide();
    });
}