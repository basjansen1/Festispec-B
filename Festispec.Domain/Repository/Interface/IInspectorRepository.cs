﻿using System;
using System.Data.Entity.Spatial;
using System.Linq;

namespace Festispec.Domain.Repository.Interface
{
    public interface IInspectorRepository : IRepository<Inspector>
    {
        IQueryable<Inspector> GetAvailableNearby(DateTime dateAvailable, DbGeography center, int inspectorId = 0);

        bool TryLogin(string username, string password);
    }
}