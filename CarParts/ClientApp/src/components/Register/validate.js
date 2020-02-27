function validateFields(items){
    let errors={};
    if(items.email.trim() === ''){
        errors={
            ...errors,
            email:"Пошта є обов'язковою!"
        }
    }
    if(items.password.trim() === ''){
        errors={
            ...errors,
            password:"Пароль є обов'язковим!"
        }
    }
    if(items.passwordConfirm.trim() === ''){
        errors={
            ...errors,
            passwordConfirm:"Подтвердите пароль!"
        }
    }
    return errors;
}

export {validateFields};