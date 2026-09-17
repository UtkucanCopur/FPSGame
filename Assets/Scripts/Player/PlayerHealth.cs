using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    private float lerpTimer;
    public float maxHealth;
    public float chipSpeed;
    public Image frontHealthBar;
    public Image backHealthBar;




    private void Start()
    {
        health = maxHealth;
    }



    private void Update()
    {
        health = Mathf.Clamp(health, 0,maxHealth);
        UpdateHealthUI();
        if (Input.GetKeyDown(KeyCode.G))
        {
            TakeDamage(Random.Range(5, 15));
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            RestoreHealth(Random.Range(5, 15));
        }

    }


    public void UpdateHealthUI()
    {
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if (fillB > hFraction)
        {
            //Taking Damage
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }

        if (fillF < hFraction)
        {
            //Healing
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
    }

    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
    }

}
