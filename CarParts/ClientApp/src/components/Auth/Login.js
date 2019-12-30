import React from 'react';
import { connect } from 'react-redux';
import './css/Authorization.css';

const Login = props => (
    <div>
        <div className="wrapper fadeInDown">
            <div id="formContent">
                <div className="fadeIn first">
                    <h1>Login</h1>
                </div>
                <form>
                    <input type="text" id="login" className="fadeIn second" name="login" placeholder="Электронная почта" />
                    <input type="password" id="password" className="fadeIn third" name="login" placeholder="Пароль" />
                    <input type="submit" className="fadeIn fourth" value="Вход" />
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

export default connect()(Login);