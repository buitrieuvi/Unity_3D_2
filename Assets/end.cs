using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class end : MonoBehaviour
{

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void back()
    {
        SceneManager.LoadScene(0);        
    }
}
