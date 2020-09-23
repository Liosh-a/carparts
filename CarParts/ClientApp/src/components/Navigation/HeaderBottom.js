import React, { Component } from 'react';
import PropTypes from 'prop-types';
import Category from '../Categories/Category';
import * as categoriesAction from '../Categories/reducer';
import { get } from 'lodash';
import { connect } from 'react-redux';


const propTypes = {
    getCategories: PropTypes.func.isRequired,
    categories: PropTypes.array.isRequired,
}

const defaultProps = {};

class HeaderBottom extends Component {
    state = {}

    constructor(props) {
        super(props);
        this.state = {
            categories: [],
        }
    }

    static getDerivedFromProps = (props, state) => {
        return {
            categories: props.categories
        }
    }

    componentDidMount() {
        this.props.getCategories();
    }

    render() {
        const { categories } = this.props;
        const categoriesList = categories.map((category) => (
        <Category key={category.parentCategory.id} name={category.parentCategory.name} childCategories={category.childCategories}/>
        ));
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
        categories: get(state, 'categories.data'),
    }
}

const mapDispatch = {
    getCategories: () => {
        return categoriesAction.getCategories();
    }
}

HeaderBottom.propTypes = propTypes;
HeaderBottom.defaultProps = defaultProps;

export default connect(mapState, mapDispatch)(HeaderBottom);