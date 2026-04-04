using System;
using UnityEngine;
using Wordania.Core.Identifiers;
using Wordania.Features.Combat.Data;

namespace Wordania.Core.Combat
{
    public sealed class ProjectileView : MonoBehaviour
    {
        [HideInInspector] public AssetId DataId;

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position + new Vector3(-2f,-1f,0f), new(1f,1f,0f));
            Gizmos.DrawWireSphere(transform.position, 0.1f);
        }
#endif
    }
}