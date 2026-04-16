using UnityEngine;
using Wordania.Core.Identifiers;

namespace Wordania.Core.Data
{
    public abstract class DataAsset : ScriptableObject
    {
        [SerializeField] private AssetId _id;
        public AssetId Id => _id;

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            _id.EditorInitialize();
        }
#endif
    }
}