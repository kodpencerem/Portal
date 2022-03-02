using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;
using VedasPortal.Models.DovizKurlari;

namespace VedasPortal.Services.Doviz
{
    public enum DegisimTurleri
    {
        DovizAlis, DovizSatis,
        EfektifAlis, EfektifSatis
    }

    public enum DovizKodlari
    {
        USD, AUD, DKK,
        EUR, GBP, CHF,
        SEK, CAD, KWD,
        NOK, SAR, JPY,
        BGN, RON, RUB,
        IRR, CNY, PKR,
        TRY,
    }

    public static class DovizDegisimleriServisi
    {

        /// <summary>
        /// Günlük döviz değişimlerini sözlük biçimde gösterir
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Dictionary<string, DovizKurlari> TumDovizDegisimleriniGetir()
        {
            try
            {
                return DovizleriGetir("http://www.tcmb.gov.tr/kurlar/today.xml");
            }
            catch (Exception)
            {
                throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
            }
        }


        /// <summary>
        /// Günlük döviz değişimlerini tablo olarak gösterir
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DataTable TumDovizDegisimleriTablosunuGetir()
        {
            try
            {
                Dictionary<string, DovizKurlari> CurrencyRates = DovizleriGetir("http://www.tcmb.gov.tr/kurlar/today.xml");

                DataTable dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Code", typeof(string));
                dt.Columns.Add("CrossRateName", typeof(string));
                dt.Columns.Add("ForexBuying", typeof(double));
                dt.Columns.Add("ForexSelling", typeof(double));
                dt.Columns.Add("BanknoteBuying", typeof(double));
                dt.Columns.Add("BanknoteSelling", typeof(double));

                foreach (string item in CurrencyRates.Keys)
                {
                    DataRow dr = dt.NewRow();
                    dr["Name"] = CurrencyRates[item].DovizAdi;
                    dr["Code"] = CurrencyRates[item].DovizKodu;
                    dr["CrossRateName"] = CurrencyRates[item].CaprazKurAdi;
                    dr["ForexBuying"] = CurrencyRates[item].DovizAlis;
                    dr["ForexSelling"] = CurrencyRates[item].DovizSatis;
                    dr["BanknoteBuying"] = CurrencyRates[item].EfektifAlis;
                    dr["BanknoteSelling"] = CurrencyRates[item].EfektifSatis;
                    dt.Rows.Add(dr);
                }

                return dt;
            }
            catch (Exception)
            {
                throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
            }
        }
        /// <summary>
        /// Geçmiş Tarihli Döviz Kurlarını Alma ( Dictionary<string DövizKuruKodu, Currency> )
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <param name="Day"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Dictionary<string, DovizKurlari> TarihBazindaDovizDegisimleriniGetir(int Year, int Month, int Day)
        {
            try
            {
                string SYear = string.Format("{0:0000}", Year);
                string SMonth = string.Format("{0:00}", Month);
                string SDay = string.Format("{0:00}", Day);

                return DovizleriGetir("http://www.tcmb.gov.tr/kurlar/" + SYear + SMonth + "/" + SDay + SMonth + SYear + ".xml");
            }
            catch (Exception)
            {
                throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
            }
        }

        /// <summary>
        /// /Geçmiş Tarihli Döviz Kurlarını Alma ( DataTable )
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <param name="Day"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DataTable TarihBazindaDovizDegisimleriTablosunuGetir(int Year, int Month, int Day)
        {
            try
            {
                string SYear = string.Format("{0:0000}", Year);
                string SMonth = string.Format("{0:00}", Month);
                string SDay = string.Format("{0:00}", Day);

                Dictionary<string, DovizKurlari> CurrencyRates = DovizleriGetir("http://www.tcmb.gov.tr/kurlar/" + SYear + SMonth + "/" + SDay + SMonth + SYear + ".xml");

                DataTable dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Code", typeof(string));
                dt.Columns.Add("CrossRateName", typeof(string));
                dt.Columns.Add("ForexBuying", typeof(double));
                dt.Columns.Add("ForexSelling", typeof(double));
                dt.Columns.Add("BanknoteBuying", typeof(double));
                dt.Columns.Add("BanknoteSelling", typeof(double));

                foreach (string item in CurrencyRates.Keys)
                {
                    DataRow dr = dt.NewRow();
                    dr["Name"] = CurrencyRates[item].DovizAdi;
                    dr["Code"] = CurrencyRates[item].DovizKodu;
                    dr["CrossRateName"] = CurrencyRates[item].CaprazKurAdi;
                    dr["ForexBuying"] = CurrencyRates[item].DovizAlis;
                    dr["ForexSelling"] = CurrencyRates[item].DovizSatis;
                    dr["BanknoteBuying"] = CurrencyRates[item].EfektifAlis;
                    dr["BanknoteSelling"] = CurrencyRates[item].EfektifSatis;
                    dt.Rows.Add(dr);
                }

                return dt;

            }
            catch (Exception)
            {
                throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
            }
        }

