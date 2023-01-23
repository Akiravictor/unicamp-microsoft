using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using OngConnection.Application.DTO;
using OngConnection.Application.Interfaces;
using OngConnection.Domain.Enums;
using OngConnection.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace OngConnection.Web.Controllers
{
	[Authorize(Roles = "AssistenteSocial")]
	public class SocialWorkerController : Controller
	{
		private readonly ILogger<SocialWorkerController> _logger;
		private readonly IFormServices _formServices;

		public SocialWorkerController(ILogger<SocialWorkerController> logger, IFormServices formServices)
		{
			_logger = logger;
			_formServices = formServices;
		}

		[HttpGet]
		public IActionResult Register()
		{
			var viewModel = new FamilyViewModel();

			return View("Register", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(FamilyViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dto = new FamilyDTO
				{
					Nome = viewModel.Nome!,
					Endereco =	viewModel.Endereco!,
					CEP = viewModel.CEP ?? "",
					Cidade = viewModel.Cidade!,
					Estado = viewModel.Estado!,
					Telefone = viewModel.Telefone ?? "",
					Email = viewModel.Email ?? "",
					Membros	= viewModel.Membros,
					Observacoes	= viewModel.Observacoes ?? ""
				};

				var result = await _formServices.RegisterFamily(dto);

				if (!result)
				{
					viewModel.IsError = true;
					viewModel.Message = "Erro ao cadastrar família. Verifique se já existe um Responsável pela Família o mesmo Nome na mesma Cidade e Estado.";
				}
				else
				{
					viewModel.Message = "Familia cadastrada com sucesso.";
					return View("Register", viewModel);
				}
			}

			return View("Register", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Details(string nome, string endereco, string cidade, string estado)
		{
			var family = _formServices.GetFamilyDetails(nome, endereco, cidade, estado);

			var viewModel = new FamilyViewModel
			{
				Nome = family.Nome,
				Email = family.Email,
				Telefone = family.Telefone,
				Endereco = family.Endereco,
				CEP = family.CEP,
				Cidade = family.Cidade,
				Estado = family.Estado,
				Atendida = family.Atendida,
				Membros = family.Membros,
				Observacoes = family.Observacoes
			};

			return View("Update",viewModel);
		}

		[ValidateAntiForgeryToken]
		public IActionResult Update(FamilyViewModel viewModel)
		{
			var dto = new FamilyDTO
			{
				Nome = viewModel.Nome!,
				Email = viewModel.Email ?? "",
				Telefone = viewModel.Telefone ?? "",
				Endereco = viewModel.Endereco!,
				CEP = viewModel.CEP ?? "",
				Cidade = viewModel.Cidade!,
				Estado = viewModel.Estado!,
				Atendida = viewModel.Atendida,
				Membros = viewModel.Membros,
				Observacoes = viewModel.Observacoes ?? ""
			};

			var result = _formServices.UpdateFamilyDetails(dto);

			if (result)
			{
				viewModel.IsError = false;
				viewModel.Message = "Cadastro atualizado com sucesso.";
			}
			else
			{
				viewModel.IsError = true;
				viewModel.Message = "Erro ao atualizar cadastro. Verifique se já existe um Responsável pela Família o mesmo Nome na mesma Cidade e Estado.";
			}

			return View("Update", viewModel);
		}

		public IActionResult List()
		{
			var viewModel = new List<FamilyViewModel>();

			var families = _formServices.GetAllFamilies();

			foreach(var family in families)
			{
				viewModel.Add(new FamilyViewModel
				{
					Nome = family.Nome,
					Endereco = family.Endereco,
					CEP = family.CEP,
					Cidade = family.Cidade,
					Estado = family.Estado,
					Telefone = family.Telefone,
					Email = family.Email,
					Membros = family.Membros,
					Atendida = family.Atendida,
					Observacoes = family.Observacoes
				});
			}

			return View("List", viewModel);
		}

		[HttpGet]
		public IActionResult Delete(string nome, string endereco, string cidade, string estado)
		{
			var family = _formServices.GetFamilyDetails(nome, endereco, cidade, estado);

			var viewModel = new FamilyViewModel
			{
				Nome = family.Nome,
				Email = family.Email,
				Telefone = family.Telefone,
				Endereco = family.Endereco,
				CEP = family.CEP,
				Cidade = family.Cidade,
				Estado = family.Estado,
				Atendida = family.Atendida,
				Membros = family.Membros,
				Observacoes = family.Observacoes
			};

			return View("Delete", viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(FamilyViewModel viewModel)
		{
			var dto = new FamilyDTO
			{
				Nome = viewModel.Nome!,
				Email = viewModel.Email ?? "",
				Telefone = viewModel.Telefone ?? "",
				Endereco = viewModel.Endereco!,
				CEP = viewModel.CEP ?? "",
				Cidade = viewModel.Cidade!,
				Estado = viewModel.Estado!,
				Atendida = viewModel.Atendida,
				Membros = viewModel.Membros,
				Observacoes = viewModel.Observacoes ?? ""
			};

			var result = _formServices.RemoveFamily(dto);

			if (result)
			{
				return RedirectToAction("List", "SocialWorker");
			}
			else
			{
				viewModel.IsError = true;
				viewModel.Message = "Erro ao atualizar cadastro. Verifique se já existe um Responsável pela Família o mesmo Nome na mesma Cidade e Estado.";
			}

			return View("Delete", viewModel);
		}
	}
}
