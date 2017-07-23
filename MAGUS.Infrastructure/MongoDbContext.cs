using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAGUS.Infrastructure.Interfaces;
using System.Configuration;

namespace MAGUS.Infrastructure
{
    public class MongoDbContext : IMongoDbContext, IDisposable
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        private bool _disposed = false;

        public MongoDbContext()
        {
            string connectionString = ConfigurationManager.AppSettings.Get("MONGOLAB_URI");

            var mongoUrl = new MongoUrl(connectionString);
            _client = new MongoDB.Driver.MongoClient(mongoUrl);
            _database = _client.GetDatabase(mongoUrl.DatabaseName);
        }

        /// <summary>
        /// Gets TEntityTpye documents from TEntity collections
        /// </summary>
        /// <typeparam name="TEntity">TEntity Collection type</typeparam>
        /// <typeparam name="TEntityType">Document type in TEntity Collection </typeparam>
        /// <remarks>(See BsonKnownTypes, BsonDiscriminator)</remarks>
        /// <returns></returns>
        public IMongoCollection<TEntityType> Collection<TEntity, TEntityType>()
        {
            return _database.GetCollection<TEntityType>(typeof(TEntity).Name.ToLower() + "s");
        }

        public IMongoCollection<TEntity> Collection<TEntity>()
        {
            return _database.GetCollection<TEntity>(typeof(TEntity).Name.ToLower() + "s");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