        /// <summary>
        /// Geçmiş Tarihli Döviz Kurunu Alma
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Dictionary<string, DovizKurlari> TarihBazindaDovizDegisimleriniGetir(DateTime date)
        {
            try
            {
                string SYear = string.Format("{0:0000}", date.Year);
                string SMonth = string.Format("{0:00}", date.Month);
                string SDay = string.Format("{0:00}", date.Day);

                return DovizleriGetir("http://www.tcmb.gov.tr/kurlar/" + SYear + SMonth + "/" + SDay + SMonth + SYear + ".xml");
            }
            catch (Exception)
            {
                throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
            }
        }

        public static DataTable TarihBazindaDovizDegisimleriTablosunuGetir(DateTime date)
        {
            try
            {
                string SYear = string.Format("{0:0000}", date.Year);
                string SMonth = string.Format("{0:00}", date.Month);
                string SDay = string.Format("{0:00}", date.Day);

                Dictionary<string, DovizKurlari> CurrencyRates = DovizleriGetir("http://www.tcmb.gov.tr/kurlar/" + SYear + SMonth + "/" + SDay + SMonth + SYear + ".xml");

                DataTable dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Code", typeof(string));
                dt.Columns.Add("CrossRateName", typeof(string));
                dt.Columns.Add("ForexBuying", typeof(double));
                dt.Columns.Add("ForexSelling", typeof(double));
                dt.Columns.Add("BanknoteBuying", typeof(double));
                dt.Columns.Add("BanknoteSelling", typeof(double));

                foreach (string item in CurrencyRates.Keys)
                {
                    DataRow dr = dt.NewRow();
                    dr["Name"] = CurrencyRates[item].DovizAdi;
                    dr["Code"] = CurrencyRates[item].DovizKodu;
                    dr["CrossRateName"] = CurrencyRates[item].CaprazKurAdi;
                    dr["ForexBuying"] = CurrencyRates[item].DovizAlis;
                    dr["ForexSelling"] = CurrencyRates[item].DovizSatis;
                    dr["BanknoteBuying"] = CurrencyRates[item].EfektifAlis;
                    dr["BanknoteSelling"] = CurrencyRates[item].EfektifSatis;
                    dt.Rows.Add(dr);
                }

                return dt;

            }
            catch (Exception)
            {
                throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
            }
        }

        public static DovizKurlari GunlukDovizDegisimleriGetir(DovizKodlari Currency)
        {
            try
            {
                Dictionary<string, DovizKurlari> CurrencyRates = DovizleriGetir("http://www.tcmb.gov.tr/kurlar/today.xml");

                if (CurrencyRates.Keys.Contains(Currency.ToString()))
                {
                    return CurrencyRates[Currency.ToString()];
                }
                else
                {
                    throw new Exception("Belirtilen para birimi(" + Currency.ToString() + ") bulunamadı!");
                }
            }
            catch (Exception)
            {
                throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
               
            }
        }

        public static DovizKurlari TarihiBazdaDovizDegisimleriGetir(DovizKodlari Currency, int Year, int Month, int Day)
        {
            try
            {
                string SYear = string.Format("{0:0000}", Year);
                string SMonth = string.Format("{0:00}", Month);
                string SDay = string.Format("{0:00}", Day);

                Dictionary<string, DovizKurlari> CurrencyRates = DovizleriGetir("http://www.tcmb.gov.tr/kurlar/" + SYear + SMonth + "/" + SDay + SMonth + SYear + ".xml");

                if (CurrencyRates.Keys.Contains(Currency.ToString()))
                {
                    return CurrencyRates[Currency.ToString()];
                }
                else
                {
                    throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
                }
            }
            catch (Exception)
            {
                throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
            }
        }

