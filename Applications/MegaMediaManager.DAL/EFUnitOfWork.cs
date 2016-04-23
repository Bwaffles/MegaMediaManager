using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace MegaMediaManager.DAL
{
    public class EFUnitOfWork :IUnitOfWork
    {
        public EFUnitOfWork(bool forceNewContext)
        {
            if (forceNewContext)
                DataContextFactory.Clear();
        }

        public void Dispose()
        {
            DataContextFactory.GetDataContext().SaveChanges();
        }

        public void Commit(bool resetAfterCommit)
        {
            DataContextFactory.GetDataContext().SaveChanges();
            if (resetAfterCommit)
                DataContextFactory.Clear();
        }

        public void Undo()
        {
            DataContextFactory.Clear();
        }
    }
}
