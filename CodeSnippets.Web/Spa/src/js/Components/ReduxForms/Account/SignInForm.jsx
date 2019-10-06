import React from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import { reduxForm, Field, formValueSelector } from 'redux-form'
import { AUTH_USER } from '../../../Actions/accountActions.js';
import { FormInputField } from '../Helpers.js';
import axios from 'axios';
import { SIGN_IN_USER } from '../../../Api/index.js';

const SignInForm = props => {
    let { authUser, values, history, account} = props;
    return ( 
        !account ?
        <form onSubmit={(e)=>{e.preventDefault(); handleAuthUser(values, authUser, history)}}>
            <div className="form-group offset-1 col-10 offset-lg-0">
                <label>Login</label>
                <Field name="login" placeholder="Your login" id="login" classes="col" width={6} component={FormInputField} />
            </div>
            <div className ="form-group offset-1 col-10 offset-lg-0">
                <label>Password</label>
                <Field name="password" isPassword={true} placeholder="Your password" id="password" classes="col" width={6} component={FormInputField} />
            </div>
            <div className="form-group offset-1 col-10 offset-lg-0">
                <button className="btn btn-outline-info">Sign in</button>
            </div>
        </form>
        : <div>
            <h3>You are already authorized!</h3>
        </div>
     );
}

const handleAuthUser = (values, authUser, history) => {
    let { login, password } = values;

    axios.post(SIGN_IN_USER, {
        login, password
    })
    .then(res=>{
        if(res.data.error === 0){
            let result= res.data.response;
            authUser({
                ...result
            });
            history.push('/')
        } else {
            console.log('Error', res.data.error)
        }
    })
}

const selector = formValueSelector('signInForm');

const mapStateToProps = store => {
    return({
    values : selector(store, 'login', 'password'),
    hasToken : store.account.token===undefined? false : true
})}

const mapDispatchToProps = dispatch => ({
    authUser : values => {
        dispatch({
            type: AUTH_USER,
            payload: values
        })
    }
})

export default withRouter(reduxForm({
    form: 'signInForm',
    onSubmit: handleAuthUser
})(connect(mapStateToProps, mapDispatchToProps)(SignInForm)));