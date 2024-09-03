using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float ArrowSpeed = 1f;
    public Rigidbody2D rgdby;

    void Awake()
    {
        rgdby = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //��ġ�� �÷��̾��
        SettingPosition();

        Shooting();
    }

    private void OnEnable()
    {
        SettingPosition();
        Shooting();
    }

    private void SettingPosition()
    {
        transform.position = GameManager.Instance.playerAttack.transform.position;
        transform.Translate(Vector2.right);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LayerMask enemy = LayerMask.NameToLayer("Enemy");
        if(collision.gameObject.layer == enemy)
        {   //�Ҹ��ϰ� ���� �ǰ�
            gameObject.SetActive(false);

            collision.gameObject.GetComponent<Enemy>().Damaged(100);
        }
    }

    private void Shooting()
    {
        rgdby.velocity = Vector3.right * ArrowSpeed;
    }
}
