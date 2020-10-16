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
let i = 0;
while (i < arrayNumbers.length) {
    console.log(arrayNumbers[i]);
    i++;
}

console.log('<--- normal for loop backwards--->');
for (let index = arrayNumbers.length; index > 0; index--) {
    console.log(arrayNumbers[index]);
}

const anotherRandomNumber = Math.random();

if (randomNumber && anotherRandomNumber > 0.7 || randomNumber && anotherRandomNumber < 0.2) {
    alert(`yeah`);
}