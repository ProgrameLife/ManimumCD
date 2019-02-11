using ManimumCD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManimumCD.Repository
{
    /// <summary>
    /// 命令仓储
    /// </summary>
    public interface ICommandRepository
    {
        /// <summary>
        /// 获取一个项目下的所有命令
        /// </summary>
        /// <param name="projectKey"></param>
        /// <returns></returns>
        List<Command> GetCommands(int projectID);   
        /// <summary>
        /// 添加命令
        /// </summary>
        /// <param name="command">命令</param>
        /// <returns></returns>
        bool AddCommand(Command command);
        /// <summary>
        /// 修改命令
        /// </summary>
        /// <param name="command">命令</param>
        /// <returns></returns>
        bool ModifyCommand(Command command);
        /// <summary>
        /// 删除命令
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        bool RemoveCommand(int id);
    }
}
