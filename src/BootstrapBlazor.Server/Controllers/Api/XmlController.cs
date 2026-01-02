// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License
// See the LICENSE file in the project root for more information.
// Maintainer: Argo Zhang(argo@live.ca) Website: https://www.blazor.zone

using Microsoft.AspNetCore.Mvc;
using System.Xml;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace BootstrapBlazor.Controllers.Api;

/// <summary>
/// XML processing controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class XmlController : ControllerBase
{
    /// <summary>
    /// Process XML data
    /// </summary>
    /// <param name="xmlData">XML content to process</param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult ProcessXml([FromBody] string xmlData)
    {
        try
        {
            var xmlDoc = new XmlDocument();
            var settings = new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Parse,
                XmlResolver = new XmlUrlResolver()
            };
            using var reader = XmlReader.Create(new System.IO.StringReader(xmlData), settings);
            xmlDoc.Load(reader);
            return Ok(xmlDoc.DocumentElement?.InnerText ?? "Processed");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

