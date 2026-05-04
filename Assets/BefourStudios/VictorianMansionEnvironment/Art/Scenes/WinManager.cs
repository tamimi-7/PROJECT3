using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinManager : MonoBehaviour
{
    public AudioSource pianoAudio;
    public Image blackScreen;
    public GameObject winText;
    public float fadeSpeed = 0.5f;

    public void TriggerWin()
    {
       
        if (pianoAudio != null) pianoAudio.Play();

       
        StartCoroutine(FadeToBlack());
    }

    IEnumerator FadeToBlack()
    {
        if (blackScreen != null)
        {
         
            blackScreen.gameObject.SetActive(true);

            Color screenColor = blackScreen.color;
           
            screenColor.a = 0f;
            blackScreen.color = screenColor;

           
            while (screenColor.a < 1f)
            {
                screenColor.a += fadeSpeed * Time.unscaledDeltaTime;
                blackScreen.color = screenColor;
                yield return null;
            }
        }

       
        if (winText != null)
        {
            winText.SetActive(true);
        }


        Time.timeScale = 0f;
    }
}