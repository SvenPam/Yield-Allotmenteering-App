using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using Yield.Core.Config;
using Yield.Infrastructure.Repositories.Interfaces;

namespace Yield.Infrastructure.Repositories
{
    public class CosmosDbBaseRepository<T> : IRepository<T>
        where T : class
    {
        private readonly IDocumentClient documentClient;
        private readonly IOptions<CosmosDbConfig> cosmosDbConfig;
        private readonly string collectionId;

        public CosmosDbBaseRepository(IDocumentClient documentClient, IOptions<CosmosDbConfig> cosmosDbConfig)
        {
            this.documentClient = documentClient;
            this.cosmosDbConfig = cosmosDbConfig;
            this.collectionId = typeof(T).Name;

            if (typeof(T).IsAbstract)
            {
                this.collectionId = this.collectionId.TrimStart('I');
            }
        }

        public async Task<T> Get(string id)
        {

            var requestOptions = new RequestOptions
            {
                PartitionKey = new PartitionKey()
            };

            try
            {
                var response =
                    await
                        this.documentClient.ReadDocumentAsync(
                            UriFactory.CreateDocumentUri(this.cosmosDbConfig.Value.Name, this.collectionId, id),
                            requestOptions);

                return (T)(dynamic)response.Resource;
            }
            catch (DocumentClientException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<IEnumerable<T>> GetItems(int maxCount = 200, int page = 0)
        {
            var query =
                this.documentClient.CreateDocumentQuery<T>(
                    UriFactory.CreateDocumentCollectionUri(this.cosmosDbConfig.Value.Name, this.collectionId),
                    new FeedOptions { MaxItemCount = maxCount }).AsDocumentQuery();

            var results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results;
        }

        public async Task<IEnumerable<T>> GetItems(Expression<Func<T, bool>> predicate, bool crossPartitionQuery, int maxCount = 200, int page = 0)
        {
            var query = this.documentClient.CreateDocumentQuery<T>(
                    UriFactory.CreateDocumentCollectionUri(this.cosmosDbConfig.Value.Name, this.collectionId),
                    new FeedOptions
                    {
                        MaxItemCount = maxCount,
                        EnableCrossPartitionQuery = crossPartitionQuery
                    })
                .Where(predicate)
                .AsDocumentQuery();

            var results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results;
        }

        public async Task<Document> Create(T item)
        {
            return
                await
                    this.documentClient.CreateDocumentAsync(
                        UriFactory.CreateDocumentCollectionUri(this.cosmosDbConfig.Value.Name, this.collectionId),
                        item);
        }

        public async Task<Document> Update(string id, T item)
        {
            return
                await
                    this.documentClient.ReplaceDocumentAsync(
                        UriFactory.CreateDocumentUri(this.cosmosDbConfig.Value.Name, this.collectionId, id),
                        item);
        }

        public async Task Delete(string id)
        {
            await
                this.documentClient.DeleteDocumentAsync(
                    UriFactory.CreateDocumentUri(this.cosmosDbConfig.Value.Name, this.collectionId, id));
        }
    }
}