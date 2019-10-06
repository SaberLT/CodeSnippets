import React from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import { reduxForm, Field, formValueSelector } from 'redux-form'
import { AUTH_USER } from '../../../Actions/accountActions.js';
import { FormInputField } from '../Helpers.js';
import { SIGN_UP_USER} from '../../../Api'
import axios from 'axios';

const SignUpForm = props => {
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
                <label>Password Confirmation</label>
                <Field name="passwordConfirmation" isPassword={true} placeholder="Your password" id="passwordConfirmation" classes="col" width={6} component={FormInputField} />
            </div>
            <div className="form-group offset-1 col-10 offset-lg-0">
                <button className="btn btn-outline-info">Sign up</button>
            </div>
        </form>
        : <div>
            <h3>You are already authorized!</h3>
        </div>
     );
}

const handleAuthUser = (values, authUser, history) => {
    let { login, password, passwordConfirmation } = values;

    if(password!==passwordConfirmation) //TODO
        console.log("Passwords doesn't match!");

    axios.post(SIGN_UP_USER, {
        login,
        password,
        passwordConfirmation
    })
    .then(res=> {
        if(res.data.error === 0) {
            let result = res.data.response;
            console.log(res.data.response);
            authUser({
                ...result
            });
            history.push('/');
        } else {
            console.log('Error: ', res.data.error)
        }
    })
}

const selector = formValueSelector('signUpForm');

const mapStateToProps = store => {
    return({
    values : selector(store, 'login', 'password', 'passwordConfirmation'),
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
    form: 'signUpForm',
    onSubmit: handleAuthUser
})(connect(mapStateToProps, mapDispatchToProps)(SignUpForm)));