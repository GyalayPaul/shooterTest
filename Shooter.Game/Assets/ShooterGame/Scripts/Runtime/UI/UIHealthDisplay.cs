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
        protected UnitController CurrentUnit { get; set; } = null;

        [SerializeField]
        protected Image HealthBarFill;

        protected const float BAR_ANIMATION_DURATION = 0.5f;

        public void Awake()
        {
            if (HealthBarFill == null) Debug.LogError("UIHealthDisplay: HealthBarFill is not assigned!");
        }
        public void ShowUnit(UnitController unit)
        {
            if (unit != CurrentUnit)
            {
                ClearUnit();
                CurrentUnit = unit;
                unit.Model.Health.OnValueChanged += UpdateHealthbarFill;
            }
            UpdateHealthbarFill(CurrentUnit.Model.Health.CurrentValue);
        }

        public void ClearUnit()
        {
            if (CurrentUnit != null)
            {
                CurrentUnit.Model.Health.OnValueChanged -= UpdateHealthbarFill;
                CurrentUnit = null;
            }
        }

        protected void UpdateHealthbarFill(int currentValue)
        {
            if (CurrentUnit != null)
            {
                HealthBarFill.DOKill();
                HealthBarFill.DOFillAmount(currentValue / CurrentUnit.Model.Health.MaxValue, BAR_ANIMATION_DURATION);
            }
        }
    }
}