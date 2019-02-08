﻿using ManimumCD.Terminal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;
using ManimumCD.Model;

namespace ManimumCD.Repository
{
    /// <summary>
    /// 命令仓储
    /// </summary>
    public class CommandRepository : ICommandRepository
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        readonly string _connectionString;
        public CommandRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        /// <summary>
        /// 获取一个项目下的所有命令
        /// </summary>
        /// <param name="projectKey"></param>
        /// <returns></returns>
        public List<Command> GetCommands(int projectID)
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                var sql = "select * from commands where validate=true";
                return con.Query<Command>(sql).ToList();
            }         
        }
    }
}
