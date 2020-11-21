using CSharpFunctionalExtensions;
using Interview.BusinessLogic.Common;
using Interview.BusinessLogic.Customers.Domain;
using Interview.BusinessLogic.Customers.Infrastructure;

namespace Interview.BusinessLogic.Customers.Application
{
    public sealed class CreateCustomerCommand : MediatR.IRequest<Result>
    {
        public CreateCustomerCommand(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
    }

    internal sealed class CreateCustomerCommandHandler : MediatR.RequestHandler<CreateCustomerCommand, Result>
    {
        private readonly OrdersContext _context;
        private readonly CustomerRepository _repository;

        public CreateCustomerCommandHandler(OrdersContext context, CustomerRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        protected override Result Handle(CreateCustomerCommand request)
        {
            if (request.FirstName == null || string.IsNullOrWhiteSpace(request.FirstName))
                return Result.Failure("First name is required.");

            if (request.LastName == null || string.IsNullOrWhiteSpace(request.LastName))
                return Result.Failure("First name is required.");

            var customer = new Customer(request.FirstName, request.LastName);

            _repository.Add(customer);

            _context.SaveChanges();

            return Result.Success();
        }
    }
}
