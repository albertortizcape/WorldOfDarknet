﻿using System.Linq;

namespace Game.Domain
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        IQueryable<T> AsQueryable();
    }
}
