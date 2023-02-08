using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    /// <summary>
    /// Generic View class for units meant to handle things such as animations and audio. 
    /// </summary>
    public class UnitView : MonoBehaviour
    {
        public AudioSource AudioSource;
        public UnitController Controller;
        public Animator Animator;

    }
}