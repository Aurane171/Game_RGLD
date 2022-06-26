using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerheath : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public healthbar healthbar;

    private bool isInvincible = false;
    public SpriteRenderer graphics;
    private float invincibilityflashdelay = 0.1f;
    private float invincibilityTimeAfterHit = 1f;

    public static playerheath instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetmaxHealth(maxHealth); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            TakeDamage(51);

        if (Input.GetKeyDown(KeyCode.M))
            HealPlayer(20); 
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthbar.setHealth(currentHealth);
            if (currentHealth <= 0)
            {
                Die();
                return;
            }
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }
    public void HealPlayer(int amount)
    {
        if ((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }
        healthbar.setHealth(currentHealth);
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityflashdelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityflashdelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }

    public void Die()
    {

        Debug.Log("le joueur est mort"); 
        move_player.instance.enabled = false;
        move_player.instance.animator.SetTrigger("Death");
        move_player.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        move_player.instance.rb.velocity = Vector3.zero;
        move_player.instance.playerCollider.enabled = false;
        GameOverManager.instance.OnPlayerDeath();
    }

    public void Respawn()
    {
        move_player.instance.enabled = true;
        move_player.instance.animator.SetTrigger("Respawn");
        move_player.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        move_player.instance.playerCollider.enabled = true;
        currentHealth = maxHealth;
        healthbar.setHealth(currentHealth);
    }

}
