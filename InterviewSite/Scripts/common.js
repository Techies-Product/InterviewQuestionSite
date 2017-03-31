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

    jQuery("#BtnLoginSocial").click(function () {
        jQuery("#")
    });
}

function FacebookLogin() {
    FB.login(function (response) {
        if (response.authResponse) {
            jQuery('#hdnAccessToken').val(response.authResponse.accessToken);
            FB.api('/me?fields=email,first_name,last_name', function (response) {
                try {
                    jQuery('#hdnSocialLoginType').val('fb');
                    jQuery('#HiddenFieldUserId').val(response.id.toString());
                    jQuery('#HiddenFieldEmail').val(response.email.toString());
                    jQuery('#HiddenFieldFirstName').val(response.first_name.toString());
                    jQuery('#HiddenFieldLastName').val(response.last_name.toString());
                    jQuery('#HiddenFieldType').val('facebook');
                    jQuery('#BtnLoginSocial').click();
                }
                catch (err) {
                    alert(jQuery('#HiddenErrorMessage').val());
                }
            });
        } else {
            console.log('User cancelled login or did not fully authorize.');
        }
    }, { scope: 'publish_actions, email' });
}