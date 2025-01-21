﻿namespace Catalog.API.Products.GetProductById;

public record class GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;

public record class GetProductByIdResult(Product Product);

internal class GetProductByIdQueryHandler
    (IDocumentSession session)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException(query.Id);
        }

        return new GetProductByIdResult(product);
    }
}