        public static DovizKurlari TarihiBazdaDovizDegisimleriGetir(DovizKodlari Currency, DateTime date)
        {
            try
            {
                string SYear = string.Format("{0:0000}", date.Year);
                string SMonth = string.Format("{0:00}", date.Month);
                string SDay = string.Format("{0:00}", date.Day);

                Dictionary<string, DovizKurlari> CurrencyRates = DovizleriGetir("http://www.tcmb.gov.tr/kurlar/" + SYear + SMonth + "/" + SDay + SMonth + SYear + ".xml");

                if (CurrencyRates.Keys.Contains(Currency.ToString()))
                {
                    return CurrencyRates[Currency.ToString()];
                }
                else
                {
                    throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
                }
            }
            catch (Exception)
            {
                throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
            }
        }

        public static DovizKurlari GunlukCaprazKurDegisimleriniGetir(DovizKodlari ToCurrencyCode, DovizKodlari FromCurrencyCode)
        {
            try
            {
                Dictionary<string, DovizKurlari> CurrencyRates = DovizleriGetir("http://www.tcmb.gov.tr/kurlar/today.xml");

                if (!CurrencyRates.Keys.Contains(FromCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + FromCurrencyCode.ToString() + ") bulunamadı!");
                }
                else if (!CurrencyRates.Keys.Contains(ToCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + ToCurrencyCode.ToString() + ") bulunamadı!");
                }
                else
                {
                    DovizKurlari MainCurrency = CurrencyRates[FromCurrencyCode.ToString()];
                    DovizKurlari OtherCurrency = CurrencyRates[ToCurrencyCode.ToString()];

                    return new DovizKurlari(
                        OtherCurrency.DovizAdi,
                        OtherCurrency.DovizKodu,
                        OtherCurrency.DovizKodu + "/" + MainCurrency.DovizKodu,
                        OtherCurrency.DovizAlis == 0 || MainCurrency.DovizAlis == 0 ? 0 : Math.Round(OtherCurrency.DovizAlis / MainCurrency.DovizAlis, 4),
                        OtherCurrency.DovizSatis == 0 || MainCurrency.DovizSatis == 0 ? 0 : Math.Round(OtherCurrency.DovizSatis / MainCurrency.DovizSatis, 4),
                        OtherCurrency.EfektifAlis == 0 || MainCurrency.EfektifAlis == 0 ? 0 : Math.Round(OtherCurrency.EfektifAlis / MainCurrency.EfektifAlis, 4),
                        OtherCurrency.EfektifSatis == 0 || MainCurrency.EfektifSatis == 0 ? 0 : Math.Round(OtherCurrency.EfektifSatis / MainCurrency.EfektifSatis, 4)
                    );
                }
            }
            catch (Exception)
            {
                throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
            }
        }

        /// <summary>
        /// Güncel Çapraz Kur Verilerini Alma
        /// </summary>
        /// <param name="ToCurrencyCode"></param>
        /// <param name="FromCurrencyCode"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static double GunlukCaprazKurlariGetir(DovizKodlari ToCurrencyCode, DovizKodlari FromCurrencyCode)
        {
            try
            {
                Dictionary<string, DovizKurlari> CurrencyRates = DovizleriGetir("http://www.tcmb.gov.tr/kurlar/today.xml");

                if (!CurrencyRates.Keys.Contains(FromCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + FromCurrencyCode.ToString() + ") bulunamadı!");
                }
                else if (!CurrencyRates.Keys.Contains(ToCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + ToCurrencyCode.ToString() + ") bulunamadı!");
                }
                else
                {
                    DovizKurlari MainCurrency = CurrencyRates[FromCurrencyCode.ToString()];
                    DovizKurlari OtherCurrency = CurrencyRates[ToCurrencyCode.ToString()];

                    return OtherCurrency.DovizAlis == 0 || MainCurrency.DovizAlis == 0 ? 0 : Math.Round(OtherCurrency.DovizAlis / MainCurrency.DovizAlis, 4);
                }
            }
            catch (Exception)
            {
                throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
            }
        }

