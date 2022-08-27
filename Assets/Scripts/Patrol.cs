
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public float speed;
    public float waitTime;
    public Transform[] moveSpots;
    private int randomSpot;

    void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move(){
        while (true)
        {
            randomSpot = Random.Range(0, moveSpots.Length);
            while(Vector3.Distance(transform.position, moveSpots[randomSpot].position) > 0.2f)
            {
                transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
                yield return null;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
}
