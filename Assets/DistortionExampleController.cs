using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DistortionExampleController : MonoBehaviour {
    private Vector3 offset;
    private bool isShake = true;

    private Vector3 originalPosition;
    void Start() {
        originalPosition = transform.position;
    }

    void Update(){
        if(isShake) {
            Vector3 newPosition = new Vector3(originalPosition.x + 0.25f * Random.value, originalPosition.y + 0.25f * Random.value, originalPosition.z);
            transform.position = newPosition;
        }
    }

    void OnMouseDown() {
        isShake = false;
        offset = gameObject.transform.position -
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }

    void OnMouseDrag() {
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
    }

}
