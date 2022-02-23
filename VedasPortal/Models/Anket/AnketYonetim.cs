using Ardalis.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Data;
using VedasPortal.Models.Anket.Contracts;
using VedasPortal.Models.Anket.DTO;
using VedasPortal.Models.Anket.Utils;

namespace VedasPortal.Models.Anket
{
    public class AnketYonetim : IAnketYonetim
    {
        VedasDbContext _context;

        public AnketYonetim(VedasDbContext context)
        {
            _context = context;
        }
        public Result<AnketDTO> GetSurvey(int id)
        {
            try
            {
                var survey = _context.Anket.Where(x => x.Id == id).Include(x => x.AnketSecenek).FirstOrDefault();

                if (survey == null)
                {
                    return Result<AnketDTO>.NotFound();
                }

                var result = Mapper.ToSurveyDTO(survey);

                return Result<AnketDTO>.Success(result);
            }
            catch (Exception)
            {

                return Result<AnketDTO>.Error("Anket getirilirken bir hata meydana geldi.");
            }

        }

        public async Task<Result<AnketDTO>> GetSurveyAsync(int id)
        {
            try
            {
                var survey = await _context.Anket.Where(x => x.Id == id).Include(x => x.AnketSecenek).FirstOrDefaultAsync();

                if (survey == null)
                {
                    return Result<AnketDTO>.NotFound();
                }

                var result = Mapper.ToSurveyDTO(survey);

                return Result<AnketDTO>.Success(result);
            }
            catch (Exception)
            {

                return Result<AnketDTO>.Error("Anket getirilirken bir hata meydana geldi.");
            }
        }

        public Result<List<AnketDTO>> GetAllSurveys()
        {
            try
            {
                var surveys = _context.Anket.Include(x => x.AnketSecenek).ToList();

                var result = Mapper.ToSurveyDTOList(surveys);

                return Result<List<AnketDTO>>.Success(result);
            }
            catch (Exception)
            {

                return Result<List<AnketDTO>>.Error("Anketler getirilirken bir hata meydana geldi");
            }
        }

        public async Task<Result<List<AnketDTO>>> GetAllSurveysAsync()
        {
            try
            {
                var surveys = await _context.Anket.Include(x => x.AnketSecenek).ToListAsync();

                var result = Mapper.ToSurveyDTOList(surveys);

                return Result<List<AnketDTO>>.Success(result);
            }
            catch (Exception)
            {

                return Result<List<AnketDTO>>.Error("Anketler getirilirken bir hata meydana geldi.");
            }
        }

        public Result<bool> DeleteSurvey(int id)
        {
            try
            {
                var survey = _context.Anket.Where(x => x.Id == id).Include(x => x.AnketSecenek).FirstOrDefault();

                if (survey == null)
                {
                    return Result<bool>.NotFound();
                }

                _context.Attach(survey);
                _context.Entry(survey).State = EntityState.Deleted;

                _context.SaveChanges();

                return Result<bool>.Success(true);
            }
            catch (Exception)
            {

                return Result<bool>.Error("Bir hata ile karşılaşıldı. Anket silinemedi!");
            }



        }

        public async Task<Result<bool>> DeleteSurveyAsync(int id)
        {
            try
            {
                var survey = await _context.Anket.Where(x => x.Id == id).Include(x => x.AnketSecenek).FirstOrDefaultAsync();

                if (survey == null)
                {
                    return Result<bool>.NotFound();
                }

                _context.Attach(survey);
                _context.Entry(survey).State = EntityState.Deleted;

                await _context.SaveChangesAsync();

                return Result<bool>.Success(true);
            }
            catch (Exception)
            {

                return Result<bool>.Error("Bir hata ile karşılaşıldı. Anket silinemedi!");
            }
        }

        public Result<AnketDTO> GetRandomSurvey()
        {
            try
            {
                Random rnd = new Random();
                var result = new AnketDTO();
                var surveys = _context.Anket.Where(x => x.SecilenAnketMi == true).Include(x => x.AnketSecenek).ToList();

                result = Mapper.ToSurveyDTO(surveys.OrderBy(x => rnd.Next()).Take(1).FirstOrDefault());

                return Result<AnketDTO>.Success(result);
            }
            catch (Exception)
            {

                return Result<AnketDTO>.Error("Rasgetele anket getirilme esnasında bir hata meydana geldi!");
            }
        }

