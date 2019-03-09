namespace Yield.Core.Providers
{
    public interface IConfigProvider {
        string CosmosDbName { get; }

        string CosmosDbConnectionString { get; }
    }
}