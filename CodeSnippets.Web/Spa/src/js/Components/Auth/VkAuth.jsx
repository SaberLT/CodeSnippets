import React, { Component } from 'react';
import VkIcon from '../../../icons/vk.svg'

const authDataDevelopment = {
    client_id: '7158988',
    request_uri: 'https://oauth.vk.com/authorize',
    redirect_uri: 'http://localhost:3000/auth/vk',
}

class VkAuth extends Component {
    formAuth = () => {
        let {client_id, request_uri, redirect_uri} = authDataDevelopment;

        let path = `${request_uri}?client_id=${encodeURIComponent(client_id)}&groups_id=7158988&redirect_uri=${encodeURIComponent(redirect_uri)}&state=123123123&response_type=token&display=popup&v=5.101?scope=1024`;
        console.log("Path: ", path);
        return path;
    }

    render() { 
        return ( 
            <button className="btn btn-outline-info offset-1 col-10 oauth-button"
                onClick={(e)=>{window.location.href=this.formAuth()}}
            >Sign up with vk.com <VkIcon /></button>
        );
    }
}

export default VkAuth;