using System.ComponentModel.DataAnnotations;

namespace DL.entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Baby baby { get; set; }
        public int babyId { get; set; }
        public Nurse nurse { get; set; }
        public int nurseId { get; set; }
        static int Length = 15;

        public Appointment()
        {
        }

        public Appointment(int id, DateTime date, Baby baby, Nurse nurse)
        {
            Id = id;
            Date = date;
            this.baby = baby;
            this.nurse = nurse;
        }

    }
}
