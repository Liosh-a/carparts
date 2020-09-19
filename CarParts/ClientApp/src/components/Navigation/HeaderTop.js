import React, { Component } from 'react';

class HeaderTop extends Component {
    state = {}
    render() {
        return (
            <div className="row">
                <div className="header-top-left col-lg-12 col-xs-12">
                    <ul className="top-log list-inline">
                        <li>
                            <i className="fa fa-lock"></i>
                            <a href="/login">Вход</a>/
                        </li>
                        <li>
                            <i className="fa fa-lock"></i>
                            <a href="/login">Регистрация</a>
                        </li>
                    </ul>
                </div>
            </div>
        );
    }
}

export default HeaderTop;