import React, { Component } from 'react';
import Category from '../Categories/Category';

class HeaderBottom extends Component {
    state = {  }
    render() { 
        return ( 
            <div className="header-bottom">
                    <div className="container">
                        <div className="main-menu-w">
                            <div className="responsive so-megamenu megamenu-style-dev">
                                <nav className="navbar-default">
                                    <div className="container-megamenu horizontal-open">
                                        <div className="megamenu-wrapper">
                                            {/* <span id="remove-megamenu" className="fa fa-times"></span> */}
                                            <div className="megamenu-pattern">
                                                <div className="container-mega">
                                                    <ul className="megamenu" data-transiton="slide" data-animationtime="250">
                                                        <li className="home hover">
                                                            <a className="link" href="/">Главная</a>
                                                        </li>
                                                        <Category categoryName="Автозапчасти"/>
                                                        <Category categoryName="Кузовные запчасти"/>
                                                        <Category categoryName="Освещение"/>
                                                        <Category categoryName="Электроника"/>
                                                        <Category categoryName="Интерьер"/>
                                                        <Category categoryName="Экстерьер"/>
                                                        <Category categoryName="Шины и Диски"/>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </nav>
                            </div>
                        </div>
                    </div>
                </div>
         );
    }
}
 
export default HeaderBottom;