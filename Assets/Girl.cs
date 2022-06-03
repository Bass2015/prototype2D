using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{

    Transform ass;
    Transform bubble;

    public float scaleSpeed;
    public float speed;
    bool inflating;
    public float horizontalSpeed;
    private bool following;
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        ass = transform.GetChild(0);
        bubble = transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        float newAssValue = ass.localScale.x;
        float newBubbleValue = bubble.localScale.x;
        if (Input.GetMouseButtonDown(0))
        {
            lastMousPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0) && newAssValue > 0.5)
        {
            newAssValue = newAssValue - scaleSpeed * Time.deltaTime;
            newBubbleValue += scaleSpeed * Time.deltaTime;
            inflating = newAssValue > 0.5;
        }
        if (Input.GetMouseButtonUp(0))
        {
            inflating = false;
        }
        if (!inflating && newBubbleValue > 0.2)
        {
            newBubbleValue -= scaleSpeed * Time.deltaTime;
        }

        if (newBubbleValue > 0.2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        }
        else if (transform.position.y > -10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
        }
        ass.localScale = new Vector2(newAssValue, newAssValue);
        bubble.localScale = new Vector2(newBubbleValue, newBubbleValue);
        if(Input.GetMouseButton(0))
            FollowMouse();

    }
    Vector2 lastMousPos;
    private void FollowMouse()
    {
        Vector2 mousePos = Input.mousePosition;
        if (mousePos.x > lastMousPos.x)
        {
            MoveRight();
        }
        if (mousePos.x < lastMousPos.x)
        {
            MoveLeft();
        }
        
    }


    private void MoveLeft()
    {
        transform.position = new Vector2(transform.position.x - horizontalSpeed * Time.deltaTime, transform.position.y);
    }

    private void MoveRight()
    {
        transform.position = new Vector2(transform.position.x + horizontalSpeed * Time.deltaTime, transform.position.y);
    }

    public float sumValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger");
        float value = ass.localScale.x + sumValue;
        ass.localScale = new Vector2(value, value);
    }
}
