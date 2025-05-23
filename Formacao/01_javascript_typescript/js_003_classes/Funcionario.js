import { Pessoa } from './Pessoa.js';

class Funcionario extends Pessoa {
    constructor(nome, idade, cargo) {
        super(nome, idade); // chama o construtor da classe pai
        this.cargo = cargo;
    }

    trabalhar() {
        console.log(`${this.nome} está trabando como: ${this.cargo}`);
    }
}

const funcionario1 = new Funcionario("Jose", 28, "Desenvolvedor");
funcionario1.saudacao();
funcionario1.trabalhar();