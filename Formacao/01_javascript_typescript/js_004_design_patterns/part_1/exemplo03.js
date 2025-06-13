// Modules (namespaces)

// Verifica se o objeto já existe, se sim, o usa, senão cria
var Westeros = Westeros || {};
Westeros.Castle = function (name) { this.name = name }; //constructor
Westeros.Castle.prototype.Build = function () { console.log("Castle built: " + this.name) };

// hierarchy of namespaces
var Westeros = Westeros || {};
Westeros.Structures = Westeros.Structures || {};
Westeros.Structures.Castle = function (name) { this.name = name }; //constructor
Westeros.Structures.Castle.prototype.Build = function () { console.log("Castle built: " + this.name) };

var winterfell = new Westeros.Structures.Castle("Winterfell");
winterfell.Build();
