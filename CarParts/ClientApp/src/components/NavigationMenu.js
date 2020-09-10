import React, { Component } from 'react';
import './Navigation.css';
import '../../node_modules/font-awesome/css/font-awesome.min.css';
import logo from './img/logo.png';
import Category from './Categories/Category';

class NavigationMenu extends Component {
    state = {}

    render() {
        return (
            <div>
                <div className="header-middle hidden-compact">
                    <div className="container">
                        <div className="row">
                            <div className="col-lg-4 col-md-4 col-sm-4 col-xs-3">
                                <div className="search-header-w">
                                    <div id="sosearchpro" className="sosearchpro-wrapper so-search ">
                                        <form>
                                            <div id="search0" className="search form-group">
                                                <input class="autosearch-input form-control search-imput" type="text" size="50"
                                                    autocomplete="off" placeholder="Поиск... " name="search" />
                                                <button type="submit" className="btn search-button"
                                                    name="submit_search"><i className="fa fa-search"></i>
                                                </button>
                                            </div>
                                            <input type="hidden" name="route" value="product/search" />
                                        </form>
                                    </div>
                                </div>
                            </div>
                            <div className="col-lg-4 col-md-4 col-sm-4 col-xs-3">
                                <div className="logo">
                                    <a href="#" className="logo-link">
                                        <img src={logo} className="logo-image" />
                                    </a>
                                </div>
                            </div>
                            <div className="col-lg-4 col-md-4 col-sm-4 col-xs-3">
                                <div className="shopping-cart">
                                    <div id="cart" className="btn-shopping-cart">
                                        <a href="/cart" className="btn-group top-cart">
                                            <div className="shopcart">
                                                <span className="icon-c">
                                                    <i className="fa fa-shopping-basket"></i>
                                                </span>
                                                <div className="shopcart-inner">
                                                    <p className="text-shopping-cart">
                                                        Моя Корзина
                                                </p>
                                                    <span className="total-shopping-cart cart-total-full">
                                                        <span className="items-cart">00</span>
                                                    </span>
                                                </div>
                                            </div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
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
                                                            <a className="link" href="#">Главная</a>
                                                        </li>
                                                        <Category/>
                                                        <Category/>
                                                        <Category/>
                                                        <Category/>
                                                        <Category/>
                                                        <Category/>
                                                        <Category/>
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
            </div>
        );
    }
}

export default NavigationMenu;


