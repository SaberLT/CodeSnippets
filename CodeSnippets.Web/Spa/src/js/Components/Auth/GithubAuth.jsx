import React, { Component } from 'react';
import GitHubIcon from '../../../icons/github.svg'

// const githubAuthDataProduction = {
//     client_id: 'c276c97b3076538e4004',
//     request_uri: 'https://github.com/login/oauth/authorize',
//     redirect_uri: 'http://localhost:3000/auth/github',
// }

const githubAuthDataDevelopment = {
    client_id: '32fd693e1152e5c78d53',
    request_uri: 'https://github.com/login/oauth/authorize',
    redirect_uri: 'http://localhost:3000/auth/github',
}

class GithubAuth extends Component {
    formAuth = () => {
        let {client_id, request_uri, redirect_uri} = githubAuthDataDevelopment;

        let path = `${request_uri}?scope=user:email&client_id=${encodeURIComponent(client_id)}&redirect_uri=${encodeURIComponent(redirect_uri)}&state=123123123`;
        console.log('Path: ', path);
        return path;
    }

    render() {
        return (
            <button className="btn btn-outline-info offset-1 col-10 oauth-button"
                onClick={()=>{window.location.href=this.formAuth()}}
            >Sign up with Github <GitHubIcon /></button>
        );
    }
    
}
 
export default GithubAuth;