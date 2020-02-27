import React, { Component } from 'react';
import AlertGroup from "../common/AlertGroup";
import { validateFields } from "./validate";
import TextFieldGroup from "../common/TextFieldGroup";
import '../css/Authorization.css';

class Registration extends Component {
    
    state = {
        email: '',
        password: '',
        passwordConfirm: '',
        loading: false,
        errors: {
        }
    }


    static getDerivedStateFromProps(nextProps, prevState) {
        return {
            loading: nextProps.loading,
            errors: nextProps.errors,
        };
    }

    setStateByErrors = (name, value) => {
        if (!!this.state.errors[name]) {
            let errors = Object.assign({}, this.state.errors);
            delete errors[name];
            this.setState({
                [name]: value,
                errors
            });
        } else {
            this.setState({ [name]: value });
        }
    };

    handleChange = e => {
        this.setStateByErrors(e.target.name, e.target.value);
    };

    handleSubmit = (e) => {
        e.preventDefault();
        const fields = this.state;
        let errors = validateFields(fields);

        const isValid = Object.keys(errors).length === 0;
        if (isValid) {
            this.props.registerUser(fields); 
        } else {
            this.props.setErrors(errors);
        }
    }

    render() {
        const { email, loading, password, passwordConfirm, errors } = this.state;
        return (
            <div>
                <div className="wrapper fadeInDown">
                    <div id="formContent">
                        <div className="fadeIn first">
                            <h1>Регистрация</h1>
                        </div>
                        {errors.invalid && (
                            <AlertGroup title={errors.invalid} alertColor="alert-danger" />
                        )}
                        <form name="form" onSubmit={this.handleSubmit}>
                            {/* <input type="text" id="name" class="fadeIn second" name="name" placeholder="name" /> */}
                            <TextFieldGroup
                                field="email"
                                label="Електронна пошта"
                                value={email}
                                error={errors.email}
                                onChange={this.handleChange}
                                type="text"
                                placeholder="Электронная почта"
                                isShowLabel={false}
                            />

                            <TextFieldGroup
                                field="password"
                                label="Пароль"
                                value={password}
                                error={errors.password}
                                onChange={this.handleChange}
                                type="text"
                                placeholder="Пароль"
                                isShowLabel={false}
                            />

                            <TextFieldGroup
                                field="passwordConfirm"
                                label="Подтверждение пароля"
                                value={passwordConfirm}
                                error={errors.passwordConfirm}
                                onChange={this.handleChange}
                                type="text"
                                placeholder="Подтверждение пароля"
                                isShowLabel={false}
                            />

                            <div>
                                <button className="btn btn-primary fadeIn fourth">
                                    {loading && <span className="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>}
                                    Регистрация
                                </button>
                            </div>
                        </form>
                        <div id="formFooter">
                            <a className="underlineHover" href="/login">Вернутся к входу</a>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

export default Registration;


