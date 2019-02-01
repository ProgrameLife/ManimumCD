using ManimumCD.Terminal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManimumCD.Repository
{
    /// <summary>
    /// 命令仓储
    /// </summary>
    public class CommandRepository : ICommandRepository
    {

        public CommandRepository()
        {

        }
        /// <summary>
        /// 获取一个项目下的所有命令
        /// </summary>
        /// <param name="projectKey"></param>
        /// <returns></returns>
        public List<Command> GetCommands(string projectKey)
        {
            return null;
        }
    }
}
