using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace Shooter.UI
{
    public class UIHealthDisplay : MonoBehaviour
    {
        protected Unit CurrentUnit { get; set; } = null;

        [SerializeField]
        protected Image HealthBarFill;

        protected const float BAR_ANIMATION_DURATION = 0.5f;

        public void Awake()
        {
            if (HealthBarFill == null) Debug.LogError("UIHealthDisplay: HealthBarFill is not assigned!");
        }
        public void ShowUnit(Unit unit)
        {
            if (unit != CurrentUnit)
            {
                ClearUnit();
                CurrentUnit = unit;
                unit.Health.OnValueChanged += UpdateHealthbarFill;
            }
            UpdateHealthbarFill(CurrentUnit.Health.CurrentValue);
        }

        public void ClearUnit()
        {
            if (CurrentUnit != null)
            {
                CurrentUnit.Health.OnValueChanged -= UpdateHealthbarFill;
                CurrentUnit = null;
            }
        }

        protected void UpdateHealthbarFill(int currentValue)
        {
            if (CurrentUnit != null)
            {
                HealthBarFill.DOKill();
                HealthBarFill.DOFillAmount(currentValue / CurrentUnit.Health.MaxValue, BAR_ANIMATION_DURATION);
            }
        }
    }
}