export class Pessoa {
    constructor(nome, idade) {
        this.nome = nome;
        this.idade = idade;
    }

    saudacao() {
        console.log(`Nome: ${this.nome}, idade: ${this.idade}`);
    }
}

const pessoa1 = new Pessoa("Jesus", 33);
pessoa1.saudacao();

