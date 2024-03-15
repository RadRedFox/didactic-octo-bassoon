import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'

import './index.css'
import './styles/button.css'
import './styles/input.css'
import './styles/table.css'

ReactDOM.createRoot( document.getElementById( 'root' )! ).render(
    <React.StrictMode>
        <App />
    </React.StrictMode>
)
