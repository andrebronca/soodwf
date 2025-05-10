import { Cliente } from "./Cliente.js"
import { ContaCorrente } from "./ContaCorrente.js";

const cc1 = new ContaCorrente('0123', 1000);
const c1 = new Cliente('A', '111', cc1);
// c1.nome = 'A';   // adicionado via construtor
// c1.cpf = '111';
// cc1.agencia = '0123'; // usando construtor
// cc1.depositar(1000);
// c1.contaCorrente = 0;

const cc2 = new ContaCorrente('0456', 100);
const c2 = new Cliente('B', '555', cc2);
// c2.nome = 'B';
// c2.cpf = '555';
// cc2.agencia = '0456'; // usando construtor
// cc2.depositar(10);
// c2.contaCorrente = cc2;
// c2.ContaCorrente.saldo = 30;    //não permite atribuir


console.log('Saldo antes da transferência');
console.log(c1);
console.log(c2);

console.log('\nTransferência de: 500');
//cc1.transferir(500, cc2);
// c1.ContaCorrente.transferir(600, c2.ContaCorrente);
// c1.ContaCorrente.transferir(600, null);
// c1.ContaCorrente.transferir(600, undefined);

console.log('\n\nSaldo depois da transferência');
console.log(cc1);
console.log(cc2);

console.log(`\n\nTotal de contas: ${ContaCorrente.totalContas}`);
// ContaCorrente.totalContas = 10;  //não permite alteração direta
console.log(`\n\nTotal de contas: ${ContaCorrente.totalContas}`);