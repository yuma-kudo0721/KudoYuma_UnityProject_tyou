using UnityEngine;

public class ItemDel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject);
        }
    }
}
