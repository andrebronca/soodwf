
### Documentação
https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide

TypeScript
- Criar de forma direta o arquivo de configuração. Esse comando ajuda na compilação do projeto.
- será criado automaticamente o aruivo tsconfig.json
> tsc --init
- Gerar projeto de compilação é necessário ter o arquivo tsconfig.json
> tsc --build --clean
- Corrigir o arquivo tsconfig.json conforme a orientação abaixo.
- Configuração básica funcional do arquivo tsconfig.json
{
  "compilerOptions": {
    "target": "ES2020",
    "module": "ESNext",
    "strict": true,
    "esModuleInterop": true,
    "skipLibCheck": true,
    "outDir": "./dist"
  },
  "include": ["src/**/*"]
}
- Criar a estrutura de pastas:
meu-projeto/
│
├── src/
│   └── main.ts
│
├── dist/
│   └── main.js  ← Gerado após a compilação
│
├── index.html
├── tsconfig.json
└── package.json (opcional)
- Criação do arquivo package.json
- Importância: permite o gerenciamento do projeto e controle de versão e dependências. Gerenciado por ferramentas (npm, yarn)
> npm init -y
- Exemplo do conteúdo de um package.json
{
  "name": "meu-projeto",
  "version": "1.0.0",
  "description": "",
  "main": "index.js",
  "scripts": {},
  "keywords": [],
  "author": "",
  "license": "ISC"
}
- Explicação do arquivo: tsconfig.json
"outDir": "./dist": define que os arquivos compilados .js serão salvos na pasta dist.
"include": ["src/**/*"]: diz ao compilador para incluir todos os .ts dentro da pasta src.
- No arquivo index.html, referenciar os arquivos js.
<script type="module" src="./dist/main.js"></script>
- Depois de criar os arquivos e a estrutura, para que a autocompilação funcione
- deve-se executar o comando a seguir dentro do diretório raiz, mesmo path dos arquivos .json. Isso irá compilar os arquivos .ts
> tsc --watch
ou
> tsc

============== IMPORTANTE
- A execução de modulo em ES6 requer uma alteração na estrutura. Ver: ts_002/chapter04
- no arquivo main.ts é realizada a importação dos scripts e a instanciação.
- tem que separar a instanciação para que a exportação/importação funcione
- Foi instalado um outro servidor web para executar o projeto
- usar o vite em vez do Live Server
- obs.: o vite está travando demais, fica com status de conectado, mas não executa os .js
- Instalar o vite
> npm install --save-dev vite
- Inserir no package.json
{
  "scripts": {
    "dev": "vite"
  }
}
- Executar
> npm run dev
- Criação de arquivo .bat para encerrar os processos do vite, executar como admin

