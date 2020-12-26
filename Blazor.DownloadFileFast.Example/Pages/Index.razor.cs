﻿using System.Text;
using System.Threading.Tasks;
using Blazor.DownloadFile.Interfaces;
using Microsoft.AspNetCore.Components;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;

namespace Blazor.DownloadFileFast.Example.Pages
{
    public partial class Index
    {
        [Inject]
        public IBlazorDownloadFileService BlazorDownloadFileService { get; set; }

        private IRandomizerString _random = RandomizerFactory.GetRandomizer(new FieldOptionsTextLipsum { Paragraphs = 10 });

        public async Task DownloadFileAsync()
        {
            var bytes = Encoding.ASCII.GetBytes(_random.Generate());

            await BlazorDownloadFileService.DownloadAsync("example.txt", bytes);
        }
    }
}