using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public float speed;
    private Vector3 dir;
    private bool isMoving;

    private float maxSpeed = 5f;
    private float minSpeed = 1f;

    private GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject paddle = GameObject.Find("Duck");
        transform.SetParent(paddle.transform);
        isMoving = false;
        dir = Vector3.Normalize(new Vector3(1, 1, 0));
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.SetParent(null);
            isMoving = true;
        }
        if (isMoving)
        {
            transform.Translate(dir * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.GetContact(0).normal;

        Vector3 reflected = Vector3.Reflect(dir, normal);
        reflected.z = 0;

        dir = Vector3.Normalize(reflected);

        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject, 0.03f);
            gm.AddScore();
            gm.SubtractBrickCount();
            ChangeSpeed(0.25f);
        }
        else if (collision.gameObject.CompareTag("Walls")) 
        {
            ChangeSpeed(0.25f);
        }
        else if (collision.gameObject.CompareTag("Duck"))
        {
            ChangeSpeed(-0.1f);
        }
        if (collision.gameObject.name.Contains("WallB"))
        {
            //Destroy(this.gameObject);
            gm.DestroyBall(gameObject);
        }
    }
    private void ChangeSpeed(float change)
    {
        float newSpeed = speed + change;
        if (newSpeed < maxSpeed && newSpeed > minSpeed)
        {
            speed = newSpeed;
        }
    }
}
