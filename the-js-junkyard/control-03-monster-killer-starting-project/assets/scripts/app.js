const ATTACK_VALUE = 10;
const STRONG_ATTACK_VALUE = 17;
const MONSTER_ATTACK_VALUE = 14;
const HEAL_VALUE = 20;

let chosenMaxLife = 100;
let currentMonsterHealth = chosenMaxLife;
let currentPlayerHealth = chosenMaxLife;

adjustHealthBars(chosenMaxLife);

function endRound() {
    const playerDamageTaken = dealPlayerDamage(MONSTER_ATTACK_VALUE);
    currentPlayerHealth -= playerDamageTaken;
    if (currentMonsterHealth <= 0 && currentPlayerHealth > 0) {
        alert('You won!');
    } else if (currentPlayerHealth <= 0 && currentMonsterHealth > 0) {
        alert('You lost!');
    } else if (currentPlayerHealth <= 0 && currentMonsterHealth <= 0) {
        alert('draw!');
    }
}

function attackMonster(attackMode) {
    const monsterDamageTaken = dealMonsterDamage(attackMode);
    currentMonsterHealth -= monsterDamageTaken;
    endRound();
}

function attackHandler() {
    attackMonster(ATTACK_VALUE);
}

function strongAttackHandler() {
    attackMonster(STRONG_ATTACK_VALUE);
}

function healPlayerHandler() {
    let healValue;
    if (currentPlayerHealth >= chosenMaxLife - HEAL_VALUE) {
        alert("You can't heal to more than your max initial health.");
        healValue = chosenMaxLife - currentPlayerHealth;
    } else {
        increasePlayerHealth(HEAL_VALUE);
        currentPlayerHealth += HEAL_VALUE;
        endRound();
    }
}

attackBtn.addEventListener('click', attackHandler);
strongAttackBtn.addEventListener('click', strongAttackHandler);
healBtn.addEventListener('click', healPlayerHandler);