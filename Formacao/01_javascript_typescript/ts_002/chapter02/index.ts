//Numbers
let myNum = 10;
let anotherNum: number = 20;

myNum = 12;
//myNum = '12';

anotherNum = 30;
//anotherNum = false;

//String
let myStr: string = 'Hello';
let anotherStr = 'World';
//myStr = true;
//anotherStr = 45;

//Boolean
let myBool: boolean = true;
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
let remuneracao: number;
remuneracao = 12000;
//remuneracao = '12000';
//remuneracao = true;


//Objects (página xiii (19 / 172))
const developer = {
    firstName: 'Nabendu',
    lastName: 'Biswas',
    age: 40,
    isTrainer: true
}

const newDeveloper: { name: string; age: number; isDev: boolean } = {
    name: 'Mousam',
    age: 39,
    isDev: true
}

newDeveloper.name = 'Mousam Mishra';
//newDeveloper.age = 'Forty';
//newDeveloper.firstName = 'Mousam';

// Arrays
const languages = ['React', 'Angular', 'Vue'];

languages.push('TypeScript');
// languages.push(56);
// languages.push(true);
const numbers: number[] = [51, 21, 35];
numbers.push(56);
// numbers.push('57');
// numbers.push(true);

// Complex Arrays
const arrOfObj: { name: string; age: number }[] = [
    { name: 'Nabendu', age: 40 },
    { name: 'Mousam', age: 39 }
];

const arrOfArrays: number[][] = [
    [11, 32, 43],
    [34, 75, 64]
];

arrOfArrays.push([21, 32, 13]);

// Functions
const addNums = (num1, num2) => { return num1 + num2; }
addNums(10, 20);
addNums(10, '20');

const multiNums = (num1: number, num2: number) => {
    return num1 * num2;
}

multiNums(10, 20);
// multiNums(10, '20');

const modNums = (num1: number, num2: number): number => {
    return num1 % num2;
    // return num1 > num2;
}

modNums(10, 20);
// modNums(10, '20');

const printSum = (num1: number, num2: number): void => {
    console.log(num1 + num2);
}

printSum(10, 20);
// printSum(10, '20');

// Union Types
let numOrStr: number | string;
numOrStr = 10;
numOrStr = 'Ten';

let arr: (number | string)[] = [10, 'Ten', true];

