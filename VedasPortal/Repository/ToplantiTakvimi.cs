using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VedasPortal.Data;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Repository
{
    public class ToplantiTakvimi : IToplantiTakvimi
    {
        private readonly VedasDbContext _dbContext;
        public ToplantiTakvimi(VedasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<SelectListItem> ToplantiMerkezleri()
        {
            try
            {
                var merkezler = (from merkez in _dbContext.Merkez.AsNoTracking()
                                 select new SelectListItem()
                                 {
                                     Text = merkez.Adi,
                                     Value = merkez.Id.ToString()
                                 }
                                 ).ToList();
                merkezler.Insert(0, new SelectListItem()
                {
                    Value = "",
                    Text = "---Seçiniz---"
                });
                return merkezler;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SelectListItem> ToplantiOdalari(int Id)
        {
            try
            {
                var listofstates = (from oda in _dbContext.ToplantiOdasi.AsNoTracking()
                                    where oda.ToplantiMerkeziId == Id
                                    select new SelectListItem()
                                    {
                                        Text = oda.Adi,
                                        Value = oda.Id.ToString()
                                    }
                    ).ToList();
                listofstates.Insert(0, new SelectListItem()
                {
                    Value = "",
                    Text = "---Seçiniz---"
                });
                return listofstates;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}