using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DriveMenu : MonoBehaviour
{
   
   public void clickOffline()
   {
     SceneManager.LoadScene("Selection");
   }
  

  public void clickJoin()
  {
        SceneManager.LoadScene("MultiplayerLobby");
       
   }

   public void clickBack()
   {
    SceneManager.LoadScene("StartMenu");
   }

   

}