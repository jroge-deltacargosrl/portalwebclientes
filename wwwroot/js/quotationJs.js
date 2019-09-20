$(document).ready(function () {
    $('.quotationForms').children('div').hide();
    $('.quotationForms').children('#4').show();
    $('.quotationForms').children('.weight-volume').show();
    $('.quotationForms').children('.comment').show();
    $('.servicesSelect').on('change', function () {
        var s = "#" + $(this).val();
        $('.quotationForms').children('div').hide();
        $('.quotationForms').children(s).show();
        if (s != "#2") {
            $('.quotationForms').children('.weight-volume').show();
            $('.quotationForms').children('.comment').css({ 'margin-top': '5%' });
            $('.quotationForms').children('.weight-volume').css({ 'margin-top': '5%' });
        } else {
            $('.quotationForms').children('.comment').css({ 'margin-top': '-5%' });
        }
        if (s == "#3" || s == "#4") {
        }
        $('.quotationForms').children('.comment').show();
    });
    var $selects = $('select');
    $selects.on('change', function () {
        $("option", $selects).prop("disabled", false);
        $selects.each(function () {
            var $select = $(this),
                $options = $selects.not($select).find('option'),
                selectedText = $select.children('option:selected').text();
            $options.each(function () {
                if ($(this).text() == selectedText) $(this).prop("disabled", true);
            });
        });
    });
    $selects.eq(0).trigger('change');
});

$nombre = $_FILES['file-0'];
var data = new FormData();
jQuery.each($('input[type=file]')[0].files, function (i, file) {
    data.append('file-' + i, file);
});
var other_data = $('form').serializeArray();
$.each(other_data, function (key, input) {
    data.append(input.name, input.value);
});
jQuery.ajax({
    url: 'php.php',
    data: data,
    cache: false,
    contentType: false,
    processData: false,
    type: 'POST',
    success: function (data) {
        alert(data);
    }
});