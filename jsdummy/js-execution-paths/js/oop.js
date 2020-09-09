class Validator {
    static REQUIRED = 'REQUIRED';
    static MIN_LENGTH = 'MIN_LENGTH';

    static validate(value, validationType, validatorValue){
        if (validationType === this.REQUIRED){
            return value.trim().length > 0;
        }
        if (validationType === this.MIN_LENGTH){
            return value.trim().length > validatorValue;
        }
    }
}

class User {
    constructor(uName, uPassword){
        this.userName = uName;
        this.password = uPassword;
    }

    greet() {
        console.log(`Hi. I'm ${this.userName}`);
    }
}

class UserInputForm {
    constructor() {
        this.form = document.getElementById('user-input');
        this.userNameInput = document.getElementById('username');
        this.userPasswordInput = document.getElementById('password');

        this.form.addEventListener('submit', this.userInputFormSubmit.bind(this));
    }
    
    userInputFormSubmit(event){
        event.preventDefault();

        const enteredUsername = this.userNameInput.value;
        const enteredPassword = this.userPasswordInput.value;

        if (
            !Validator.validate(enteredUsername, Validator.REQUIRED) || 
            !Validator.validate(enteredPassword, Validator.MIN_LENGTH, 5)
        ) {
            alert('Invalid input - username or password is wrong');
            return;
        }

        const newUser = new User(enteredUsername, enteredPassword);
        console.log(newUser);
        newUser.greet();
    }
}

new UserInputForm();