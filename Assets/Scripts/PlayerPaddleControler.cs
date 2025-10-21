using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPaddleControler : MonoBehaviour
{
    public float speed = 5f;
    public string movementAxisName = "Vertical";
    public bool isPlayer = true;
    public SpriteRenderer spriteRenderer;

    public List<Sprite> allSprites;

    // Sprites de Efeito
    public Sprite currentBaseSprite; // sprite padrão
    public Sprite hitSprite;         // sprite quando colide

    private bool isHit = false;

    public Image paddleImage; // arrastar a imagem do jogador no inspector

    private void Start()
    {
        if (SaveController.Instance == null)
        {
           // Debug.LogWarning("SaveController não encontrado!");
            return;
        }

        //  Obtem sprites salvos, se existirem
        Sprite savedBase = isPlayer
            ? SaveController.Instance.spritePlayer
            : SaveController.Instance.spriteEnemy;

        Sprite savedHit = isPlayer
            ? SaveController.Instance.spritePlayerHit
            : SaveController.Instance.spriteEnemyHit;

        //  Fallback: se nao houver sprite salvo, mantem o que esta no Inspector
        if (savedBase != null)
        {
            currentBaseSprite = savedBase;
        }
        else
        {
           // Debug.Log("Nenhum sprite salvo para {(isPlayer ? "PLAYER" : "ENEMY")}, mantendo o padrao do Inspector.");
        }

        //  Define o sprite hit:
        // 1️ Se houver salvo no SaveController, usa ele
        // 2️ Senão, tenta encontrar na lista allSprites
        // 3️ Se nada for encontrado, mantem o do Inspector
        if (savedHit != null)
        {
            hitSprite = savedHit;
        }
        else
        {
            Sprite autoFoundHit = FindHitSpriteFor(currentBaseSprite);
            if (autoFoundHit != null)
            {
                hitSprite = autoFoundHit;
               // Debug.Log("Hit Sprite encontrado automaticamente: {hitSprite.name}");
            }
            else
            {
                //Debug.Log("Usando Hit Sprite padrao do Inspector para {(isPlayer ? "PLAYER" : "ENEMY")}.");
            }
        }

        //  Aplica sprite inicial
        if (currentBaseSprite != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = currentBaseSprite;
        }

        //Debug.Log("Sprite final para {(isPlayer ? "PLAYER" : "ENEMY")}: {currentBaseSprite?.name ?? "NULO"} | Hit: {hitSprite?.name ?? "NULO"}");
    }

    void Update()
    {
        float moveInput = Input.GetAxis(movementAxisName);
        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;
        newPosition.y = Mathf.Clamp(newPosition.y, -2.90f, 2.90f);
        transform.position = newPosition;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isHit && collision.gameObject.CompareTag("Ball"))
        {
            isHit = true;

            if (hitSprite != null)
                spriteRenderer.sprite = hitSprite;

            Invoke(nameof(ReturnToNormal), 0.2f);
        }
    }

    void ReturnToNormal()
    {
        spriteRenderer.sprite = currentBaseSprite;
        isHit = false;
    }

    //Funcao que procura o sprite de hit baseado no nome do sprite base
    Sprite FindHitSpriteFor(Sprite baseSprite)
    {
        if (baseSprite == null || allSprites == null || allSprites.Count == 0)
            return null;

        string expectedHitName = baseSprite.name + "_Hit";

        foreach (var s in allSprites)
        {
            if (s != null && s.name == expectedHitName)
                return s;
        }

        Sprite hitFromResources = Resources.Load<Sprite>(expectedHitName);
        if (hitFromResources != null)
            return hitFromResources;

        return null;
    }
}


