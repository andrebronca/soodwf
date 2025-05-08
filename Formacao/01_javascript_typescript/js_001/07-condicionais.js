console.log('Trabalhando com condicionais');

const listaDeDestinos = new Array(
    'São Paulo', 'Rio de Janeiro', 'Curitiba'
);

let idade = 17;
let acompanhado = true;
let temPassagem = false;
// não demonstrado
const IDADE_MINIMA = 18;
let viajar = false;

if (idade >= IDADE_MINIMA) {
    viajar = true;
} else if (acompanhado) {
    viajar = true;
}

if (idade >= IDADE_MINIMA || acompanhado) {
    viajar = true;
}

// ternário (não demonstrado)
viajar = idade >= IDADE_MINIMA ? true : false;

viajar = idade >= IDADE_MINIMA ? (acompanhado ? true : false) : false;

viajar = idade >= IDADE_MINIMA || acompanhado ? true : false;

if (viajar && temPassagem) {
    listaDeDestinos.splice(1, 1);
}