        /// <summary>
        /// Geçmiş Tarihli Çapraz Kur Verilerini Alma
        /// </summary>
        /// <param name="ToCurrencyCode"></param>
        /// <param name="FromCurrencyCode"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DovizKurlari TarihBazindaCaprazKurlariGetir(DovizKodlari ToCurrencyCode, DovizKodlari FromCurrencyCode, DateTime date)
        {
            try
            {
                string SYear = string.Format("{0:0000}", date.Year);
                string SMonth = string.Format("{0:00}", date.Month);
                string SDay = string.Format("{0:00}", date.Day);

                Dictionary<string, DovizKurlari> CurrencyRates = DovizleriGetir("http://www.tcmb.gov.tr/kurlar/" + SYear + SMonth + "/" + SDay + SMonth + SYear + ".xml");

                if (!CurrencyRates.Keys.Contains(FromCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + FromCurrencyCode.ToString() + ") bulunamadı!");
                }
                else if (!CurrencyRates.Keys.Contains(ToCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + ToCurrencyCode.ToString() + ") bulunamadı!");
                }
                else
                {
                    DovizKurlari MainCurrency = CurrencyRates[FromCurrencyCode.ToString()];
                    DovizKurlari OtherCurrency = CurrencyRates[ToCurrencyCode.ToString()];

                    return new DovizKurlari(
                        OtherCurrency.DovizAdi,
                        OtherCurrency.DovizKodu,
                        OtherCurrency.DovizKodu + "/" + MainCurrency.DovizKodu,
                        OtherCurrency.DovizAlis == 0 || MainCurrency.DovizAlis == 0 ? 0 : Math.Round(OtherCurrency.DovizAlis / MainCurrency.DovizAlis, 4),
                        OtherCurrency.DovizAlis == 0 || MainCurrency.DovizAlis == 0 ? 0 : Math.Round(OtherCurrency.DovizAlis / MainCurrency.DovizAlis, 4),
                        OtherCurrency.DovizAlis == 0 || MainCurrency.DovizAlis == 0 ? 0 : Math.Round(OtherCurrency.DovizAlis / MainCurrency.DovizAlis, 4),
                        OtherCurrency.DovizAlis == 0 || MainCurrency.DovizAlis == 0 ? 0 : Math.Round(OtherCurrency.DovizAlis / MainCurrency.DovizAlis, 4)
                    );
                }
            }
            catch (Exception)
            {
                throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
            }
        }

        public static double TarihBazindaCaprazKurGetir(DovizKodlari ToCurrencyCode, DovizKodlari FromCurrencyCode, DateTime date)
        {
            try
            {
                string SYear = string.Format("{0:0000}", date.Year);
                string SMonth = string.Format("{0:00}", date.Month);
                string SDay = string.Format("{0:00}", date.Day);

                Dictionary<string, DovizKurlari> CurrencyRates = DovizleriGetir("http://www.tcmb.gov.tr/kurlar/" + SYear + SMonth + "/" + SDay + SMonth + SYear + ".xml");

                if (!CurrencyRates.Keys.Contains(FromCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + FromCurrencyCode.ToString() + ") bulunamadı!");
                }
                else if (!CurrencyRates.Keys.Contains(ToCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + ToCurrencyCode.ToString() + ") bulunamadı!");
                }
                else
                {
                    DovizKurlari MainCurrency = CurrencyRates[FromCurrencyCode.ToString()];
                    DovizKurlari OtherCurrency = CurrencyRates[ToCurrencyCode.ToString()];

                    return OtherCurrency.DovizAlis == 0 || MainCurrency.DovizAlis == 0 ? 0 : Math.Round(OtherCurrency.DovizAlis / MainCurrency.DovizAlis, 4);
                }
            }
            catch (Exception)
            {
                throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
            }
        }

