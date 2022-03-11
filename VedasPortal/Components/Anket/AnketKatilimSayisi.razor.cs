using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Repository.Interface.Anket;

namespace VedasPortal.Components.Anket
{
    public partial class AnketKatilimSayisi : ComponentBase
    {

        [Inject]
        public IJSRuntime JSRuntime { get; set; }
   
        [Inject]
        public IAnketYonetim AnketYonetim { get; set; }

        private int? AnketlerSayisi { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            var anketler = await AnketYonetim.TumAnketleriGetirAsync();

            if (anketler.IsSuccess)
            {
                AnketlerSayisi = anketler.Value.Count();
            }
            else
            {
                AnketlerSayisi = 0;
            }

        }

    }
}