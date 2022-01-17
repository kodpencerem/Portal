using Microsoft.AspNetCore.Components;
using VedasPortal.Models.YayinDurumlari;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.Duyurular.Admin
{
    public class DuyuruEkleDuzenleModel : ComponentBase
    {
        [Inject]
        public IBaseRepository<Yayin> DuyuruServisi { get; set; }
        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }
        [Parameter]

        public int duyuruId { get; set; }

        protected string Title = "Ekle";
        public Yayin duyuru = new Yayin();

        protected override void OnParametersSet()
        {
            if (duyuruId != 0)
            {
                Title = "Duzenle";
                duyuru = DuyuruServisi.Get(duyuruId);
            }
        }

        protected void DuyuruKayit()
        {
            DuyuruServisi.AddUpdate(duyuru);

            Cancel();
        }

        

        public void Cancel()
        {
            UrlNavigationManager.NavigateTo("/duyurulistele");
        }
    }
}
