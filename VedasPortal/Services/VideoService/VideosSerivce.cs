using System;
using System.Collections.Generic;
using VedasPortal.Models.Video;

namespace VedasPortal.Services.VideoService
{
    public interface IVideoService
    {
        List<VideoDetay> VideoGetir();
    }

    public class StaticVideoService : IVideoService
    {
        public List<VideoDetay> VideoGetir()
        {
            return new List<VideoDetay>
            {
                new VideoDetay
                {
                    UrlAdres = "https://www.youtube.com/watch?v=KrStu87QRXI",
                    VideoBasligi = "Blazor WebAssembly CI/CD with Azure DevOps Pipelines [Blazor Topics] | AK Academy",
                    KayitTarihi = new DateTime(2020, 4, 1)
                },
                 new VideoDetay
                {
                    UrlAdres = "https://www.youtube.com/watch?v=KrStu87QRXI",
                    VideoBasligi = "Localization and Multi Languages UI in Blazor WebAssembly [Blazor Topics] | AK Academy",
                    KayitTarihi = new DateTime(2020, 4, 13)
                },
                 new VideoDetay
                {
                    UrlAdres = "https://www.youtube.com/watch?v=KrStu87QRXI",
                    VideoBasligi = "SignalR & Real-Time in Blazor Webassembly & ASP.NET Core API [Blazor Topics] | AK Academy",
                    KayitTarihi = new DateTime(2020, 2, 11)
                },
                 new VideoDetay
                {
                    UrlAdres = "https://www.youtube.com/watch?v=KrStu87QRXI",
                    VideoBasligi = "Uploading Files in Blazor Web Assembly & ASP.NET Core Web API [Blazor Topics] | AK Academy",
                    KayitTarihi = new DateTime(2020, 3, 23)
                },
            };
        }
    }
}
