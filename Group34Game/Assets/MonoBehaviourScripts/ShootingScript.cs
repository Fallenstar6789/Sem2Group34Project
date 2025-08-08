using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject bullet;
<<<<<<< HEAD
<<<<<<< HEAD
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            var clone = Instantiate(bullet,gameObject.transform.position,gameObject.transform.rotation);
            Destroy(clone, 4.0f);
        }
    }
=======
=======
>>>>>>> parent of e6b46df (i++)
    private InventoryManager inventory;
    private PlayerInputActions inputActions;

    void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Player.Shoot.performed += ctx => Fire();
    }

    void Start()
    {
        inventory = FindObjectOfType<InventoryManager>();
    }

    void Fire()
    {
        if (inventory != null && inventory.ammo > 0)
        {
            var clone = Instantiate(bullet, transform.position, transform.rotation);
            Destroy(clone, 4.0f);
            inventory.UseAmmo(1);
        }
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
<<<<<<< HEAD
>>>>>>> parent of e6b46df (i++)
=======
>>>>>>> parent of e6b46df (i++)
}
