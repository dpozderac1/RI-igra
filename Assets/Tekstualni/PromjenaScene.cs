using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PromjenaScene : MonoBehaviour
{
    static int brojPrethodneScene = 0;
    
    public void ucitajScenu(string naziv)
    {
        brojPrethodneScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(naziv);
    }

    public void vratiSeNaPrethodnuScenu()
    {
        SceneManager.LoadScene(brojPrethodneScene);
    }
}
