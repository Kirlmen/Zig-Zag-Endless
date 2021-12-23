using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RDG;

public class CarController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private bool movingLeft = true;
    //private bool firstInput = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isStarted)
        {
            Movement();
            CheckInput();
            GameManager.Instance.ScoreIncrease();
        }

        if (transform.position.y < 0.3f)
        {
            GameManager.Instance.GameOver();
        }

    }

    private void Movement()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void CheckInput()
    {
        // if (firstInput) //ignore the first input. dont change direciton.
        // {
        //     firstInput = false;
        //     return;
        // }

        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
            Vibration.Vibrate(100, 10, false);
        }
    }

    private void ChangeDirection()
    {
        if (movingLeft)
        {
            movingLeft = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            movingLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
}
