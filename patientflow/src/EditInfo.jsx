import { useState } from "react";

function EditInfo(){
    console.log("hi")
    const [name, setName] = useState("")
    const [completeForm] = useState(false)

    function handle(event){
        // event.preventDefault();
        if(!name){
            alert("Please enter full name");
        }
        console.log("hit")
        completeForm(true);
    }
    
    console.log("after")
    return(
        <div>
            <form onSubmit={handle}> 
                <label> Name: </label>
                <input type="text" className="text-black" onChange={(event) => setName(event.target.value)} placeholder="Full Name"/>
            </form>
            <div>
            <button type="submit">Done</button>
            </div>
        </div>
    )

}

export default EditInfo