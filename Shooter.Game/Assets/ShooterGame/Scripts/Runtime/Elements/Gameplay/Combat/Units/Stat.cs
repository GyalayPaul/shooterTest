using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Shooter
{
    public class Stat
    {
        public int MaxValue = 100;
        public int MinValue = 0;
        public int CurrentValue
        {
            get
            {
                return CurrentValueInternal;
            }
            set
            {
                if (value < MaxValue && value > MinValue && value != CurrentValueInternal)
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

        protected int CurrentValueInternal= 100;

        /// <summary>
        /// Changes the stat's value (adds or subtracts) by the given ammount. 
        /// </summary>
        /// <param name="value"></param>
        public void Change(int value)
        {
            CurrentValue = Mathf.Clamp(CurrentValue + value, MinValue, MaxValue);
        }

        public Action<int> OnValueChanged;

    }
}