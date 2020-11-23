using CSharpFunctionalExtensions;
using Interview.BusinessLogic.Common;
using Interview.BusinessLogic.Products.Domain;
using Interview.BusinessLogic.Products.Infrastructure;

namespace Interview.BusinessLogic.Products.Application
{
    public sealed class CreateProductCommand : MediatR.IRequest<Result>
    {
        public CreateProductCommand(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string  Name  { get; }
        public decimal Price { get; }
    }

    internal sealed class CreateProductCommandHandler : MediatR.RequestHandler<CreateProductCommand, Result>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductRepository _repository;

        public CreateProductCommandHandler(UnitOfWork unitOfWork, ProductRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        protected override Result Handle(CreateProductCommand request)
        {
            var productResult = Product.Create(request.Name, request.Price);

            if (productResult.IsFailure) return productResult;

            _repository.Add(productResult.Value);

            _unitOfWork.Commit();

            return Result.Success();
        }
    }
}
