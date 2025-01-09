using BL.InterfaceService;
using DL;
using DL.entities;

namespace BL
{
    public class NurseService:INurseService
    {
        public readonly IDataContext _dataContext;

        public NurseService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Nurse> GetAllNurses()
        {
            return _dataContext.Nurses.ToList();
        }
        public Nurse GetNurseById(int id)
        {
            return _dataContext.Nurses.ToList().Find(n => n.Id == id);
        }
        public void PostNurse(Nurse nurse)
        {

            _dataContext.Nurses.Add(nurse);
            _dataContext.SaveChanges();
        }
        public void PutNurse(int id, Nurse nurse)
        {
            _dataContext.Nurses.ToList().Remove(_dataContext.Nurses.ToList().Find(x => x.Id == id));
            _dataContext.Nurses.Add(nurse);
            _dataContext.SaveChanges();
        }
        public void DeleteNurse(int id)
        {
            _dataContext.Nurses.ToList().RemoveAt(id);
            _dataContext.SaveChanges();
        }
    }
}
