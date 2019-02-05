using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace ManimumCD.Terminal
{
    /// <summary>
    /// windows 下的PowerShell实现
    /// </summary>
    public class PowerShellTerminal : ITerminal
    {
        /// <summary>
        /// 执行cmd命令
        /// </summary>
        /// <param name="command">cmd命令</param>
        /// <returns>返回结果</returns>
        public string Execute(params string[] commands)
        {
            return RunScript(commands);      
        }
        /// <summary>
        /// 运行powershell脚本
        /// </summary>
        /// <param name="scripts">命令</param>
        /// <param name="pars">参数</param>
        /// <returns></returns>
        string RunScript(string[] scripts, params PSParam[] pars)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            foreach (var scr in scripts)
            {
                pipeline.Commands.AddScript(scr);
            }
            //注入参数   
            if (pars != null)
            {
                foreach (var par in pars)
                {
                    runspace.SessionStateProxy.SetVariable(par.Key, par.Value);
                }
            }
            //返回结果   
            var results = pipeline.Invoke();
            runspace.Close();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }
            return stringBuilder.ToString();
        }
    }


}
