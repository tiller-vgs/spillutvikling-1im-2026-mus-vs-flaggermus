using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    public float invincibilityTime = 0.2f;

    [Header("Damage Feedback")]
    public GameObject damagePopupPrefab; 
    public SpriteRenderer spriteRenderer;  
    public Color flashColor = Color.red;
    public float flashDuration = 0.1f;

    private int currentHealth;
    private bool isInvincible = false;
    private Color originalColor;

    void Start()
    {
        currentHealth = maxHealth;

        if (spriteRenderer != null)
            originalColor = spriteRenderer.color;

        Debug.Log("Player health set to: " + currentHealth);
    }

    public void TakeDamage(int amount)
    {
        if (isInvincible) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        ShowDamagePopup(amount);
        StartCoroutine(FlashEffect());

        Debug.Log("Player took " + amount + " damage. Health now: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(InvincibilityFrames());
        }
    }

    private void ShowDamagePopup(int amount)
    {
        if (damagePopupPrefab != null)
        {
            GameObject popup = Instantiate(damagePopupPrefab, transform.position, Quaternion.identity);
            popup.GetComponent<TextMesh>().text = "-" + amount.ToString();
        }
    }

    private IEnumerator FlashEffect()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            spriteRenderer.color = originalColor;
        }
    }

    private IEnumerator InvincibilityFrames()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Player healed " + amount + ". Health now: " + currentHealth);
    }

    private void Die()
    {
        Debug.Log("Player died!");
    }
}
