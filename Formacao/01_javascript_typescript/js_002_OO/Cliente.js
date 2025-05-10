import { ContaCorrente } from "./ContaCorrente.js";

// A maior parte da classe eu fiz adapatações
export class Cliente {
    _nome;
    _cpf;
    _ContaCorrente;

    // constructor(nome, cpf) { //só pode ter um construtor
    //     this._nome = nome;
    //     this._cpf = cpf;
    // }

    constructor(nome, cpf, conta_corrente) {
        this._nome = nome;
        this._cpf = cpf;
        this.contaCorrente = conta_corrente;
    }

    set contaCorrente(conta) {
        if (conta instanceof ContaCorrente)
            this._ContaCorrente = conta;
    }

    get contaCorrente() {
        return this._ContaCorrente;
    }

    get nome() {
        return this._nome;
    }

    get cpf() {
        return this._cpf;
    }

    _valida(conta) {
        return conta != undefined && conta != null;
    }
}