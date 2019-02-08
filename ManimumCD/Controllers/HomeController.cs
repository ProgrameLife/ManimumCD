using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ManimumCD.Model;
using ManimumCD.Repository;
using ManimumCD.Terminal;
using Microsoft.AspNetCore.Mvc;


namespace ManimumCD.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 终端
        /// </summary>
        readonly ITerminal _terminal;
        /// <summary>
        /// 命令仓储
        /// </summary>
        readonly ICommandRepository _commandRepository;
        public HomeController(ITerminal terminal, ICommandRepository commandRepository)
        {
            _terminal = terminal;
            _commandRepository = commandRepository;
        }
        public IActionResult Build(int projectID)
        {
            foreach (var command in _commandRepository.GetCommands(projectID))
            {
                command.CommandResult = _terminal.Execute(command.CommandText);
                var expectResult = false;
                switch (command.ExpectOperator)
                {
                    case ExpectOperator.Equal:
                        expectResult = command.CommandResult == command.ExpectValue;
                        break;
                    case ExpectOperator.Contain:
                        expectResult = command.CommandResult.Contains(command.ExpectValue);
                        break;
                    case ExpectOperator.None:
                        expectResult = true;
                        break;
                }
                if (!expectResult)
                {
                    break;
                }
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }


    }
}
