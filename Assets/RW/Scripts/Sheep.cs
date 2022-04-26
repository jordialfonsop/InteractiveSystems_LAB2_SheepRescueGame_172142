using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{

    public float runSpeed;
    public float gotHayDestroyDelay;
    private bool hitByHay;
    public float dropDestroyDelay;
    private Collider myCollider;
    private Rigidbody myRigidbody;
    private SheepSpawner sheepSpawner;
    public float heartOffset; // 1
    public GameObject heartPrefab; // 2
    private int hitpoints = 1;

    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }

    void Start(){
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(-Vector3.forward * runSpeed * Time.deltaTime);
    }

    private void HitByHay()
    {
        sheepSpawner.RemoveSheepFromList (gameObject);
        hitByHay = true; // 1
        runSpeed = 0; // 2
        Destroy(gameObject, gotHayDestroyDelay); // 3
        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();; // 1
        tweenScale.targetScale = 0; // 2
        tweenScale.timeToReachTarget = gotHayDestroyDelay;
        SoundManager.Instance.PlaySheepHitClip();
        GameStateManager.Instance.SavedSheep();
    }

    private void Drop()
    {
        sheepSpawner.RemoveSheepFromList (gameObject);
        GameStateManager.Instance.DroppedSheep();
        myRigidbody .isKinematic = false;
        myCollider .isTrigger = false;
        Destroy(gameObject, dropDestroyDelay );
        SoundManager.Instance.PlaySheepDroppedClip();
    }

    private void OnTriggerEnter (Collider other) // 1
    {
        
        hitpoints --;
        if (other.CompareTag("Hay") && !hitByHay) // 2
        {
            if (hitpoints > -1)
            {
                Destroy(other.gameObject); // 3
                HitByHay(); // 4
            }
        }
        else if (other.CompareTag("DropSheep"))
        {
            if (hitpoints > -1)
            {
                Drop();
            }
        }
    }



}
