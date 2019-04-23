function MostrarEditForm(nombre) {
    $("#editForm" + nombre).css("display", "block");
    $("#btn" + nombre).css("visibility", "hidden");
}

function Editar(nombre) {
    if ($("#txtDescripcion" + nombre).val() !== " " && $("#txtDescripcion" + nombre).val() !== "") {
        $("#form" + nombre).submit();
    } else {
        return false;
    }
}