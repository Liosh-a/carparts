import React, { Component } from 'react';
import { Collapse } from 'reactstrap';

class Category extends Component {

    constructor(props) {
        super(props);

        this.toggle = this.toggle.bind(this);
        this.state = {
            isOpen: false
        };
    }
    toggle() {
        this.setState({
            isOpen: !this.state.isOpen
        });
    }

    render() {
        return (
            <div className="item">
                <span className="btn" onClick={this.toggle}>Toggle</span>
                <Collapse isOpen={this.state.isOpen}>
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
    }
}

export default Category;