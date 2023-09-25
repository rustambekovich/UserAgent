using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Useragent.DataAccess;

public class BaseRepository
{
    protected NpgsqlConnection _connection;

    public BaseRepository()
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;



        //string connection = "Host = localhost; Database = greensale-db; Port = 5432; User Id = postgres; Password = 1234";
        this._connection = new NpgsqlConnection();
    }
}
