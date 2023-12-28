using BoDi;
using MessAbout.Specs.Hosting;

namespace MessAbout.Specs.Hooks
{
    [Binding]
    public sealed class MessAboutHooks
    {
        private readonly IObjectContainer _objectContainer;

        public MessAboutHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            var factory = new SpecsWebAppFactory();
            await factory.InitializeAsync();
            _objectContainer.RegisterInstanceAs(factory);
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            var factory = _objectContainer.Resolve<SpecsWebAppFactory>();
            await factory.DisposeAsync();
        }
    }
}
