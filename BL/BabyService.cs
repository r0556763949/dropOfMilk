using BL.InterfaceService;
using DL;
using DL.entities;

namespace BL
{
    public class BabyService:IBabyService
    {
        public readonly IDataContext _dataContext;

        public BabyService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Baby> GetAllBaby()
        {
            if(_dataContext.Babies.Count()==0)
            {
                throw new Exception("no babies");
            }
            return _dataContext.Babies.ToList();
        } 
        public Baby GetBabyById(int id) 
        {
            if(_dataContext.Babies.ToList().Find(x => x.Id == id)==null)
            {
                throw new Exception("no found id");
            }
            return _dataContext.Babies.ToList().Find(x => x.Id == id);
        }
        public void PostBaby(Baby baby)
        {
            if (baby == null || baby is not Baby)
            {
                throw new Exception("no VALID baby");
            }
            _dataContext.Babies.Add( baby);
            _dataContext.SaveChanges();
        }
        public void PutById(int id, Baby baby)
        {
            if (_dataContext.Babies.ToList().Find(x => x.Id == id) == null)
            {
                throw new Exception("no found id");
            }
            if (baby == null || baby is not Baby)
            {
                throw new Exception("no VALID baby");
            }
            _dataContext.Babies.Remove(_dataContext.Babies.ToList().Find(x => x.Id == id));
            _dataContext.Babies.Add(baby);
            _dataContext.SaveChanges();
        }
        public void DeleteById(int id)
        {
            if (_dataContext.Babies.ToList().Find(x => x.Id == id) == null)
            {
                throw new Exception("no found id");
            }
            _dataContext.Babies.Remove(_dataContext.Babies.ToList().Find(x => x.Id == id));
            _dataContext.SaveChanges();
        }
    }
}
