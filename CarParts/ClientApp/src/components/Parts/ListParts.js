import React, { Component } from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import * as partsActions from './reducer';
import EclipseWidget from '../Eclipse/EclipseWidget';
import PartItem from './PartItem';
import { push } from 'connected-react-router';
import { get } from 'lodash';


const propTypes = {
    getParts: PropTypes.func.isRequired,
    parts: PropTypes.array.isRequired
}

const defaultProps = {};

class ListParts extends Component {
    state = {}

    constructor(props) {
        super(props);
        this.state = {
            parts: [],
            loading: false
        }
    }

    static getDerivedFromProps = (props, state) => {
        return {
            parts: props.parts,
            loading: props.isLoading
        }
    }

    componentDidMount() {
        const page = parseInt(this.props.match.params.page, 10) || 1;
        // This method is called when the component is first added to the document
        this.searchDataFetched(page);
    }

    componentDidUpdate() {
        const page = parseInt(this.props.match.params.page, 10) || 1;
        if (this.props.currentPage !== page) {
            this.searchDataFetched(page);
        }
        // This method is called when the route parameters change
    }

    searchDataFetched(page) {
        this.props.getParts(page);
    }


    callBackParams = (page) => {
        //console.log('props', this.props);
        this.props.push(`/parts/${page}`);
    }


    render() {
        const { loading, parts } = this.state;
        const partsContent = parts.map((part) =>
            <PartItem key={part.id}{...part} />)
        return (
            <div>
                <h1>Parts List</h1>
                <div>
                    {partsContent}
                </div>

                {loading && <EclipseWidget />}
            </div>
        );
    }
}

const mapState = (state) => {
    return {
        isLoading: get(state, 'parts.loading'),
        IsFailed: get(state, 'parts.failed'),
        IsSuccess: get(state, 'parts.success'),
        parts: get(state, 'parts.data'),
    }
}

const mapDispatch = {
    getParts: (page) => {
        return partsActions.getParts(page);
    }
}

ListParts.propTypes = propTypes;
ListParts.defaultProps = defaultProps;

export default connect(mapState, mapDispatch)(ListParts);