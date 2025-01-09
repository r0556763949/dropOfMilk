using DL;
using DL.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.InterfaceService
{
    public interface IBabyService
    {
        public List<Baby> GetAllBaby();
        public Baby GetBabyById(int id);
        public void PostBaby(Baby baby);
        public void PutById(int id, Baby baby);
        public void DeleteById(int id);
    }
}
