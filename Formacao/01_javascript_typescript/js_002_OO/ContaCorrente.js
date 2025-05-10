export class ContaCorrente {
    agencia;
    _saldo = 0;

    sacar(valor) {
        if (this._saldo >= valor) {
            this._saldo -= valor;
            this._comprovante();
            return valor;
        }
        //não há saldo suficiente para sacar
    }

    depositar(valor) {
        if (valor <= 0) return;
        //valor do depósito é inválido

        this._saldo += valor;
        this._comprovante();
    }

    _comprovante() {
        console.log(`Saldo atual: ${this._saldo}`);
    }
}