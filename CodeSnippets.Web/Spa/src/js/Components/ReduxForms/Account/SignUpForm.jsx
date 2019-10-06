import React from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import { reduxForm, Field, formValueSelector } from 'redux-form'
import { AUTH_USER } from '../../../Actions/accountActions.js';
import { FormInputField } from '../Helpers.js';
import { SIGN_UP_USER, SIGN_IN_USER} from '../../../Api'
import axios from 'axios';

const SignUpForm = props => {
    let { authUser, values, history, account} = props;
    return ( 
        !account ?
        <form onSubmit={(e)=>{e.preventDefault();handleAuthUser(values, authUser, history)}}>
            <div className="form-group offset-1 col-10 offset-lg-0">
                <label>Username</label>
                <Field name="username" placeholder="Your username" id="username" classes="col" width={6} component={FormInputField} />
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
                <button className="btn btn-outline-info">Sign in</button>
            </div>
        </form>
        : <div>
            <h3>You are already authorized!</h3>
        </div>
     );
}

const handleAuthUser = (values, authUser, history) => {
    let { username, password, passwordConfirmation } = values;

    if(password!=passwordConfirmation) //TODO
        console.log("passwords doesn't match!");

    axios.post(SIGN_UP_USER, {
        username,
        password,
        passwordConfirmation
    })
    .then(res=> {
        console.log('Response isL ', res)
        if(res.data.error === 0) {
            let result = res.data.response;
            authUser(result);
            history.push('/');
        } else {
            console.log('Error: ', res.data.error)
        }
    })
}

const selector = formValueSelector('signInForm');

const mapStateToProps = store => {
    return({
    values : selector(store, 'username', 'password', 'passwordConfirmation'),
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