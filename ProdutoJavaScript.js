function montaTableProduto(produto) {
    var resultado =
        "<tr>" +
        "<td style='display: none;'>" + produto.sku + "</td>" +
    
        "<td>" + produto.name + "</td>" +
        "<td>" + produto.inventory + "</td>" +       
        "<td>" +
        "<button type='button' " +
        "onclick='GetContaById(this);' " +
        "class='btn btn-default' " +
        "data-id='" + produto.sku + "'>" +
        "<span class='glyphicon glyphicon-edit' />"
        + "</button>" +
        "</td >" +
        "<td>" +
        "<button type='button' " +
        "onclick='eventoClickDelete(this);' " +
        "class='btn btn-default' " +
        "data-id='" + produto.sku + "'>" +
        "<span class='glyphicon glyphicon-remove' />" +
        "</button>" +
        "</td>" +
        "</tr>";
    return resultado;
}

function adicionaProduto(produto) {
    $.each(produto, function (i, c) {
        if ($("#produtoTable tbody").length == 0) {
            $("#produtoTable").append("<tbody></tbody>");
        }
        $("#produtoTable tbody").append(
            montaTableProduto(c));
    });
}

function ListaProdutos() {
    $.ajax({
        url: '/Home/GetAll/',
        type: 'GET',
        dataType: 'json',
        success: function (produtos) {
            adicionaProduto(produtos);
        },
        error: function (request, message, error) {
            alert(message);
        }
    });
}
