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
        public string LastName  { get; }
    }

    internal sealed class CreateCustomerCommandHandler : MediatR.RequestHandler<CreateCustomerCommand, Result>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly CustomerRepository _repository;

        public CreateCustomerCommandHandler(UnitOfWork unitOfWork, CustomerRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        protected override Result Handle(CreateCustomerCommand request)
        {
            var customerResult = Customer.Create(request.FirstName, request.LastName);

            if (customerResult.IsFailure) return customerResult;

            _repository.Add(customerResult.Value);

            _unitOfWork.Commit();

            return Result.Success();
        }
    }
}
