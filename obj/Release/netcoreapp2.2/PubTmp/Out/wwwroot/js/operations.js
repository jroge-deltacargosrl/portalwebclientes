$("#formuploadajax").on("submit", function (e) {
    e.preventDefault();
    var f = $(this);
    var formData = new FormData(document.getElementById("formuploadajax"));
    formData.append("dato", "valor");
    console.log(formData.get("nombre"));
    console.log(formData.get("archivo1"));
    console.log(formData.get("archivo2"));
$.ajax({
    url: "recibe.php",
    type: "post",
    dataType: "html",
    data: formData,
    cache: false,
    contentType: false,
    processData: false
})
    .done(function (res) {
        $("#mensaje").html("Respuesta: " + res);
    });
});