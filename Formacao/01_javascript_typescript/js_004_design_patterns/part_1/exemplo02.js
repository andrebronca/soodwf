// Inheritance: não há, o que há é uma cópia as propriedades

var Castle = function () { };
Castle.prototype.build = function () { console.log("Castle build"); }

var Winterfell = function () { };
Winterfell.prototype.build = Castle.prototype.build;
Winterfell.prototype.addGodsWood = function () { }
var winterfell = new Winterfell();
winterfell.build();

function clone(source, destination) {
    for (var attr in source.prototype) {
        destination.prototype[attr] = source.prototype[attr];
    }
}