const form = document.getElementById('user-input');

function onFormSubmit(event) {
    event.preventDefault();

    const userNameInput = document.getElementById('username');
    const enteredUsername = userNameInput.value;

    const userPasswordInput = document.getElementById('password');
    const enteredPassword = userPasswordInput.value;

    if(enteredUsername.trim().length === 0) {
        alert('Invalid input - username must not be empty');
        return;
    }
    if(enteredPassword.trim().length <= 5) {
        alert('Invalid input - password must be six characters or loger');
        return;
    }

    const user = {
        username: enteredUsername,
        password: enteredPassword
    };

    console.log(user);
    console.log(`Hi, I am ${user.username}`);
}

form.addEventListener('submit', onFormSubmit);