using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    public int currentHealth;
    public bool isDead = false;

    [Header("Damage Feedback")]
    public Renderer enemyRenderer;
    public Color hitColor = Color.red;
    public float hitFlashDuration = 0.1f;
    private Color originalColor;

    [Header("Death Settings")]
    public GameObject deathEffect;
    public float destroyDelay = 1f;
    public bool dropLoot = false;
    public GameObject lootPrefab;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip hitSound;
    public AudioClip deathSound;

    void Start()
    {
        currentHealth = maxHealth;

        if (enemyRenderer != null)
        {
            originalColor = enemyRenderer.material.color;
        }
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;

        if (audioSource != null && hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

        if (enemyRenderer != null)
        {
            StopAllCoroutines();
            StartCoroutine(HitFlash());
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    System.Collections.IEnumerator HitFlash()
    {
        enemyRenderer.material.color = hitColor;
        yield return new WaitForSeconds(hitFlashDuration);
        enemyRenderer.material.color = originalColor;
    }
    void Die()
    {
        if (isDead) return;
        isDead = true;
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        if (audioSource != null && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }
        if (dropLoot && lootPrefab != null)
        {
            Instantiate(lootPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject, destroyDelay);
    }
}
