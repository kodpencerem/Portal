using Blazorise.Snackbar;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VedasPortal.Components.ShowModalComponent;
using VedasPortal.Entities.Models.User;
using VedasPortal.Enums;

namespace VedasPortal.Pages.Auth
{
    public partial class Users
    {
        [Inject]
        public HttpClient client { get; set; }
        public SnackbarStack snackbarStack;
        public OnayComponent<User> refOnay;
        public OnayComponent<User> refOnayEkle;
        public Blazorise.DataGrid.DataGrid<RoleList> refUserRoleGrid { get; set; }
        public List<User> listUser { get; set; } = new List<User>();
        public List<User> listLdapUser { get; set; } = new List<User>();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await GetAllUser();
            await GetAllUserLdap();
            await UserRoleLoad();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            //await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await InvokeAsync(StateHasChanged);
            }
        }
        public async Task Remove()
        {
            try
            {

                var res = await client.PostAsync($"Auth/DeleteUser/{refOnay.item.UserName}", null);
                listUser.Remove(listUser.FirstOrDefault(q => q.UserName == refOnay.item.UserName));
                await snackbarStack.PushAsync("Silme işlemi Başarılı", SnackbarColor.Success);
                listSelectedUserRole.Clear();
                StateHasChanged();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public async Task AddNewUser()
        {
            try
            {
                if (listSelectedUserRole.Count == 0)
                {
                    await snackbarStack.PushAsync("Kullanıcı oluşturulamadı, Lütfen yetki seçiniz!", SnackbarColor.Danger);
                    return;
                }
                if (refOnayEkle.item.Id != 0)
                    refOnayEkle.item.Roles.Clear();
                listSelectedUserRole.ForEach(q =>
                {
                    refOnayEkle.item.Roles.Add(q.RoleNameEnum);
                });
                var res = await client.PostAsJsonAsync<User>("Auth/CreateUser", refOnayEkle.item);
                if (refOnayEkle.item.Id != 0 && res.IsSuccessStatusCode)
                {
                    await snackbarStack.PushAsync("Güncelleme işlemi başarılı!", SnackbarColor.Success);
                    if (listUser.FirstOrDefault(q => q.Id == refOnayEkle.item.Id) != null)
                        listUser.FirstOrDefault(q => q.Id == refOnayEkle.item.Id).Roles = refOnayEkle.item.Roles;
                }
                else if (res.IsSuccessStatusCode)
                {
                    var nUser = await res.Content.ReadFromJsonAsync<User>();
                    listUser.Add(nUser);
                    listLdapUser.Remove(nUser);
                    StateHasChanged();
                    await snackbarStack.PushAsync("Kullanıcı ekleme işlemi başarılı!", SnackbarColor.Success);
                }
                else
                {
                    var resHata = await res.Content.ReadAsStringAsync();
                    await snackbarStack.PushAsync("Hata Oluştu:" + resHata, SnackbarColor.Danger);

                }
                listSelectedUserRole.Clear();
                StateHasChanged();
            }
            catch (System.Exception ex)
            {
                await snackbarStack.PushAsync("Hata Oluştu: " + ex.Message, SnackbarColor.Danger);
            }
        }
        async Task GetAllUser()
        {

            listUser = await client.GetFromJsonAsync<List<User>>("Auth/GetAllUser");

        }
        async Task GetAllUserLdap()
        {
            listLdapUser = await client.GetFromJsonAsync<List<User>>("Auth/GetAllUserLdap");
        }

        string selectedTab = "yenikullanici";

        private Task OnSelectedTabChanged(string name)
        {
            selectedTab = name;

            return Task.CompletedTask;
        }

        //yetki i�lemleri
        public List<RoleList> listUserRole { get; set; } = new List<RoleList>();
        public List<RoleList> listSelectedUserRole { get; set; } = new List<RoleList>();

        public Task UserRoleLoad()
        {
            listUserRole = (from x in System.Enum.GetNames<EYetkiTipleri>().ToList()
                            select new RoleList
                            {
                                RoleNameEnum = System.Enum.Parse<EYetkiTipleri>(x),
                                RoleName = System.Enum.Parse<EYetkiTipleri>(x).ResYetkiTipleri()

                            }).OrderBy(q => q.RoleName).ToList();
            listUserRole.Remove(listUserRole.FirstOrDefault(q => q.RoleNameEnum == EYetkiTipleri.SuperAdmin));
            return Task.CompletedTask;
        }

        public async Task YetkiGuncelle(User context)
        {
            try
            {

                refOnayEkle.ShowModal();
                StateHasChanged();
                refOnayEkle.item = context;
                listSelectedUserRole.Clear();
                var roles = (from q in context.Roles
                             select new RoleList { RoleNameEnum = q, RoleName = q.ResYetkiTipleri() }).ToList();
                foreach (var item in roles)
                {
                    listSelectedUserRole.Add(item);
                }

                StateHasChanged();
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
    public class RoleList
    {
        public EYetkiTipleri RoleNameEnum { get; set; }
        public string RoleName { get; set; }
    }
}