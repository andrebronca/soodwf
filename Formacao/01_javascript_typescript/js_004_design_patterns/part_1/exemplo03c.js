// Módulo principal
var Westros = Westros || {};
Westros.Structure = Westros.Structure || {};

// Classe BaseStructure (classe base)
class BaseStructure {
    constructor() {
        // Poderíamos adicionar propriedades ou inicializações comuns aqui
    }
}

Westros.Structure.BaseStructure = BaseStructure;

// Classe Castle que herda de BaseStructure
class Castle extends BaseStructure {
    constructor(name) {
        super(); // Chama o construtor da classe pai (BaseStructure)
        this.name = name;
    }

    Build() {
        console.log("Castle built: " + this.name);
    }
}

Westros.Structure.Castle = Castle;

// Instância
const winterfell = new Westros.Structure.Castle("Winterfell");
winterfell.Build(); // Saída: Castle built: Winterfell