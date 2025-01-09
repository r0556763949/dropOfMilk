using DL.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IDataContext
    {
        int SaveChanges();
         DbSet<Appointment> Appointments { get; set; }
         DbSet<Nurse> Nurses { get; set; }
         DbSet<Baby> Babies { get; set; }
    }
}
