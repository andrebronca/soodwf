export class ContaBancaria {
    //propriedade privada
    #saldo = 0;

    constructor(titular) {
        this.titular = titular;
    }

    depositar(valor) {
        if (valor > 0) {
            this.#saldo += valor;
        }
    }

    sacar(valor) {
        if (valor <= this.#saldo) {
            this.#saldo -= valor;
        } else {
            console.log("Saldo insuficiente");
        }
    }

    mostrarSaldo() {
        console.log(`Saldo de: ${this.titular}: R$ ${this.#saldo.toFixed(2)}`);
    }
}

const conta = new ContaBancaria("Maria");
conta.depositar(1000);
conta.sacar(300);
conta.mostrarSaldo();