        public static DovizKurlari TarihBazindaCaprazKurlariGetir(DovizKodlari ToCurrencyCode, DovizKodlari FromCurrencyCode, int Year, int Month, int Day)
        {
            try
            {
                string SYear = string.Format("{0:0000}", Year);
                string SMonth = string.Format("{0:00}", Month);
                string SDay = string.Format("{0:00}", Day);

                Dictionary<string, DovizKurlari> CurrencyRates = DovizleriGetir("http://www.tcmb.gov.tr/kurlar/" + SYear + SMonth + "/" + SDay + SMonth + SYear + ".xml");

                if (!CurrencyRates.Keys.Contains(FromCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + FromCurrencyCode.ToString() + ") bulunamadı!");
                }
                else if (!CurrencyRates.Keys.Contains(ToCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + ToCurrencyCode.ToString() + ") bulunamadı!");
                }
                else
                {
                    DovizKurlari MainCurrency = CurrencyRates[FromCurrencyCode.ToString()];
                    DovizKurlari OtherCurrency = CurrencyRates[ToCurrencyCode.ToString()];

                    return new DovizKurlari(
                        OtherCurrency.DovizAdi,
                        OtherCurrency.DovizKodu,
                        OtherCurrency.DovizKodu + "/" + MainCurrency.DovizKodu,
                        OtherCurrency.DovizAlis == 0 || MainCurrency.DovizAlis == 0 ? 0 : Math.Round(OtherCurrency.DovizAlis / MainCurrency.DovizAlis, 4),
                        OtherCurrency.DovizAlis == 0 || MainCurrency.DovizAlis == 0 ? 0 : Math.Round(OtherCurrency.DovizAlis / MainCurrency.DovizAlis, 4),
                        OtherCurrency.DovizAlis == 0 || MainCurrency.DovizAlis == 0 ? 0 : Math.Round(OtherCurrency.DovizAlis / MainCurrency.DovizAlis, 4),
                        OtherCurrency.DovizAlis == 0 || MainCurrency.DovizAlis == 0 ? 0 : Math.Round(OtherCurrency.DovizAlis / MainCurrency.DovizAlis, 4)
                    );
                }
            }
            catch (Exception)
            {
                throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
            }
        }

        public static double TarihBazindaCaprazKurGetir(DovizKodlari ToCurrencyCode, DovizKodlari FromCurrencyCode, int Year, int Month, int Day)
        {
            try
            {
                string SYear = string.Format("{0:0000}", Year);
                string SMonth = string.Format("{0:00}", Month);
                string SDay = string.Format("{0:00}", Day);

                Dictionary<string, DovizKurlari> CurrencyRates = DovizleriGetir("http://www.tcmb.gov.tr/kurlar/" + SYear + SMonth + "/" + SDay + SMonth + SYear + ".xml");

                if (!CurrencyRates.Keys.Contains(FromCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + FromCurrencyCode.ToString() + ") bulunamadı!");
                }
                else if (!CurrencyRates.Keys.Contains(ToCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + ToCurrencyCode.ToString() + ") bulunamadı!");
                }
                else
                {
                    DovizKurlari MainCurrency = CurrencyRates[FromCurrencyCode.ToString()];
                    DovizKurlari OtherCurrency = CurrencyRates[ToCurrencyCode.ToString()];

                    return OtherCurrency.DovizAlis == 0 || MainCurrency.DovizAlis == 0 ? 0 : Math.Round(OtherCurrency.DovizAlis / MainCurrency.DovizAlis, 4);
                }
            }
            catch (Exception)
            {
                throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
            }
        }

        /// <summary>
        /// Güncel Kur Fiyatı Hesaplama
        /// </summary>
        /// <param name="Amount"></param>
        /// <param name="FromCurrencyCode"></param>
        /// <param name="ToCurrencyCode"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static double GunlukDovizDegisimiHesapla(double Amount, DovizKodlari FromCurrencyCode, DovizKodlari ToCurrencyCode)
        {
            try
            {
                Dictionary<string, DovizKurlari> CurrencyRates = DovizleriGetir("http://www.tcmb.gov.tr/kurlar/today.xml");

                if (!CurrencyRates.Keys.Contains(FromCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + FromCurrencyCode.ToString() + ") bulunamadı!");
                }
                else if (!CurrencyRates.Keys.Contains(ToCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + ToCurrencyCode.ToString() + ") bulunamadı!");
                }
                else
                {
                    DovizKurlari MainCurrency = CurrencyRates[FromCurrencyCode.ToString()];
                    DovizKurlari OtherCurrency = CurrencyRates[ToCurrencyCode.ToString()];

                    return OtherCurrency.DovizAlis == 0 || MainCurrency.DovizAlis == 0 ? 0 : Math.Round(Amount * (MainCurrency.DovizAlis / OtherCurrency.DovizAlis), 4);
                }
            }
            catch (Exception)
            {
                throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
            }
        }

