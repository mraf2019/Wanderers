using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string name = "";
    public Transform tf;
    public float initialX;
    public float initialY;
    public bool isSelected = false;

    public void Start()
    {
        tf = GetComponent<Transform>();
        initialX = tf.localScale.x;
        initialY = tf.localScale.y;
    }
    public void ResetCharacter()
    {
        tf.localScale = new Vector2(initialX, initialY);
        isSelected = false;
    }
    public void OnPointerClick()
    {
        isSelected = !isSelected;
        if (isSelected)
        {
            Vector2 scaleUp = new Vector2(initialX + 0.2f, initialY + 0.2f);
            tf.localScale = scaleUp;
            Debug.Log("selected");
        }
        else
            ResetCharacter();
        CharacterManager.Instance.OnCharacterSelected(this);
    }
}
