using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;

    private playerConrtoller playerConrtollerScript;

    private float leftBound = -30;
    // Start is called before the first frame update
    void Start()
    {
        playerConrtollerScript = GameObject.Find("player").GetComponent<playerConrtoller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerConrtollerScript.gameOver == true)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
        
}
