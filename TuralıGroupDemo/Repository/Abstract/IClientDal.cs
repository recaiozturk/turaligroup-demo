using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuralıGroupDemo.Entity;

namespace TuralıGroupDemo.Repository.Abstract
{
    public interface IClientDal:IRepository<Client>
    {

        //geriye id döndürsün
        int LoginCheck(string username, string password);
    }
}
