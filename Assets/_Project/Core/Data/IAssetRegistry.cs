
using Wordania.Core.Identifiers;

namespace Wordania.Core.Data
{
    public interface IAssetRegistry<T> where T: DataAsset
    {
        T Get(AssetId id);
    }
}