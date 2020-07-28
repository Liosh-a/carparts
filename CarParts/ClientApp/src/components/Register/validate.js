function validateFields(items) {
    let errors = {};
    if (items.email.trim() === '') {
        errors = {
            ...errors,
            email: "Введите электронную почту !"
        }
    }
    if (items.password.trim() === '') {
        errors = {
            ...errors,
            password: "Введите пароль !"
        }
    }
    if (items.passwordConfirm.trim() === '') {
        errors = {
            ...errors,
            passwordConfirm: "Введите пароль !"
        }
    }
    return errors;
}

export { validateFields };