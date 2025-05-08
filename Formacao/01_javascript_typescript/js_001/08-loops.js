console.log('Trabalhando com loop');

const listaDeDestinos = new Array(
    'São Paulo', 'Rio de Janeiro', 'Curitiba'
);

console.log(listaDeDestinos);

let idade = 17;
let acompanhado = true;
let temPassagem = true;
let destino = 'Curitiba';
// não demonstrado
const IDADE_MINIMA = 18;
let atendRequisitoViagem = false;

// não demonstrado
atendRequisitoViagem = ((idade >= IDADE_MINIMA || acompanhado) && temPassagem) ? true : false;

if (atendRequisitoViagem) {
    for (let i = 0; i < listaDeDestinos.length; i++) {  // não demonstrado
        if (listaDeDestinos[i] == destino) {
            listaDeDestinos.splice(i, 1);
            continue;   // não demonstrado
        }
    }
}

console.log(listaDeDestinos);