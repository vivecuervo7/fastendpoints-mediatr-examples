using FastEndpoints;

namespace Example_FastEndpoints_RpcServer.Contracts;

public class AddNumbersCommand : ICommand<AddNumbersCommandResult>
{
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }
}
