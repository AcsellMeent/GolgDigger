using UnityEngine;

public class PlayerMovementProperties : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    public float Speed { get => _speed; }
}
