import React, { useState } from 'react';
import propTypes from 'prop-types';
import '../Navigation/Navigation.css';
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';

const Category = ({
    id,
    name = "Категория"
     }) => {


    const [dropdownOpen, setDropdownOpen] = useState(false);

    const toggle = () => setDropdownOpen(prevState => !prevState);


    return (
        <li className="category-link" key={id}>
            <Dropdown isOpen={dropdownOpen} toggle={toggle}>
                <DropdownToggle caret  className="dropdown-category">
                {name}
            </DropdownToggle>
                <DropdownMenu >
                    <DropdownItem>Авто</DropdownItem>
                </DropdownMenu>
            </Dropdown>
        </li>
    );
};

Category.propTypes = {
    categoryName: propTypes.string.isRequired,
};

export default Category;