import React, { Component } from 'react';
import logo from '../img/logo.png';
import FluidGrid from '@allpro/react-fluid-grid';

class HeaderMiddle extends Component {
    state = {}
    render() {
        return (
                <div className="header-middle hidden-compact">
                    <div className="container">
                    <FluidGrid container className="row">
                            <FluidGrid item minWidth="30%">
                                <div id="sosearchpro" className="sosearchpro-wrapper so-search ">
                                    <form>
                                        <div id="search0" className="search form-group">
                                            <input className="autosearch-input form-control search-imput" type="text" size="50"
                                                autoComplete="off" placeholder="Поиск... " name="search" />
                                            <button type="submit" className="btn search-button"
                                                name="submit_search"><i className="fa fa-search"></i>
                                            </button>
                                        </div>
                                    </form>
                                </div>
                            </FluidGrid>
                            <FluidGrid item minWidth="40%">
                                <div className="logo">
                                    <a href="/" className="logo-link">
                                        <img src={logo} className="logo-image" />
                                    </a>
                                </div>
                            </FluidGrid>
                            <FluidGrid item minWidth="30%" >
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
                            </FluidGrid>
                        </FluidGrid>
                    </div>
                </div>
        );
    }
}

export default HeaderMiddle;