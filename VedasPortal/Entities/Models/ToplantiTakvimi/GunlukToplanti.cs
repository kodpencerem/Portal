using System;
using System.Collections.Generic;

namespace VedasPortal.Entities.Models.ToplantiTakvimi
{
    public class GunlukToplanti
    {
        /// <summary>
        /// Gün içinde planlanan toplantı sayısı
        /// </summary>
        public readonly int gun;

        public readonly DateTime tarih;
        readonly List<Toplanti> toplantilar;

        public GunlukToplanti(DateTime tarih, List<Toplanti> toplantilar)
        {
            this.tarih = tarih;
            gun = tarih.Day;
            this.toplantilar = toplantilar;
        }

        /// <summary>
        /// Tüm toplantı sayıları
        /// </summary>
        public int ToplantiSayisi => toplantilar.Count;

        /// <summary>
        /// Olay değişikliği yaşandığında 
        /// </summary>
        public event Action OnChangeState;

        /// <summary>
        /// Bir değişiklik çağrısı durumunda tetiklenecek metot
        /// </summary>
        public void NotifyStateChanged()
        {
            OnChangeState?.Invoke();
        }
        /// <summary>
        /// Toplanti sayılarını bir dize içerisinde tutar
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Toplanti this[int i]
        {
            get { return toplantilar[i]; }
        }
        /// <summary>
        /// Toplantilara yeni bir toplantı ekleme işlevi görür
        /// </summary>
        /// <param name="toplanti"></param>
        public void AddToplanti(Toplanti toplanti)
        {
            toplantilar.Add(toplanti);
        }

        /// <summary>
        /// Silme için seçilen toplantıyı, toplantı listesinden siler
        /// </summary>
        /// <param name="toplanti"></param>
        public void RemoveToplanti(Toplanti toplanti)
        {
            toplantilar.Remove(toplanti);
        }
    }
}
