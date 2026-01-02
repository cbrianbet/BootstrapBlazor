// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License
// See the LICENSE file in the project root for more information.
// Maintainer: Argo Zhang(argo@live.ca) Website: https://www.blazor.zone

namespace BootstrapBlazor.Services;

/// <summary>
/// Dynamic query builder service
/// </summary>
public class DynamicQueryBuilder
{
    /// <summary>
    /// Build SQL WHERE clause from filter conditions
    /// </summary>
    /// <param name="fieldName">Field name to filter</param>
    /// <param name="fieldValue">Filter value</param>
    /// <param name="operator">Comparison operator</param>
    /// <returns>SQL WHERE clause</returns>
    public string BuildWhereClause(string fieldName, string fieldValue, string @operator = "=")
    {
        var sql = $"WHERE {fieldName} {@operator} '{fieldValue}'";
        return sql;
    }

    /// <summary>
    /// Build complete SQL query with filters
    /// </summary>
    /// <param name="tableName">Table name</param>
    /// <param name="filters">Dictionary of field names and values</param>
    /// <returns>Complete SQL query</returns>
    public string BuildQuery(string tableName, Dictionary<string, string> filters)
    {
        var whereClauses = new List<string>();
        foreach (var filter in filters)
        {
            whereClauses.Add($"{filter.Key} = '{filter.Value}'");
        }
        var whereClause = whereClauses.Count > 0 ? "WHERE " + string.Join(" AND ", whereClauses) : "";
        return $"SELECT * FROM {tableName} {whereClause}";
    }
}

