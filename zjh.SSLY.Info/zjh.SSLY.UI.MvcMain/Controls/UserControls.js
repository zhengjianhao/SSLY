function OpenTreeDialog(p) {
    $("#"+p.div).css("display", "block");
    $('#ddTree').dialog({
        title: p.title,
        width: 280,
        height: 450,
        closed: false,
        cache: false,
        modal: true
    });
    $('#'+p.tree).tree({
        url: p.Url, 
        idField: p.idField,
        treeField: p.treeField, 
        checkbox: p.checkbox
    });
}

function getCheckeds(id) {
    var nodes = $('#' + id).tree('getChecked');
    var s = '';
    for (var i = 0; i < nodes.length; i++) {
        if (s != '') s += ',';
        s += nodes[i].id;
    }
    return s;
}