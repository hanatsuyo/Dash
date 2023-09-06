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

    void Jump() {
    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    canJump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
      if(collision.gameObject.CompareTag("Ground")) {
      canJump = true;
      }
      if (collision.gameObject.CompareTag("Wall"))
        {
            if (Mathf.Abs(collision.contacts[0].normal.y) > 0.9f)
            {
              // 上部に接触した場合の処理（プレイヤーは乗れる）
              // 例えば、ジャンプ可能にする、得点を加算するなどの処理を記述
              canJump = true;
            }
            else if (Mathf.Abs(collision.contacts[0].normal.x) > 0.9f)
            {
              // ここに壁に衝突した時の処理を記述する。
              Vector3 explosionPosition = transform.position;
              gameObject.SetActive(false);
              Instantiate(explosionPrefab, explosionPosition, Quaternion.identity);
              Invoke(nameof(ReloadScene), 1.5f);
            }
        }
        if(collision.gameObject.CompareTag("Spike")) {
              Vector3 explosionPosition = transform.position;
              gameObject.SetActive(false);
              Instantiate(explosionPrefab, explosionPosition, Quaternion.identity);
              Invoke(nameof(ReloadScene), 1.5f);
        }
    }

    private void ReloadScene () {
      SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
