using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ItripDal
    {
        public List<Trip> getAll();

        public Trip? getById(int id);

        public int add(Trip tr);

        public bool update(int id, Trip tr);

        public bool delete(int id);
    }
}