        public static double GunlukDovizDegisimiHesapla(double Amount, DovizKodlari FromCurrencyCode, DovizKodlari ToCurrencyCode, DegisimTurleri exchangeType)
        {
            try
            {
                Dictionary<string, DovizKurlari> CurrencyRates = DovizleriGetir("http://www.tcmb.gov.tr/kurlar/today.xml");

                if (!CurrencyRates.Keys.Contains(FromCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + FromCurrencyCode.ToString() + ") bulunamadı!");
                }
                else if (!CurrencyRates.Keys.Contains(ToCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + ToCurrencyCode.ToString() + ") bulunamadı!");
                }
                else
                {
                    DovizKurlari MainCurrency = CurrencyRates[FromCurrencyCode.ToString()];
                    DovizKurlari OtherCurrency = CurrencyRates[ToCurrencyCode.ToString()];

                    switch (exchangeType)
                    {
                        case DegisimTurleri.DovizAlis:
                            return OtherCurrency.DovizAlis == 0 || MainCurrency.DovizAlis == 0 ? 0 : Math.Round(Amount * (MainCurrency.DovizAlis / OtherCurrency.DovizAlis), 4);
                        case DegisimTurleri.DovizSatis:
                            return OtherCurrency.DovizSatis == 0 || MainCurrency.DovizSatis == 0 ? 0 : Math.Round(Amount * (MainCurrency.DovizSatis / OtherCurrency.DovizSatis), 4);
                        case DegisimTurleri.EfektifAlis:
                            return OtherCurrency.EfektifAlis == 0 || MainCurrency.EfektifAlis == 0 ? 0 : Math.Round(Amount * (MainCurrency.EfektifAlis / OtherCurrency.EfektifAlis), 4);
                        case DegisimTurleri.EfektifSatis:
                            return OtherCurrency.EfektifSatis == 0 || MainCurrency.EfektifSatis == 0 ? 0 : Math.Round(Amount * (MainCurrency.EfektifSatis / OtherCurrency.EfektifSatis), 4);
                        default:
                            return 0;
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
            }
        }

        /// <summary>
        /// Geçmiş Tarihli Kur Fiyatı Hesaplama
        /// </summary>
        /// <param name="Amount"></param>
        /// <param name="FromCurrencyCode"></param>
        /// <param name="ToCurrencyCode"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static double TarihBazindaDovizDegisimiHesapla(double Amount, DovizKodlari FromCurrencyCode, DovizKodlari ToCurrencyCode, DateTime date)
        {
            try
            {
                string SYear = string.Format("{0:0000}", date.Year);
                string SMonth = string.Format("{0:00}", date.Month);
                string SDay = string.Format("{0:00}", date.Day);

                Dictionary<string, DovizKurlari> CurrencyRates = DovizleriGetir("http://www.tcmb.gov.tr/kurlar/" + SYear + SMonth + "/" + SDay + SMonth + SYear + ".xml");

                if (!CurrencyRates.Keys.Contains(FromCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + FromCurrencyCode.ToString() + ") bulunamadı!");
                }
                else if (!CurrencyRates.Keys.Contains(ToCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + ToCurrencyCode.ToString() + ") bulunamadı!");
                }
                else
                {
                    DovizKurlari MainCurrency = CurrencyRates[FromCurrencyCode.ToString()];
                    DovizKurlari OtherCurrency = CurrencyRates[ToCurrencyCode.ToString()];

                    return OtherCurrency.DovizAlis == 0 || MainCurrency.DovizAlis == 0 ? 0 : Math.Round(Amount * (MainCurrency.DovizAlis / OtherCurrency.DovizAlis), 4);
                }
            }
            catch (Exception)
            {
                throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
            }
        }

        public static double TarihBazindaDovizDegisimiHesapla(double Amount, DovizKodlari FromCurrencyCode, DovizKodlari ToCurrencyCode, DegisimTurleri exchangeType, DateTime date)
        {
            try
            {
                string SYear = string.Format("{0:0000}", date.Year);
                string SMonth = string.Format("{0:00}", date.Month);
                string SDay = string.Format("{0:00}", date.Day);

                Dictionary<string, DovizKurlari> CurrencyRates = DovizleriGetir("http://www.tcmb.gov.tr/kurlar/" + SYear + SMonth + "/" + SDay + SMonth + SYear + ".xml");

                if (!CurrencyRates.Keys.Contains(FromCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + FromCurrencyCode.ToString() + ") bulunamadı!");
                }
                else if (!CurrencyRates.Keys.Contains(ToCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + ToCurrencyCode.ToString() + ") bulunamadı!");
                }
                else
                {
                    DovizKurlari MainCurrency = CurrencyRates[FromCurrencyCode.ToString()];
                    DovizKurlari OtherCurrency = CurrencyRates[ToCurrencyCode.ToString()];

                    switch (exchangeType)
                    {
                        case DegisimTurleri.DovizAlis:
                            return OtherCurrency.DovizAlis == 0 || MainCurrency.DovizAlis == 0 ? 0 : Math.Round(Amount * (MainCurrency.DovizAlis / OtherCurrency.DovizAlis), 4);
                        case DegisimTurleri.DovizSatis:
                            return OtherCurrency.DovizSatis == 0 || MainCurrency.DovizSatis == 0 ? 0 : Math.Round(Amount * (MainCurrency.DovizSatis / OtherCurrency.DovizSatis), 4);
                        case DegisimTurleri.EfektifAlis:
                            return OtherCurrency.EfektifAlis == 0 || MainCurrency.EfektifAlis == 0 ? 0 : Math.Round(Amount * (MainCurrency.EfektifAlis / OtherCurrency.EfektifAlis), 4);
                        case DegisimTurleri.EfektifSatis:
                            return OtherCurrency.EfektifSatis == 0 || MainCurrency.EfektifSatis == 0 ? 0 : Math.Round(Amount * (MainCurrency.EfektifSatis / OtherCurrency.EfektifSatis), 4);
                        default:
                            return 0;
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
            }
        }

        public static double TarihBazindaDovizDegisimiHesapla(double Amount, DovizKodlari FromCurrencyCode, DovizKodlari ToCurrencyCode, int Year, int Month, int Day)
        {
            try
            {
                string SYear = string.Format("{0:0000}", Year);
                string SMonth = string.Format("{0:00}", Month);
                string SDay = string.Format("{0:00}", Day);

                Dictionary<string, DovizKurlari> CurrencyRates = DovizleriGetir("http://www.tcmb.gov.tr/kurlar/" + SYear + SMonth + "/" + SDay + SMonth + SYear + ".xml");

                if (!CurrencyRates.Keys.Contains(FromCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + FromCurrencyCode.ToString() + ") bulunamadı!");
                }
                else if (!CurrencyRates.Keys.Contains(ToCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + ToCurrencyCode.ToString() + ") bulunamadı!");
                }
                else
                {
                    DovizKurlari MainCurrency = CurrencyRates[FromCurrencyCode.ToString()];
                    DovizKurlari OtherCurrency = CurrencyRates[ToCurrencyCode.ToString()];

                    return OtherCurrency.DovizAlis == 0 || MainCurrency.DovizAlis == 0 ? 0 : Math.Round(Amount * (MainCurrency.DovizAlis / OtherCurrency.DovizAlis), 4);
                }
            }
            catch (Exception)
            {
                throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
            }
        }

        public static double TarihBazindaDovizDegisimiHesapla(double Amount, DovizKodlari FromCurrencyCode, DovizKodlari ToCurrencyCode, DegisimTurleri exchangeType, int Year, int Month, int Day)
        {
            try
            {
                string SYear = string.Format("{0:0000}", Year);
                string SMonth = string.Format("{0:00}", Month);
                string SDay = string.Format("{0:00}", Day);

                Dictionary<string, DovizKurlari> CurrencyRates = DovizleriGetir("http://www.tcmb.gov.tr/kurlar/" + SYear + SMonth + "/" + SDay + SMonth + SYear + ".xml");

                if (!CurrencyRates.Keys.Contains(FromCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + FromCurrencyCode.ToString() + ") bulunamadı!");
                }
                else if (!CurrencyRates.Keys.Contains(ToCurrencyCode.ToString()))
                {
                    throw new Exception("Belirtilen para birimi(" + ToCurrencyCode.ToString() + ") bulunamadı!");
                }
                else
                {
                    DovizKurlari MainCurrency = CurrencyRates[FromCurrencyCode.ToString()];
                    DovizKurlari OtherCurrency = CurrencyRates[ToCurrencyCode.ToString()];

                    switch (exchangeType)
                    {
                        case DegisimTurleri.DovizAlis:
                            return OtherCurrency.DovizAlis == 0 || MainCurrency.DovizAlis == 0 ? 0 : Math.Round(Amount * (MainCurrency.DovizAlis / OtherCurrency.DovizAlis), 4);
                        case DegisimTurleri.DovizSatis:
                            return OtherCurrency.DovizSatis == 0 || MainCurrency.DovizSatis == 0 ? 0 : Math.Round(Amount * (MainCurrency.DovizSatis / OtherCurrency.DovizSatis), 4);
                        case DegisimTurleri.EfektifAlis:
                            return OtherCurrency.EfektifAlis == 0 || MainCurrency.EfektifAlis == 0 ? 0 : Math.Round(Amount * (MainCurrency.EfektifAlis / OtherCurrency.EfektifAlis), 4);
                        case DegisimTurleri.EfektifSatis:
                            return OtherCurrency.EfektifSatis == 0 || MainCurrency.EfektifSatis == 0 ? 0 : Math.Round(Amount * (MainCurrency.EfektifSatis / OtherCurrency.EfektifSatis), 4);
                        default:
                            return 0;
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Belirtilen tarih bir hafta sonu veya resmi tatil olabilir!");
            }
        }

        private static Dictionary<string, DovizKurlari> DovizleriGetir(string Link)
        {
            try
            {
                XmlTextReader rdr = new XmlTextReader(Link);
                // XmlTextReader nesnesini yaratıyoruz ve parametre olarak xml dokümanın urlsini veriyoruz
                // XmlTextReader urlsi belirtilen xml dokümanlarına hızlı ve forward-only giriş imkanı sağlar.
                XmlDocument myxml = new XmlDocument();
                // XmlDocument nesnesini yaratıyoruz.
                myxml.Load(rdr);
                // Load metodu ile xml yüklüyoruz
                XmlNode tarih = myxml.SelectSingleNode("/Tarih_Date/@Tarih");
                XmlNodeList mylist = myxml.SelectNodes("/Tarih_Date/Currency");
                XmlNodeList adi = myxml.SelectNodes("/Tarih_Date/Currency/Isim");
                XmlNodeList kod = myxml.SelectNodes("/Tarih_Date/Currency/@Kod");
                XmlNodeList doviz_alis = myxml.SelectNodes("/Tarih_Date/Currency/ForexBuying");
                XmlNodeList doviz_satis = myxml.SelectNodes("/Tarih_Date/Currency/ForexSelling");
                XmlNodeList efektif_alis = myxml.SelectNodes("/Tarih_Date/Currency/BanknoteBuying");
                XmlNodeList efektif_satis = myxml.SelectNodes("/Tarih_Date/Currency/BanknoteSelling");

                Dictionary<string, DovizKurlari> ExchangeRates = new Dictionary<string, DovizKurlari>();

                ExchangeRates.Add("TRY", new DovizKurlari("Türk Lirası", "TRY", "TRY/TRY", 1, 1, 1, 1));

                for (int i = 0; i < adi.Count; i++)
                {
                    DovizKurlari cur = new DovizKurlari(adi.Item(i).InnerText.ToString(),
                        kod.Item(i).InnerText.ToString(),
                        kod.Item(i).InnerText.ToString() + "/TRY",
                        string.IsNullOrWhiteSpace(doviz_alis.Item(i).InnerText.ToString()) ? 0 : Convert.ToDouble(doviz_alis.Item(i).InnerText.ToString().Replace(".", ",")),
                        string.IsNullOrWhiteSpace(doviz_satis.Item(i).InnerText.ToString()) ? 0 : Convert.ToDouble(doviz_satis.Item(i).InnerText.ToString().Replace(".", ",")),
                        string.IsNullOrWhiteSpace(efektif_alis.Item(i).InnerText.ToString()) ? 0 : Convert.ToDouble(efektif_alis.Item(i).InnerText.ToString().Replace(".", ",")),
                        string.IsNullOrWhiteSpace(efektif_satis.Item(i).InnerText.ToString()) ? 0 : Convert.ToDouble(efektif_satis.Item(i).InnerText.ToString().Replace(".", ","))
                        );

                    ExchangeRates.Add(kod.Item(i).InnerText.ToString(), cur);
                }

                return ExchangeRates;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
