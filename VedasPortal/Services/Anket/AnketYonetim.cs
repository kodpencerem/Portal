using Ardalis.Result;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VedasPortal.Data;
using VedasPortal.Entities.DTOs.Anket;
using VedasPortal.Entities.Models.Anket;
using VedasPortal.Entities.Models.User;
using VedasPortal.Repository.Interface;
using VedasPortal.Repository.Interface.Anket;
using VedasPortal.Utils.Anket.ToMapper;

namespace VedasPortal.Services.Anket
{
    public class AnketYonetim : IAnketYonetim
    {
        readonly VedasDbContext _context;
        public AnketUser AnketUser { get; set; } = new();
        [Inject]
        public IToastService ToastService { get; set; }
        private readonly AuthenticationStateProvider _AuthenticationStateProvider;
        public AnketYonetim(VedasDbContext context, AuthenticationStateProvider AuthenticationStateProvider)
        {
            _AuthenticationStateProvider = AuthenticationStateProvider;
            _context = context;
        }
        public Result<AnketDTO> AnketGetir(int id)
        {
            try
            {
                var anketDTO = _context.Anket.Where(x => x.Id == id).Include(x => x.AnketSecenek).FirstOrDefault();

                if (anketDTO == null)
                {
                    return Result<AnketDTO>.NotFound();
                }

                var result = Mapper.ToAnketDTO(anketDTO);

                return Result<AnketDTO>.Success(result);
            }
            catch (Exception)
            {

                return Result<AnketDTO>.Error("Anket getirilirken bir hata meydana geldi.");
            }

        }

        public async Task<Result<AnketDTO>> AnketGetirAsync(int id)
        {
            try
            {
                var anket = await _context.Anket.Where(x => x.Id == id).Include(x => x.AnketSecenek).FirstOrDefaultAsync();

                if (anket == null)
                {
                    return Result<AnketDTO>.NotFound();
                }

                var result = Mapper.ToAnketDTO(anket);

                return Result<AnketDTO>.Success(result);
            }
            catch (Exception)
            {

                return Result<AnketDTO>.Error("Anket getirilirken bir hata meydana geldi.");
            }
        }

        public Result<List<AnketDTO>> TumAnketleriGetir()
        {
            try
            {
                var anketler = _context.Anket.Include(x => x.AnketSecenek).ToList();

                var result = Mapper.ToAnketDTOList(anketler);

                return Result<List<AnketDTO>>.Success(result);
            }
            catch (Exception)
            {

                return Result<List<AnketDTO>>.Error("Anketler getirilirken bir hata meydana geldi");
            }
        }

        public async Task<Result<List<AnketDTO>>> TumAnketleriGetirAsync()
        {
            try
            {
                var anketler = await _context.Anket.Include(x => x.AnketSecenek).ToListAsync();

                var result = Mapper.ToAnketDTOList(anketler);

                return Result<List<AnketDTO>>.Success(result);
            }
            catch (Exception)
            {

                return Result<List<AnketDTO>>.Error("Anketler getirilirken bir hata meydana geldi.");
            }
        }

        public Result<bool> AnketSil(int id)
        {
            try
            {
                var anket = _context.Anket.Where(x => x.Id == id).Include(x => x.AnketSecenek).FirstOrDefault();

                if (anket == null)
                {
                    return Result<bool>.NotFound();
                }

                _context.Attach(anket);
                _context.Entry(anket).State = EntityState.Deleted;

                _context.SaveChanges();

                return Result<bool>.Success(true);
            }
            catch (Exception)
            {

                return Result<bool>.Error("Bir hata ile karşılaşıldı. Anket silinemedi!");
            }
        }
        public async Task<Result<bool>> AnketSilAsync(int id)
        {
            try
            {
                var anket = await _context.Anket.Where(x => x.Id == id).Include(x => x.AnketSecenek).FirstOrDefaultAsync();

                if (anket == null)
                {
                    return Result<bool>.NotFound();
                }

                _context.Attach(anket);
                _context.Entry(anket).State = EntityState.Deleted;

                await _context.SaveChangesAsync();

                return Result<bool>.Success(true);
            }
            catch (Exception)
            {

                return Result<bool>.Error("Bir hata ile karşılaşıldı. Anket silinemedi!");
            }
        }
        public Result<AnketDTO> RastGeleAnketGetir()
        {
            try
            {
                Random rnd = new();
                var result = new AnketDTO();
                var anketler = _context.Anket.Where(x => x.SecilenAnketMi == true).Include(x => x.AnketSecenek).ToList();

                result = Mapper.ToAnketDTO(anketler.OrderBy(x => rnd.Next()).Take(1).FirstOrDefault());

                return Result<AnketDTO>.Success(result);
            }
            catch (Exception)
            {

                return Result<AnketDTO>.Error("Rasgetele anket getirilme esnasında bir hata meydana geldi!");
            }
        }

