using System.Net.Cache;
using System.Text.Json.Serialization;

namespace DL.entities
{
    public class Baby
    {
        //[JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }


        //public Baby()
        //{
        //}

        //public Baby(int id, string name, DateTime dateOfBirth, int countOfAppointments)
        //{
        //    Id = id;
        //    Name = name;
        //    DateOfBirth = dateOfBirth;
        //    CountOfAppointments = countOfAppointments;
        //}
        //public TimeSpan Age()
        //{
        //    DateTime date = DateTime.Now;
        //   return date.Subtract(DateOfBirth);
        //}
        //public int AppLeft()
        //{
        //    return 5 - CountOfAppointments;
        //}
    }
}
