import React from "react";
import propTypes from "prop-types";

const PartItem = ({
    id,
    name,
    price
}) => {
    return (
        <div className="item_single" key={id}>
            <img src="http://img.tjskl.org.cn/pic/z2577d9d-200x200-1/pinarello_lungavita_2010_single_speed_bike.jpg" alt="item" />
            <h2 className="name_cart">{name}</h2>

            <p>Price: {price}$</p>
            <button className="add-to-cart" type="button">Add to cart</button>
        </div>
    )
};

PartItem.propTypes = {
    name: propTypes.string.isRequired,
    price: propTypes.number.isRequired
};

export default PartItem;
