using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
  // Start is called before the first frame update
  public player player;
    void Start()
    {
      Debug.Log(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Mathf.Abs(collision.contacts[0].normal.y) > 0.9f)
            {
              // 上部に接触した場合の処理（プレイヤーは乗れる）
              // 例えば、ジャンプ可能にする、得点を加算するなどの処理を記述
              player.canJump = true;
            }
            else if (Mathf.Abs(collision.contacts[0].normal.x) > 0.9f)
            {
                // ここに壁に衝突した時の処理を記述する。
            }
        }
    }
}
