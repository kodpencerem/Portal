using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using VedasPortal.Data;
using VedasPortal.Entities.DTOs.Anket;
using VedasPortal.Repository.Interface.Anket;

namespace VedasPortal.Components.Anket
{
    public partial class EnPopulerAnket : ComponentBase
    {
        [Inject]
        public IAnketYonetim AnketYonetim { get; set; }

        [Inject]
        public VedasDbContext Context { get; set; }

        private AnketDTO Anket { get; set; }


        protected override async Task OnParametersSetAsync()
        {
            var result = await AnketYonetim.EnPopulerAnketAsync();

            if (result.IsSuccess)
            {
                Anket = result.Value;
            }

        }
    }
}
