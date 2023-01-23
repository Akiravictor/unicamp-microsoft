using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OngConnection.Application.DTO;

namespace OngConnection.Web.Models
{
    public class PeopleViewModel
    {
        public List<FamilyDTO>? ListaAtendendo { get; set; }
        public List<FamilyDTO>? ListaDeEspera { get; set; }
        public List<FamilyDTO>? ListaDeAtendidos { get; set; }

        [ValidateNever]
        public bool IsError { get; set; } = false;
        [ValidateNever]
        public string Message { get; set; } = "";
    }
}