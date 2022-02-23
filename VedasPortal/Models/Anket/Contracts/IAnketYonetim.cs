using Ardalis.Result;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Models.Anket.DTO;

namespace VedasPortal.Models.Anket.Contracts
{
    public interface IAnketYonetim
    {
        Result<AnketDTO> GetSurvey(int id);
        Task<Result<AnketDTO>> GetSurveyAsync(int id);
        Result<List<AnketDTO>> GetAllSurveys();
        Task<Result<List<AnketDTO>>> GetAllSurveysAsync();
        Result<bool> DeleteSurvey(int id);
        Task<Result<bool>> DeleteSurveyAsync(int id);
        Result<AnketDTO> GetRandomSurvey();
        Task<Result<AnketDTO>> GetRandomSurveyAsync();
        Result<AnketDTO> AddSurvey(AnketDTO survey);
        Task<Result<AnketDTO>> AddSurveyAsync(AnketDTO survey);
        Result<bool> UpdateSurvey(AnketDTO survey);
        Task<Result<bool>> UpdateSurveyAsync(AnketDTO survey);
        Result<AnketDTO> GetMostPopularSurvey();
        Task<Result<AnketDTO>> GetMostPopularSurveyAsync();

    }
}