        public async Task<Result<AnketDTO>> RastGeleAnketGetirAsync()
        {
            try
            {
                Random rnd = new();
                var result = new AnketDTO();
                var anketler = await _context.Anket.Where(x => x.SecilenAnketMi == true).Include(x => x.AnketSecenek).ToListAsync();

                if (anketler.Count == 0)
                {
                    return Result<AnketDTO>.NotFound();
                }

                result = Mapper.ToAnketDTO(anketler.OrderBy(x => rnd.Next()).Take(1).FirstOrDefault());

                return Result<AnketDTO>.Success(result);
            }
            catch (Exception)
            {

                return Result<AnketDTO>.Error("Rasgetele anket getirilme esnasında bir hata meydana geldi!");
            }
        }

        public Result<AnketDTO> AnketEkle(AnketDTO anketDTO)
        {
            try
            {
                var anketEkle = Mapper.FromAnketDTO(anketDTO);
                anketDTO.OlusturulmaTarihi = DateTime.Now;
                _context.Anket.Add(anketEkle);
                _context.SaveChanges();

                anketDTO = Mapper.ToAnketDTO(anketEkle);

                return Result<AnketDTO>.Success(anketDTO);
            }
            catch (Exception)
            {

                return Result<AnketDTO>.Error("Anket eklendiği sırada bir hatayla karşılaşıldı.");
            }
        }

        public async Task<Result<AnketDTO>> AnketEkleAsync(AnketDTO anketDTO)
        {
            try
            {
                var anketEkle = Mapper.FromAnketDTO(anketDTO);
                anketDTO.OlusturulmaTarihi = DateTime.Now;
                await _context.Anket.AddAsync(anketEkle);
                await _context.SaveChangesAsync();

                anketDTO = Mapper.ToAnketDTO(anketEkle);

                return Result<AnketDTO>.Success(anketDTO);
            }
            catch (Exception)
            {

                return Result<AnketDTO>.Error("Anket eklendiği sırada bir hatayla karşılaşıldı.");
            }
        }


        public Result<bool> AnketDuzenle(AnketDTO anketDTO)
        {
            try
            {
                var guncelOySayisi = 0;


                foreach (var secenekDTO in anketDTO.AnketSecenekleri)
                {
                    guncelOySayisi += secenekDTO.ToplamKatilim;
                }

                var guncelAnket = Mapper.FromAnketDTO(anketDTO);
                var anketiGuncelle = _context.Anket.FirstOrDefault(x => x.Id == anketDTO.AnketId);
                anketiGuncelle.ToplamAlinanSure = guncelOySayisi;
                anketiGuncelle.ToplamKatilim = guncelOySayisi;
                anketiGuncelle.AnketSecenek = guncelAnket.AnketSecenek;

                _context.SaveChanges();




                return Result<bool>.Success(true);
            }
            catch (Exception)
            {

                return Result<bool>.Error("Anket güncellenirken bir hatayla karşılaşıldı.");
            }
        }
        private IEnumerable<Claim> claims = Enumerable.Empty<Claim>();

        public async Task<Result<bool>> AnketDuzenleAsync(AnketDTO anketDTO)
        {
            var authState = await _AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var anketUser = _context.AnketUser.FirstOrDefault(x=>x.ApplicationUserId==user);
            try
            {

                if (anketUser.ApplicationUserId == user && anketUser.AnketId==null)
                {
                    var guncelOySayisi = 0;

                    foreach (var secenekDTO in anketDTO.AnketSecenekleri)
                    {
                        guncelOySayisi += secenekDTO.ToplamKatilim;
                    }

                    var guncelAnket = Mapper.FromAnketDTO(anketDTO);
                    var anketiGuncelle = _context.Anket.FirstOrDefault(x => x.Id == anketDTO.AnketId);

                    anketUser.AnketId = anketDTO.AnketId;

                    anketiGuncelle.ToplamAlinanSure = guncelOySayisi;
                    anketiGuncelle.ToplamKatilim = guncelOySayisi;
                    anketiGuncelle.AnketSecenek = guncelAnket.AnketSecenek;

                    _context.SaveChanges();
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Success(false);
                }

            }
            catch (Exception)
            {

                return Result<bool>.Error("Anket güncellenirken bir hatayla karşılaşıldı.");
            }
        }

        public Result<AnketDTO> EnPopulerAnket()
        {
            try
            {
                var anket = _context.Anket.Include(x => x.AnketSecenek).OrderByDescending(x => x.ToplamAlinanSure).FirstOrDefault();

                if (anket != null)
                {
                    var result = Mapper.ToAnketDTO(anket);
                    return Result<AnketDTO>.Success(result);
                }
                else
                {
                    return Result<AnketDTO>.NotFound();
                }
            }
            catch (Exception)
            {

                return Result<AnketDTO>.Error("En popüler anket getirildiği esnada bir hata meydana geldi!");
            }
        }

        public async Task<Result<AnketDTO>> EnPopulerAnketAsync()
        {
            try
            {
                var anket = await _context.Anket.Include(x => x.AnketSecenek).OrderByDescending(x => x.ToplamAlinanSure).FirstOrDefaultAsync();

                if (anket != null)
                {
                    var result = Mapper.ToAnketDTO(anket);
                    return Result<AnketDTO>.Success(result);
                }
                else
                {
                    return Result<AnketDTO>.NotFound();
                }
            }
            catch (Exception)
            {

                return Result<AnketDTO>.Error("En popüler anket getirildiği esnada bir hata meydana geldi!");
            }
        }
    }
}
