const ATTACK_VALUE = 10;
const STRONG_ATTACK_VALUE = 17;
const MONSTER_ATTACK_VALUE = 14;

let chosenMaxLife = 100;
let currentMonsterHealth = chosenMaxLife;
let currentPlayerHealth = chosenMaxLife;

adjustHealthBars(chosenMaxLife);

function attackMonster(attackMode) {
    // let maxDamage;
    // if(attackMode === 'ATTACK') {
    //     maxDamage = ATTACK_VALUE;
    // } else if(attackMode === 'STRONG_ATTACK') {
    //     maxDamage = STRONG_ATTACK_VALUE;
    // }
    const monsterDamageTaken = dealMonsterDamage(attackMode);
    currentMonsterHealth -= monsterDamageTaken;
    const playerDamageTaken = dealPlayerDamage(MONSTER_ATTACK_VALUE);
    currentPlayerHealth -= playerDamageTaken;
    if (currentMonsterHealth <= 0 && currentPlayerHealth > 0) {
        alert('You won!');
    } else if (currentPlayerHealth <= 0 && currentMonsterHealth > 0) {
        alert('You lost!');
    } else if (currentPlayerHealth <=0 && currentMonsterHealth <= 0) {
        alert('draw!');
    }
}

function attackHandler() {
    attackMonster(ATTACK_VALUE);
}

function strongAttackHandler() {
    attackMonster(STRONG_ATTACK_VALUE);
}

attackBtn.addEventListener('click', attackHandler);
strongAttackBtn.addEventListener('click', strongAttackHandler);