using System;
using System.Net;

namespace MyPortfolioApi.Application.DTOs.Common;

public class BaseResponseDto
{
    public HttpStatusCode Status { get; set; } = HttpStatusCode.OK;
    public string Message { get; set; } = string.Empty;
}
