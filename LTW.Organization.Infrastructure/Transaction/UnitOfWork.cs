﻿using LavanderTyperWeb.Core.Data;
using LavanderTyperWeb.Data.Common.Interfaces;

namespace LavanderTyperWeb.Data.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UnitOfWork(IApplicationDbContext applicationDbContext) => _applicationDbContext = applicationDbContext;

        public async Task CommitChangesAsync() => await _applicationDbContext.Save();
    }
}
