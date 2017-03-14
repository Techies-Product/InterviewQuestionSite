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
    jQuery("#btnRegister").click(function () {
        var returnVal = true
        if (jQuery("#FirstName").val().trim().length === 0) {
            returnVal = false;
            alert("Please Enter First Name");
        }
        if (jQuery("#LastName").val().trim().length === 0) {
            returnVal = false;
            alert("Please Enter Last Name");
        }
        if (jQuery("#Password").val().trim().length === 0) {
            returnVal = false;
            alert("Please Enter Password");
        }
        //else if(){

        //}
        return returnVal;
    });

}