var Validator = {
    REQUIRED: 'REQUIRED',
    MIN_LENGTH: 'MIN_LENGTH',

    validate: function(value, validationType, validatorValue) {
        if (validationType === this.REQUIRED) {
            return value.trim().length > 0;
        }
        if (validationType === this.MIN_LENGTH) {
            return value.trim().length > validatorValue;
        }
    }
}

var User = {
    username: "",
    password: "",

    greet: function() {
        console.log(`Hi. I'm ${this.userName}`);
    }
}

var UserInputForm = {
    form: document.getElementById('user-input'),
    userNameInput: document.getElementById('username'),
    userPasswordInput: document.getElementById('password'),

    userInputFormSubmit: function() {
        event.preventDefault();

        var enteredUsername = this.userNameInput.value;
        var enteredPassword = this.userPasswordInput.value;

        if (
            !Validator.validate(enteredUsername, Validator.REQUIRED) || 
            !Validator.validate(enteredPassword, Validator.MIN_LENGTH, 5)
        ) {
            alert('Invalid input - username or password is wrong');
            return;
        }

        User.username = enteredUsername;
        User.password = enteredPassword;
        console.log(User);
        User.greet();
    }
}