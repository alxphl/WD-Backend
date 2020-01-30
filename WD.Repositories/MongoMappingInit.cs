using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using WD.Entities;

namespace WD.Repositories
{
    public static class MongoMappingInit
    {
        public static void RegisterBsonClassMaps()
        {
            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(x => x.Id)
                    .SetIdGenerator(new GuidGenerator())
                    .SetSerializer(new GuidSerializer(BsonType.String));

                cm.MapProperty(p => p.Tear).SetSerializer(new EnumSerializer<TearEnum>(BsonType.String));
            });

        }
    }
}
