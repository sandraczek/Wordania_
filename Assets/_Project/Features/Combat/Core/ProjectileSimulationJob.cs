using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Wordania.Features.Combat.Data;

namespace Wordania.Features.Combat.Core{
    [BurstCompile(CompileSynchronously = true)]
    public struct ProjectileSimulationJob : IJobParallelFor
    {
        [ReadOnly] public float DeltaTime;
        
        // We modify this array directly in memory
        public NativeArray<ProjectileRuntimeData> Projectiles;

        public void Execute(int index)
        {
            ProjectileRuntimeData data = Projectiles[index];
            
            // Skip already dead projectiles (though our system minimizes these)
            if (!data.IsActive) return;

            // 1. Handle Lifetime
            data.RemainingLifetime -= DeltaTime;
            if (data.RemainingLifetime <= 0f)
            {
                data.IsActive = false;
                Projectiles[index] = data;
                return;
            }

            // 2. Physics & Movement
            data.PreviousPosition = data.CurrentPosition;
            
            // Apply Gravity (9.81f is just a base constant, modify as needed)
            data.Velocity.y -= 9.81f * data.GravityMultiplier * DeltaTime;
            
            // Integrate Position
            data.CurrentPosition += data.Velocity * DeltaTime;

            // 3. Write back to native array
            Projectiles[index] = data;
        }
    }
}