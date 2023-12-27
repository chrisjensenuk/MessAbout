﻿using MediatR;
using MessAbout.Api.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace MessAbout.Api.IntegrationTests
{
    public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>, IDisposable
    {
        private readonly IServiceScope _scope;
        protected readonly ISender Sender;
        protected readonly ApplicationDbContext DbContext;

        protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
        {
            _scope = factory.Services.CreateScope();

            Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
            DbContext = _scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        }

        public void Dispose()
        {
            _scope?.Dispose();
            DbContext?.Dispose();
        }
    }
}
