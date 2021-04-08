// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#Book').change(function () {
        $.ajax({
            url: "/home/enumeratechapters?id=" + $("#Book").val(),
            type: "get",
            success: function (data) {
                var items = '';
                $('#ChapterNumber').empty();
                $.each(data, function (i, chapterNumber) {
                    items += "<option value='" + chapterNumber + "'>" + chapterNumber + "</option>";
                })
                $('#ChapterNumber').html(items);
                console.log(data);
            },
            error: function () {
                alert("An error has occured!");
            }
        });
    });
    var items = "<option value='0'>Select</option>";
    
    $('#VerseNumber').html(items);
});