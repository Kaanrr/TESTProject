using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.RefillHealth();
                Destroy(gameObject);

            }
        }

    }
}
