using UnityEngine;

public class ConveyorEndZone : MonoBehaviour
{
    [SerializeField]
    private LimitedActivity _limitedActivity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ConveyoyBag>())
        {
            Destroy(other.gameObject);
            _limitedActivity.AddResources(1);
        }
    }
}
