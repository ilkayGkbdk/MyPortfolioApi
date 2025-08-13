using System;

namespace MyPortfolioApi.Application.DTOs.Common;

public class BaseResponseDto
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
}
