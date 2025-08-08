using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawn;
    public int amount = 1;
    public float delaySpawn = 1f;
    public bool spawnsDead;

    private int getAmount;
    private float timer;
    private int spawned;
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
    }

    private void Update()
    {
        timer += Time.deltaTime;

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
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (spawn != null && spawn.GetComponent<MeshFilter>() != null)
        {
            Gizmos.DrawWireMesh(spawn.GetComponent<MeshFilter>().sharedMesh, transform.position, transform.rotation, Vector3.one);
        }
    }
}
