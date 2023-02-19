using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MasterSceneManager : MonoBehaviour
{
    public bool UseMe;
    public Canvas MM;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += SceneSwapper;
        SceneManager.LoadScene(1);
    }
    public void OnDestroy()
    {
        SceneManager.sceneLoaded -= SceneSwapper;
    }
    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void SceneSwapper(Scene s, LoadSceneMode m)
    {
        MasterSceneManager[] temp = GameObject.FindObjectsOfType<MasterSceneManager>();
        if(temp.Length == 1)
        {
            UseMe = true;
        }
        else if (UseMe)
        {
            Destroy(this.gameObject);
        }
        if(s.buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
        if(s.buildIndex == 1)
        {
            MM.gameObject.SetActive(true);
        }
        else
        {
            MM.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelLoader(int level)
    {
        SceneManager.LoadScene(level);
    }
}
