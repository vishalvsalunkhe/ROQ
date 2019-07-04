    function readURL(input) {
    var url = input.value;
    var ext = url.substring(url.lastIndexOf('.') + 1).toLowerCase();
    if (input.files && input.files[0] && (ext == "gif" || ext == "png" || ext == "jpeg" || ext == "jpg")) {
        var reader = new FileReader();
        reader.onload = function (e) {
        }
        reader.readAsDataURL(input.files[0]);
    } else {
        alert("Only files with extension .jpg,.jpeg,.png,.gif are allowed for images")
    }
}

function readURL(input, divImagePreview, imagepreview, ImageFile) {
    $("#divImagePreview").css("display", "none");
    var url = input.value;
    var ext = url.substring(url.lastIndexOf('.') + 1).toLowerCase();
    if (input.files && input.files[0] && (ext == "gif" || ext == "png" || ext == "jpeg" || ext == "jpg")) {
        var reader = new FileReader();
        reader.onload = function (e) {
            //$("#divImagePreview").css("display", "");
            //$('#imagepreview').attr('src', e.target.result);
            divImagePreview.css("display", "");
            imagepreview.attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    } else {
        //$("#ImageFile").val(null);
        //$("#divImagePreview").css("display", "none");
        ImageFile.val(null);
        divImagePreview.css("display", "none");
        alert("Only files with extension .jpg,.jpeg,.png,.gif are allowed for images")
    }
}
function InitTiny() {
    tinyMCE.init({
        selector: "textarea",
        // theme: "mobile",
        height: 500,
        plugins: [
            "advlist autolink link image lists charmap print preview hr anchor pagebreak spellchecker",
            "searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking",
            "save table contextmenu directionality emoticons template paste textcolor"
        ],
        //content_css: "css/content.css",
        toolbar: "insertfile undo redo | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | print preview media fullpage | forecolor backcolor",
        style_formats: [
            { title: 'Bold text', inline: 'b' },
            { title: 'Red text', inline: 'span', styles: { color: '#ff0000' } },
            { title: 'Red header', block: 'h1', styles: { color: '#ff0000' } },
            { title: 'Example 1', inline: 'span', classes: 'example1' },
            { title: 'Example 2', inline: 'span', classes: 'example2' },
            { title: 'Table styles' },
            { title: 'Table row 1', selector: 'tr', classes: 'tablerow1' }
        ]
    });
}

function UploadFile(fileUploadPathString) {
    var formData = new FormData();
    var fileInput = document.getElementById('ImageFile');
    if (fileInput.files.length <= 0) {
        alert("Please select the file to upload");
        fileInput.focus();
        return false;
    }
    for (i = 0; i < fileInput.files.length; i++) {
        formData.append(fileInput.files[i].name, fileInput.files[i]);
    }
    formData.append("fileUploadPath", fileUploadPathString);
    $.ajax({
        type: 'POST',
        url: "/Base/UploadFile",
        data: formData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (response) {
            if (response.code == 1) {
                $("#tblImages").find('tbody')
                    .append($('<tr data-UploadedFileName=' + response.UploadedFileName + ' >')
                        .append($('<td ><a href="' + response.UploadedFilePath + '" alt="Image description" target="_blank">' + response.ActualFileName + '</a></td>'
                            + '<td><span id="aDeleteImg" class="aDeleteImg fa fa-trash-alt"></span></td></tr>')
                        )
                    );
                $('#ImageFile').val(null);
            }
            else
                alert(response.Message);
        },
        error: function (xhr, error, status) {
            alert(error, status);
        }
    })};
