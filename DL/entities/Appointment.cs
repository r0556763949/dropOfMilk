using System.ComponentModel.DataAnnotations;

namespace DL.entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int BabyId { get; set; }
        public Baby Baby { get; set; }
        public int NurseId { get; set; }

        public Nurse Nurse { get; set; }

        public Appointment()
        {
        }

        //public Appointment(int id, DateTime date, Baby baby, Nurse nurse)
        //{
        //    Id = id;
        //    Date = date;
        //    this.baby = baby;
        //    this.nurse = nurse;
        //}

    }
}
