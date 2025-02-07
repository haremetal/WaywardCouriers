using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth = 10;
    private int currentHealth;

    [SerializeField] private Animator playerAnim;

    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void Damage(int damageAmount)
    {
        playerAnim.SetTrigger("hurt");
        currentHealth -= damageAmount;
        Debug.Log($"Player took {damageAmount} damage! Current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died.");
    }
}
