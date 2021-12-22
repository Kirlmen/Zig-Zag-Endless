using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] Transform player;
    Vector3 distance;
    [SerializeField] float smoothValue;
    // Start is called before the first frame update
    void Start()
    {
        distance = player.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 currentPos = transform.position;
        Vector3 targetPos = player.position - distance;

        transform.position = Vector3.Lerp(currentPos, targetPos, smoothValue * Time.deltaTime);
    }
}
