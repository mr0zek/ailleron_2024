﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using SFC.Infrastructure.Interfaces;
using SFC.Notifications.Features.NotificationQuery.Contract;
using SFC.SharedKernel;

namespace SFC.Notifications.Features.NotificationQuery
{
    internal class GetSendNotificationsCountQueryHandler : IQueryHandler<GetSendNotificationsCountRequest, GetSendNotificationsCountResponse>
  {
    private readonly IDbConnection _connection;

    public GetSendNotificationsCountQueryHandler(ConnectionString connectionString)
    {
      _connection = new SqlConnection(connectionString.ToString());
    }

    public GetSendNotificationsCountResponse HandleQuery(GetSendNotificationsCountRequest query)
    {
      return new GetSendNotificationsCountResponse()
      {
        Result = _connection.Query<dynamic>(
        @"select loginName, count(*) as count from Notifications.Notifications where loginName in @loginNames and notificationType = @notificationType group by loginName",
        new { loginNames = query.LoginNames.Select(f => f.ToString()).ToArray(), query.NotificationType }).Select(f => new NotificationsCountResult()
        {
          LoginName = f.loginName,
          Count = f.count
        })
      };
    }
  }
}
