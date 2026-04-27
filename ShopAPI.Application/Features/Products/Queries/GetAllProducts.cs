using MediatR;
using ShopAPI.Domain.Interfaces;

namespace ShopAPI.Application.Features.Products.Queries;

public record GetAllProductsQuery() : IRequest<IEnumerable<GetAllProductsResponse>>;

public record GetAllProductsResponse(Guid Id, string Name, string Description, decimal Price, int Stock);

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<GetAllProductsResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<GetAllProductsResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync(cancellationToken);

        return products.Select(p => new GetAllProductsResponse(
            p.Id,
            p.Name,
            p.Description,
            p.Price,
            p.Stock
        ));
    }
}