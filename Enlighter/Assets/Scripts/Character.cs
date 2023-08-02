using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string name = "";
    public int characterId;
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
        tf.position = tf.position - new Vector3(0, 78, 0);
        isSelected = false;
    }
    public void OnPointerClick()
    {
        isSelected = !isSelected;
        if (isSelected)
        {
            Vector2 scaleUp = new Vector2(initialX + 0.2f, initialY + 0.2f);
            tf.localScale = scaleUp;
            tf.position = tf.position + new Vector3(0, 78, 0);
            Debug.Log("selected");
        }
        else
            ResetCharacter();
        CharacterManager.Instance.OnCharacterSelected(this);
    }
}
