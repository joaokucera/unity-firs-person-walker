using System.Collections;
using UnityEngine;

namespace Assets.Scripts.GAME.Cannon
{
    public interface ICannonView
    {
        Transform ShootingPoint { get; }
        CannonSettings CannonSettings { get; }
        Coroutine StartCoroutine(IEnumerable coroutine);
    }
}
