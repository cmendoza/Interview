using CSharpFunctionalExtensions;
using Interview.BusinessLogic.Common;
using Interview.BusinessLogic.Orders.Infrastructure;
using Interview.BusinessLogic.Products.Infrastructure;

namespace Interview.BusinessLogic.Orders.Application
{
    public sealed class AddItemToCartCommand : MediatR.IRequest<Result>
    {
        public AddItemToCartCommand(long orderId, long productId, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }

        public long OrderId   { get; }
        public long ProductId { get; }
        public int  Quantity  { get; }
    }

    internal sealed class AddItemToCartCommandHandler : MediatR.RequestHandler<AddItemToCartCommand, Result>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly OrderRepository _orderRepository;
        private readonly ProductRepository _productRepository;

        public AddItemToCartCommandHandler(UnitOfWork unitOfWork,
                                           OrderRepository orderRepository,
                                           ProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        protected override Result Handle(AddItemToCartCommand request)
        {
            if (request.Quantity <= 0) return Result.Failure("Quantity must be greater than zero.");

            var order = _orderRepository.Get(request.OrderId);
            if (order is null) return Result.Failure($"OrderId doesn't exist: {request.OrderId}");

            var product = _productRepository.Get(request.ProductId);
            if (product is null) return Result.Failure($"ProductId doesn't exist: {request.ProductId}");

            order.AddOrUpdateItem(product, request.Quantity);

            _unitOfWork.Commit();

            return Result.Success();
        }
    }
}
