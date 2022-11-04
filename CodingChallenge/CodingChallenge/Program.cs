using CodingChallenge.Services;
using CodingChallenge.Services.ContentsInspectors;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection sc = new();
sc.AddSingleton<IClueFinder, ClueFinder>();
sc.AddSingleton<IClueDownloader, ClueDownloader>();
sc.AddSingleton<IValueFinder, ValueFinder>();
sc.AddSingleton<IClueTraverser, ClueTraverser>();
sc.AddSingleton<IContentInspectorService, DoubloonInspectorService>();
sc.AddSingleton<IContentInspectorService, HolyGrailInspectorService>();
sc.AddSingleton<IContentInspectorService, SpiderInspectorService>();
sc.AddSingleton<IContentInspectorService, BootInspectorService>();
sc.AddSingleton<IHuntService, HuntService>();
var huntService = sc.BuildServiceProvider().GetService<IHuntService>();
await huntService.Hunt("https://e0f5e8673c64491d8cce34f5.z35.web.core.windows.net/treasure.json");
