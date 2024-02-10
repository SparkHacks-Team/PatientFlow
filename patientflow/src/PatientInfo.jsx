import Taskbar from './components/Taskbar.jsx'
import { useState } from 'react'


export default function PatientInfo({patientName}) {
    const [showInfo, setShowInfo] = useState(true);

    const deleteInfo = () => {
      setShowInfo(!showInfo);
    };

    function editInfo(){
        
    }

    return (
        <div>
        <Taskbar/>
        {showInfo && (<div className="flex bg-slate-50 m-1 border-4 text-cyan-50 rounded-lg" id="info">
            <div className="justify-center items-center text-slate-900 font-bold p-5">{patientName}</div>
            <div className="">
            <button className="btn btn-success mx-2" onClick={editInfo}> Edit </button>
            <button className="btn btn-error" onClick={deleteInfo}> Delete </button>
            </div>
        </div>)}
        </div>
    )
}