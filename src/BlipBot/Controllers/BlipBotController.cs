using BlitBot.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlipBot.API.Controllers
{
    [Route("api/bitbot")]
    public class BlipBotController : MainController
    {
        private readonly IRequestGitHubService _requestGitHubService;
        public BlipBotController(INotificador notificador, 
                                 IRequestGitHubService requestGitHubService) : base(notificador)
        {
            _requestGitHubService = requestGitHubService;
        }

        [HttpGet("obter-informacao")]
        public async Task<IActionResult> ObterInformacao()
        
        {
            var repositoriosObtidos = await _requestGitHubService.ObterRepositoriosDoGitHub();
            return CustomResponse(repositoriosObtidos);
        }
    }
}
