using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//import scene management
using UnityEngine.SceneManagement;
public class RestartController : MonoBehaviour
{
   
    public void RestartGame()
    {
         SceneManager.LoadScene("Menu");
    }
    
}
