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
        /// <returns></returns>
        public List<Project> GetProjects()
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                var sql = "select * from projects where validate=true";
                return con.Query<Project>(sql).ToList();
            }
        }
        /// <summary>
        /// 获取全部项目
        /// </summary>
        /// <returns></returns>
        public List<Project> GetAllProjects()
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                var sql = "select * from projects";
                return con.Query<Project>(sql).ToList();
            }
        }
        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="project">项目</param>
        /// <returns></returns>
        public bool AddProject(Project project)
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                project.Validate = true;
                var sql = "insert projects(name,describe,validate) values(@name,@describe,@validate)";
                return con.Execute(sql, project) > 0;
            }
        }

        /// <summary>
        /// 修改项目
        /// </summary>
        /// <param name="project">项目</param>
        /// <returns></returns>
        public bool ModifyProject(Project project)
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                var sql = "update projects set name=@name,describe=@describe,validate=@validate where id=@id";
                return con.Execute(sql, project) > 0;
            }
        }
        /// <summary>
        /// 删除项目
        /// </summary>
        /// <param name="id">项目ID</param>
        /// <returns></returns>
        public bool RemoveProject(int id)
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                var sql = "delete from projects where id=@id";
                return con.Execute(sql, new { id }) > 0;
            }
        }
    }
}
