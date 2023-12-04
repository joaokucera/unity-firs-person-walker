using System.Collections;
using UnityEngine;

namespace Assets.Scripts.GAME.Cannon
{
    public class CannonView : MonoBehaviour, ICannonView
    {
        [SerializeField]
        Transform shootingPoint;

        [SerializeField]
        CannonSettings cannonSettings;

        public Transform ShootingPoint => shootingPoint;
        public CannonSettings CannonSettings => cannonSettings;

        public Coroutine StartCoroutine(IEnumerable coroutine)
        {
            return StartCoroutine(coroutine.GetEnumerator());
        }
    }
}
