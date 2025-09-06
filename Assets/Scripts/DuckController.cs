using UnityEngine;

public class DuckController : MonoBehaviour
{
    public float speed;

    //0 means not moving
    //1 is moving to the right
    //-1 is moving to the left
    private int direction;

    private float maxX = 7.31f;
    private float minX = -7.09f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            direction = -1;
            Debug.Log("A key was pressed, move left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = 1;
            Debug.Log("D key was pressed, move right");
        }
        else
        {
            direction = 0;
        }

        Vector3 newPos = transform.position + Vector3.right * direction * speed * Time.deltaTime;

        if (newPos.x < maxX && newPos.x > minX)
        {
            transform.position = newPos;
        }

    }
}
