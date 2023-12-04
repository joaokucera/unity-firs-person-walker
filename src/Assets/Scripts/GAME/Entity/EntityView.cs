using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.GAME.Entity
{
    [RequireComponent(typeof(Collider))]
    public class EntityView : MonoBehaviour, IEntityView
    {
        [SerializeField]
        EntitySettings entitySettings;

        public EntitySettings EntitySettings => entitySettings;
        public Action<Collider> OnTriggerEnterCallback { get; set; }

        void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterCallback?.Invoke(other);
        }

        public Coroutine StartCoroutine(IEnumerable coroutine)
        {
            return StartCoroutine(coroutine.GetEnumerator());
        }

        public void CancelCoroutine(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }
    }
}
