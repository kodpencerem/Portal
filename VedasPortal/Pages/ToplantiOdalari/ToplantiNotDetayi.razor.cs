using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.ToplantiTakvimi.ToplantiNotu;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.ToplantiOdalari
{
    public partial class ToplantiNotDetayi
    {
        [Inject]
        private IBaseRepository<ToplantiNotu> ToplantiNotu { get; set; }
        [Parameter]
        public int ToplantiNotId { get; set; }

        private ToplantiNotu NotVeKararDetayi { get; set; }

        protected override Task OnInitializedAsync()
        {
            NotVeKararDetayi = ToplantiNotu.Get(ToplantiNotId);
            return Task.CompletedTask;
        }
    }
}
