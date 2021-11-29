using UnityEngine;

namespace Weapon
{
    public class WeaponChangerItem : MonoBehaviour
    {
        [SerializeField] private Weapons _id;

        public Weapons Id => _id;
    }
}