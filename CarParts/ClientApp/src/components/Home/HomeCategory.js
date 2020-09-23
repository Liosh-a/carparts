import React from 'react';
import demo from '../img/demo.jpg';
import './home.css';

const HomeCategory = ({id, name}) => {

    return(
        <div className="product-item-container item--static col-lg-2 col-sm-6" key={id}>
        <div className="left-block">
            <div className="product-image-container second_img">
                <a>
                    <img src={demo} className="img-1 img-responsive" alt="image1"/>
                </a> 
            </div>
        </div>
        <div className="right-block">
            <h4><a>{name}</a></h4>
        </div>
    </div>
    )
}

export default HomeCategory;