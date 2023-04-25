using Cinemachine;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHP : MonoBehaviour
{
    public Image healthBar;

    public 

    float health, maxHealth = 150;
    float lerpSpeed;

    private void Start()
    {
        health = maxHealth;

    }

    private void Update()
    { 
        lerpSpeed = 3f * Time.deltaTime;
        HealthBarFill();
        ColourVariation();
    }

    void HealthBarFill()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount,health / maxHealth, lerpSpeed);

        
    }

    void ColourVariation()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        healthBar.color = healthColor;

    }

    public void playerDamage()
    {
        health -= 15;
    }







}