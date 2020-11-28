using Game.Domain;
using Game.Infraestructura.EntityTypeConfigurations;
using Game.Infrastructure.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Threading.Tasks;

namespace Game.Infraestructura
{
    public class GameContext : DbContext, IUnitOfWork
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options) { }

        public DbSet<Domain.Entities.PlayerAgrgegate.Player> Players { get; set; }
        public DbSet<Domain.Entities.UserAggregate.User> Users { get; set; }

        public IDbContextTransaction CurrentTransaction { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlayerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await base.SaveChangesAsync();
            return true;
        }

        public async Task BeginTransactionAsync()
        {
            CurrentTransaction ??= await Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync();
                CurrentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (CurrentTransaction != null)
                {
                    CurrentTransaction.Dispose();
                    CurrentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                CurrentTransaction?.Rollback();
            }
            finally
            {
                if (CurrentTransaction != null)
                {
                    CurrentTransaction.Dispose();
                    CurrentTransaction = null;
                }
            }
        }
    }
}