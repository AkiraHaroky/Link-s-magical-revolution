using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialogues : MonoBehaviour
{
    [SerializeField] private GameObject dialog_K;
    [SerializeField] private GameObject pointer;
    [SerializeField] private GameObject border_Dialogue;
    [SerializeField] private GameObject buttonNext; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Link"))
        {
            dialog_K.SetActive(true);
        }
    }

    public void EndDialogueK()
    {
        dialog_K.SetActive(false);
        pointer.SetActive(true);
        border_Dialogue.SetActive(false);
        Destroy(gameObject);
    }

    public void NextLevel()
    {
        buttonNext.SetActive(true);
    }

    public void Nextnow()
    {
        SceneManager.LoadScene("Fight_2");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
