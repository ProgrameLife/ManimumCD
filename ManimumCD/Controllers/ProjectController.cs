using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ManimumCD.Repository;
using ManimumCD.Terminal;
using Microsoft.AspNetCore.Mvc;


namespace ManimumCD.Controllers
{
    public class ProjectController : Controller
    {
        /// <summary>
        /// 终端
        /// </summary>
        readonly ITerminal _terminal;
        /// <summary>
        /// 命令仓储
        /// </summary>
        readonly ICommandRepository _commandRepository;
        public ProjectController(ITerminal terminal, ICommandRepository commandRepository)
        {
            _terminal = terminal;
            _commandRepository = commandRepository;
        }
        [HttpGet("/projects")]
        public IActionResult Index()
        {
            return View();
        }

    }
}
