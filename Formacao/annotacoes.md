

### versão do node
c:\> node -v
c:\> node --version

### executar o node
c:\> node

### executar a aplicação
c:\> npm run server

### criação de um módulo
'Dentro do diretório, executar: npm init
'Após responder as perguntas, irá criar um arquivo: package.json

### Proposta de encapsulamento em JS
https://github.com/tc39/proposal-class-fields#private-fields

### Documentação sobre NPM
'Gerenciador de pacotes do javascript: npm
https://docs.npmjs.com/cli/v11/using-npm/scripts
https://docs.npmjs.com/cli/v11/configuring-npm/package-json


### erros
PS D:\Alura\soodwf\Formacao\01_javascript_typescript\ts_001> npm run server
npm : O arquivo C:\Program Files\nodejs\npm.ps1 não pode ser carregado porque a execução de scripts foi desabilitada    
neste sistema. Para obter mais informações, consulte about_Execution_Policies em
https://go.microsoft.com/fwlink/?LinkID=135170.
No linha:1 caractere:1
+ npm run server
+ ~~~
    + CategoryInfo          : ErrodeSegurança: (:) [], PSSecurityException
    + FullyQualifiedErrorId : UnauthorizedAccess
PS D:\Alura\soodwf\Formacao\01_javascript_typescript\ts_001>

Abrir o PowerShell em modo administrador
> Get-ExecutionPolicy
É provável que apareça: Restricted
> Set-ExecutionPolicy RemoteSigned
 y ou a
 > npm run server


### erros na execução
S D:\Alura\soodwf\Formacao\01_javascript_typescript\ts_001> npm run server
npm error code ENOENT
npm error syscall open
npm error path D:\Alura\soodwf\Formacao\01_javascript_typescript\ts_001\package.json
npm error errno -4058
npm error enoent Could not read package.json: Error: ENOENT: no such file or directory, open 'D:\Alura\soodwf\Formacao\01_javascript_typescript\ts_001\package.json'
npm error enoent This is related to npm not being able to find a file.
npm error enoent
npm error A complete log of this run can be found in: C:\Users\andre.bronca\AppData\Local\npm-cache\_logs\2025-05-16T13_24_36_787Z-debug-0.log
PS D:\Alura\soodwf\Formacao\01_javascript_typescript\ts_001> 

falta o arquivo package.json
criar o arquivo
> npm init -y

PS D:\Alura\soodwf\Formacao\01_javascript_typescript\ts_001> npm run
Lifecycle scripts included in ts_001@1.0.0:
  test
    echo "Error: no test specified" && exit 1
PS D:\Alura\soodwf\Formacao\01_javascript_typescript\ts_001> 
