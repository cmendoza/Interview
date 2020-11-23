using CSharpFunctionalExtensions;
using Interview.BusinessLogic.Common;
using Interview.BusinessLogic.Customers.Domain;
using Interview.BusinessLogic.Customers.Infrastructure;

namespace Interview.BusinessLogic.Customers.Application
{
    public sealed class UpdateCustomerCommand : MediatR.IRequest<Result>
    {
        public UpdateCustomerCommand(long id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public long   Id        { get; }
        public string FirstName { get; }
        public string LastName  { get; }
    }

    internal sealed class UpdateCustomerCommandHandler : MediatR.RequestHandler<UpdateCustomerCommand, Result>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly CustomerRepository _repository;

        public UpdateCustomerCommandHandler(UnitOfWork unitOfWork, CustomerRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        protected override Result Handle(UpdateCustomerCommand request)
        {
            var customer = _repository.Get(request.Id);

            if (customer is null) return Result.Failure($"CustomerId doesn't exists: {request.Id}");

            customer.UpdateProfileInfo(request.FirstName, request.LastName);

            _unitOfWork.Commit();

            return Result.Success();
        }
    }
}