        public async Task<Result<AnketDTO>> GetRandomSurveyAsync()
        {
            try
            {
                Random rnd = new Random();
                var result = new AnketDTO();
                var surveys = await _context.Anket.Where(x => x.SecilenAnketMi == true).Include(x => x.AnketSecenek).ToListAsync();

                if (surveys.Count == 0)
                {
                    return Result<AnketDTO>.NotFound();
                }

                result = Mapper.ToSurveyDTO(surveys.OrderBy(x => rnd.Next()).Take(1).FirstOrDefault());

                return Result<AnketDTO>.Success(result);
            }
            catch (Exception)
            {

                return Result<AnketDTO>.Error("Rasgetele anket getirilme esnasında bir hata meydana geldi!");
            }
        }

        public Result<AnketDTO> AddSurvey(AnketDTO survey)
        {
            try
            {
                var surveyToAdd = Mapper.FromSurveyDTO(survey);
                survey.OlusturulmaTarihi = DateTime.Now;
                _context.Anket.Add(surveyToAdd);
                _context.SaveChanges();

                survey = Mapper.ToSurveyDTO(surveyToAdd);

                return Result<AnketDTO>.Success(survey);
            }
            catch (Exception)
            {

                return Result<AnketDTO>.Error("Anket eklendiği sırada bir hatayla karşılaşıldı.");
            }
        }

        public async Task<Result<AnketDTO>> AddSurveyAsync(AnketDTO survey)
        {
            try
            {
                var surveyToAdd = Mapper.FromSurveyDTO(survey);
                survey.OlusturulmaTarihi = DateTime.Now;
                await _context.Anket.AddAsync(surveyToAdd);
                await _context.SaveChangesAsync();

                survey = Mapper.ToSurveyDTO(surveyToAdd);

                return Result<AnketDTO>.Success(survey);
            }
            catch (Exception)
            {

                return Result<AnketDTO>.Error("Anket eklendiği sırada bir hatayla karşılaşıldı.");
            }
        }

        public Result<bool> UpdateSurvey(AnketDTO survey)
        {
            try
            {

                var updateVoteCount = 0;

                foreach (var option in survey.AnketSecenekleri)
                {
                    updateVoteCount += option.ToplamKatilim;
                }

                var updatedSurvey = Mapper.FromSurveyDTO(survey);
                var surveyToUpdate = _context.Anket.FirstOrDefault(x => x.Id == survey.AnketId);
                surveyToUpdate.ToplamAlinanSure = updateVoteCount;
                surveyToUpdate.ToplamKatilim = updateVoteCount;
                surveyToUpdate.AnketSecenek = updatedSurvey.AnketSecenek;


                _context.SaveChanges();

                return Result<bool>.Success(true);
            }
            catch (Exception)
            {

                return Result<bool>.Error("Anket güncellenirken bir hatayla karşılaşıldı.");
            }
        }

        public async Task<Result<bool>> UpdateSurveyAsync(AnketDTO survey)
        {
            try
            {
                var updateVoteCount = 0;

                foreach (var option in survey.AnketSecenekleri)
                {
                    updateVoteCount += option.ToplamKatilim;
                }

                var updatedSurvey = Mapper.FromSurveyDTO(survey);
                var surveyToUpdate = await _context.Anket.FirstOrDefaultAsync(x => x.Id == survey.AnketId);
                surveyToUpdate.ToplamAlinanSure = updateVoteCount;
                surveyToUpdate.ToplamKatilim = updateVoteCount;
                surveyToUpdate.AnketSecenek = updatedSurvey.AnketSecenek;

                await _context.SaveChangesAsync();

                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {

                return Result<bool>.Error("Anket güncellenirken bir hatayla karşılaşıldı.");
            }
        }

        public Result<AnketDTO> GetMostPopularSurvey()
        {
            try
            {
                var survey = _context.Anket.Include(x => x.AnketSecenek).OrderByDescending(x => x.ToplamAlinanSure).FirstOrDefault();

                if (survey != null)
                {
                    var result = Mapper.ToSurveyDTO(survey);
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

        public async Task<Result<AnketDTO>> GetMostPopularSurveyAsync()
        {
            try
            {
                var survey = await _context.Anket.Include(x => x.AnketSecenek).OrderByDescending(x => x.ToplamAlinanSure).FirstOrDefaultAsync();

                if (survey != null)
                {
                    var result = Mapper.ToSurveyDTO(survey);
                    return Result<AnketDTO>.Success(result);
                }
                else
                {
                    return Result<AnketDTO>.NotFound();
                }
            }
            catch (Exception ex)
            {

                return Result<AnketDTO>.Error("En popüler anket getirildiği esnada bir hata meydana geldi!");
            }
        }
    }
}
