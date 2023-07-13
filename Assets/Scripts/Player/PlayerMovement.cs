using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    public int level = 1;
    public LevelGetter lg;
    public float moveSpeed;
    Rigidbody2D rb;
    public float lastHorizontalVector;
    public float lastVerticalVector;
    public Vector2 moveDir;
    public Vector2 lastMovedVector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lg = GetComponent<LevelGetter>();
        lastMovedVector = new Vector2(1, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
    }

    void FixedUpdate()
    {
        moveSpeed = (int)lg.levelProperties[level]["playerMoveSpd"];
        Move();
    }

    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if(moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f); //last x
        }

        if(moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector); //last y
        }

        if (moveDir.x != 0 && moveDir.y != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);
        }
    }

    void Move()
    {
        rb.velocity = moveDir * moveSpeed;
    }
}
