import { composeWithDevTools } from 'redux-devtools-extension'
import { createStore, applyMiddleware } from 'redux'

import rootReduxer from '../Reducers/rootReducer.js';

const configureStore = initialState => {
    const store = createStore(rootReduxer, initialState)  
    
    //const store = createStore(rootReducer, initialState, composeWithDevTools(applyMiddleware(thunk)));

    if(module.hot){
        module.hot.accept('../Reducers/rootReducer.js', () => {
            const nextRootReducer = require('../Reducers/rootReducer.js');
            store.replaceReducer(nextRootReducer);
        })
    }

    return store;
}

export default configureStore;