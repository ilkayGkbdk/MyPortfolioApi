using System;

namespace MyPortfolioApi.Application.Exceptions;

public class DataNotFoundException : Exception
{
    public DataNotFoundException(string name, object key)
        : base($"Entity '{name}' ({key}) was not found.")
    {
    }
}
