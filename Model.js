var Produto = function () {
    var p = this;
    p.Id = "";
    p.sku = "";
    p.name = "";
    p.inventory = "";
};

var Inventory = function () {
    var i = this;
    i.Id = "";
    i.quantity = "";
    i.warehouse = "";
};

var Warehouse = function () {
    var w = this;
    w.Id = "";
    w.locality = "";
    w.quantity = "";
    w.type = "";
}