/// <reference path="jquery-1.10.2.js" />
document.addEventListener('DOMContentLoaded', function () {
    deferTagsLayoutLoading();
});
function deferTagsLayoutLoading() {
    if (window.jQuery) {
        jQuery = jQuery.noConflict();
        deferTagsScriptLoad();
    }
    else {
        setTimeout(function () { deferTagsLayoutLoading() }, 100);
    }
}
function deferTagsScriptLoad() {
    jQuery("#IsCompany").change(function () {
        jQuery("#hddIsCompany").val((jQuery("#IsCompany:checked").length == 1) ? "true" : "false");
    });
    jQuery(".date").each(function (index, item) {
        var _date = new Date(jQuery(this).html().trim());
        jQuery(this).html(month_name[_date.getMonth()] + ', ' + _date.getDate() + ' ' + _date.getFullYear()).show();
    });
}
function CheckFormSubmit() {
    if (jQuery("#Name").val().trim().lengh == 0) {
        alert("Please Enter Tag Name...");
        return false;
    }
    return true;
}