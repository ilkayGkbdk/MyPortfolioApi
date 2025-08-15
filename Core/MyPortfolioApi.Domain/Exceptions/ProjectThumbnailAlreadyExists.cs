using System;

namespace MyPortfolioApi.Domain.Exceptions;

public class ProjectThumbnailAlreadyExists : Exception
{
    public ProjectThumbnailAlreadyExists(string thumbnailUrl)
        : base($"Project with thumbnail url '{thumbnailUrl}' already exists.")
    {
    }
}