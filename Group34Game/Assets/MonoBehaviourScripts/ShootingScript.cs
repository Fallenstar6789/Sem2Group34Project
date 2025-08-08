using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject bullet;
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            var clone = Instantiate(bullet,gameObject.transform.position,gameObject.transform.rotation);
            Destroy(clone, 4.0f);
        }
    }
}
