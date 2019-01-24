using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManimumCI.Repostory
{
    class CmdForWinRepository : ICmdForWinRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        string ExcCmd(string cmd)
        {
            using (var process = new System.Diagnostics.Process())
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
                process.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                process.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                process.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                process.StartInfo.CreateNoWindow = true;//不显示程序窗口
                process.Start();//启动程序     //向cmd窗口发送输入信息
                process.StandardInput.WriteLine("cd ConsoleApp6");
                process.StandardInput.AutoFlush = true;
                process.StandardInput.WriteLine("cd MyFirstUnitTests");
                process.StandardInput.AutoFlush = true;
                process.StandardInput.WriteLine(cmd + "&exit");
                process.StandardInput.AutoFlush = true;
                //p.StandardInput.WriteLine("exit");
                //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
                //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令
                //获取cmd窗口的输出信息
                string output = process.StandardOutput.ReadToEnd();
                //StreamReader reader = p.StandardOutput;
                //string line=reader.ReadLine();
                //while (!reader.EndOfStream)
                //{
                //    str += line + "  ";
                //    line = reader.ReadLine();
                //}
                process.WaitForExit();//等待程序执行完退出进程
                process.Close();
                return output;
            }
        }
    }
}
