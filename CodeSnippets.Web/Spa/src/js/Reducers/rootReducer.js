import { combineReducers } from 'redux'
import { reducer as formReducer } from 'redux-form'

import accountReducer from './accountReducer.js'

export default combineReducers({
    account: accountReducer,

    form: formReducer
});