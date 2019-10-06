import React, { Component } from 'react';
import { Nav, NavDropdown } from 'react-bootstrap'
import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom'
import cookie from 'js-cookie';
import '../../../css/navbar.css';

import { AUTH_USER, LOGOUT_USER } from '../../Actions/accountActions.js'

class NavBarUserBlock extends Component {
    componentWillMount() {
        let { authUser } = this.props;
        let authCookie = cookie.getJSON('AUTH');

        if(authCookie!==undefined)
            authUser(authCookie);       
    }

    render() {
        let { account, history } = this.props;
        let { logoutUser } = this.props;
    
        let isAuthed = account.token!=='';
    
            return ( <div>
                { isAuthed 
                    ?
                    <Nav>
                        <NavDropdown title={`Hello, ${account.username} `} id="collasible-nav-dropdown">
                            <NavDropdown.Item >Profile</NavDropdown.Item>
                            <NavDropdown.Item onClick={()=>logoutUser()}>Log out</NavDropdown.Item>
                        </NavDropdown>
                    </Nav>
                    : 
                    <Nav>
                        <Nav.Link onClick={()=>history.push('/signin')}>Sign in</Nav.Link>
                        <Nav.Link onClick={()=>history.push('/signup')}>Sign up</Nav.Link>
                    </Nav>}
                </div>
        );
    }
}

const mapStateToProps = ({ account }) => ({
    account
});

const mapDispatchToProps = dispatch => ({
    authUser: values => {
        dispatch({
            type: AUTH_USER,
            payload: values
        })
    },
    logoutUser: () => {
        dispatch({
            type: LOGOUT_USER
        })
    }
})

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(NavBarUserBlock));