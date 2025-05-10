
// A maior parte da classe eu fiz adapatações
export class ContaCorrente {
    static _totalContas = 0;    //impedir alterações do valor
    _agencia;
    _saldo;
    _verComprovante = false;

    constructor(agencia, saldo) {
        this._agencia = agencia;
        this._saldo = saldo;
        ContaCorrente._totalContas++;
    }

    static get totalContas() {
        return ContaCorrente._totalContas;
    }

    // Torna a propriedade somente leitura
    // Object.defineProperty(ContaCorrente, '_totalContas', {
    //     writable: false,
    //     configurable: false
    // });

    set _saldo(vlr) {
        this._saldo = vlr < 0 ? 0 : vlr;
    }

    get saldo() {
        return this._saldo;
    }

    sacar(valor) {
        if (this._saldo >= valor) {
            this._saldo -= valor;
            this._comprovante();
            return valor;
        }
        // não há saldo suficiente para sacar
    }

    depositar(valor) {
        if (valor <= 0) return;
        //valor do depósito é inválido

        this._saldo += valor;
        this._comprovante();
    }

    _temSaldo(valor) {
        return this._saldo >= valor;
    }

    transferir(valor, conta_destino) {
        if (this._temSaldo(valor) && this._validaDestino(conta_destino)) {
            this.sacar(valor);
            conta_destino.depositar(valor);
        }
    }

    _validaDestino(conta) {
        return conta != undefined && conta != null;
    }

    _comprovante() {
        if (this._verComprovante) {
            console.log(`Agencia: ${this.agencia}: Saldo atual: ${this._saldo}`);
        }
    }
}