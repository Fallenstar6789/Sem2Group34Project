using UnityEngine;

public class EnermyHealth : MonoBehaviour
{
    private int hitNumber;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("bullet")) 
        {
            hitNumber++; 
        }
        if(hitNumber == 2) 
        {
            Destroy(gameObject);
        }
    }

}
