import React, { Component } from 'react';
import { PartItem } from '../Parts/PartItem';

class Cart extends Component {

    handleRemove = (model) => {
        this.props.removeItem(model);
    }

    constructor(props) {
        super(props);
        this.state = {}
    }
    render() {
        // let addedItems = this.props.items.length ?(
        //     this.props.items.map(
        //         item => {
        return (
            <div>
                <h1>Корзина</h1>
                <div>
                    <h2>Добавлено: </h2>
                </div>
            </div>
        );
    }
    //     )
    // )

}
// }

export default Cart;