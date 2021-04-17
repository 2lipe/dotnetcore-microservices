using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Api.Entities
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        private DateTime? _createdAt;

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? CreatedAt
        {
            get => _createdAt ?? DateTime.UtcNow;
            set => _createdAt = value;
        }
        
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? UpdatedAt { get; set; }
    }
}