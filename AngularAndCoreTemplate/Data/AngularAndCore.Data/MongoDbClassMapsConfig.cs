using AngularAndCore.Data.Models;
using AngularAndCore.Data.Models.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace AngularAndCore.Data
{
  public class MongoDbClassMapsConfig
  {
    private MongoDbClassMapsConfig() { }

    public static void RegisterAllMaps()
    {
      RegisterClassMapBaseModel();
      RegisterClassMapUser();
    }

    private static void RegisterClassMapBaseModel()
    {
      BsonClassMap.RegisterClassMap<BaseModel>(cm =>
      {
        cm.AutoMap();
        cm.MapMember(c => c.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
        cm.IdMemberMap.SetSerializer(new StringSerializer(BsonType.ObjectId));
      });
    }

    private static void RegisterClassMapUser()
    {
      BsonClassMap.RegisterClassMap<User>(cm =>
      {
        cm.AutoMap();
        cm.MapMember(c => c.Username).SetIsRequired(true);
        cm.MapMember(c => c.Password).SetIsRequired(true);
      });
    }
  }
}