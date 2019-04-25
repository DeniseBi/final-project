using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CnvaseMeneger : MonoBehaviour
{
    public LoadAssetBundles loadAssetBundles;
    public GameObject TemplatesPanel;
    public GameObject player;
    public GameObject MenuCamera;
    public GameObject PauseMenu;
    public HidePointer pointer;
    public GameObject pauseText;

    private bool EnablePause;

    //Data for the asset bundle
    string clickedBtnName;
    string path;

    //Set up
    private void Start()
    {
        player.SetActive(false);
        MenuCamera.SetActive(true);
        TemplatesPanel.SetActive(true);
        PauseMenu.SetActive(false);
        pauseText.SetActive(false);
        EnablePause = false;

    }

    private void Update()
    {
        //Enable to pause the game 
        if(EnablePause)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Pause();
            }
        }
       
    }

    public void LoadAssetBundel(Button clickedBtn)
    {
        //Load the required asset bundle
        clickedBtnName = clickedBtn.name;
        path = @"Assets/AssetBundles\" + clickedBtnName;
        loadAssetBundles.LoadAssetBundle(path);

        //set up the game UI
        TemplatesPanel.SetActive(false);
        MenuCamera.SetActive(false);
        pauseText.SetActive(true);
        EnablePause = true;
        Time.timeScale = 1.0f;
    }
    
    //Puase the game and set up the required UI
    public void Pause()
    {
        Time.timeScale = 0.0f;
        pointer.HideOrShowPointer();
        PauseMenu.SetActive(true);
        MenuCamera.SetActive(true);
        player.SetActive(false);
        pauseText.SetActive(false);
        EnablePause = false;
    }

    //Continue the game and set up the required UI
    public void ContinueBtn()
    {
        Time.timeScale = 1.0f;
        pointer.HideOrShowPointer();
        player.SetActive(true);
        pauseText.SetActive(true);
        PauseMenu.SetActive(false);
        MenuCamera.SetActive(false);
        EnablePause = true;
    }

    //Initialize the game
    public void BackToMainMenuBtn()
    {
        SceneManager.LoadScene(0);
    }

}
