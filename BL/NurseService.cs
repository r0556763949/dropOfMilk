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
            if (_dataContext.Nurses.Count() == 0)
            {
                throw new Exception("no Nurses");
            }
            return _dataContext.Nurses.ToList();
        }
        public Nurse GetNurseById(int id)
        {
            if (_dataContext.Nurses.ToList().Find(x => x.Id == id) == null)
            {
                throw new Exception("no found id");
            }
            return _dataContext.Nurses.ToList().Find(n => n.Id == id);
        }
        public void PostNurse(Nurse nurse)
        {
            if (nurse == null || nurse is not Nurse)
            {
                throw new Exception("no VALID nurse");
            }
            _dataContext.Nurses.Add(nurse);
            _dataContext.SaveChanges();
        }
        public void PutNurse(int id, Nurse nurse)
        {
            if (_dataContext.Nurses.ToList().Find(x => x.Id == id) == null)
            {
                throw new Exception("no found id");
            }
            if (nurse == null || nurse is not Nurse)
            {
                throw new Exception("no VALID nurse");
            }
            _dataContext.Nurses.ToList().Remove(_dataContext.Nurses.ToList().Find(x => x.Id == id));
            _dataContext.Nurses.Add(nurse);
            _dataContext.SaveChanges();
        }
        public void DeleteNurse(int id)
        {

            if (_dataContext.Nurses.ToList().Find(x => x.Id == id) == null)
            {
                throw new Exception("no found id");
            }
            _dataContext.Nurses.Remove(_dataContext.Nurses.ToList().Find(x => x.Id == id));
            _dataContext.SaveChanges();
        }
    }
}
