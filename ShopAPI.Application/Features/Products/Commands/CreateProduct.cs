using MediatR;
using ShopAPI.Application.Common.Interfaces;
using ShopAPI.Domain.Entities;
using ShopAPI.Domain.Interfaces;
using System.Runtime.InteropServices;

namespace ShopAPI.Application.Features.Products.Commands;

public record CreateProductCommand(string Name, string Description, decimal Price, int Stock) : IRequest<Guid>;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _productRepository;
    private readonly IApplicationDbContext _context;

    public CreateProductHandler(IProductRepository productRepository, IApplicationDbContext context)
    {
        _productRepository = productRepository;
        _context = context;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Product.Create(request.Name, request.Description, request.Price, request.Stock);

        await _productRepository.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return product.Id;

    }
}