/// <reference path="jquery-1.10.2.js" />
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
}