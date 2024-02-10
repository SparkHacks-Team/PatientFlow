export default function PatientRecord({patientName}) {
    return (
        <li className="bg-red-100 m-1 border-4">
        <div>{patientName}</div>
        </li>
    )
}