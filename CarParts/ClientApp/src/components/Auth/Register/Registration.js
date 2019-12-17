import React, {Component} from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import {registerUser} from './RegisterReducer';
import EclipseWidget from '../../Eclipse';
import classnames from 'classnames';
import '../css/Authorization.css';

const propTypes = {
        register: PropTypes.func.isRequired,
        loading: PropTypes.bool.isRequired
    };

class Registration extends Component {

    state = {
        email: '',
        password: '',
        passwordConfirm: '',
        loading: this.props.loading,
        errors: {
            // email: 'Invalid',
            // password: 'Invalid'
        }
    }

    handleSubmit = (e) => {
                e.preventDefault();
                console.log('--register submit--');
                const {email, password, passwordConfirm} = this.state;
                this.props.register({
                    email: email, 
                    password: password, 
                    passwordConfirm: passwordConfirm}
                );
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

    render() {
        const {email, loading, password, passwordConfirm, errors} = this.state;
        return (
            <div>
                <div className="wrapper fadeInDown">
                    <div id="formContent">
                        <div className="fadeIn first">
                            <h1>Регистрация</h1>
                        </div>
                        <form name="form" onSubmit={this.handleSubmit}>
                            {/* <input type="text" id="name" class="fadeIn second" name="name" placeholder="name" /> */}
                            <div>
                                <input 
                                    type="text"
                                    id="email"
                                    className={classnames('form-control', { 'is-invalid': !!errors.email })}
                                    name="email"
                                    value={email}
                                    onChange={this.handleChange}
                                    placeholder="Электронная почта" />
                                {!!errors.email &&
                                    <div className="help-block">{errors.email}</div>
                                }
                            </div>
                            
                            <div>
                                <input
                                    type="password"
                                    id="password"
                                    className={classnames('form-control', { 'is-invalid': !!errors.password })}
                                    name="password"
                                    value={password}
                                    placeholder="Пароль"
                                    onChange={this.handleChange} />
                                {!!errors.password &&
                                    <div className="help-block">{errors.password}</div>
                                }
                            </div>
                            <div>
                                <input
                                    type="password"
                                    id="passwordConfirm"
                                    className={classnames('form-control', { 'is-invalid': !!errors.password })}
                                    name="passwordConfirm"
                                    value={passwordConfirm}
                                    placeholder="Подтверждение пароля"
                                    onChange={this.handleChange} />
                                {!!errors.passwordConfirm &&
                                    <div className="help-block">{errors.password}</div>
                                }
                            </div>
                          
                            <input type="submit" className="fadeIn fourth" value="Зарегистрироватся" />
                        </form>
                        {loading && <EclipseWidget/>}
                        <div id="formFooter">
                            <a className="underlineHover" href="/login">Вернутся к входу</a>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

const mapState = (state) => {
    return {
        loading: state.register.loading,
        errors: state.register.errors,
    }
}

Registration.propTypes = propTypes;
 
export default connect(mapState, {register: registerUser})(Registration);


