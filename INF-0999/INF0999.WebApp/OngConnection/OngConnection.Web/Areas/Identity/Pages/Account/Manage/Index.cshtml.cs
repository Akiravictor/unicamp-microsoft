// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OngConnection.Application.DTO;
using OngConnection.Application.Interfaces;
using OngConnection.Domain.Enums;
using OngConnection.Domain.Models;

namespace OngConnection.Web.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUserServices _userServices;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IUserServices userServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userServices = userServices;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            [Required]
            public string Nome { get; set; } = "";
            public string Telefone { get; set; } = "";

            [Required]
            public string Endereco { get; set; } = "";

            [Required]
            public string CEP { get; set; } = "";

            [Required]
            public string Cidade { get; set; } = "";

            [Required]
			public string Estado { get; set; } = "";

            [Required]
            public OngType OngType { get; set; } = OngType.Vazio;

            [ValidateNever]
            public bool IsError { get; set; }
            [ValidateNever]
            public string Message { get; set; }
        }

        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);

            var roles = await _userManager.GetRolesAsync(user);
            Input = new InputModel();

            if (roles.Contains(UserType.ONG.GetDescription()))
            {
                var ong = _userServices.GetOngByEmail(userName);

                Input.Nome = ong.NomeOng;
                Input.Telefone = ong.Telefone;
                Input.Endereco = ong.Endereco;
                Input.CEP = ong.CEP;
                Input.Cidade = ong.Cidade;
                Input.Estado = ong.Estado;
                Input.OngType = ong.Tipo;
            }
            else if (roles.Contains(UserType.AssistenteSocial.GetDescription()))
            {
                var social = _userServices.GetSocialWorkerByEmail(userName);
                
                Input.Nome = social.Nome;
				Input.Telefone = social.Telefone;
				Input.Endereco = social.Endereco;
				Input.CEP = social.CEP;
				Input.Cidade = social.Cidade;
				Input.Estado = social.Estado;
			}

            Username = userName;

        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var roles = await _userManager.GetRolesAsync(user);

            var result = false;

			if (roles.Contains(UserType.ONG.GetDescription()))
            {
                var dto = new OngDTO
                {
                    NomeOng = Input.Nome,
                    Telefone = Input.Telefone,
                    Email = user.Email,
                    Endereco = Input.Endereco,
                    CEP = Input.CEP,
                    Cidade = Input.Cidade,
                    Estado = Input.Estado,
                    Tipo = Input.OngType
                };
			    
                result = _userServices.UpdateUser(dto);
            }
			else if (roles.Contains(UserType.AssistenteSocial.GetDescription()))
            {
                var dto = new SocialWorkerDTO
                {
                    Nome = Input.Nome,
                    Telefone = Input.Telefone,
                    Email = user.Email,
                    Endereco = Input.Endereco,
                    CEP = Input.CEP,
                    Cidade = Input.Cidade,
                    Estado = Input.Estado
                };

				result = _userServices.UpdateUser(dto);
			}


            if (!result)
            {
                StatusMessage = "Falha ao tentar atualizar o perfil.";

			}

            
            StatusMessage = "Seu perfil foi salvo com sucesso.";
            return RedirectToPage();
        }
    }
}
