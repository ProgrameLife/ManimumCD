using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManimumCD.Repository
{
    /// <summary>
    /// 终端命令
    /// </summary>
    public class Command
    {
        /// <summary>
        /// 项目关键字
        /// </summary>
        public string ProjectKey { get; set; }
        
        /// <summary>
        /// 命令语句
        /// </summary>
        public string CommandText { get; set; }
        /// <summary>
        /// 命令返回结果
        /// </summary>
        public string CommandResult { get; set; }
        /// <summary>
        /// 返回值和期望值关系
        /// </summary>
        public ExpectOperator ExpectOperator { get; set; }
        /// <summary>
        /// 期望值
        /// </summary>
        public string ExpectValue { get; set; }


    }
}
