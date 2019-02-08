using ManimumCD.Terminal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;
using ManimumCD.Model;

namespace ManimumCD.Repository
{
    /// <summary>
    /// 项目仓储
    /// </summary>
    public interface IProjectRepository 
    {
        List<Project> GetProjects();
        
    }
}
