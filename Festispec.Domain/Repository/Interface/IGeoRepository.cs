using System;

namespace Festispec.Domain.Repository.Interface
{
    public interface IGeoRepository : IDisposable
    {
        Address Find(string postalCode, string houseNumber);
    }
}