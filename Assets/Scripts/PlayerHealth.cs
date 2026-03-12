using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{  // This script manages the player's health, damage, healing, and visual feedback for taking damage.
    [Header("Health Settings")]
    public int maxHealth = 100;
    public float invincibilityTime = 0.2f;
    // The maxHealth variable defines the player's maximum health, while invincibilityTime determines how long the player is invincible after taking damage.
    [Header("Damage Feedback")]
    public GameObject damagePopupPrefab; 
    public SpriteRenderer spriteRenderer;  
    public Color flashColor = Color.red;
    public float flashDuration = 0.1f;
    // The damagePopupPrefab is a reference to a prefab that will display the damage taken. The spriteRenderer is used to change the player's color when taking damage, and flashColor and flashDuration control the visual feedback.
    private int currentHealth;
    private bool isInvincible = false;
    private Color originalColor;
    // currentHealth keeps track of the player's current health, isInvincible indicates whether the player is currently invincible, and originalColor stores the player's original color for flashing effects.
    void Start()
    {
        currentHealth = maxHealth;

        if (spriteRenderer != null)
            originalColor = spriteRenderer.color;

        Debug.Log("Player health set to: " + currentHealth);
    }
    // The Start method initializes the player's health to maxHealth and stores the original color of the sprite for later use in the flash effect.
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
    // The TakeDamage method reduces the player's health by the specified amount, shows a damage popup, triggers a flash effect, and checks if the player has died. If the player is still alive, it starts the invincibility frames.
    private void ShowDamagePopup(int amount)
    {
        if (damagePopupPrefab != null)
        {
            GameObject popup = Instantiate(damagePopupPrefab, transform.position, Quaternion.identity);
            popup.GetComponent<TextMesh>().text = "-" + amount.ToString();
        }
    }
    // The ShowDamagePopup method instantiates a damage popup at the player's position and sets the text to display the amount of damage taken.
    private IEnumerator FlashEffect()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            spriteRenderer.color = originalColor;
        }
    }
    // The FlashEffect coroutine changes the player's color to flashColor for a short duration and then reverts it back to the original color.
    private IEnumerator InvincibilityFrames()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
    }
    // The InvincibilityFrames coroutine sets the player to invincible for a short duration, preventing them from taking damage again immediately after being hit.
    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Player healed " + amount + ". Health now: " + currentHealth);
    }
    // The Heal method increases the player's health by the specified amount and ensures it does not exceed maxHealth.
    private void Die()
    {
        Debug.Log("Player died!");
    }
}
