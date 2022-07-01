using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VedasPortal.Data;
using VedasPortal.Entities.DTOs.Anket;
using VedasPortal.Entities.Models.Anket;
using VedasPortal.Entities.Models.User;
using VedasPortal.Entities.ViewModels.Anket;
using VedasPortal.Repository.Interface;
using VedasPortal.Repository.Interface.Anket;
using VedasPortal.Utils.Anket.FromMapper;

namespace VedasPortal.Pages.Anket
{
    public partial class Anket : ComponentBase
    {


        [Parameter]
        public int Id { get; set; }

        [Inject]
        public VedasDbContext Context { get; set; }

        [Inject]
        public Mapper mapper { get; set; }
       
        [Inject]
        public IAnketYonetim AnketYonetim { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }

        private AnketVm AnketVm = new AnketVm();

        private AnketDTO AnketDTO;

        private bool isReady = false;

        [Inject]
        public IBaseRepository<AnketUser> AnketUserServisi { get; set; }

        public AnketUser AnketUser { get; set; }
        protected IEnumerable<AnketUser> AnketKatilimcilari { get; set; }

        protected IEnumerable<AnketUser> TumHaberleriGetir()
        {
            AnketKatilimcilari = AnketUserServisi.GetAll().ToList();
            return AnketKatilimcilari;
        }

        public ApplicationUser ApplicationUser { get; set; }
        [CascadingParameter]
        public Task<AuthenticationState> State { get; set; }
        public string UserName;

        protected override async Task OnInitializedAsync()
        {
            var authState = await State;
            UserName = authState.User.Identity.Name;
            var result = await AnketYonetim.AnketGetirAsync(Id);

            if (result.IsSuccess)
            {
                AnketDTO = result.Value;
                AnketVm = mapper.AnketToAnketVm(AnketDTO);
            }

            isReady = true;
        }

        private async Task AnketGonder()
        {
            
            var authState = await State;
            var user = authState.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var anketUser = Context.AnketUser.Where(x => x.ApplicationUserId == user && x.AnketId==AnketVm.AnketId).Any();
            if (!anketUser)
            {

                var anketKullanici = new AnketUser()
                {
                    AnketId = null,
                    ApplicationUserId = user
                };
                AnketUserServisi.Add(anketKullanici);              
            }
            else
            {

                ToastService.ShowInfo("Halihazırda ankete katılmışsınız zaten!", "Teşekkürler");
            }

            var model = AnketVm;

            AnketVm.YapilanAnket();
            AnketVm.SonucAl();

            AnketDTO.ToplamAlinanSure = AnketVm.ToplamAlinanSure;
            AnketDTO.AnketSecenekleri = AnketVm.AnketSecenekleri;
            AnketDTO.ToplamKatilim = AnketVm.ToplamKatilim;

            var result = await AnketYonetim.AnketDuzenleAsync(AnketDTO);

            if (result.IsSuccess)
            {
                ToastService.ShowInfo("Ankete katılımınız için teşekkür ederiz.", "Teşekkürler");

                NavigationManager.NavigateTo("/Anketler");
            }

            else
            {
                ToastService.ShowError("Bir hata ile karşılaşıldı!", "");
            }

        }

        private void SecilenDegeriGuncelle(string secilmisSecenekId)
        {
            AnketVm.SecilenSecenek = secilmisSecenekId;
        }


    }
}
