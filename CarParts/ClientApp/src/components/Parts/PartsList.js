import React, { Component } from 'react';
import PartItem from './PartItem';
import '../css/styles.css';

class PartsList extends Component {
    state = {
        name: 'Part1',
        price: 100
    }

    render() {
        const { name, price } = this.state;

        return (
            <div className="grid">
                <PartItem name={name} price={price} />
                <PartItem name={name} price={price} />
                <PartItem name={name} price={price} />
                <PartItem name={name} price={price} />
                <PartItem name={name} price={price} />
                <PartItem name={name} price={price} />
                <PartItem name={name} price={price} />
            </div>
        );
    }
}

export default PartsList;