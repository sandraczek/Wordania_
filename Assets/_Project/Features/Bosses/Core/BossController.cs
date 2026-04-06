using UnityEngine;
using Wordania.Features.Bosses.Data;

namespace Wordania.Features.Bosses.Core
{
    public interface IBossController
    {
        void Initialize(BossTemplate template);
    }
    public abstract class BossController : MonoBehaviour, IBossController
    {
        public abstract void Initialize(BossTemplate template);
    }
    public abstract class BossController<TTemplate> : BossController
        where TTemplate : BossTemplate
    {
        protected TTemplate _template;
        public override void Initialize(BossTemplate template)
        {
            if (template is TTemplate typedTemplate)
            {
                OnInitialize(typedTemplate);
                _template = typedTemplate;
            }
            else
            {
                Debug.LogError($"[BossSystem] Template mismatch on {gameObject.name}. " +
                                      $"Expected {typeof(TTemplate).Name}, got {template.GetType().Name}");
            }
        }

        protected abstract void OnInitialize(TTemplate template);
        public abstract void OnDeathSequenceComplete();
    }
}