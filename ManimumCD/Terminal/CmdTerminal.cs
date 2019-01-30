using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ManimumCD.Terminal
{
    /// <summary>
    /// windows 下的cmd.exe实现
    /// </summary>
    public class CmdTerminal : ITerminal
    {
        /// <summary>
        /// 执行cmd命令
        /// </summary>
        /// <param name="command">cmd命令</param>
        /// <returns>返回结果</returns>
        public string Execute(params string[] commands)
        {
            using (var process = new Process())
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
                process.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                process.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                process.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                process.StartInfo.CreateNoWindow = true;//不显示程序窗口
                process.Start();//启动程序     //向cmd窗口发送输入信息
                foreach (var command in commands)
                {
                    process.StandardInput.WriteLine(command);
                    process.StandardInput.AutoFlush = true;
                }
                //p.StandardInput.WriteLine("exit");           
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();//等待程序执行完退出进程
                process.Close();
                return output;
            }
        }
    }
}
