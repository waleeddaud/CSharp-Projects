namespace BLL;
public class Appointment{
    private int appointmentId;
    private int DoctorID;
    private string PatientCNIC;
    private DateTime AppointmentDate;
    public static int counter = 0;
    public int AppointmentID
    {
        get { return appointmentId; }
    }
    public override string ToString(){
        return $"\nAppointment Details:\nAppointment ID: {AppointmentID}, Doctor ID: {DoctorID}, Patient CNIC: {PatientCNIC}, Date: {AppointmentDate}\n";
    }
    public Appointment(int doctorID, string patientCNIC, DateTime date)
    {
        counter++;
        // This wiil ensure uniqueness of ids
        this.appointmentId = new Random().Next(999) + counter*1000;
        this.PatientCNIC = patientCNIC;
        this.DoctorID = doctorID;
        this.AppointmentDate = date;
    }
} 
/*Class Appointment
• Private int AppointmentID: Generate randomly.
• Private int DoctorID
• Private string PatientCNIC
• Private DateTime AppointmentDate
• Public Appointment(int doctorID, string patientCNIC, DateTime date): Creates new
appointment.
• Public int AppointmentID: Getter only.
• Public override ToString(): Returns formatted appointment details*/