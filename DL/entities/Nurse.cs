namespace DL.entities
{
    public enum DAYS { SUNDAY,MONDAY , TUESDAY , WEDNESDAY, THURSDAY, FRIDAY}
    public class Nurse
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DAYS[] DaysOfWork { get; set; }
        public Nurse() { }
        public Nurse(int id, String name, DAYS[] daysOfWork)
        {
            Id = id;
            Name = name;
            DaysOfWork = daysOfWork;
        }
        public bool IsDayOk(DAYS day) 
        {
            foreach (var item in DaysOfWork)
            {
                if (item == day)
                    return true;
            }
            return false;
        }

    }
}
