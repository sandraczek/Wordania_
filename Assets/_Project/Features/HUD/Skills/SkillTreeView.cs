using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Wordania.Features.HUD.Skills
{
    public class SkillTreeView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _skillPointsText;
        [SerializeField] private Transform _nodesContainer;

        private SkillNodeView[] _nodeViews;

        public IReadOnlyCollection<SkillNodeView> NodeViews => _nodeViews;

        private void Awake()
        {
            _nodeViews = _nodesContainer.GetComponentsInChildren<SkillNodeView>(includeInactive: true);
        }

        public void UpdateSkillPoints(int currentPoints)
        {
            if (_skillPointsText != null)
            {
                _skillPointsText.text = $"skill points: {currentPoints}";
            }
        }

        public void SetVisibility(bool isVisible)
        {
            gameObject.SetActive(isVisible);
        }
    }
}