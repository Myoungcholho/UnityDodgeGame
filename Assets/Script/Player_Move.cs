using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    private Rigidbody playerRigid;
    public float speed = 8f;


    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /* 1. if�� 4�� ��� , 2. ���������� ������ ��ȯ�� �����*/
        {
            /* if(Input.GetKey(KeyCode.UpArrow) == true)
             {
                 playerRigid.AddForce(0f, 0f, speed);
             }

             if (Input.GetKey(KeyCode.DownArrow) == true)
             {
                 playerRigid.AddForce(0f, 0f, -speed);
             }

             if (Input.GetKey(KeyCode.RightArrow) == true)
             {
                 playerRigid.AddForce(speed, 0f, 0f);
             }

             if (Input.GetKey(KeyCode.LeftArrow) == true)
             {
                 playerRigid.AddForce(-speed, 0f, 0f);
             }*/
        }
        
        // <- , A Ű 2���� �����..
        float _x = Input.GetAxis("Horizontal");
        float _z = Input.GetAxis("Vertical");

        float _x_speed = _x * speed;
        float _z_speed = _z * speed;

        Vector3 newVelocity = new Vector3(_x_speed, 0, _z_speed);
        playerRigid.velocity = newVelocity;



    }
    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gm = FindObjectOfType<GameManager>();
        gm.EndGame();
    }
}
