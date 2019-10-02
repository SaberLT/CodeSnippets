// Delete if all would be good with JWT Token from ASP.NET CORE (Web Api)
import cookie from 'js-cookie';
import { AUTH_USER, LOGOUT_USER } from '../Actions/accountActions.js'

const initState = {
    token: '',
    username: ''
}

const accountReducer = (state = initState, action) => {
    switch(action.type) {
        case AUTH_USER: {
            cookie.set('AUTH', action.payload, { expires: 30 })
            return {...state,
                ...action.payload
            }
        }
        case LOGOUT_USER: {
            return {...state,
                ...action.payload
            }
        }
        default:
            return state;
    }
}

export default accountReducer;