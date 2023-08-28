using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
  private float moveSpeed = 5.0f;
  private float jumpForce = 5.0f;
  private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
    rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    Vector3 movement = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
    transform.Translate(movement);
    // スペースキーを押したか、画面をタップした場合にジャンプさせる
    if ((Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)))
      {
          Jump();
      }    
    }

    void Jump() {
    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
