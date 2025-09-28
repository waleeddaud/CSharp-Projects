namespace BLL;;

public class Patient
{
    private string name;
    private string cnic {get;};
    private List<int> Appointments;

    public string CNIC
    {
        get { return cnic; }
    }

    public Patient(string name, string cnic)
    {
        this.name = name;
        this.cnic = cnic;
        Appointments = new List<int>();
    }

    public bool HasAppointment(int appointmentID)
    {
        foreach (int ids in Appointments)
        {
            if (ids == appointmentID)
            {
                return true;
            }
        }
        return false;
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