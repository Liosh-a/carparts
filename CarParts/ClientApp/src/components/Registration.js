import React from 'react';
import { connect } from 'react-redux';
import './css/Authorization.css'

const Registration = props => (
    <div>
        <div class="wrapper fadeInDown">
            <div id="formContent">
                <div class="fadeIn first">
                    <h1>Registration</h1>
                </div>
                <form>
                    <input type="text" id="name" class="fadeIn second" name="name" placeholder="name" />
                    <input type="text" id="login" class="fadeIn second" name="login" placeholder="gmail" />
                    <input type="password" id="password" class="fadeIn third" name="login" placeholder="Пароль" />
                    <input type="password" id="confirmpassword" class="fadeIn third" name="confirmPassword" placeholder="Підтвердження паролю" />
                    <input type="submit" class="fadeIn fourth" value="Зареєструватись" />
                </form>
                <div id="formFooter">
                    <a class="underlineHover" href="/login">Повернутись до входу</a>
                </div>
            </div>
        </div>
    </div>
);

export default connect()(Registration);