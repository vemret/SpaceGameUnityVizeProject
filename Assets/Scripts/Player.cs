using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Ball ball;
    string axisName = "Horizontal";
    public float moveSpeed = 10;
    // Start is called before the first frame update

  
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        float moveAxis = Input.GetAxis(axisName) * moveSpeed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveAxis, 0);
    }
}
