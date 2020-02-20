function validateFields(items){
    let errors={};
    if(items.email.trim()===''){
        errors={
            ...errors,
            email:"Пошта є обов'язковою!"
        }
    }
    if(items.password.trim()===''){
        errors={
            ...errors,
            password:"Пароль є обов'язковим!"
        }
    }
    return errors;
}

export {validateFields};