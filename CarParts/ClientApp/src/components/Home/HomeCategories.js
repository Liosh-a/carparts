import React from 'react';
import HomeCategory from './HomeCategory';
import './home.css';

const HomeCategories = ({ id, name, childCategories = [] }) => {
    const categories = childCategories.map(item => (
        <HomeCategory key={item.id} name={item.name} />
    ))
    console.log("child",childCategories)
    return (
        <div className="extra_layout" key={id}>
            <h3 className="modtitle"><span>{name}</span></h3>
            <div className="mdcontent row">
                {categories}
            </div>
        </div>
    )
}

export default HomeCategories;

