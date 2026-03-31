using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public RoundCounter round;
    public int numBaskets = 4;
    public float basketBottomY = -14f,
                 basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        round = GameObject.Find("RoundCounter").GetComponent<RoundCounter>();
        for (int i = 0; i < numBaskets; i++) {
            GameObject tBasketGO = Instantiate(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (i * basketSpacingY);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AppleMissed()
    {
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject apple in apples)
            Destroy(apple);

        GameObject[] branches = GameObject.FindGameObjectsWithTag("Branch");
        foreach (GameObject branch in branches)
            Destroy(branch);

        int basketIndex = basketList.Count - 1;
        GameObject basketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        if (basketList.Count == 0)
            GameOver();
        else
        {
            round.text.text = "Round " + (numBaskets - basketList.Count + 1).ToString();
        }
    }

    public void GameOver()
    {
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject apple in apples)
            Destroy(apple);

        GameObject[] branches = GameObject.FindGameObjectsWithTag("Branch");
        foreach (GameObject branch in branches)
            Destroy(branch);

        round.text.text = "Game Over";
        AppleTree tree = GameObject.FindObjectOfType<AppleTree>();
        tree.functional = false;
    }

    public void OnMouseDown()
    {
        SceneManager.LoadScene("_Scene_0");
    }
}
