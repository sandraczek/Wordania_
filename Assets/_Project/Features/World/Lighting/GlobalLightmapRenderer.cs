// GlobalLightmapRenderer.cs
using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using VContainer.Unity;
using Wordania.Features.World;
using Wordania.Features.World.Config;

namespace Wordania.World.Lighting
{
    public sealed class GlobalLightmapRenderer : ILightmapRenderer, IStartable, IDisposable
    {
        private Texture2D _lightmapTexture;
        private readonly WorldSettings _settings;
        private readonly byte _minLight = 10;

        private static readonly int GlobalLightmapId = Shader.PropertyToID("_GlobalLightMap");
        private static readonly int GlobalWorldSizeId = Shader.PropertyToID("_WorldSize");

        public GlobalLightmapRenderer(WorldSettings settings)
        {
            _settings = settings;
        }
        public void Start()
        {
            _lightmapTexture = new Texture2D(_settings.Width, _settings.Height, TextureFormat.R8, false, true)
            {
                filterMode = FilterMode.Bilinear,
                wrapMode = TextureWrapMode.Clamp
            };

            Shader.SetGlobalTexture(GlobalLightmapId, _lightmapTexture);
            Shader.SetGlobalVector(GlobalWorldSizeId, new Vector4(_settings.Width, _settings.Height, 0, 0));
        }

        public void ApplyLightmap(TileData[] tiles)
        {
            if (_lightmapTexture == null) return;

            NativeArray<byte> textureData = _lightmapTexture.GetRawTextureData<byte>();

            for (int i = 0; i < tiles.Length; i++)
            {
                textureData[i] = (byte)(_minLight + (255 - _minLight) * tiles[i].Light / 31);
                // textureData[i] = byte.MaxValue;
            }

            _lightmapTexture.Apply(false, false);
            Debug.Log("rendering");
        }

        public void Dispose()
        {
            if (_lightmapTexture != null)
            {
                UnityEngine.Object.Destroy(_lightmapTexture);
            }
        }
    }
}