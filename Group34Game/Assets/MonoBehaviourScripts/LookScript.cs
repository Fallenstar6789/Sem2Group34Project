using UnityEngine;

public class LookScript : MonoBehaviour
{
    private GameObject Player;
    private float minClamp = -45;
    private float maxClamp = 45;
    public Vector2 rotation;
    private Vector2 currentLookRot;
    private Vector2 rotationV = new Vector2(0, 0);
    public float lookSensitivity = 2f;
    public float lookSmoothDamp = 0.1f;
    void Start()
    {
        Player = transform.parent.gameObject;
    }
    void Update()
    {
        rotation.y += Input.GetAxis("Mouse Y") * lookSensitivity;
        rotation.y = Mathf.Clamp(rotation.y, minClamp, maxClamp);
        Player.transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * lookSensitivity);
        currentLookRot.y = Mathf.SmoothDamp(currentLookRot.y, rotation.y, ref rotationV.y, lookSmoothDamp);
        transform.localEulerAngles = new Vector3(-currentLookRot.y, 0, 0);

    }
}
