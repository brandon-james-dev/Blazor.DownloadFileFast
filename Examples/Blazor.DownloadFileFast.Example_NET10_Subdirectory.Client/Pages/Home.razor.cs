using Blazor.DownloadFileFast.Interfaces;
using Microsoft.AspNetCore.Components;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using System.Text;

namespace Blazor.DownloadFileFast.Example_NET10_Subdirectory.Client.Pages;

public partial class Home
{
    [Inject]
    public IBlazorDownloadFileService BlazorDownloadFileService { get; set; } = null!;

    private readonly IRandomizerString _random = RandomizerFactory.GetRandomizer(new FieldOptionsTextLipsum { Paragraphs = 10 });

    public async Task DownloadFileAsync()
    {
        var bytes = Encoding.ASCII.GetBytes(_random.Generate()!);

        await BlazorDownloadFileService.DownloadFileAsync("example.txt", bytes);
    }
}