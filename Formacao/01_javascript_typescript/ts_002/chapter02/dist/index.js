"use strict";
//Numbers
let myNum = 10;
let anotherNum = 20;
myNum = 12;
//myNum = '12';
anotherNum = 30;
//anotherNum = false;
//String
let myStr = 'Hello';
let anotherStr = 'World';
//myStr = true;
//anotherStr = 45;
//Boolean
let myBool = true;
let anotherBool = false;
//myBool = 'true';
//anotherBool = 76;
//Inference (o tipo não foi definido na criação)
//não é a forma recomendada
let salary;
salary = 12000;
salary = '12000';
salary = true;
//Inference
let remuneracao;
remuneracao = 12000;
//remuneracao = '12000';
//remuneracao = true;
//Objects (página xiii (19 / 172))
const developer = {
    firstName: 'Nabendu',
    lastName: 'Biswas',
    age: 40,
    isTrainer: true
};
const newDeveloper = {
    name: 'Mousam',
    age: 39,
    isDev: true
};
newDeveloper.name = 'Mousam Mishra';
//newDeveloper.age = 'Forty';
//newDeveloper.firstName = 'Mousam';
// Arrays
const languages = ['React', 'Angular', 'Vue'];
languages.push('TypeScript');
// languages.push(56);
// languages.push(true);
const numbers = [51, 21, 35];
numbers.push(56);
// numbers.push('57');
// numbers.push(true);
// Complex Arrays
const arrOfObj = [
    { name: 'Nabendu', age: 40 },
    { name: 'Mousam', age: 39 }
];
const arrOfArrays = [
    [11, 32, 43],
    [34, 75, 64]
];
arrOfArrays.push([21, 32, 13]);
// Functions
// const addNums = (num1, num2) => { return num1 + num2; }
// addNums(10, 20);
// addNums(10, '20');
const multiNums = (num1, num2) => {
    return num1 * num2;
};
multiNums(10, 20);
// multiNums(10, '20');
const modNums = (num1, num2) => {
    return num1 % num2;
    // return num1 > num2;
};
modNums(10, 20);
// modNums(10, '20');
const printSum = (num1, num2) => {
    console.log(num1 + num2);
};
printSum(10, 20);
// printSum(10, '20');
// Union Types
let numOrStr;
numOrStr = 10;
numOrStr = 'Ten';
// let arr: (number | string)[] = [10, 'Ten', true];
// Literal Types
// Define os tipos aceitáveis
let myLiteral = 'Nabendu';
myLiteral = 'Mousam';
myLiteral = 'Shikha';
myLiteral = 'Hriday';
// myLiteral = 'Parag';
// Enum types
// é uma combinação de: Union Types & Literal Types
var Role;
(function (Role) {
    Role[Role["ADMIN"] = 0] = "ADMIN";
    Role[Role["READ_ONLY"] = 1] = "READ_ONLY";
    Role[Role["AUTHOR"] = 2] = "AUTHOR";
})(Role || (Role = {}));
;
const myRole = Role.ADMIN;
const hridayRole = Role.AUTHOR;
// Optionals Type
// age aqui não será utilizado na declaração, então deve ser marcada como undefined
let optionalObj = {
    name: 'Nabendu',
    age: undefined
};
//opcional mas não obrigatório: '?'
let betterOptObj = {
    name: 'Nabendu'
};
const person1 = {
    name: 'Nabendu',
    age: 40,
    isDev: true
};
const person2 = {
    name: 'Mousam',
    age: 39,
    isDev: true
};
const person3 = {
    name: 'Nabendu',
    age: 40,
    isDev: true
};
const person4 = 'Nabendu';
const coder1 = [
    { name: 'Nabendu', category: 'frontend', age: 40 },
    { name: 'Mousam', category: 'backend', age: 39 },
];
