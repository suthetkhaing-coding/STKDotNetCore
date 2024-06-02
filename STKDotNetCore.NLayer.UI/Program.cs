// See https://aka.ms/new-console-template for more information
using STKDotNetCore.NLayer.BusinessLogic.Services;
using STKDotNetCore.NLayer.DataAccess.Models;

Console.WriteLine("Hello, World!");

BL_Blog bL_Blog = new BL_Blog();
BlogModel blogModel = new BlogModel
{
    BlogTitle = "Title NLayer",
    BlogAuthor = "Author NLayer",
    BlogContent = "Content NLayer"
};

int result = bL_Blog.CreateBlog("Create", blogModel);

string message = result > 0 ? "Saving Successful." : "Saving Failed.";
Console.WriteLine(message);
