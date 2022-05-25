using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace VedasPortal.Repository.Interface
{
    public interface IToplantiTakvimi
    {
        List<SelectListItem> ToplantiMerkezleri();
        List<SelectListItem> ToplantiOdalari(int Id);
    }
}
