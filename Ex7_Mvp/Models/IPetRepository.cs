using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex7_Mvp.Models
{
   public interface IPetRepository
    {
        void Add(PetModel petModel);
        void Edit(PetModel petModel);
        void Delete(long id);
        IEnumerable<PetModel> GetAll();
        IEnumerable<PetModel> GetByValue(string value);//Searchs


        //  Service Broker?

        // Sql Dependancy
    }
}
