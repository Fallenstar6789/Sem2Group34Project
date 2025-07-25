using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour
{
    public TextMeshProUGUI healthPanel;
    public int health = 100;
    private void Start()
    {
        ApplyDamage(0);
    }

    void ApplyDamage(int damage)
    {
        if(healthPanel != null && health > 0) 
        {
            health = health - damage;
            healthPanel.text ="Health: " + health.ToString();
        }
    }
}
