using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace VedasPortal.Repository.Interface
{
    public interface IToplantiTakvimi
    {
        List<SelectListItem> TMerkezler();
        List<SelectListItem> OdaListe(int Id);
    }
}
