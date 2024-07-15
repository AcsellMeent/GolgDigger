using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [SerializeField]
    private GameObject _sandPref;

    [SerializeField]
    private Transform _spawnPoint;

    public void LoadSand()
    {
        Instantiate(_sandPref, _spawnPoint.position, transform.rotation);
    }
}
