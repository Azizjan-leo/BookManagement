using AutoMapper;
using BookManagement.DAL.Repositories;
using BookManagement.Model;
using BookManagement.Model.Entities;

namespace BookManagement.BLL.Services.Interfaces;

public interface IAuthorService
{
    public Task<OperationResult> AddAuthor(AuthorModel author);
}
