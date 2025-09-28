namespace BLL; 
public class Doctor
{
    private int doctorID ;
    private string name ;
    private string specialization;
    private bool isAvailable;
    public static int counter = 0;
    public int DoctorID
    {
        get { return doctorID; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Specialization
    {
        get { return specialization; }
        set { specialization = value; }
    }
    public bool IsAvailable
    {
        get { return isAvailable; }
    }
    private int GenerateDoctorID()
    {
        id = Random.Random().nextInt(999) + counter*1000;
        return id;
    }
    public Doctor(string name , string specialization){ 
        DoctorID = GenerateDoctorID(); this.name = name; this.specialization = specialization; this.isAvailable = true; counter++;
    }
    public void MarkUnavailable(){
        this.isAvailable = false;
    }
    public void MarkAvailable(){
        this.isAvailable = true;
    }
    public override string ToString(){
        return $"\nDoctor details:\nDoctor ID: {DoctorID}, Name: {Name}, Specialization: {Specialization}, Available: {IsAvailable}\n";
    }
}
/*Class Doctor
• Private int DoctorID: Generate this ID using the Random function for each new
doctor.
• Private string Name: Take the doctor’s name as input.
• Private string Specialization: Doctor’s specialization (e.g., Cardiologist, Dentist).
• Private bool IsAvailable: A flag indicating doctor’s availability.
• Private int GenerateDoctorID(): Generates a unique ID using the Random function.
• Public Doctor(string name, string specialization): Assigns values and sets IsAvailable
= true.
• Public int DoctorID: Getter only.
• Public string Name: Getter & Setter.
• Public string Specialization: Getter & Setter.
• Public bool IsAvailable: Getter.
• Public void MarkUnavailable(): Sets IsAvailable = false.
• Public void MarkAvailable(): Sets IsAvailable = true.
• Override ToString(): Custom string representation of doctor.*/