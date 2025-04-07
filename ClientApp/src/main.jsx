import App from './App'
import { createRoot } from 'react-dom/client'
import { Provider } from 'react-redux';
import { store } from './Redux/store'
import './styles/Normalize.css'
import './fonts/fonts.css'
import './styles/global.less'

createRoot(document.getElementById('root')).render(
    <Provider store={store}>
        <App />
    </Provider>
)