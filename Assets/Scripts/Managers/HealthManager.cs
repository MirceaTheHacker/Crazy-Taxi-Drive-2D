using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Image[] imagesArray;
    public Sprite fullHeartSprite;
    public Sprite emptyHeartSprite;

    internal int maxHealth;
    internal int curHealth;

    internal void InitializeHarts()
    {
        for (int i = 0; i < imagesArray.Length; i++)
        {
            if (i >= maxHealth)
            {
                imagesArray[i].enabled = false;
            }
            if (i >= curHealth)
            {
                imagesArray[i].sprite = emptyHeartSprite;
            }
            else if (i < curHealth)
            {
                imagesArray[i].sprite = fullHeartSprite;
            }
        }
    }

    public void UpdateHearts(int damageValue)
    {
        curHealth -= damageValue;
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        for (int i = 0; i < imagesArray.Length; i++)
        {
            if (i >= maxHealth)
            {
                imagesArray[i].enabled = false;
            }
            else
            {
                imagesArray[i].enabled = true;
            }
            if (i >= curHealth)
            {
                if (imagesArray[i].sprite == fullHeartSprite)
                {
                    //this means that we are just now changing this heart from full to empty
                    StartCoroutine(FlashHeart(imagesArray[i]));
                }
            }
            else
            {
                imagesArray[i].sprite = fullHeartSprite;
            }
        }
    }

    private IEnumerator FlashHeart(Image heart)
    {
        float timer = 2f;
        float startTime = Time.time;
        Color originalColor = heart.color;
        Color fadedColor = originalColor;
        fadedColor.a = 0.5f;

        while (timer >= 0)
        {
            timer -= Time.time - startTime;
            heart.color = fadedColor;
            yield return new WaitForSeconds(0.15f);
            heart.color = originalColor;
            yield return new WaitForSeconds(0.15f);
        }
        heart.sprite = emptyHeartSprite;
    }
}
