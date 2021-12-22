using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    float dropTimer;


    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            StartCoroutine(PlatformDrop());
        }
    }

    IEnumerator PlatformDrop()
    {
        if (GameManager.Instance.score < 1000 && GameManager.Instance.score > 0)
        {
            dropTimer = 1.5f;
        }
        else if (GameManager.Instance.score < 2500 && GameManager.Instance.score > 1000)
        {
            dropTimer = 1f;
        }
        else if (GameManager.Instance.score < 5000 && GameManager.Instance.score > 2500)
        {
            dropTimer = 0.6f;
        }
        else if (GameManager.Instance.score < 8000 && GameManager.Instance.score > 5000)
        {
            dropTimer = 0.3f;
        }
        else if (GameManager.Instance.score < 15000 && GameManager.Instance.score > 8000)
        {
            dropTimer = 0.2f;
        }

        yield return new WaitForSeconds(dropTimer);
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        Destroy(this.gameObject, 1.5f);
    }

}
