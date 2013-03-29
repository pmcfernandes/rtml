//------------------------------------------------------------------------------
// <copyright file="CSSqlStoredProcedure.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using Realtime.Common;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void Publisher (SqlString hostname, SqlString route, SqlString message)
    {
        SqlDataRecord record = new SqlDataRecord(
            new SqlMetaData("Result", SqlDbType.NVarChar, 512)
            );

        using (Realtime.Publisher.Publisher pub = new Realtime.Publisher.Publisher(new ServerConfig()
        {
            Host = hostname.ToString(),
            Port = 8081,
            Route = route.ToString(),
            Debug = true
        }))
        {
            pub.Publish(message.ToString()
                , () =>
                {
                    record.SetString(0, "Message is correct sended to Server.");

                    SqlContext.Pipe.SendResultsStart(record);
                    SqlContext.Pipe.SendResultsEnd();
                });
        }
    }
}
