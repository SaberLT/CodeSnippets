import React, { Component } from 'react';
import axios from 'axios';
import { withRouter } from 'react-router-dom'
import { connect } from 'react-redux';
import qs from 'qs';
import { AUTH_USER } from '../../Actions/accountActions.js';

class VkAuthResult extends Component {
    doTheHusstle = () => {
        let { authUser, history } = this.props;

        console.log('Props',this.props);
        const code  = qs.parse(this.props.location.hash)
        console.log('Code: ', code)
        
        axios.post('http://localhost:50708/api/oauth/vkAuth', code)
        .then(res => {
            if(res.data.error === 0) {
                let result = res.data.response;
                authUser({
                    ...result
                });
                history.push('/');
            } else {
                console.log('Error', res.data.error);
            }
         });
    }

    render() { 
        return ( <div>
            {this.doTheHusstle()}
            <h3>Please wait until authorization...</h3>
        </div>);
    }
}
 
const mapDispatchToProps = dispatch => ({
    authUser: values => {
        dispatch({
            type: AUTH_USER,
            payload: values
        })
    }
})

export default withRouter(connect(null, mapDispatchToProps)(VkAuthResult))