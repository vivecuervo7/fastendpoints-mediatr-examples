using FastEndpoints;

namespace Example_FastEndpoints.Api.Features.CommandBusExample;

public class DoubleValueCommand : ICommand<int>
{
    public int Value { get; set; }
}
