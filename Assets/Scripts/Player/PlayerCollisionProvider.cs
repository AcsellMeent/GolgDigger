using System;
using UnityEngine;

public class PlayerCollisionProvider : MonoBehaviour
{
    public event Action<Collider> TriggerEnter;
    public event Action<Collider> TriggerStay;

    private void OnTriggerEnter(Collider other) => TriggerEnter?.Invoke(other);
    private void OnTriggerStay(Collider other) => TriggerStay?.Invoke(other);
}
