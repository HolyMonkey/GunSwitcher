using System;
using UnityEngine;

namespace Movement
{
    public class ClampCharacterRotation : MonoBehaviour
    {
        [SerializeField] private Transform _character;

        private void Update()
        {
            ClampRotation();
        }

        private void ClampRotation()
        {
            _character.localEulerAngles = new Vector3(0, 180, 0);
        }
    }
}