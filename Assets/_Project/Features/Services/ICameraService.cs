using UnityEngine;

namespace Wordania.Features.Services
{
    using UnityEngine;
    public interface ICameraService
    {
        void FollowTarget(Transform target);
        void Warp(Vector3 delta);
    }
}
