/// <reference path="jquery-1.10.2.js" />

var month_name = new Array("Jan", "Feb", "Mar",
"Apr", "May", "Jun", "Jul", "Aug", "Sep",
"Oct", "Nov", "Dec");

document.addEventListener('DOMContentLoaded', function () {
    deferMainLayoutLoading();
});
function deferMainLayoutLoading() {
    if (window.jQuery) {
        jQuery = jQuery.noConflict();
        deferCommonScriptLoad();
    }
    else {
        setTimeout(function () { deferMainLayoutLoading() }, 100);
    }
}
function deferCommonScriptLoad() {
    jQuery("head").append("<link href='https://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet'>");
    /*Binding Admin Drop Down Function*/
    jQuery("ul.log-off #AdminMenu").change(function(){
        window.location.href=(jQuery(this).find(':selected').data("href"));
    });
}