import React from 'react';
import NavigationMenu from './NavigationMenu';

export default props => (
  <div className="layout">
    <NavigationMenu />
    <div>
      {props.children}
    </div>
  </div>
);
