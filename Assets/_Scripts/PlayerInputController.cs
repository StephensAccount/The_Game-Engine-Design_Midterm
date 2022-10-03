using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public PlayerAction inputAction;

    // Singleton: creating a instance
    public static PlayerInputController controller;

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }

    void Awake()
    {
        // instance
        if (controller == null)
        {
            controller = this;
        }

        inputAction = new PlayerAction();
    }
}
