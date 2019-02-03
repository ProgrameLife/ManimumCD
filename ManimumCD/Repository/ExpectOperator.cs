using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManimumCD.Repository
{
    /// <summary>
    /// 返回值和期望值关系
    /// </summary>
    public enum ExpectOperator
    {
        /// <summary>
        /// 无操作
        /// </summary>
        None,
        /// <summary>
        /// 相等
        /// </summary>
        Equal,
        /// <summary>
        /// 包含
        /// </summary>
        Contain

    }
}
