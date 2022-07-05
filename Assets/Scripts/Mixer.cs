using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NTR.Utensils
{
    public class Mixer : MonoBehaviour, IUtensil
    {
        public void UseUtensil()
        {
            Debug.Log("You are using the mixer!");
        }
    }
}