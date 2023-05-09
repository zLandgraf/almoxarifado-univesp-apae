function geraCampos(campos) {
    var html = '';
    for (var i = 0; i < campos.length; i++) {
        html += "<div class='d-print-none' style='display: inline-flex; margin: 5px;'><input type='checkbox' checked value='" + i + "'> " + campos[i] + "</div>";
    }
    $("#campos").html(html);
}
$(window).on("load", function () {
    $('body').on("click", "input[type=checkbox]", function () {
        var checked = $(this).prop("checked");
        var indice = $(this).val();

        if (checked == false) {
            var trs = $(".itens tr, tr.itens");
            for (var i = 0; i < trs.length; i++) {
                var tds = $(trs[i]).find("td");
                $(tds[indice]).fadeOut();
                if (tds.length - 1 == indice) {
                    tds[indice - 1].style = 'text-align: right';
                }
            }
        } else {
            var trs = $(".itens tr, tr.itens");
            for (var i = 0; i < trs.length; i++) {
                var tds = $(trs[i]).find("td");
                $(tds[indice]).fadeIn();
                if (tds.length - 1 == indice) {
                    tds[indice - 1].style = 'text-align: left';
                }
            }
        }
    });
});