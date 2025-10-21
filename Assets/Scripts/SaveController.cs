using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour

{
    //public Color colorPlayer = Color.white;
   // public Color colorEnemy = Color.white;

    public Sprite Player;
    public Sprite Enemy;

    private static SaveController _instance;

    public Sprite spritePlayer;
    public Sprite spritePlayerHit;
    public Sprite spriteEnemy;
    public Sprite spriteEnemyHit;

    public string namePlayer;
    public string nameEnemy;

    private string SaveWinnerKey = "SavedWinner ";

    //Propriedade estática para acessar a instancia
    public static SaveController Instance
    {
        get
        {
            if (_instance == null)
            {
                //Procure a instancia na cena
                _instance = FindAnyObjectByType<SaveController>();

                //Se não encontrar, crie uma nova instancia
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            //Debug.Log("SaveController duplicado destruído");
            Destroy(gameObject);
            return;
        }

        _instance = this; // agora a instância é registrada corretamente
        DontDestroyOnLoad(gameObject);
        //Debug.Log("SaveController iniciado e persistente");
    }

    public string GetName(bool isplayer)
    {
        return isplayer ? namePlayer : nameEnemy;
    }

    public void Reset()
    {
        nameEnemy = " ";
        namePlayer = " ";
        spriteEnemy = Enemy != null ? Enemy : spriteEnemy;
        spritePlayer = Player != null ? Player : spritePlayer;
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString(SaveWinnerKey, winner);
    }

    public string GetLasWinner()
    {
    return PlayerPrefs.GetString(SaveWinnerKey);
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SetSpritePlayer(Sprite normal, Sprite hit)
    {
        spritePlayer = normal;
        spritePlayerHit = hit;
        PlayerPrefs.SetString("PlayerSpriteName", spritePlayer.name);
        PlayerPrefs.Save();
    }

    public void SetSpriteEnemy(Sprite normal, Sprite hit)
    {
        spriteEnemy = normal;
        spriteEnemyHit = hit;
        PlayerPrefs.SetString("EnemySpriteName", spriteEnemy.name);
        PlayerPrefs.Save();
    }
    public void LoadSavedSprites(Sprite[] allSprites)
    {
        string playerName = PlayerPrefs.GetString("PlayerSpriteName", "");
        string enemyName = PlayerPrefs.GetString("EnemySpriteName", "");

        foreach (Sprite s in allSprites)
        {
            if (s.name == playerName)
                spritePlayer = s;
            if (s.name == enemyName)
                spriteEnemy = s;
        }
    }
}
