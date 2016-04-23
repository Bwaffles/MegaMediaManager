namespace Infrastructure
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
        IUnitOfWork Create(bool forceNew);
    }
}
