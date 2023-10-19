using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairDirectionToMouse : MonoBehaviour
{
    public Transform from;
    public float distance;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Vector2 posMouse = cam.ScreenToWorldPoint(Input.mousePosition);
        float distanceBetweenFromToMouse = Vector2.Distance(from.position, posMouse);

        if (distanceBetweenFromToMouse > distance)
        {
            transform.position = from.position;
            Vector2 direction = posMouse - (new Vector2(from.position.x, from.position.y));
            direction = direction.normalized;
            transform.position +=  new Vector3(direction.x*distance, direction.y*distance, 0);
        }
        else
        {
            transform.position = posMouse;
        }
    }
}
