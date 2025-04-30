using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCross : MonoBehaviour
{
    [SerializeField] GameObject Cross;
    private bool starExists = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) && !starExists)
        {
            GameObject obj = Instantiate(Cross);
            starExists = true;
            //obj.GetComponent<spin>().();
        }

        // if (Input.GetKeyUp(KeyCode.Return)&& starExists)
        //{
        // starExists = false;
    }
}




