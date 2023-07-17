using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class RectGuide : MonoBehaviour, ICanvasRaycastFilter
{
    private int changetime = 0;
    private Material material;
    private Vector3 center;
    private float width;
    private float height;
    private RectTransform target;
    private Vector3[] targetCorners = new Vector3[4];
    public string TargetName = "Joystick";
    public float zoom = 1.3f;
    // public Vector2 pos;

    public void GuideTarget(Canvas canvas, RectTransform target){
        // material = transform.GetComponent<Image>().material;
        this.target = target;
        //get center position
        target.GetWorldCorners(targetCorners);
        for (int i = 0; i < targetCorners.Length; i++){
            targetCorners[i] = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, targetCorners[i]);
            Vector2 LocalPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), targetCorners[i], canvas.worldCamera, out LocalPosition);
            targetCorners[i] = LocalPosition;
        }
        //computer center point
        center.x = targetCorners[0].x + (targetCorners[3].x - targetCorners[0].x)/2;
        center.y = targetCorners[0].y + (targetCorners[1].y - targetCorners[0].y)/2;
        height = targetCorners[1].y - targetCorners[0].y;
        width = targetCorners[3].x - targetCorners[0].x;
        //set material center
        material.SetVector("_Center", center);
        //set size
        material.SetFloat("_SliderY", height * zoom);
        material.SetFloat("_SliderX", width * zoom);
    }

    private void Start(){
        material = transform.GetComponent<Image>().material;
        if (material == null){
            throw new System.Exception("No material found!");
        }
    }

    private void Update(){
        if (changetime == 0){
            GuideTarget(GameObject.Find("Canvas").GetComponent<Canvas>(), GameObject.Find(TargetName).GetComponent<RectTransform>());changetime++;
        }
        
    }

    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        if (target == null) { return false; } // 事件不会渗透 

        return !RectTransformUtility.RectangleContainsScreenPoint(target,sp);
    }
}
