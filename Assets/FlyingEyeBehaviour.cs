using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeBehaviour1 : MonoBehaviour{
    public Transform player;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        Vector2 direction = player.position - transform.position;
        Debug.Log(direction);
    }
}
