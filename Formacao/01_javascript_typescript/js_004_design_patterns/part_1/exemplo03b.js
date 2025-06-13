// versão ES5/IIFE
// Immediately Invoked Function Expression 
// "Função Expressão Imediatamente Invocada

// Módulo principal
var Westros = Westros || {};
Westros.Structure = Westros.Structure || {};

// Definição de __extends (simulando herança clássica em ES5)
var __extends = function (child, parent) {
    for (var key in parent) {
        if (parent.hasOwnProperty(key)) {
            child[key] = parent[key];
        }
    }

    function Temp() {
        this.constructor = child;
    }
    Temp.prototype = parent.prototype;
    child.prototype = new Temp();
    child.__super = parent.prototype;
};

// outra possibilidade de: __extends
var __extends2 = this.__extends2 || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};

// Classe BaseStructure
var BaseStructure = (function () {
    function BaseStructure() { }
    return BaseStructure;
})();

Westros.Structure.BaseStructure = BaseStructure;

// Classe Castle que herda de BaseStructure
var Castle = (function (_super) {
    __extends(Castle, _super);

    function Castle(name) {
        _super.call(this); // Chama o construtor da classe pai
        this.name = name;
    }

    Castle.prototype.Build = function () {
        console.log("Castle built: " + this.name);
    };

    return Castle;
})(Westros.Structure.BaseStructure);

Westros.Structure.Castle = Castle;

// Instância
var winterfell = new Westros.Structure.Castle("Winterfell");
winterfell.Build(); // Saída: Castle built: Winterfell