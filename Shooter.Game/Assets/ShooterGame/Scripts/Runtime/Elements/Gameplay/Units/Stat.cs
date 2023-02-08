using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Shooter
{
    /// <summary>
    /// Observable int class with a minimum and maximum value. Useful for stats such as health, armor, resistances etc. 
    /// </summary>
    public class Stat
    {
        public int MaxValue = 100;
        public int MinValue = 0;

        public Action<int> OnValueChanged;
        public Action OnMinValueReached;
        public int CurrentValue
        {
            get
            {
                return CurrentValueInternal;
            }
            set
            {
                if (value <= MaxValue && value >= MinValue && value != CurrentValueInternal)
                {
                    CurrentValueInternal = value;
                    OnValueChanged?.Invoke(CurrentValueInternal);
                }
                else
                {
                    Debug.LogError("Can't set stat value outside of max and min value range");
                }
            }
        }

        protected int CurrentValueInternal = 100;

        /// <summary>
        /// Changes the stat's value (adds or subtracts) by the given ammount. 
        /// </summary>
        /// <param name="value"></param>
        public void Change(int value)
        {
            CurrentValue = Mathf.Clamp(CurrentValue + value, MinValue, MaxValue);
            if (CurrentValue == MinValue) OnMinValueReached?.Invoke();
        }

        public Stat(int maxValue, int currentValue, int minValue = 0)
        {
            MaxValue = maxValue;
            CurrentValueInternal = currentValue;
            MinValue = minValue;
        }
    }
}