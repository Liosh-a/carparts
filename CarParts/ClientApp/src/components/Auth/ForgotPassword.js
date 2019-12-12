import React from 'react';
import { connect } from 'react-redux';
import './css/Authorization.css';

const ForgotPassword = props => (
    <div>
        <div class="wrapper fadeInDown">
            <div id="formContent">
                <div class="fadeIn first">
                    <h1>Forgot Password?</h1>
                </div>
                <form>
                    <input type="text" id="login" class="fadeIn second" name="login" placeholder="gmail" />
                    <input type="submit" class="fadeIn fourth" value="Відновити" />
                </form>
                <div id="formFooter">
                    <a class="underlineHover" href="/login">Повернутись до входу</a>
                </div>
                <div id="formFooter">
                    <a class="underlineHover" href="/registration">Already have not account?</a>
                </div>
            </div>
        </div>
    </div>
);

export default connect()(ForgotPassword);