let saldo = 3000;

//buscar no index.html o valor referente ao elemento
const elementoSaldo = document.querySelector(".saldo-valor .valor");
//altera o valor no index.html
elementoSaldo.textContent = saldo;

// identifica a class e o elemento html
const elementForm = document.querySelector(".block-nova-transacao form");
// listenet do submit, porém sem recarregar a página
elementForm.addEventListener("submit", function (event) {
    event.preventDefault(); // evita o carregamento da página

    if (!elementForm.checkValidity()) {
        alert("Por favor, preencher todos os campos do formulário!");
        return;
    }

    // definindo o tipo de objeto de acordo com o html
    const inputTipoTransacao = elementForm.querySelector("#tipoTransacao");
    const inputValor = elementForm.querySelector("#valor");
    const inputData = elementForm.querySelector("#data");

    // obtendo o valor
    let vlrTipoTransacao = inputTipoTransacao.value;
    let vlrValor = inputValor.value;
    let vlrData = inputData.value;

    // criando um objeto do tipo transação
    const novaTransacao = {
        tipoTransacao: vlrTipoTransacao,
        valor: vlrValor,
        data: vlrData
    };

    // debug
    console.log(novaTransacao);
    // reset do formulário
    elementForm.reset();
});