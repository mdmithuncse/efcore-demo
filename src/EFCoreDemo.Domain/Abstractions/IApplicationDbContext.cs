namespace EFCoreDemo.Domain.Abstractions
{
    internal interface IApplicationDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
