using MediatR;
using MessAbout.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MessAbout.Api.Products
{
    public class CreateProduct
    {
        public sealed class Command : IRequest<Guid>
        {
            public string Name { get; set; } = string.Empty;
        }

        internal sealed class Handler : IRequestHandler<Command, Guid>
        {
            private readonly ApplicationDbContext _dbContext;
            public Handler(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = new Product
                {
                    Name = request.Name
                };

                _dbContext.Products.Add(product);

                await _dbContext.SaveChangesAsync();

                return product.Id;
            }
        }
    }

    
}
