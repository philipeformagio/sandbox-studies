const defaultResult = 0;
let currentResult = defaultResult;

currentResult = (currentResult + 10) * 3 / 2 - 1;

let calculcationDescription = `(${defaultResult} + 10) * 3 / 2 -1`;
let errorMessage = 'An error ' + 
                   ' occurred!';
let errorMessage2 = 'An error \n occurred!';


outputResult(currentResult, calculcationDescription);
