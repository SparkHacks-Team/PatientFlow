namespace MedicationAPI.Model
{
    public class Medication
    {
        public int Medication_ID {  get; set; }
        public int Patient_ID { get; set; }
        public string Name { get; set; }
        public int Frequency { get; set; }
        public DateTime Date { get; set; }
    }
}
