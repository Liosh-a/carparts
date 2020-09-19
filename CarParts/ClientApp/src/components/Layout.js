import React from 'react';
import NavigationMenu from './Navigation/NavigationMenu';

export default props => (
  <div className="layout">
    <NavigationMenu />
    <div>
      {props.children}
    </div>
  </div>
);
