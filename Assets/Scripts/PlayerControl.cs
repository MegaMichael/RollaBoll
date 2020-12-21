using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject winTextObject;
    private float movementX;
    private float movementY;
    private int cout;
    public float speed = 0;
    public TextMeshProUGUI coutText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cout = 0;

        SetCountTex();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountTex()
    {
        coutText.text = "Count:" + cout.ToString();
        if(cout >= 6)
        {
            winTextObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            cout++;
            SetCountTex();
        }
    }
}
