using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    //variables
    public int maxHealth = 150;
    public int currentHealth;

    public HealthBar healthBar;
    public Collider DeathBox;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.MaxHealth(maxHealth);//Sets UI healthbar to maxHealths value
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;//Reduce currentHealths value by damages value
        healthBar.CurrentHealth(currentHealth);//Sets UI healthbar to currentHealths value
        if (currentHealth <= 0)
        {
            Dead();
        }
    }
    public void Dead()
    {
        Debug.Log("You Died");
        SceneManager.LoadScene(2);
    }
}
