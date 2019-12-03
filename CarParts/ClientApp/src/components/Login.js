import React from 'react';
import { connect } from 'react-redux';
import './css/Authorization.css'

const Login = props => (
    <div>
        <div class="wrapper fadeInDown">
            <div id="formContent">
                <div class="fadeIn first">
                    <h1>Login</h1>
                </div>
                <form>
                    <input type="text" id="login" class="fadeIn second" name="login" placeholder="gmail" />
                    <input type="password" id="password" class="fadeIn third" name="login" placeholder="Пароль" />
                    <input type="submit" class="fadeIn fourth" value="Log In" />
                </form>
                <div id="formFooter">
                    <a class="underlineHover" href="/forgot-password">Forgot Password?</a>
                </div>
                <div id="formFooter">
                    <a class="underlineHover" href="/registration">Already have not account?</a>
                </div>
            </div>
        </div>
    </div>
);

export default connect()(Login);