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
        /// <param name="projectID">项目ID</param>
        /// <returns></returns>
        public List<Command> GetCommands(int projectID)
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                var sql = "select * from commands where validate=true and projectid=@projectid";
                return con.Query<Command>(sql, new { projectid = projectID }).ToList();
            }
        }
        /// <summary>
        /// 获取项目全部命令
        /// </summary>
        /// <returns></returns>
        public List<Command> GetPorjectCommands(int projectID)
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                var sql = "select * from commands where projectid=@projectid";
                return con.Query<Command>(sql, new { projectid = projectID }).ToList();
            }
        }
        /// <summary>
        /// 添加命令
        /// </summary>
        /// <param name="command">命令</param>
        /// <returns></returns>
        public bool AddCommand(Command command)
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                command.Validate = true;
                var sql = "insert into commands(projectid,terminaltypeid,commandtext,commandresult,exectoperator,expectvalue,validate) values(@projectid,@terminaltypeid,@commandtext,@commandresult,@exectoperator,@expectvalue,@validate)";
                return con.Execute(sql, command) > 0;
            }
        }
        /// <summary>
        /// 修改命令
        /// </summary>
        /// <param name="command">命令</param>
        /// <returns></returns>
        public bool ModifyCommand(Command command)
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                var sql = "update commands projectid=@projectid,terminaltypeid=@terminaltypeid,commandtext=@commandtext,commandresult=@commandresult,exectoperator=@commandresult,expectvalue=@commandresult,validate=@commandresult) where id=@id";
                return con.Execute(sql, command) > 0;
            }
        }
        /// <summary>
        /// 删除命令
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public bool RemoveCommand(int id)
        {
            using (var con = new SQLiteConnection(_connectionString))
            {
                var sql = "delete from commands where id=@id";
                return con.Execute(sql, new { id }) > 0;
            }
        }
    }
}
