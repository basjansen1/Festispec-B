﻿using System;
using System.Linq;

namespace Festispec.Domain.Repository.Interface
{
    public interface IGeoRepository : IDisposable
    {
        IQueryable<Address> GetByPostalCode(string postalCode);
    }
}