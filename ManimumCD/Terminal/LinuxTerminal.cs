using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ManimumCD.Terminal
{
    /// <summary>
    /// Linux 终端实现
    /// </summary>
    public class LinuxTerminal : ITerminal
    {
        /// <summary>
        /// 执行cmd命令
        /// </summary>
        /// <param name="command">cmd命令</param>
        /// <returns>返回结果</returns>
        public string Execute(params string[] commands)
        {
            return null;
        }
    }
}
