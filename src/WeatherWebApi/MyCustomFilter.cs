using Microsoft.FeatureManagement;

[FilterAlias(nameof(MyCustomFilter))]
public class MyCustomFilter : IContextualFeatureFilter<MyCustomFilterContext>
{
    public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context, MyCustomFilterContext appContext)
    {
        var settings = context.Parameters.Get<MyCustomFilterSettings>()
                       ?? throw new ArgumentNullException(nameof(MyCustomFilterSettings));
        return Task.FromResult(settings.LuckyNumber == appContext.InputNumber);
    }
}

public class MyCustomFilterSettings
{
    public int LuckyNumber { get; set; }
}

public class MyCustomFilterContext
{
    public int InputNumber { get; set; }
}