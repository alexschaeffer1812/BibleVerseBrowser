// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    var $loading = $("#spinner").hide();

    // Shows and hides the spinning indicator
    $(document)
        .ajaxStart(function () {
            $loading.show();
            $("#searchButton").attr("disabled", true);
        })
        .ajaxStop(function () {
            $loading.hide();
            $("#searchButton").attr("disabled", false);
        });
    

    // Populates the Book dropdown
    $('#Testament').change(function () {

        $.ajax({
            url: "/home/enumeratebooks?testament=" + $("#Testament").val(),
            type: "get",
            async: true,
            success: function (data) {
                var items = '';
                $('#Book').empty();
                var obj = jQuery.parseJSON(JSON.stringify(data));
                $.each(obj, function (i, book) {
                    items += "<option value='" + book.id + "'>" + book.bookName + "</option>";
                })
                $('#Book').html(items);
                console.log(data);
                EnumerateChapters()
            },
            error: function () {
                alert("An error has occured!");
            }
        });


    });

    // Polulates the Chapter dropdown
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

    // Populates the Verse dropdown
    $('#ChapterNumber').change(function () {
        $.ajax({
            url: "/home/enumerateverses?id=" + $("#Book").val() + "&&chapterNumber=" + $("#ChapterNumber").val(),
            type: "get",
            success: function (data) {
                var items = '';
                $('#VerseNumber').empty();
                $.each(data, function (i, verseNumber) {
                    items += "<option value='" + verseNumber + "'>" + verseNumber + "</option>";
                })
                $('#VerseNumber').html(items);
                console.log(data);
            },
            error: function () {
                alert("An error has occured!");
            }
        });
    });


    function EnumerateChapters() {
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
                EnumerateVerses();
            },
            error: function () {
                alert("An error has occured!");
            }
        });
    }

    function EnumerateVerses() {
        $.ajax({
            url: "/home/enumerateverses?id=" + $("#Book").val() + "&&chapterNumber=" + $("#ChapterNumber").val(),
            type: "get",
            success: function (data) {
                var items = '';
                $('#VerseNumber').empty();
                $.each(data, function (i, verseNumber) {
                    items += "<option value='" + verseNumber + "'>" + verseNumber + "</option>";
                })
                $('#VerseNumber').html(items);
                console.log(data);
            },
            error: function () {
                alert("An error has occured!");
            }
        });
    }

});