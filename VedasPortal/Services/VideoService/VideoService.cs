using System;
using System.Collections.Generic;
using VedasPortal.Entities.Models.Video;

namespace VedasPortal.Services.VideoService
{
    public interface IVideoService
    {
        List<Video> VideoGetir();
    }

    public class StaticVideoService : IVideoService
    {
        public List<Video> VideoGetir()
        {
            return new List<Video>
            {
                new Video
                {
                    
                    Baslik = "Blazor WebAssembly CI/CD with Azure DevOps Pipelines [Blazor Topics] | Vedaş Akademi",
                    KayitTarihi = new DateTime(2021, 12, 4)
                },
                 new Video
                {
                   
                    Baslik = "Localization and Multi Languages UI in Blazor WebAssembly [Blazor Topics] | Vedaş Akademi",
                    KayitTarihi = new DateTime(2021, 12, 3)
                },
                 new Video
                {
                    
                    Baslik = "SignalR & Real-Time in Blazor Webassembly & ASP.NET Core API [Blazor Topics] | Vedaş Akademi",
                    KayitTarihi = new DateTime(2021, 12, 2)
                },
                 new Video
                {
                    
                    Baslik = "Uploading Files in Blazor Web Assembly & ASP.NET Core Web API [Blazor Topics] | Vedaş Akademi",
                    KayitTarihi = new DateTime(2021, 12, 1)
                },
            };
        }
    }
}
