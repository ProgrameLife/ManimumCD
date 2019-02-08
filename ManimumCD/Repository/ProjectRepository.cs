using ManimumCD.Terminal;
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
    public class ProjectRepository : IProjectRepository
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        readonly string _connectionString;
        public ProjectRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        /// <summary>
        /// 获取一个项目下的所有命令
        /// </summary>
        /// <param name="projectKey"></param>
        /// <returns></returns>
        public List<Project> GetProjects()
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                var sql = "select * from projects where validate=true";
                return con.Query<Project>(sql).ToList();
            }
        }
    }
}
