using DL.entities;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BL.InterfaceService
{
    public interface INurseService : IEnumerable
    {
        public IEnumerable<Nurse> GetAllNurses();
        public Nurse GetNurseById(int id);
        public void PostNurse(Nurse nurse);
        public void PutNurse(int id, Nurse nurse);
        public void DeleteNurse(int id);
    
}
}
