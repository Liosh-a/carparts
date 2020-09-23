import React, { useState } from 'react';
import propTypes from 'prop-types';
import '../Navigation/Navigation.css';
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';

const Category = ({ id, name, childCategories=[] }) => {
    
    const [dropdownOpen, setDropdownOpen] = useState(false);

    const toggle = () => setDropdownOpen(prevState => !prevState);

    const dropdownCategories = childCategories.map(item => (
    <DropdownItem key={item.id}>{item.name}</DropdownItem>
    ))
    return (
        <li className="category-link" key={id}>
            <Dropdown isOpen={dropdownOpen} toggle={toggle}>
                <DropdownToggle caret className="dropdown-category">
                    {name}
                </DropdownToggle>
                <DropdownMenu >
                    {dropdownCategories}
                </DropdownMenu>
            </Dropdown>
        </li>
    )
}

export default Category;