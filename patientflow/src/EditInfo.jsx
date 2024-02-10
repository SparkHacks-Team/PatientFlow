import { useState } from "react";
import Taskbar from './components/Taskbar.jsx'
import ButtonLink from "./ButtonLink.jsx";

function EditInfo(){
    console.log("hi")
    const [name, setName] = useState("")
    const [completeForm] = useState(false)

    function handle(event){
        // event.preventDefault();
        if(!name){
            alert("Please enter full name");
        }
        completeForm(true);
    }
    
    return(
        <div>
            <Taskbar/>
            <div className="bg-gray-500 p-40 mx-8 justify-center rounded flex items-center h-screen">
                <form onSubmit={handle} className="justify-center"> 
                    <label> Name: </label>
                    <input type="text" className="text-white" onChange={(event) => setName(event.target.value)} placeholder="Full Name"/>
                    <label> Medication Type: </label>
                    <input type="text" className="text-white" onChange={(event) => setName(event.target.value)} placeholder="Medication Name"/>
                    <label> Doctor: </label>
                    <input type="text" className="text-white" onChange={(event) => setName(event.target.value)} placeholder="Doctor Name"/>
                </form>
                <div>
                <ButtonLink linkref={"/test"} desc={"Done"} type={"success"}/>
                </div>
            </div>
        </div>
    )

}

export default EditInfo