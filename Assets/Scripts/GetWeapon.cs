using UnityEngine;

public class GetWeppon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Weapon"))
        {
            other.gameObject.SetActive(false);
        }
    }
  
}
