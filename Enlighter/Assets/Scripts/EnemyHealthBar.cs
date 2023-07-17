using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public static EnemyHealthBar instance { get; private set; }
    public Image mask;

    float originalSize;

    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
    }


    public void Setvalue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
