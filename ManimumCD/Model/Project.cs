using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManimumCD.Model
{
    /// <summary>
    /// 项目
    /// </summary>
    public class Project
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 有效性
        /// </summary>
        public bool Validate { get; set; }
    }
}
