﻿/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace VideoDetails
{
    class MostPopulorVideos
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Youtube video details");

                var service = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyB2xtEZ1PWhmbPAPbyC6LtapaubOGdWhcI"
            });

            var request = service.Videos.List("snippet");
            request.Chart = VideosResource.ListRequest.ChartEnum.MostPopular;
            request.RegionCode = "in";
            request.MaxResults = 10;

            var results = await request.ExecuteAsync();

            if (results.Items.Count <= 0) Console.WriteLine("No videos");

            foreach (var video in results.Items)
            {
                Console.WriteLine($"{video.Snippet.Title} https://www.youtube.com/watch?v={video.Id}");
            }                                                                                   


        }
    }
}
*/