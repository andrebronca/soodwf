console.log("Atribuição de variáveis");

let nome = "Dino";
const sobrenome = "Sauro";

console.log(nome + sobrenome);

console.log(nome + " " + sobrenome);
console.log(nome, sobrenome);
console.log(`Nome: ${nome} ${sobrenome}`);  // interpolação

const nomeCompleto = nome + " " + sobrenome;
nome = nome + " " + sobrenome;  // não é recomendado a sobrescrita

console.log(nome);
console.log(nomeCompleto);

