const startGameBtn = document.getElementById('start-game-btn');
const resetGameBtn = document.getElementById('reset-game-btn');

const ROCK = 'ROCK';
const PAPER = 'PAPER';
const SCISSORS = 'SCISSORS';
const DEFAULT_USER_CHOICE = ROCK;
const RESULT_DRAW = 'DRAW';
const RESULT_PLAYER_WINS = 'PLAYER_WINS';
const RESULT_COMPUTER_WINS = 'COMPUTER_WINS';

let isGamingRunning = false;

const getRandomChoice = () => {
    const choices = ['ROCK', 'PAPER', 'SCISSORS'];
    const random = Math.floor(Math.random() * choices.length);
    return choices[random];
};

const getPlayerChoice = () => {
    const selection = prompt(`${ROCK}, ${PAPER} or ${SCISSORS}?`, '').toUpperCase();
    if (
        selection !== ROCK &&
        selection !== PAPER &&
        selection !== SCISSORS
    ) {
        const defaultChoice = getRandomChoice();
        alert(`Invalid choice! We chose ${defaultChoice} for you!`);
        return defaultChoice;
    }
    return selection;
};

const getWinner = (cChoice, pChoice) => {
    return cChoice === pChoice
        ? RESULT_DRAW
        : (cChoice === ROCK && pChoice === PAPER) || 
          (cChoice === PAPER && pChoice === SCISSORS) ||
          (cChoice === SCISSORS && pChoice === ROCK)
        ? RESULT_PLAYER_WINS
        : RESULT_COMPUTER_WINS

    // if (cChoice === pChoice) {
    //     return RESULT_DRAW;
    // } else if (
    //     (cChoice === ROCK && pChoice === PAPER) || 
    //     (cChoice === PAPER && pChoice === SCISSORS) ||
    //     (cChoice === SCISSORS && pChoice === ROCK)
    // ) {
    //     return RESULT_PLAYER_WINS;
    // } else {
    //     return RESULT_COMPUTER_WINS;
    // }
};

startGameBtn.addEventListener('click', function startGame() {
    if(isGamingRunning) {
        return;
    }
    isGamingRunning = true;
    console.log('Game is starting...');
    const playerChoice = getPlayerChoice(); console.log(playerChoice);
    const computerChoice = getRandomChoice(); console.log(computerChoice);
    const winner = getWinner(computerChoice, playerChoice);
    console.log(winner);
});

resetGameBtn.addEventListener('click', function resetGame() {
    isGamingRunning = false;
})