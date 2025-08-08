using UnityEngine;
using System.Collections;
using System.Collections.Generic;

<<<<<<< HEAD
public class Enemy
{
    public GameObject go;
    public bool active;

    public Enemy(GameObject newGo, bool newBool)
    {
        go = newGo;
        active = newBool;
    }
}

=======
>>>>>>> bd8314035e62a84aa7d4cadf4fb6c9348072c2b8
public class EnemySpawner : MonoBehaviour
{
    public GameObject spawn;
    public int amount = 1;
<<<<<<< HEAD
    public float delaySpawn = 1f;
    public bool spawnsDead;
=======
    public float delaySpawn = 1;
>>>>>>> bd8314035e62a84aa7d4cadf4fb6c9348072c2b8

    private int getAmount;
    private float timer;
    private int spawned;
<<<<<<< HEAD
    private int enemyDead;

    public List<Enemy> enemies = new List<Enemy>();

    private void Start()
    {
        RPGFPGameManager.RoundComplete += ResetRound;
        ResetRound();

        for (int i = 0; i < getAmount; i++)
        {
            GameObject instance = Instantiate(spawn, transform.position, Quaternion.identity);
            instance.transform.parent = null;
            instance.SetActive(false);
            enemies.Add(new Enemy(instance, false));
        }
    }

    public void ResetRound()
    {
        spawnsDead = false;
        getAmount = amount;
        spawned = 0;
        timer = 0;
        enemyDead = 0;
=======
    private void Start()
    {
        ResetRound();
    }
    private void ResetRound()
    {
        getAmount = amount;
>>>>>>> bd8314035e62a84aa7d4cadf4fb6c9348072c2b8
    }

    private void Update()
    {
        timer += Time.deltaTime;
<<<<<<< HEAD

        if (timer >= delaySpawn && spawned < getAmount)
        {
            timer = 0f;

            // Activate next enemy in the pool
            enemies[spawned].go.transform.position = transform.position;
            enemies[spawned].go.SetActive(true);
            enemies[spawned].active = true;
            StartCoroutine(SetKinematic(spawned));
            spawned++;
        }

        // Check for dead enemies
        int deadCount = 0;
        for (int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].go.activeSelf && enemies[i].active)
            {
                enemies[i].active = false;
                deadCount++;
            }
        }

        if (deadCount == enemies.Count)
        {
            spawnsDead = true;
        }
    }

    private IEnumerator SetKinematic(int id)
    {
        yield return null;
        Rigidbody rb = enemies[id].go.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
=======
        if (delaySpawn < timer)
        {
            if(spawned < getAmount) 
            {
                timer = 0;
                spawned++;
                GameObject instance = Instantiate(spawn, transform);
                instance.transform.parent = null;
            }
        }
>>>>>>> bd8314035e62a84aa7d4cadf4fb6c9348072c2b8
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
<<<<<<< HEAD
        if (spawn != null && spawn.GetComponent<MeshFilter>() != null)
=======
        if(spawn != null) 
>>>>>>> bd8314035e62a84aa7d4cadf4fb6c9348072c2b8
        {
            Gizmos.DrawWireMesh(spawn.GetComponent<MeshFilter>().sharedMesh, transform.position, transform.rotation, Vector3.one);
        }
    }
}
