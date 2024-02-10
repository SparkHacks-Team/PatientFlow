// import reactLogo from './assets/react.svg'
import viteLogo from './assets/logo.png'
// import './App.css'
import './Main.css'
import React from 'react';
import { useNavigate } from "react-router-dom";
import Taskbar from './components/Taskbar'
import { func } from 'prop-types';
import ButtonLink from './ButtonLink';

function App() {

  // let nav = useNavigate();

  // function changePage() {
  //   let page = "/itracker.html";
  //   nav(page);
  // }

  return (
    <>
      <Taskbar/>
      <div className="flex">
        <div>
        <a href="" target="_blank">
          <img src={viteLogo} className="w-5/12 mx-auto float-left pt-20" alt="logo" />
        </a>
        <div className="inline-block items-center justify-center pt-40 pl-60">
          <h1 className="p-5 font-mono text-stone-800 font-semibold flex justify-center opacity-0 animate-fade">Patient Flow</h1>
          <p className="p-5 font-mono text-stone-800 font-medium opacity-0 animate-fade"> Welcome to Patient Flow. Register to manage below.</p>
          <div className="flex justify-center opacity-0 animate-fade">
          {/* <Link to="/itracker.html"> */}
            {/* <button>
              Start Here
            </button> */}
            <ButtonLink/>
          </div>
          </div>
        </div>
      </div>
    </>
  )
}

export default App
