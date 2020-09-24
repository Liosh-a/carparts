import React, { Component } from 'react';
import HomeCategories from './HomeCategories';
import * as categoriesAction from '../Categories/reducer';
import { get } from 'lodash';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import "./home.css";

const propTypes = {
    getCategories: PropTypes.func.isRequired,
    categories: PropTypes.array.isRequired,
}

const defaultProps = {};

class HomeContainer extends Component {
    state = {}

    constructor(props) {
        super(props);
        this.state = {
            categories: []
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
        console.log(categories);
        const categoriesList = categories.map((category) => (
            <HomeCategories key={category.parentCategory.id} name={category.parentCategory.name} childCategories={category.childCategories} />
        ));
        return (
            <div className="container">
                <div className="pre_text">
                    Категории
        </div>
                {categoriesList}
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

HomeContainer.propTypes = propTypes;
HomeContainer.defaultProps = defaultProps;

export default connect(mapState, mapDispatch)(HomeContainer);