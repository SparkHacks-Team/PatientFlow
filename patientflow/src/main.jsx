import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import Itracker from './Itracker.jsx'
import PatientInfo from './PatientInfo.jsx'
import EditInfo from './EditInfo.jsx'
import './index.css'

import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";

const router = createBrowserRouter([
  {
    path: "/",
    element: <App/>,
  },
  {
    path: "/test",
    element: <PatientInfo patientName={"JohnDoe"}/>,
  },
  {
    path: "/form",
    element: <EditInfo/>,
  },
]); 

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>,
)
