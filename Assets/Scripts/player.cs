using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    private float moveSpeed = 11.0f;
    private float jumpForce = 17.0f;
    private Rigidbody2D rb;
    private bool canJump = true;
    public GameObject explosionPrefab;
    private bool onJumpPad = false; // JumpPadに触れているかどうかを示すフラグ
    private float jumpPadMultiplier = 2.0f; // JumpPadに触れている間のジャンプ力の倍率

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        transform.Translate(movement);

        // スペースキーを押したか、画面をタップした場合にジャンプさせる
        if (canJump && (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)))
        {
            Jump();
        }
    }

    void Jump()
    {
        // JumpPadに触れている場合はジャンプ力を倍にする
        float effectiveJumpForce = onJumpPad ? jumpForce * jumpPadMultiplier : jumpForce;
        Debug.Log(effectiveJumpForce);
        rb.velocity = new Vector2(rb.velocity.x, effectiveJumpForce);
        canJump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (Mathf.Abs(collision.contacts[0].normal.y) > 0.9f)
            {
                canJump = true;
            }
            else if (Mathf.Abs(collision.contacts[0].normal.x) > 0.9f)
            {
                Vector3 explosionPosition = transform.position;
                gameObject.SetActive(false);
                Instantiate(explosionPrefab, explosionPosition, Quaternion.identity);
                Invoke(nameof(ReloadScene), 1.5f);
            }
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            Vector3 explosionPosition = transform.position;
            gameObject.SetActive(false);
            Instantiate(explosionPrefab, explosionPosition, Quaternion.identity);
            Invoke(nameof(ReloadScene), 1.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("JumpPad"))
        {
          Debug.Log("enter");
            // JumpPadに触れたらフラグを設定
            onJumpPad = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("JumpPad"))
        {
          Debug.Log("exit");
            // JumpPadから離れたらフラグを解除
            onJumpPad = false;
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
