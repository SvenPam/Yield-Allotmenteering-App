using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Yield.Core.Providers;
using Yield.Infrastructure.Repositories.Interfaces;

namespace Yield.Infrastructure.Repositories
{
    public class CosmosDbBaseRepository<T> : IRepository<T>
        where T : class
    {
        private readonly IDocumentClient documentClient;
        private readonly IConfigProvider configProvider;
        private readonly string collectionId;

        public CosmosDbBaseRepository(IDocumentClient documentClient, IConfigProvider configProvider)
        {
            this.documentClient = documentClient;
            this.configProvider = configProvider;
            this.collectionId = typeof(T).Name;
        }

        public async Task<T> Get(string id, string partitionKey = null)
        {
            RequestOptions requestOptions = null;

            if (!string.IsNullOrEmpty(partitionKey))
            {
                requestOptions = new RequestOptions
                {
                    PartitionKey = new PartitionKey(id)
                };
            }
            try
            {
                var response =
                    await
                        this.documentClient.ReadDocumentAsync(
                            UriFactory.CreateDocumentUri(this.configProvider.CosmosDbName, this.collectionId, id),
                            requestOptions);

                return (T)(dynamic)response.Resource;
            }
            catch (DocumentClientException ex)
            { 
                if(ex.StatusCode == HttpStatusCode.NotFound) {
                    return null;
                } else throw;
            }
        }

        public async Task<IEnumerable<T>> GetItems(int maxCount = 200, int page = 0)
        {
            var query =
                this.documentClient.CreateDocumentQuery<T>(
                    UriFactory.CreateDocumentCollectionUri(this.configProvider.CosmosDbName, this.collectionId),
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
                    UriFactory.CreateDocumentCollectionUri(this.configProvider.CosmosDbName, this.collectionId),
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
                        UriFactory.CreateDocumentCollectionUri(this.configProvider.CosmosDbName, this.collectionId),
                        item);
        }

        public async Task<Document> Update(string id, T item)
        {
            return
                await
                    this.documentClient.ReplaceDocumentAsync(
                        UriFactory.CreateDocumentUri(this.configProvider.CosmosDbName, this.collectionId, id),
                        item);
        }

        public async Task Delete(string id)
        {
            await
                this.documentClient.DeleteDocumentAsync(
                    UriFactory.CreateDocumentUri(this.configProvider.CosmosDbName, this.collectionId, id));
        }
    }
}