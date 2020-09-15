const task3Element = document.getElementById('task-3');

function greeting() {
    alert('Hello, there!');
}

function greetingName(name) {
    alert(`Hello, ${name}`);
}

function concatenatingString(param1, param2, param3) {
    return `${param1}, ${param2}, ${param3}`
}

//greeting();

greetingName('Zlatan');

task3Element.addEventListener('click', greeting);

// const result = concatenatingString('Zlatan', 'Philipe', 'Laylay');
// alert(result);
alert(concatenatingString('Zlatan', 'Philipe', 'Laylay'));