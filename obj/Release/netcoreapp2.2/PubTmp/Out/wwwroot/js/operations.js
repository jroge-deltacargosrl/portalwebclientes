$(document).ready(function () {
    console.log("OK");
    $(".divUpload").click(function () {
        $("input[name=fileIds]").val($(this).context.id);
        //console.log($(this).context.id);
    });
    $(".divView").click(function () {
        console.log($(this).attr("id"));
        $("#toView").attr("src", "https://docs.google.com/gview?url=https://deltacargostorage.blob.core.windows.net/pdf/" + $(this).attr("id") + "&embedded=true");
        /*console.log(
            "https://docs.google.com/gview?url=https://deltacargostorage.blob.core.windows.net/pdf/" +
            $(this).attr("id") +
            "&embedded=true"
        );*/
    });
});