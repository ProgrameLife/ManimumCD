using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManimumCD.Repository
{
    /// <summary>
    /// 构建仓储
    /// </summary>
    public interface IBuildRepository
    {
        /// <summary>
        /// 构建
        /// </summary>
        /// <returns></returns>
        string Build();
    }
}
