using CSharpFunctionalExtensions;
using Interview.BusinessLogic.Common;
using Interview.BusinessLogic.Customers.Infrastructure;
using Interview.BusinessLogic.Orders.Domain;
using Interview.BusinessLogic.Orders.Infrastructure;

namespace Interview.BusinessLogic.Orders.Application
{
    public sealed class CreateOrderCommand : MediatR.IRequest<Result<long>>
    {
        public CreateOrderCommand(long customerId) => CustomerId = customerId;

        public long CustomerId { get; }
    }

    internal sealed class CreateOrderCommandHandler : MediatR.RequestHandler<CreateOrderCommand, Result<long>>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly CustomerRepository _customerRepository;
        private readonly OrderRepository _orderRepository;

        public CreateOrderCommandHandler(UnitOfWork unitOfWork,
                                         CustomerRepository customerRepository,
                                         OrderRepository orderRepository)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        protected override Result<long> Handle(CreateOrderCommand request)
        {
            var customer = _customerRepository.Get(request.CustomerId);
            if (customer is null) return Result.Failure<long>($"CustomerId doesn't exist: {request.CustomerId}");

            var order = new Order(customer);

            _orderRepository.Add(order);

            _unitOfWork.Commit();

            return Result.Success(order.Id);
        }
    }
}
