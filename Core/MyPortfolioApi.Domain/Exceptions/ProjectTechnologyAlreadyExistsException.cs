using System;

namespace MyPortfolioApi.Domain.Exceptions;

public class ProjectTechnologyAlreadyExistsException : Exception
{
    public ProjectTechnologyAlreadyExistsException(string projectId, string technologyId)
        : base($"Project technology with Project ID {projectId} and Technology ID {technologyId} already exists.")
    {
    }
}
