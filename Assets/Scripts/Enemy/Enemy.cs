using System;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public Action Die;
        
        [SerializeField] private Transform _enemyPosition;
    }
}