const randomNumber = Math.random(); // produces random number between 0 (including) and 1 (excluding)

if (randomNumber >= 0.7) {
    alert(`The number ${randomNumber} is greater or equal than 0.7`);
}

const arrayNumbers = [0, 1, 2, 3, 4, 5, 6, 7];

console.log('<--- normal for loop--->');
for (let i = 0; i < arrayNumbers.length; i++) {
    console.log(arrayNumbers[i]);
}

console.log('<--- for-of loop--->');
for (const number of arrayNumbers) {
    console.log(number)
}

console.log('<--- while loop --->')
let counter = 0;
while (counter < arrayNumbers.length) {
    console.log(arrayNumbers[counter]);
    counter++;
}

console.log('<--- normal for loop backwards--->');
for (let index = arrayNumbers.length - 1; index >= 0; index--) {
    console.log('Index', index);
    console.log(arrayNumbers[index]);
}

const anotherRandomNumber = Math.random();

if (
    (randomNumber > 0.7 && anotherRandomNumber > 0.7) || 
    randomNumber <= 0.2 || 
    anotherRandomNumber <= 0.2
    ) {
    alert('Greater than 0.7 or smaller than 0.2');
}