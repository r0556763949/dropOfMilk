using DL.entities;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.InterfaceService
{
    public interface INurseService
    {
        public List<Nurse> GetAllNurses();
        public Nurse GetNurseById(int id);
        public void PostNurse(Nurse nurse);
        public void PutNurse(int id, Nurse nurse);
        public void DeleteNurse(int id);
    
}
}
