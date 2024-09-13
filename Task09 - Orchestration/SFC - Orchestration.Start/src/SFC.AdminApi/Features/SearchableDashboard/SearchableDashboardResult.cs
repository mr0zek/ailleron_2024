﻿using System.Collections.Generic;

namespace SFC.AdminApi.Features.SearchableDashboard
{
  public class SearchableDashboardResult
  {
    public IEnumerable<SearchableDashboardEntry> Results { get; }

    public SearchableDashboardResult(IEnumerable<SearchableDashboardEntry> results)
    {
      Results = results;
    }
  }
}