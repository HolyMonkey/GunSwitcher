using Enemies;
using Movement;
using RootMotion.FinalIK;
using UnityEditor.SearchService;
using UnityEngine;

namespace Weapon
{
    public class Pistol : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _muzzleFlare;
        [SerializeField] private int _damage;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _shootPosition;

        [SerializeField] private AimController _aimController;
        [SerializeField] private TargetsFinder _finder;

        [SerializeField] private Enemy _currentTarget;
        
        // private 

    }
}