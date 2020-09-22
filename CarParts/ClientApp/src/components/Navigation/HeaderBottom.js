import React, { Component } from 'react';
import PropTypes from 'prop-types';
import Category from '../Categories/Category';
import * as categoriesAction from '../Categories/reducer';
import { get } from 'lodash';
import { connect } from 'react-redux';
import EclipseWidget from '../Eclipse/EclipseWidget';

const propTypes = {
    getCategories: PropTypes.func.isRequired,
    categories: PropTypes.array.isRequired
}

const defaultProps = {};

class HeaderBottom extends Component {
    state = {}

    constructor(props) {
        super(props);
        this.state = {
            categories: [],
            loading: false
        }
    }

    static getDerivedFromProps = (props, state) => {
        return {
            categories: props.categories,
            loading: props.isLoading
        }
    }

    render() {
        const { categories } = this.state;
        const categoriesList = categories.map((category) =>
            <Category key={category.id}{...category} />)
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
                                                    {categoriesList}
                                                </ul>
                                                {loading && <EclipseWidget />}
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

const mapState = (state) => {
    return {
        IsFailed: get(state, 'categories.failed'),
        IsSuccess: get(state, 'categories.success'),
        parts: get(state, 'categories.data'),
    }
}

const mapDispatch = {
    getParts: (model) => {
        return categoriesAction.getCategories(model);
    }
}

export default connect(mapState, mapDispatch)(HeaderBottom);