<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExUBBEditor.ascx.cs" Inherits="RuPengSite.Ctrls.ExUBBEditor" %>
    <span id="btnUploadImgPlaceholder"></span>
    <span id="btnUploadFilePlaceholder"></span>
    <div id="divFileProgressContainer"></div>

    <script type="text/javascript" src="<%=ResolveUrl("~/js/ubbeditor/ubbEditor.js") %>"></script>  
    <script src="<%=ResolveUrl("~/js/swfupload/swfupload.js") %>" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/js/swfupload/handlers.js")%>" type="text/javascript"></script>

    <script type="text/javascript">
        var nEditor = new ubbEditor("<%=TextAreaClientId%>");
        nEditor.tLang = 'zh-cn';
        nEditor.tInit('nEditor', '<%=ResolveUrl("~/js/ubbeditor/")%>');
    </script>    
    
    <script type="text/javascript">
        var uploadImageFinish = function (file, response) {
            var result = $.parseJSON(response);
            if (result[0] == "error") {//第一个为状态码
                alert(result[1]);
                return;
            }
            nEditor.tinsertHTML("<img src='" + result[2] + "'></img>");
        }
        var uploadImg;
        $(function () {
            uploadImg = new SWFUpload({
                // Backend Settings
                upload_url: '<%=ResolveUrl("~/Post/UploadFileHandler.ashx")%>',
                post_params: {
                    "ASPSESSID": "<%=Session.SessionID %>"
                },

                // File Upload Settings
                file_size_limit: "2 MB",
                file_types: '<%=AllowedUploadImgExts %>',
                file_types_description: "图片",
                file_upload_limit: 0,    // Zero means unlimited

                swfupload_preload_handler: preLoad,
                swfupload_load_failed_handler: loadFailed,
                file_queue_error_handler: fileQueueError,
                file_dialog_complete_handler: fileDialogComplete,
                upload_progress_handler: uploadProgress,
                upload_error_handler: uploadError,
                upload_success_handler: uploadImageFinish,

                // Button settings
                button_image_url: '<%=ResolveUrl("~/js/swfupload/images/XPButtonNoText_160x22.png")%>',
                button_placeholder_id: "btnUploadImgPlaceholder",
                button_width: 160,
                button_height: 22,
                button_text: '上传图片（最大2MB）',
                button_text_top_padding: 1,
                button_text_left_padding: 5,

                // Flash Settings
                flash_url: '<%=ResolveUrl("~/js/swfupload/swfupload.swf")%>', // Relative to this file
                flash9_url: '<%=ResolveUrl("~js/swfupload/swfupload_fp9.swf")%>', // Relative to this file\
                custom_settings: { upload_target: "divFileProgressContainer" },

                // Debug Settings
                debug: false,
                auto: true
            });
        });

        var uploadFileFinish = function (file, response) {
            var result = $.parseJSON(response);
            if (result[0] == "error") {//第一个为状态码
                alert(result[1]);
                return;
            }
            //插入超链接
            nEditor.tinsertHTML("<a href='" + result[2] + "'>" + result[3] + "</a>");
        }
        var uploadFile;
        $(function () {
            uploadFile = new SWFUpload({
                // Backend Settings
                upload_url:  '<%=ResolveUrl("~/Post/UploadFileHandler.ashx")%>',
                post_params: {
                    "ASPSESSID": "<%=Session.SessionID %>"
                },

                // File Upload Settings
                file_size_limit: "2 MB",
                file_types: '<%=AllowedUploadFileExts %>',
                file_upload_limit: 0,    // Zero means unlimited

                swfupload_preload_handler: preLoad,
                swfupload_load_failed_handler: loadFailed,
                file_queue_error_handler: fileQueueError,
                file_dialog_complete_handler: fileDialogComplete,
                upload_progress_handler: uploadProgress,
                upload_error_handler: uploadError,
                upload_success_handler: uploadFileFinish,

                // Button settings
                button_image_url: '<%=ResolveUrl("~/js/swfupload/images/XPButtonNoText_160x22.png")%>',
                button_placeholder_id: "btnUploadFilePlaceholder",
                button_width: 160,
                button_height: 22,
                button_text: '上传文件（最大2MB）',
                button_text_top_padding: 1,
                button_text_left_padding: 5,

                // Flash Settings
                flash_url: '<%=ResolveUrl("~/js/swfupload/swfupload.swf")%>', // Relative to this file
                flash9_url:  '%=ResolveUrl("~js/swfupload/swfupload_fp9.swf")%>',  // Relative to this file\
                custom_settings: { upload_target: "divFileProgressContainer" },

                // Debug Settings
                debug: false,
                auto: true
            });
        });
    </script>