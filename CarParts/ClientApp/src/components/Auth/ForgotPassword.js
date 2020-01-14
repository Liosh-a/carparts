import React from 'react';
import { connect } from 'react-redux';
import './css/Authorization.css';

const ForgotPassword = props => (
    <div>
        <div className="wrapper fadeInDown">
            <div id="formContent">
                <div className="fadeIn first">
                    <h1>Забыли пароль?</h1>
                </div>
                <form>
                    <input type="text" id="login" className="fadeIn second" name="login" placeholder="Электронная почта" />
                    <input type="submit" className="fadeIn fourth" value="Восстановить" />
                </form>
                <div id="formFooter">
                    <a className="underlineHover" href="/login">Вернутся к входу</a>
                </div>
                <div id="formFooter">
                    <a className="underlineHover" href="/registration">Еще не зарегиcтрированы?</a>
                </div>
            </div>
        </div>
    </div>
);

export default connect()(ForgotPassword);