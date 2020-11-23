using CSharpFunctionalExtensions;
using Interview.BusinessLogic.Common;
using Interview.BusinessLogic.Products.Infrastructure;

namespace Interview.BusinessLogic.Products.Application
{
    public sealed class UpdateProductCommand : MediatR.IRequest<Result>
    {
        public UpdateProductCommand(long id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public long    Id    { get; }
        public string  Name  { get; }
        public decimal Price { get; }
    }

    internal sealed class UpdateProductCommandHandler : MediatR.RequestHandler<UpdateProductCommand, Result>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductRepository _repository;

        public UpdateProductCommandHandler(UnitOfWork unitOfWork, ProductRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        protected override Result Handle(UpdateProductCommand request)
        {
            var product = _repository.Get(request.Id);

            if (product is null) return Result.Failure($"ProductId doesn't exist: {request.Id}");

            product.UpdateInfo(request.Name, request.Price);

            _unitOfWork.Commit();

            return Result.Success();
        }
    }
}
