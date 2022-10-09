using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int currentLevel;
    public GameObject[] Menus;
    public GameObject[] Levels;
    public static LevelManager instance;
    private LevelManager()
    {

    }
      //this is a static method that returns the instance of the class
         
    

    public void Awake()
    {
           if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        // DontDestroyOnLoad(gameObject);

        // LoadNextLevel();
        HideAll();
        // DisableAll();
    }

    public void HideAll()
    {
        foreach (var level in Levels)
        {
            level.SetActive(false);
        }
    }
    public void HideMainMenu(){
        Menus[0].SetActive(false);
    }
    public void LoadNextLevel()
    {
        if(currentLevel<Levels.Length)
        {
        HideAll();
        Levels[currentLevel].SetActive(true);
        currentLevel++;
        }
    }
    
}
