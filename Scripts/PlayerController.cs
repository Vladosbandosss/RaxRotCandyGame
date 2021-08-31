using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float maxXpos = 7.7f;
    float minXpos = -7.7f;
   public bool CanMove = true;
    [SerializeField] float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {
            Move();
        }
    }

    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * inputX * moveSpeed * Time.deltaTime;
        float Xpos =Mathf.Clamp(transform.position.x, minXpos, maxXpos);
        transform.position = new Vector3(Xpos, transform.position.y, transform.position.z);

    }
}
