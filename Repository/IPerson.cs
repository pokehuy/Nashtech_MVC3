using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_a2.Models;

namespace asp_a2.Repository
{
    public interface IPerson
    {
         List<PersonModel> List();
         void Create(PersonModel per);
         void Update(PersonModel per);
         PersonModel Delete(int id);        
    }
}