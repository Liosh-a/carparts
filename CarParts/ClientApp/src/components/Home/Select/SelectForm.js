import React, { Component } from 'react';
import SelectItem from './Select';
import PropTypes from 'prop-types';
import { get } from 'lodash';
import { connect } from 'react-redux';
import * as YearsStore from './reducer';

class SelectForm extends Component {

    state = {}

    constructor(props) {
        super(props);
        this.state = {
            years: {},
            marks: {},
            models: {}
        }
    }

    componentDidMount = () => {
        this.props.getYears();
    }

    render() {
        const {years:{data=[]}} = this.props;
        return (
            <form className="row">
                <SelectItem className="select-part" selectName="Год выпуска" options={data}/>
                <SelectItem className="select-part" selectName="Марка" />
                <SelectItem className="select-part" selectName="Модель" />
                <div className="col-lg-3 col-md-3 col-sm-12 my-sm-2 searchButton">
                    <button type="button" id="sas_search_button0">Поиск</button>
                </div>
            </form>
        );
    }
}

const mapStateToProps = (state) => {
    console.log("state", state);
    return {
        years:{
            IsFailed: get(state, 'select.years.failed'),
            IsSuccess: get(state, 'select.years.success'),
            data: get(state, 'select.years.data')
        },
        marks:{
            IsFailed: get(state, 'marks.failed'),
            IsSuccess: get(state, 'marks.success'),
            data: get(state, 'marks.data')
        },
        models:{
            IsFailed: get(state, 'models.failed'),
            IsSuccess: get(state, 'models.success'),
            data: get(state, 'models.data')
        }
    }
}

const mapDispatch = {
    getYears: () => {
        return YearsStore.getYears();
    },
    getMarks: (id) => {
        return YearsStore.getMarks(id);
    },
    getModels: (id) => {
        return YearsStore.getModels(id);
    }
}

export default connect(mapStateToProps, mapDispatch) (SelectForm);