import React from 'react';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import { Navbar, NavbarBrand, NavbarToggler, Collapse, NavItem, NavLink } from 'reactstrap';
import { logout } from '../src/components/Auth/actions';
import { connect } from 'react-redux';

export class NavMenu extends React.Component {
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
      <Navbar className="nav-container navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow mb-3" light>
        <NavbarBrand tag={Link} to="/">
          <h2 className="mt-2">Koparts</h2>
        </NavbarBrand>
        <NavbarToggler onClick={this.toggle} className="mr-2" />
        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={this.state.isOpen} navbar>
          {/* {this.props.isAuthenticated ?
            <ul className="android-navigation mdl-navigation navbar-nav navbar-dark flex-grow">
              <NavItem>
                <NavLink tag={Link} className="mdl-navigation__link mdl-typography--text-uppercase mb-2 pt-0" to="/parts-list">Home</NavLink>
              </NavItem>
              <NavItem className="mdl-navigation__link mdl-typography--text-uppercase mb-2 pt-0" onClick={() => this.props.logout()}>
                Выход
            </NavItem>
              <NavItem>
                <NavLink tag={Link} className="mdl-navigation__link mdl-typography--text-uppercase mb-2 pt-0" to="/">Корзина</NavLink>
              </NavItem>
            </ul>
            : */}
            <ul className="android-navigation mdl-navigation navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="mdl-navigation__link mdl-typography--text-uppercase mb-2 pt-0 txt-dark" to="/parts-list">Home</NavLink>
              </NavItem>
              {/* <NavItem>
                <NavLink tag={Link} className="mdl-navigation__link mdl-typography--text-uppercase mb-2 pt-0" to="/login">Вход</NavLink>
              </NavItem> */}
              <NavItem>
                <NavLink tag={Link} className="mdl-navigation__link mdl-typography--text-uppercase mb-2 pt-0" to="/cart">Корзина</NavLink>
              </NavItem>
            </ul>
          {/* } */}
        </Collapse>
      </Navbar>
    );
  }
}

const mapState = (state) => {
  return {
    isAuthenticated: state.login.isAuthenticated
  }
}


export default connect(mapState, { logout })(NavMenu)