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
    }
}
