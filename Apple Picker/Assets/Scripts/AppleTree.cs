using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public bool functional = true;
    public GameObject applePrefab,
                      branchPrefab;
    public float speed = 1f,
                 leftAndRightEdge = 10f,
                 changeDirChance = 0.1f,
                 appleDropDelay = 1f,
                 branchDropChance = 0.25f;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        if (!functional)
            return;
        if (Random.value > branchDropChance)
        {
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position;
        }
        else
        {
            GameObject branch = Instantiate<GameObject>(branchPrefab);
            branch.transform.position = transform.position;
            //branch.transform.rotation = 
        }
        Invoke("DropApple", appleDropDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (!functional)
            return;
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //if (Mathf.Abs(pos.x) <= leftAndRightEdge)
        //{
        //    speed *= -1;
        //}
        if (pos.x < -leftAndRightEdge)
            speed = Mathf.Abs(speed);
        else if (pos.x > leftAndRightEdge)
            speed = -Mathf.Abs(speed);
    }

    void FixedUpdate()
    {
        if (Random.value < changeDirChance)
            speed *= -1;
    }
}
