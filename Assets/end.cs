using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class end : MonoBehaviour
{

    public GameObject panel_end;

    // Start is called before the first frame update
    void Start()
    {
        if (true) 
        {
            StartCoroutine(n());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator n() 
    {
        panel_end.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);


    }
}
