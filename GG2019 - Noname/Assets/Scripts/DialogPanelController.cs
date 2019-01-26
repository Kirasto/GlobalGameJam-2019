using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogPanelController : MonoBehaviour
{
    [SerializeField]
    GameObject panel;
    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    float timeBetweenLetters = 0.2f;
    float timer;
    int letterIndex;
    string textToDraw;

    Player player;

    public static DialogPanelController instance;
    bool dialogOn;
    bool dialogWrite;

    private void Awake()
    {
        dialogOn = false;
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public static void setDialog(string dialog, bool blockMove = false)
    {
        instance.startDialog(dialog, blockMove);
    }

    public void startDialog(string dialog, bool blockMove)
    {
        if (instance)
        {
            dialogOn = true;
            panel.SetActive(true);
            timer = 0;
            textToDraw = dialog;
            letterIndex = 0;
            dialogWrite = true;
            if (player)
                player.canMove = false;
        }
    }

    void Update()
    {
        if (dialogOn && dialogWrite)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                letterIndex++;
                timer = timeBetweenLetters;
                text.SetText(textToDraw.Substring(0, letterIndex));
                if (letterIndex >= textToDraw.Length)
                    dialogWrite = false;
            }
        }

        if (dialogOn && !dialogWrite && Input.GetMouseButtonDown(0))
        {
            if (player)
                player.canMove = true;
            dialogOn = false;
            panel.SetActive(false);
        }
    }
}
