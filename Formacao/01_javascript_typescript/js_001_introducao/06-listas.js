console.log('Trabalhando com listas');

const listaDeDestinos = new Array(
    'Salvador', 'São Paulo', 'Rio de Janeiro'
);


console.log("Destinos possíveis");
console.log(listaDeDestinos);

console.log('Adicionando depois de criada a lista');
listaDeDestinos.push('Curitiba');
console.log(listaDeDestinos);

console.log('Removendo item da lista');
listaDeDestinos.splice(0, 1);
console.log(listaDeDestinos);

console.log('Exibir o primeiro item');
console.log(listaDeDestinos[0]);

console.log('Exibir o útimo elemento');
console.log(listaDeDestinos[listaDeDestinos.length - 1]);