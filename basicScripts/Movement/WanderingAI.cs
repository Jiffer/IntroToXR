using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public float rotateSpeed = 50f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;


    // Update is called once per frame
    void Update()
    {
        // start Coroutine over when it completes:        
        if (isWandering == false){
            StartCoroutine(Wander()); 
        }
        if(isRotatingRight){
            transform.Rotate(transform.up * Time.deltaTime * rotateSpeed);
        }
        if(isRotatingLeft){
            transform.Rotate(transform.up * Time.deltaTime * -rotateSpeed);
        }
        if(isWalking){
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    // Wander coroutine 
    // sets the values and steps through the stages in time
    IEnumerator Wander(){
        // set new random values:
        int walkWait = Random.Range(1,3);
        int walkTime = Random.Range(1,5);
        int rotateWait = Random.Range(1,3);
        int rotTime = Random.Range(1,4);
        int rotateLorR = Random.Range(0,2);
        
        // begin wandering
        isWandering = true;
        // brief pause before moving
        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        // begin walking
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        // pause before rotating
        yield return new WaitForSeconds(rotateWait);
        // randomly turn left or right
        if(rotateLorR == 0){
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if(rotateLorR == 1){
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }
        isWandering = false;
    }
}
