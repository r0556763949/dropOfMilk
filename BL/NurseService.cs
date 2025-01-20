using BL.InterfaceService;
using DL;
using DL.entities;
using System.Collections;

namespace BL
{
    public class NurseService : INurseService
    {
        public readonly IDataContext _dataContext;

        public NurseService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Nurse> GetAllNurses()
        {
            if (_dataContext.Nurses.Count() == 0)
            {
                throw new Exception("no Nurses");
            }
            return _dataContext.Nurses;
        }
        public Nurse GetNurseById(int id)
        {
            var nurse = _dataContext.Nurses.FirstOrDefault(x => x.Id == id);

            if (nurse == null)
            {
                throw new Exception("no found id");
            }

            return nurse;
        }
        public void PostNurse(Nurse nurse)
        {
            if (nurse == null)
            {
                throw new Exception("no VALID nurse");
            }
            _dataContext.Nurses.Add(nurse);
            _dataContext.SaveChanges();
        }
        public void PutNurse(int id, Nurse nurse)
        {
            var nurseById = _dataContext.Nurses.FirstOrDefault(x => x.Id == id);
            if (nurseById  == null)
            {
                throw new Exception("no found id");
            }
            if (nurse  == null)
            {
                throw new Exception("no VALID nurse");
            }
            nurseById.Name = nurse.Name;
            nurseById.DaysOfWork = nurse.DaysOfWork;
            _dataContext.SaveChanges();
        }
        public void DeleteNurse(int id)
        {
            var nurseById = _dataContext.Nurses.FirstOrDefault(x => x.Id == id);

            if (nurseById == null)
            {
                throw new Exception("no found id");
            }
            _dataContext.Nurses.Remove(nurseById);
            _dataContext.SaveChanges();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
