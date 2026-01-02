// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License
// See the LICENSE file in the project root for more information.
// Maintainer: Argo Zhang(argo@live.ca) Website: https://www.blazor.zone

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace BootstrapBlazor.Controllers.Api;

/// <summary>
/// User API controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    /// <summary>
    /// Get user by ID
    /// </summary>
    /// <param name="id">User ID</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var user = new
        {
            Id = id,
            UserName = $"User{id}",
            Email = $"user{id}@example.com",
            Profile = $"Profile data for user {id}"
        };
        return Ok(user);
    }
}

