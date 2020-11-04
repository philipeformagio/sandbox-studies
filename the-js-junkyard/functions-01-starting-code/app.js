const startGameBtn = document.getElementById('start-game-btn');

const ROCK = 'ROCK';
const PAPER = 'PAPER';
const SCISSORS = 'SCISSORS';
const DEFAULT_USER_CHOICE = ROCK;

let isGamingRunning = false;

const getRandomChoice = function() {
    const choices = ['ROCK', 'PAPER', 'SCISSORS'];
    const random = Math.floor(Math.random() * choices.length);
    return choices[random];
};

const getPlayerChoice = function() {
    const selection = prompt(`${ROCK}, ${PAPER} or ${SCISSORS}?`, '').toUpperCase();
    if (
        selection !== ROCK &&
        selection !== PAPER &&
        selection !== SCISSORS
    ) {
        const defaultChoice = getRandomChoice();
        alert(`Invalid choice! We chose ${DEFAULT_USER_CHOICE} for you!`);
        return DEFAULT_USER_CHOICE;
    }
    return selection;
};

startGameBtn.addEventListener('click', function startGame() {
    if(isGamingRunning) {
        return;
    }
    isGamingRunning = true;
    console.log('Game is starting...');
    const playerSelection = getPlayerChoice();
    console.log(playerSelection);
});