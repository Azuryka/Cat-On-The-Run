using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDamageEffect : MonoBehaviour
{
    [SerializeField]
    private Material material;

    [SerializeField]
    private Color tintColor;

    [SerializeField]
    private bool takeDamage = false;

    [SerializeField]
    private float fadeSpeed = 1.0f;

    private float originalAlpha = 255f;

    [SerializeField]
    private float currentAlpha = 0f;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        if (takeDamage && currentAlpha > 0)
        {
            currentAlpha -= fadeSpeed * Time.deltaTime;
            tintColor.a = currentAlpha;
            material.SetColor("_Tint", tintColor);
        }
        else if (takeDamage && currentAlpha <= 0)
        {
            tintColor.a = 0f;
            material.SetColor("_Tint", tintColor);
            takeDamage = false;
        }
    }

    public void Damage()
    {
        currentAlpha = originalAlpha;
        tintColor = new Color(1, 0, 0, originalAlpha);
        material.SetColor("_Tint", tintColor);
        takeDamage = true;
    }
}
