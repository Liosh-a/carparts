import React, { Component } from 'react';
import './Navigation.css';

class HeaderTop extends Component {
    state = {}
    render() {
        return (
            <div className="row">
                <div className="header-top-left col-lg-12 col-xs-12">
                    <ul className="top-log list-inline">
                        <li className="list-inline-item">
                            <i className="fa fa-lock"></i>
                            <a className="log-nav" href="/login">Вход</a>
                        </li>
                        <li className="list-inline-item">
                            <i className="fa fa-lock"></i>
                            <a className="log-nav" href="/registration">Регистрация</a>
                        </li>
                    </ul>
                </div>
            </div>
        );
    }
}

export default HeaderTop;