// Class HospitalSystem
// • Private List<Doctor> doctors
// • Private List<Patient> patients
// • Private List<Appointment> appointments
// • Public HospitalSystem()
// • Public AddPatient(): Takes input, inserts into database & file system.
// • Public UpdatePatient(string cnic): Updates details in DB & file system.
// • Public DeletePatient(string cnic): Removes patient from DB & file system.
// • Public DisplayPatients(): Displays all patients.
// • Public AddDoctor(): Inserts doctor into DB & file system.
// • Public UpdateDoctor(int doctorID): Updates doctor details in DB & file system.
// • Public DeleteDoctor(int doctorID): Deletes doctor from DB & file system.
// • Public DisplayDoctors(): Displays all doctors with availability.
// • Public BookAppointment(int doctorID, string cnic, DateTime date): Creates an
// appointment if doctor is available.
// • Public CancelAppointment(int appointmentID, string cnic): Cancels an appointment.
// • Public DeclareMostConsultedDoctor(): Displays doctor with maximum
// appointments.
namespace BLL;
public class HospitalSystem
{
    private List<Doctor> doctors;
    private List<Patient> patients;
    private List<Appointment> appointments;

    public HospitalSystem()
    {
        doctors = new List<Doctor>();
        patients = new List<Patient>();
        appointments = new List<Appointment>();
    }

    public void AddPatient(string name, string cnic)
    {
        Patient newPatient = new Patient(name, cnic);
        patients.Add(newPatient);
    }

}