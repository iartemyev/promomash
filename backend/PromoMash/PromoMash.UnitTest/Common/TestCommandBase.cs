using System;
using PromoMash.Persistence;

namespace PromoMash.UnitTest.Common;

public abstract class TestCommandBase : IDisposable
{
    protected readonly PromoMashDbContext Context;

    public TestCommandBase()
    {
        Context = PromoMashContextFactory.Create();
    }

    public void Dispose()
    {
        PromoMashContextFactory.Destroy(Context);
    }
}