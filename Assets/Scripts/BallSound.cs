using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BollSound : MonoBehaviour
{
    public AudioClip bounceSound; // Som da bola batendo
    private AudioSource audioSource;

    void Start()
    {
        // Garante que há um AudioSource no mesmo GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false; // Não tocar sozinho
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se bateu em jogador, parede, etc
        if (collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("Wall") ||
            collision.gameObject.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(bounceSound);
        }
    }
}
