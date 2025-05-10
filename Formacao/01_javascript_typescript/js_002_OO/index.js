import { Cliente } from "./Cliente.js"
import { ContaCorrente } from "./ContaCorrente.js";



const c1 = new Cliente();
const cc1 = new ContaCorrente();
c1.nome = 'Jose';
c1.cpf = '11122233344';
cc1.agencia = '0123';
cc1.depositar(200);

const c2 = new Cliente();
const cc2 = new ContaCorrente();
c2.nome = 'Jesus';
c2.cpf = '55522233344';
cc2.agencia = '0123';
cc2.depositar(100);

console.log(c1);
console.log(c2);
console.log(cc1);
console.log(cc2);