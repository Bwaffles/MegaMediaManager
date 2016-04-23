using System;

namespace Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit(bool resetAfterCommit);
        void Undo();
    }
}
