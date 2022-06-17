using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuralıGroupDemo.Entity;
using TuralıGroupDemo.Repository.Abstract;

namespace TuralıGroupDemo.Repository.ConcreteEF
{
    public class EfClientDal : EfGenericRepository<Client, Context>, IClientDal
    {
        //kullanıcı sistemde var mı burada kontrol ediyoruz
        public bool LoginCheck(string username, string password)
        {
            using (var context = new Context())
            {
                var userInDb = context.Clients.Where(x => x.Name.Equals(username) && x.Password.Equals(password)).FirstOrDefault();
                if (userInDb != null)
                {
                    return true;
                }

                return false;
            }
 
        }
    }
}