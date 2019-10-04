import React from 'react';
import SignUpForm from '../ReduxForms/Account/SignUpForm.jsx'
import '../../../css/account.css'

const SignUpPage = props => {
    return ( <div className="row">
    <div className="col-12 col-lg-6">
        <p className="h3">Oldschool sign up:</p>
        <SignUpForm />
    </div>
    <div className="col-12 col-lg-6">
        <p className="h3">Modern OAuth sign up:</p>
        <button className="btn btn-outline-info col-12 oauth-button">Sign up with Github</button>
        <button className="btn btn-outline-info col-12 oauth-button">Sign up with vk.com</button>
    </div>
</div>);
}
 
export default SignUpPage;