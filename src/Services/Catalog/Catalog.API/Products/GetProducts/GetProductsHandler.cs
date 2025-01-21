﻿namespace Catalog.API.Products.GetProducts;

public record class GetProductsQuery() : IQuery<GetProductsResult>;

public record class GetProductsResult(IEnumerable<Product> Products);

internal class GetProductsQueryHandler 
    (IDocumentSession session)
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>().ToListAsync(cancellationToken);

        return new GetProductsResult(products);
    }
}
