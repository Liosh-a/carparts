import React, { useState } from 'react';
import { Collapse } from 'reactstrap';
import propTypes from 'prop-types';

const Category = ({ categoryName }) => {

    
    const [isOpen, setIsOpen] = useState(false);

    const toggle = () => setIsOpen(!isOpen);

    return (
        <div className="item">
            <span className="btn" onClick={toggle}>{categoryName}</span>
            <Collapse isOpen={isOpen}>
                <div className="smenu">
                    <button>Тормозные колодки барабанные</button>
                    <button>Тормозной барабан</button>
                    <button>Трос ручного тормоза</button>
                    <button>Скобы тормозных колодок</button>
                    <button>Ремкомплект барабанных колодок</button>
                    <button>Тормозной поршень</button>
                    <button>Гидравлика тормозной системы</button>
                    <button>Датчик износа тормозных колодок</button>
                </div>
            </Collapse>
        </div>
    );
};

Category.propTypes = {
    categoryName: propTypes.string.isRequired,
};

export default Category;