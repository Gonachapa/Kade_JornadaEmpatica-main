using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealtBarC : MonoBehaviour
{
    public Image healthBar; // Reference to the Image component of the health bar
    public float maxHealth = 100f; // Maximum health
    public float currentHealth; // Current health
    public float healthDecreaseAmount = 8f; // Amount of health to decrease per second

    void Start()
    {
        currentHealth = maxHealth;
        StartCoroutine(DecreaseHealthOverTime());
    }

    IEnumerator DecreaseHealthOverTime()
    {
        while (currentHealth > 0)
        {
            yield return new WaitForSeconds(1f);
            if (healthBar.gameObject.activeSelf) // Check if the health bar is active
            {
                currentHealth -= healthDecreaseAmount;
                UpdateHealthBar();
            }
        }
    }

    void UpdateHealthBar()
    {
        float fillAmount = currentHealth / maxHealth;
        healthBar.fillAmount = Mathf.Clamp(fillAmount, 0f, 1f);
    }
}
