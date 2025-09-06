using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject[] brickPrefabs;

    public float brickWidth = 1.4f;
    public float brickHeight = -1.4f;
    public int numRows = 6;
    public int numCols = 12;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnBricks();
    }

    private void SpawnBricks()
    //this is action
    {
        for (int r = 0; r < numRows; r++)
        //for loop out
        {
            //1. if it is row 1 and row 6 -> we want to spawn brick 0
            //2. else if it is row 2 and row 3 -> we want to spawn brick 1
            //3. else if it is row 4 and row 5 -> we want to spawn brick 2
            Debug.Log("r = " + r);
            if (r == 0)
            {
                Debug.Log("hello 0 5");
                for (int c = 0; c < numCols; c++)
                {
                    Debug.Log("c = " + c);
                    Instantiate(brickPrefabs[0],
                new Vector3(transform.position.x + c * brickWidth,
                                            transform.position.y + r * brickHeight,
                                            transform.position.z),
                                transform.rotation);
                }
            }
            else if (r == 5)
            {
                Debug.Log("hello 0 5");
                for (int c = 0; c < numCols; c++)
                {
                    Debug.Log("c = " + c);
                    Instantiate(brickPrefabs[2],
                new Vector3(transform.position.x + c * brickWidth,
                                            transform.position.y + r * brickHeight,
                                            transform.position.z),
                                transform.rotation);
                }
            }
            else if (r == 1 || r == 2)
            {
                //make another false condition for the columns that are 
                //if c==1234 c==89,10, then not spawn brick,

                Debug.Log("hello 1 2");
                for (int c = 0; c < numCols; c++)
                {
                    if (c == 1 || c == 2 || c == 3 || c == 8 || c == 9 || c == 10)
                    {
                        continue;
                    }
                    else
                    {
                        //Debug.Log("c = " + c);
                        Instantiate(brickPrefabs[3],
                    new Vector3(transform.position.x + c * brickWidth,
                                                transform.position.y + r * brickHeight,
                                                transform.position.z),
                                    transform.rotation);
                    }

                }
            }
            else if (r == 3 || r == 4)
            {
                Debug.Log("hello 3 4");
                for (int c = 0; c < numCols; c++)
                {
                    //if c 123489,10 then not spawn brick
                    //else spawn brick
                    if ((0 < c && 4 > c) || (7 < c && 11 > c))
                    {
                        continue;
                    }
                    else
                    {
                        //Debug.Log("c = " + c);
                        Instantiate(brickPrefabs[1],
                        new Vector3(transform.position.x + c * brickWidth,
                                                    transform.position.y + r * brickHeight,
                                                    transform.position.z),
                                        transform.rotation);
                    }
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
