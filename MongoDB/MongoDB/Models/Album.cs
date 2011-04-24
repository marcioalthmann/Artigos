using Norm;
using Norm.BSON.DbTypes;

namespace MongoDB.Models
{
    public class Album
    {
        [MongoIdentifier]
        public ObjectId IdAlbum { get; set; }

        public DbReference<EstiloMusical> EstiloMusical { get; set; }
        public string Nome { get; set; }
    }
}