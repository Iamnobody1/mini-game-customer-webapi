using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Yoda.Services.Customer.Data;
using Yoda.Services.Customer.Entities;
using Yoda.Services.Customer.Models;

namespace Yoda.Services.Customer.Services.Product;

public class ProductService : IProductService
{
    private readonly YodaContext _DataContext;
    private readonly IMapper _mapper;

    public ProductService(YodaContext dataContext, IMapper mapper)
    {
        _DataContext = dataContext;
        _mapper = mapper;
    }

    public ProductModel GetById(int id)
    {
        var item = _DataContext.Products?.AsNoTracking().FirstOrDefault(item => item.Id == id);
        if (item == null)
            return null;
        return new ProductModel()
        {
            Id = item.Id,
            Name = item.Name
        };
    }

    public IEnumerable<ProductModel> GetList(int start = 0, int length = 10)
    {
        return _DataContext.Products.AsNoTracking().Skip(start).Take(length).Select(Product => new ProductModel()
        {
            Id = Product.Id,
            Name = Product.Name
        });
    }

    public int Create(ProductModel product)
    {
        var item = _mapper.Map<ProductEntity>(product);
        _DataContext.Products.Add(item);
        _DataContext.SaveChanges();
        return item.Id;
    }

    public void Delete(int id)
    {
        var item = _DataContext.Products.FirstOrDefault(Product => Product.Id == id);
        _DataContext.Products.Remove(item);
        _DataContext.SaveChanges();
    }

    public void Update(int id, ProductModel product)
    {
        var item = _DataContext.Products.FirstOrDefault(product => product.Id == id);
        if (item != null)
        {
            item.Name = product.Name;
            _DataContext.SaveChanges();
        }
    }
}
