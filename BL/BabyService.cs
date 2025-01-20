using BL.InterfaceService;
using DL;
using DL.entities;
using System.Collections;

namespace BL
{
    public class BabyService : IBabyService
    {
        public readonly IDataContext _dataContext;

        public BabyService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Baby> GetAllBaby()
        {
            var babies = _dataContext.Babies.AsEnumerable();

            if (!babies.Any())
            {
                throw new Exception("No babies found.");
            }

            return babies;
        }
        public Baby GetBabyById(int id)
        {
            var baby = _dataContext.Babies.FirstOrDefault(x => x.Id == id);
            if (baby == null)
            {
                throw new KeyNotFoundException($"Baby with ID {id} not found.");
            }
            return baby;
        }

        public void PostBaby(Baby baby)
        {
            if (baby == null)
            {
                throw new Exception("no VALID baby");
            }
            _dataContext.Babies.Add(baby);
            _dataContext.SaveChanges();
        }
        public void PutById(int id, Baby baby)
        {
            if (baby == null)
            {
                throw new ArgumentNullException(nameof(baby), "Baby cannot be null.");
            }

            var existingBaby = _dataContext.Babies.FirstOrDefault(x => x.Id == id);
            if (existingBaby == null)
            {
                throw new KeyNotFoundException($"Baby with ID {id} not found.");
            }

            existingBaby.Name = baby.Name;
            existingBaby.DateOfBirth = baby.DateOfBirth;

            _dataContext.SaveChanges();
        }
        public void DeleteById(int id)
        {
            var baby = _dataContext.Babies.FirstOrDefault(x => x.Id == id);
            if (baby == null)
            {
                throw new KeyNotFoundException($"Baby with ID {id} not found.");
            }

            _dataContext.Babies.Remove(baby);
            _dataContext.SaveChanges();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
