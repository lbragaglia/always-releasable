using Microsoft.FeatureManagement;

public abstract class FeatureFilter<TContext> : IEndpointFilter
{
    protected abstract string FeatureFlag { get; }

    private readonly IFeatureManager _featureManager;

    protected FeatureFilter(IFeatureManager featureManager)
    {
        _featureManager = featureManager;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var isEnabled = await _featureManager.IsEnabledAsync(FeatureFlag, GetFeatureContext(context));
        if (!isEnabled)
        {
            return TypedResults.NotFound();
        }

        return await next(context);
    }

    protected abstract TContext GetFeatureContext(EndpointFilterInvocationContext context);
}