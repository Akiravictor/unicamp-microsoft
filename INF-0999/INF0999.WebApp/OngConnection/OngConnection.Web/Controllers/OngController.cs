using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OngConnection.Application.DTO;
using OngConnection.Application.Interfaces;
using OngConnection.Domain.Enums;
using OngConnection.Domain.Interfaces;
using OngConnection.Domain.Models;
using OngConnection.Web.Models;
using System.Diagnostics;

namespace OngConnection.Web.Controllers
{
    [Authorize(Roles = "ONG")]
	public class OngController : Controller
	{
        private readonly ILogger<OngController> _logger;
		private readonly IDashboardServices _dashboardServices;
		private readonly IFormServices _formServices;

        public OngController(ILogger<OngController> logger, IDashboardServices dashboardServices, IFormServices formServices)
		{
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
			_dashboardServices = dashboardServices ?? throw new ArgumentNullException(nameof(dashboardServices));
			_formServices = formServices ?? throw new ArgumentNullException(nameof(formServices));
		}

        public IActionResult People()
        {
			var viewModel = LoadViewModel();

            return View("People", viewModel);
        }

		[ValidateAntiForgeryToken]
		public IActionResult MoveToAttend(string id)
        {

			var result = _dashboardServices.MoveFamily(id, ContactType.EmAtendimento);

			var viewModel = LoadViewModel();

			if (!result)
			{
				viewModel.IsError = true;
				viewModel.Message = "Não foi possível mover o card.";
			}

			return View("People", viewModel);
		}

		[ValidateAntiForgeryToken]
		public IActionResult MoveToFinish(string id)
		{
			var result = _dashboardServices.MoveFamily(id, ContactType.Concluido);

			var viewModel = LoadViewModel();

			if (!result)
			{
				viewModel.IsError = true;
				viewModel.Message = "Não foi possível mover o card.";
			}

			return View("People", viewModel);
		}

		[ValidateAntiForgeryToken]
		public IActionResult MoveToReject(string id)
		{
			var result = _dashboardServices.MoveFamily(id, ContactType.Recusado);

			var viewModel = LoadViewModel();

			if (!result)
			{
				viewModel.IsError = true;
				viewModel.Message = "Não foi possível mover o card.";
			}

			return View("People", viewModel);
		}

		public IActionResult Details(string id)
		{
			var dto = _formServices.GetFamilyDetails(id);

			var viewModel = DTOtoVM(dto);

			return View("Details", viewModel);			
		}

		private PeopleViewModel LoadViewModel()
		{
			var model = new PeopleViewModel();

			var families = _dashboardServices.GetAllFamilies();

			model.ListaAtendendo = families.Where(f => f.Atendida == ContactType.EmAtendimento).ToList();
			model.ListaDeAtendidos = families.Where(f => f.Atendida == ContactType.Concluido).ToList();

			model.ListaDeEspera = families.Where(f => f.Atendida == ContactType.NaoAtendido).ToList();
			model.ListaDeEspera.AddRange(families.Where(f => f.Atendida == ContactType.Recusado).ToList());

			return model;
		}

		private FamilyViewModel DTOtoVM(FamilyDTO dto)
		{
			return new FamilyViewModel
			{
				Id = dto.Id,
				Nome = dto.Nome,
				Email = dto.Email,
				Telefone = dto.Telefone,
				Endereco = dto.Endereco,
				CEP = dto.CEP,
				Cidade = dto.Cidade,
				Estado = dto.Estado,
				Membros = dto.Membros,
				Observacoes = dto.Observacoes,
				Atendida = dto.Atendida
			};
		}
	}
}