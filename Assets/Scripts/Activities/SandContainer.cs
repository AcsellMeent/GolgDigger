using UnityEngine;

public class SandContainer : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _bagOfSandView;

    [SerializeField]
    private int _boxCapacity;

    [SerializeField]
    private int _currentBagCount;

    public bool Filled { get; private set; }

    public void AddBag()
    {
        if (Filled) return;
        if (_currentBagCount < _bagOfSandView.Length)
            _bagOfSandView[_currentBagCount]!.SetActive(true);
        _currentBagCount++;

        if (_currentBagCount == _boxCapacity)
        {
            Filled = true;
        }
    }
}
