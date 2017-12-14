using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Festispec.Domain
{
    public partial class Question
    {
        [NotMapped]
        public bool IsDeleted { get; set; } = false;

        public string MetadataParameter1
        {
            get { return DeserializedMetadata[0]; }
            set
            {
                var deserializedMetadata = DeserializedMetadata;
                deserializedMetadata[0] = value;
                SerializeMetadata(deserializedMetadata);
            }
        }

        public string MetadataParameter2
        {
            get { return DeserializedMetadata[1]; }
            set
            {
                var deserializedMetadata = DeserializedMetadata;
                deserializedMetadata[1] = value;
                SerializeMetadata(deserializedMetadata);
            }
        }

        private string[] DeserializedMetadata =>
            Metadata == null ? new string[2] : JsonConvert.DeserializeObject<string[]>(Metadata);

        private void SerializeMetadata(string[] deserializedMetadata)
        {
            Metadata = JsonConvert.SerializeObject(deserializedMetadata);
        }
    }
}