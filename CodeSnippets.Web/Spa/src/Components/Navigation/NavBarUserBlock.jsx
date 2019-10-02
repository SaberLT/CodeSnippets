import React from 'react';
import { Nav } from 'react-bootstrap'

const NavBarUserBlock = (props) => {
    return ( 
        <Nav>
            <Nav.Link href="#signin">Sign in</Nav.Link>
            <Nav.Link href="#signup">Sign up</Nav.Link>
        </Nav>
    );
}
 
export default NavBarUserBlock;