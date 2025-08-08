using UnityEngine;
using System.Collections;

public class BulletContact : MonoBehaviour
{
    public GameObject particle;
    void OnCollisionEnter(Collision other) 
    {
        ContactPoint contact = other.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        Instantiate(particle, pos, rot);
        gameObject.SetActive(false);
    }
}
