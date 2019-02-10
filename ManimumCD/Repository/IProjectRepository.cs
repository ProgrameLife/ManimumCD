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

        /// <summary>
        /// 删除项目
        /// </summary>
        /// <param name="id">项目ID</param>
        /// <returns></returns>
        bool RemoveProject(int id);

        /// <summary>
        /// 修改项目
        /// </summary>
        /// <param name="project">项目</param>
        /// <returns></returns>
        bool ModifyProject(Project project);
        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="project">项目</param>
        /// <returns></returns>
        bool AddProject(Project project);
    }
}
