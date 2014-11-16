function hideById(elementId) {
    $('#' + elementId).hide();
}

function onRequestEndRefresh(e) {
    if (e.type == "update" || e.type == "create") {
        this.read();
    }
}