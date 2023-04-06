using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectDeath : MonoBehaviour
{
    private string _tag;

    private void Start()
    {
        _tag = gameObject.tag;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TriggerDeathAll") || (collision.gameObject.CompareTag("TriggerDeathAngel") && _tag == "Angel") || (collision.gameObject.CompareTag("TriggerDeathDemon") && _tag == "Demon"))
        {
            CharacterDeath();
        }
    }

    private void CharacterDeath()
    {
        SceneManager.LoadScene("_Aleksandr");
    }
}