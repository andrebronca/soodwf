//Numbers
var myNum = 10;
var anotherNum = 20;
myNum = 12;
//myNum = '12';
anotherNum = 30;
//anotherNum = false;
//String
var myStr = 'Hello';
var anotherStr = 'World';
//myStr = true;
//anotherStr = 45;
//Boolean
var myBool = true;
var anotherBool = false;
//myBool = 'true';
//anotherBool = 76;
//Inference (o tipo não foi definido na criação)
//não é a forma recomendada
var salary;
salary = 12000;
salary = '12000';
salary = true;
//Inference
var remuneracao;
remuneracao = 12000;
//remuneracao = '12000';
//remuneracao = true;
//Objects (página xiii (19 / 172))
var developer = {
    firstName: 'Nabendu',
    lastName: 'Biswas',
    age: 40,
    isTrainer: true
};
var newDeveloper = {
    name: 'Mousam',
    age: 39,
    isDev: true
};
newDeveloper.name = 'Mousam Mishra';
//newDeveloper.age = 'Forty';
//newDeveloper.firstName = 'Mousam';
// Arrays
var languages = ['React', 'Angular', 'Vue'];
languages.push('TypeScript');
// languages.push(56);
// languages.push(true);
var numbers = [51, 21, 35];
numbers.push(56);
// numbers.push('57');
// numbers.push(true);
// Complex Arrays
var arrOfObj = [
    { name: 'Nabendu', age: 40 },
    { name: 'Mousam', age: 39 }
];
var arrOfArrays = [
    [11, 32, 43],
    [34, 75, 64]
];
arrOfArrays.push([21, 32, 13]);
// Functions
var addNums = function (num1, num2) { return num1 + num2; };
addNums(10, 20);
addNums(10, '20');
