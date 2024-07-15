using UnityEngine;

public class PlayerDollEffect : MonoBehaviour
{
    [SerializeField]
    private Transform _playerModel;

    [SerializeField]
    private Transform _target;

    private void Update()
    {
        if (_target)
        {
            _playerModel.eulerAngles = new Vector3(
                (50 * (transform.position.z - _target.position.z) * -_playerModel.forward.z) + 50 * ((transform.position.x - _target.position.x) * -_playerModel.forward.x),
                _playerModel.localEulerAngles.y,
                0);
        }
    }
}
