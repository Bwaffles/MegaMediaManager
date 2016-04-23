using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace MegaMediaManager.DAL
{
    public class EFUnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return Create(false);
        }

        public IUnitOfWork Create(bool forceNew)
        {
            return new EFUnitOfWork(forceNew);
        }
    }
}
