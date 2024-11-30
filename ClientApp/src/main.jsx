import { createRoot } from 'react-dom/client'
import App from './App'
import './styles/Normalize.css'
import './fonts/fonts.css'
import './styles/global.less'
import { Provider } from 'react-redux';
import { store } from './auth/Register/store.js';

createRoot(document.getElementById('root')).render(
    <Provider store={store}>
        <App />
    </Provider>
)