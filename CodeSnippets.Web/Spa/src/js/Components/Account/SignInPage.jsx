import React from 'react';
import SignInForm from '../ReduxForms/Account/SignInForm.jsx'
import '../../../css/account.css'

const SignInPage = props => {
    return (
        <div className="row">
            <div className="col-12 col-lg-6">
                <p className="h3">Oldschool sign in:</p>
                <SignInForm />
            </div>
            <div className="col-12 col-lg-6">
                <p className="h3">Modern OAuth sign in:</p>
                <button className="btn btn-outline-info col-12 oauth-button">Sign in with Github</button>
                <button className="btn btn-outline-info col-12 oauth-button">Sign in with vk.com</button>
            </div>
        </div> );
}
 
export default SignInPage;