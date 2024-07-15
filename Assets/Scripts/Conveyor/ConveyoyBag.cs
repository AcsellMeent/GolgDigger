using UnityEngine;

public class ConveyoyBag : MonoBehaviour
{
    private void Update()
    {
        transform.position = transform.position + transform.forward * Time.deltaTime;
    }
}
