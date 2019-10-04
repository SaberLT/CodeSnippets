import React from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import { reduxForm, Field, formValueSelector } from 'redux-form'
import { AUTH_USER } from '../../../Actions/accountActions.js';
import { FormInputField } from '../Helpers.js';
//import axios from 'axios'

const SignUpForm = props => {
    let { authUser, values, history, account} = props;
    return ( 
        !account ?
        <form>
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
        // <Form>
        //     <FormGroup>
        //         <Form.Label>Login</Form.Label>
        //         <Field name="username" placeholder="username" id="username" width={6} component={FormInput} />
        //     </FormGroup>
        //     <FormGroup>
        //         <Form.Label>Password</Form.Label>
        //         <Field name="password" placeholder="password" id="password" width={6} hasPassword={true} component={FormInput} />
        //     </FormGroup>
        //     <button type="submit" onClick={(e)=>{e.preventDefault(); handleAuthUser(values, authUser, history)}}>Send</button>
        // </Form>
        : <div>
            <h3>You are already authorized!</h3>
        </div>
     );
}

const handleAuthUser = (values, authUser, history) => {
    console.log(values)
}

//const selector = formValueSelector('signInForm');

const mapStateToProps = store => {
    return({
    values : formValueSelector('signUpForm')(store, 'username', 'password', 'passwordConfirmation'),
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