using Refit;
using STKDotNetCore.ConsoleAppRefitExamples;

//var service = RestService.For<IBlogApi>("https://localhost:7120");
//var lst = await service.GetBlogs();
//foreach (var item in lst)
//{
//Console.WriteLine($"Id => {item.BlogId}");
//Console.WriteLine($"Title => {item.BlogTitle}");
//Console.WriteLine($"Author => {item.BlogAuthor}");
//Console.WriteLine($"Content => {item.BlogContent}");
//Console.WriteLine("------------------------");
//}

RefitExample refitExample = new RefitExample();
await refitExample.RunAsync();