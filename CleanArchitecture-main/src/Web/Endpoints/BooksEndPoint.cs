using LibraryManagement.Application.Common.Models;
using LibraryManagement.Application.LibraryManagements;
using LibraryManagement.Application.LibraryManagements.Queries;

namespace LibraryManagement.Web.Endpoints;

public class BooksEndPoint : EndpointGroupBase
{
    public BooksEndPoint()
    {
        
    }

    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateAuthor)
            .MapPut(UpdateAuthor, "{id}")
            //.MapDelete(DeleteAuthor, "{id}")
            .MapGet(GetAuthorItem, "getAuthorItem")
            .MapGet(GetCategories, "getCategories")
            .MapGet(GetBooks, "getBooks")
            .MapGet(GetAuthorItemStor, "getAuthorItemStor");
    }

    public async Task<Result<string>> CreateAuthor(ISender sender, CreateBookAndAuthorCommand command)
    {
        var author = await sender.Send(command);

        if (!author.Succeeded)
        {
            return Result<string>.Failure(author.Errors, null);
        }

        return Result<string>.Success(author.Value ?? string.Empty);
    }

    public async Task<Result<string>> UpdateAuthor(ISender sender, Guid id, UpdateBookAndAuthorCommand command)
    {
        if (id != command.Id)
            return (Result<string>)Results.BadRequest();
       
        var result = await sender.Send(command);
        
        if (result.Value == null || !result.Succeeded)
        {
            return Result<string>.Failure(result.Errors, null);
        }
        
        return Result<string>.Success(result.Value);
    }

    public async Task<Result<string>> DeleteAuthor(ISender sender, Guid id, DeleteBookAndAuthorCommand command)
    {
        if (id != command.Id)
            return (Result<string>)Results.BadRequest();
        
        var result = await sender.Send(command);

        if (result.Value == null || !result.Succeeded)
        {
            return Result<string>.Failure(result.Errors, null);
        }

        return Result<string>.Success(result.Value);
    }

    public async Task<GetBookAndAuthorByIdFrameWorkViewModel> GetAuthorItem(ISender sender, [AsParameters] GetBookAndAuthorByIdFrameWorkQuery bookAndAuthor)
    {
        return await sender.Send(new GetBookAndAuthorByIdFrameWorkQuery() { Id = bookAndAuthor.Id });
    }

    public async Task<List<string>> GetCategories(ISender sender, [AsParameters] GetAllCategoriesQuery bookAndAuthor)
    {
        return await sender.Send(new GetAllCategoriesQuery() { Id = bookAndAuthor.Id });
    }

    public async Task<List<GetBookAndAuthorByIdStoredQueryViewModel>> GetAuthorItemStor(ISender sender, [AsParameters] GetBookAndAuthorByIdStoredQuery bookAndAuthor)
    {
        return await sender.Send(new GetBookAndAuthorByIdStoredQuery() { Id = bookAndAuthor.Id });
    }

    public async Task<List<GetBooksByCategorieQueryViewModel>> GetBooks(ISender sender, [AsParameters] GetBooksByCategorieQuery categories)
    {
        return await sender.Send(new GetBooksByCategorieQuery() { Categorie = categories.Categorie });
    }
}
