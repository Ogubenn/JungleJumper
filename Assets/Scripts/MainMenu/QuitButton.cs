using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("��k�� yap�ld�");
        Application.Quit();
    }

    public void CharacterSelection()
    {
        SceneManager.LoadScene(1);
    }

}//class
