using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManimumCD.Terminal
{
    /// <summary>
    /// 终端
    /// </summary>
    public interface ITerminal
    {
        /// <summary>
        /// 执行终端
        /// </summary>
        /// <param name="command">终端命令</param>
        /// <returns>执行命令返回结果</returns>
        string Execute(params string[] command);
    }
}
