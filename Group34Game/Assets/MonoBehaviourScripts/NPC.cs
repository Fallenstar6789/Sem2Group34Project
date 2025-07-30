using UnityEngine;
using TMPro;
using System.Collections;

public class NPC : MonoBehaviour
{
    public GameObject interactPromptUI;
    public TextMeshProUGUI dialogueText;
    private bool playerInRange = false;
    private Coroutine hideCoroutine;

    private InventoryManager inventory;

    public int totalKeysRequired = 3;
    public int totalEnemiesRequired = 5;

    void Start()
    {
        if (interactPromptUI != null)
            interactPromptUI.SetActive(false);

        if (dialogueText != null)
            dialogueText.text = "";

        inventory = FindObjectOfType<InventoryManager>();
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            string message = GetDynamicMessage();

            if (dialogueText != null)
            {
                dialogueText.text = message;

                if (hideCoroutine != null)
                    StopCoroutine(hideCoroutine);

                hideCoroutine = StartCoroutine(HideDialogueAfterSeconds(3f));
            }

            if (interactPromptUI != null)
                interactPromptUI.SetActive(false);
        }
    }

    private string GetDynamicMessage()
    {
        int keys = inventory != null ? inventory.keys : 0;

        if (keys >= totalKeysRequired)
        {
            return "Well done! You’ve collected all keys and Defeat all Enemies. Lets Move on .";
        }
        else
        {
            return $"Destroy all enemies and collect {totalKeysRequired} keys.\n(You Have: {keys})";
        }
    }

    private IEnumerator HideDialogueAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (dialogueText != null)
            dialogueText.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (interactPromptUI != null)
                interactPromptUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (interactPromptUI != null)
                interactPromptUI.SetActive(false);

            if (dialogueText != null)
                dialogueText.text = "";
        }
    }
}