var isBusy = false;
document.addEventListener('DOMContentLoaded', function () {
    deferQuestionLoading();
});
function deferQuestionLoading() {
    if (window.jQuery) {
        jQuery = jQuery.noConflict();
        deferQuestionLoaded();
    }
    else {
        setTimeout(function () { deferQuestionLoading() }, 100);
    }
}
function deferQuestionLoaded() {
    jQuery("#btnReply").click(function () {
        jQuery("#ReplyContainer").toggle();
    });
    (function () {
        jQuery(function () {
            jQuery('#ReplyAnswer').tinymce({
                // Location of TinyMCE script
                script_url: '/Scripts/tinymce/tiny_mce.js',
                theme: "advanced",
                height: "300",
                width: "100%",
                verify_html: false,
                plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,wordcount,advlist,autosave",

                // Theme options
                //theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,styleselect,formatselect,fontselect,fontsizeselect",
                //theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
                //theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
                //theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak,restoredraft,codehighlighting,netadvimage",

                theme_advanced_buttons1: "bold,italic,underline|formatselect,fontselect,fontsizeselect,|,cut,copy,paste,pastetext,pasteword,|,bullist,numlist,outdent,indent,|,undo,redo,|,link,unlink,image,|,preview,|,forecolor,backcolor",
                theme_advanced_buttons2: "tablecontrols,|,sub,sup,|,charmap,emotions,iespell,media,|,|,fullscreen,|,restoredraft,codehighlighting,netadvimage",
                theme_advanced_buttons3: "",
                theme_advanced_buttons4: "",

                theme_advanced_toolbar_location: "top",
                theme_advanced_toolbar_align: "left",
                theme_advanced_statusbar_location: "bottom",
                theme_advanced_resizing: false,

                // Example content CSS (should be your site CSS)
                //content_css: "/Scripts/tinymce/css/content.css",
                convert_urls: false,

                // Drop lists for link/image/media/template dialogs
                template_external_list_url: "lists/template_list.js",
                external_link_list_url: "lists/link_list.js",
                external_image_list_url: "lists/image_list.js",
                media_external_list_url: "lists/media_list.js",

            });
        });
    })();
    jQuery("#btnSubmit").click(function () {
        var answer = jQuery(tinymce.get("ReplyAnswer").getBody()).text().trim();
        if (answer.length === 0) { return false; }
        if (isBusy) { return false; }
        jQuery.ajax({
            url: '/answers/SubmitAnswer',
            type: 'post',
            data: JSON.stringify({ 'answer': tinymce.get("ReplyAnswer").getContent(), 'qid': jQuery("#hddQuestionId").val() }),
            dataType: 'json',
            contentType: 'application/json',
            beforeSend: function () {
                isBusy = true;
            },
            success: function (data) {
                if (data == "Login") {
                    alert("Please Login First.");
                }
                else if (data == false) {
                    alert("Something went wrong.");
                }
                else {
                    alert("Successfully Submitted");
                    jQuery("#ReplyContainer").hide();
                    tinymce.get("ReplyAnswer").setContent("");
                }
            },
            error: function (err) {
            },
            complete: function () {
                isBusy = false;
            }
        });
    });

    //Upvote Downvote 
    jQuery("#upvote").click(function () {
        var answerId = this.getAttribute("data-answerid");
        UpAndDownVote(answerId, true);
    });
    jQuery("#downvote").click(function () {
        var answerId = this.getAttribute("data-answerid");
        UpAndDownVote(answerId, false);
    });
}
function UpAndDownVote(ansId, IsUpvote) {
    jQuery.ajax({
        url: '/answers/UpvoteDownvote',
        data: JSON.stringify({ "answerId": ansId, "IsUpvote": IsUpvote }),
        dataType: 'json',
        type:'post',
        contentType: 'application/json',
        beforeSend: function (xhr) {
            isBusy = true;
        },
        success: function (data) {
            if (data == 1) {
                //Here we will write the code for new template...
            }
        },
        error: function (err) {
            console.log("Error: " + err);
        },
        complete: function () {
            isBusy = false;
        }
    });
}