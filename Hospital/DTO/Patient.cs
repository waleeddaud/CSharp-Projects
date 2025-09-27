namespace DTO;

public class Patient
{
    private string Name;
    private string CNIC;
    private List<int> Appointments;

    public Patient(string name, string cnic)
    {
        Name = name;
        CNIC = cnic;
        Appointments = new List<int>();
    }

    public string GetCNIC()
    {
        return CNIC;
    }

    public bool HasAppointment(int appointmentID)
    {
        return true;
    }

    public void AddAppointment(int appointmentID)
    {
        if (!HasAppointment(appointmentID))
        {
            Appointments.Add(appointmentID);
        }
    }
}

/*Class Patient
• Private string Name
• Private string CNIC
• Private List<int> Appointments: Stores Appointment IDs booked by this patient.
• Public Patient(string name, string cnic)
• Public string CNIC: Getter only.
• Public bool HasAppointment(int appointmentID): Checks if patient already has that
appointment.*/