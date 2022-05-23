using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    [SerializeField]
    private GameObject  dialogPanelPrefab;
    [SerializeField]
    private GameObject  mainCanvas;
    [SerializeField]
    private PauseGame   pause;

    private CanvasGroup canvasGroup;

    private bool isActive = false;

    private void Start()
    {
        canvasGroup = mainCanvas.GetComponentInChildren<CanvasGroup>();
    }

    private void YesPressed()
    {
        Application.Quit();
    }

    private void NoPressed()
    {
        isActive = false;

        pause.Unpause();
        if (canvasGroup)
            canvasGroup.interactable = true;
    }

    public void Exit()
    {
        if (isActive == true) // Prevent multiple dialog windows to open at the same time
            return ;
        isActive = true;

        if (canvasGroup)
            canvasGroup.interactable = false; // Disable main canvas group, so it won't work while the dialog window is opened
        YesNoDialog.ShowDialog
        (
            Instantiate(dialogPanelPrefab, mainCanvas.transform),
            null,
            "Are you sure want to quit?",

            "Yes",
            () => YesPressed(),

            "No",
            () => NoPressed()
        );

        pause.Pause();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }
}
