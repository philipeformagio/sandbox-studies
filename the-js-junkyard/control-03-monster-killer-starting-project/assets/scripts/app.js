const ATTACK_VALUE = 10;
const MONSTER_ATTACK_VALUE = 14;

let chosenMaxLife = 100;
let currentMonsterHealth = chosenMaxLife;
let currentPlayerHealth = chosenMaxLife;

adjustHealthBars(chosenMaxLife);

function attackHandler() {
    const monsterDamageTaken = dealMonsterDamage(ATTACK_VALUE);
    currentMonsterHealth -= monsterDamageTaken;
    const playerDamageTaken = dealPlayerDamage(MONSTER_ATTACK_VALUE);
    currentPlayerHealth -= playerDamageTaken;
    if (currentMonsterHealth <= 0) {
        alert('You won!');
    } else if (currentPlayerHealth <= 0) {
        alert('You lost!');
    }
}

attackBtn.addEventListener('click', attackHandler);