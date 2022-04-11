using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController ch_Controller;
    public float x;
    public float y;
    public float speedMove;
    private Vector3  moveVector;


    // Use this for initialization
    void Start()
    {
        speedMove = 3;
        ch_Controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        CharacterMove();
        if (Input.GetKey(KeyCode.Mouse0)) gameObject.GetComponent<Animator>().SetTrigger("Attack");
        if (Input.GetKey(KeyCode.Mouse1)) gameObject.GetComponent<Animator>().SetTrigger("SlashAttack");
        x = Input.GetAxis("Vertical");
        y = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.W))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y, 0), 0.2f);
        if (Input.GetKey(KeyCode.S))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y + 180, 0), 0.2f);
        if (Input.GetKey(KeyCode.A))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y - 90, 0), 0.2f);
        if (Input.GetKey(KeyCode.D))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.rotation.y + 90, 0), 0.2f);

    }
    private void CharacterMove()
    {
        // перемещение по поверхности
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * speedMove;
        moveVector.z = Input.GetAxis("Vertical") * speedMove;

        ch_Controller.Move(moveVector * Time.deltaTime); // метод передвижения по направлению
    }
    void FixedUpdate()
    {
        gameObject.GetComponent<Animator>().SetFloat("Speed", x, 0.1f, Time.deltaTime);
        gameObject.GetComponent<Animator>().SetFloat("Direction", y, 0.1f, Time.deltaTime);
    }
}