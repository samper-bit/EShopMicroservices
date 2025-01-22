﻿namespace Basket.API.Basket.StoreBasket;

public record class StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

public record class StoreBasketResult(string UserName);

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null!");
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required");
    }
}

public class StoreBasketCommandHandler : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        ShoppingCart cart = command.Cart;
        // TODO: store basket in database
        // TODO: update cache

        return new StoreBasketResult("swn");
    }
}
