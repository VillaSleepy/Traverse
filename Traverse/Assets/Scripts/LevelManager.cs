using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private GameObject[] getEnemyAmount;
    private int enemyAmount;
    private int loadLevel = 1;
    private int currentScene;

    private void Update()
    {
        //dot.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        getEnemyAmount = GameObject.FindGameObjectsWithTag("Enemy");
        enemyAmount = getEnemyAmount.Length;

        currentScene = SceneManager.GetActiveScene().buildIndex;

        if (enemyAmount <= 0 && currentScene == loadLevel - 1 && currentScene != 0 && currentScene != 1)
        {
            NextLevel();
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(sceneBuildIndex:loadLevel, LoadSceneMode.Single);
        loadLevel++;
    }

}
