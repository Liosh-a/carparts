import React, { Component } from "react";
import { validateFields } from "./validate";
import TextFieldGroup from "../common/TextFieldGroup";
import AlertGroup from "../common/AlertGroup";

export class Login extends Component {

    state = {
        email: "",
        password: "",
        errors: {
        },
        loading: false,

    };

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

    handleSubmit = e => {
        e.preventDefault();
        const fields = this.state;
        let errors = validateFields(fields);

        const isValid = Object.keys(errors).length === 0;
        console.log(this.props);
        if (isValid) {
            this.props.loginUser(fields);
        } else {
            this.props.setErrors(errors);
        }
    };

    render() {
        const { email, password, errors, loading } = this.state;

        return (
            <div>
                <div className="wrapper fadeInDown">
                    <div id="formContent">
                        <div className="fadeIn first">
                            <h1>Вход</h1>
                        </div>
                        {errors.invalid && (
                            <AlertGroup title={errors.invalid} alertColor="alert-danger" />
                        )}
                        <form name="form" onSubmit={this.handleSubmit}>
                        <TextFieldGroup
                                field="email"
                                label="Електронна пошта"
                                value={email}
                                error={errors.email}
                                onChange={this.handleChange}
                                type="text"
                                placeholder="Электронная пошта"
                                isShowLabel={false}
                            />

                            <TextFieldGroup
                                field="password"
                                label="Пароль"
                                value={password}
                                error={errors.password}
                                onChange={this.handleChange}
                                type="password"
                                placeholder="Пароль"
                                isShowLabel={false}
                            />

                            <div className="form-group">
                                <button
                                    className="btn btn-primary fadeIn fourth"
                                >
                                    {loading && <span className="spinner-border spinner-border-sm mr-2" role="status" aria-hidden="true"></span>}
                                    Вход
                                </button>
                            </div>
                        </form>
                        <div id="formFooter">
                            <a className="underlineHover" href="/forgot-password">Забыли пароль?</a>
                        </div>
                        <div id="formFooter">
                            <a className="underlineHover" href="/registration">Еще не зарегистрированы?</a>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

export default Login;

