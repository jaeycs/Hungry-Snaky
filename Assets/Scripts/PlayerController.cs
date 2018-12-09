using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Button upButton;
    public Button downButton;
    public Button leftButton;
    public Button rightButton;

    public Player player;
    public GameManager gm;

    private float timer;

    private static int UP, DOWN, LEFT, RIGHT = 0;
    private static float ONE_UNIT = 0.72f;
    private static int FALSE = 0;
    private static int TRUE = 1;

    private void Start()
    {
        timer = 0;

        upButton.onClick.AddListener(onUpButtonClick);
        downButton.onClick.AddListener(onDownButtonClick);
        leftButton.onClick.AddListener(onLeftButtonClick);
        rightButton.onClick.AddListener(onRightButtonClick);

        // Go right direction as starting
        onRightButtonClick();

        // Add first head pos to the list
        gm.copyHead(new Vector3(transform.position.x, transform.position.y, transform.position.z));
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer > 1f)
        {
            // Move Head
            movePlayer();

            // Update Body positions and render it before adding the new head position to the list

            // Add new head position to the list
            gm.copyHead(new Vector3(transform.position.x, transform.position.y, transform.position.z));

            timer = 0;
        }
    }

    private void Update()
    {

    }

    // Keep the player moving in the direction it was moving
    private void movePlayer()
    {
        if (UP == TRUE)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + ONE_UNIT, transform.position.z);
            player.transform.rotation = Quaternion.Euler(player.transform.rotation.x, player.transform.rotation.y, 90f);
        }
        else if (DOWN == TRUE)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - ONE_UNIT, transform.position.z);
            player.transform.rotation = Quaternion.Euler(player.transform.rotation.x, player.transform.rotation.y, 270f);
        }
        else if (LEFT == TRUE)
        {
            transform.position = new Vector3(transform.position.x - ONE_UNIT, transform.position.y, transform.position.z);
            player.transform.rotation = Quaternion.Euler(player.transform.rotation.x, player.transform.rotation.y, 180f);
        }
        else if (RIGHT == TRUE)
        {
            transform.position = new Vector3(transform.position.x + ONE_UNIT, transform.position.y, transform.position.z);
            player.transform.rotation = Quaternion.Euler(player.transform.rotation.x, player.transform.rotation.y, 0f);
        }
    }

    public void onUpButtonClick()
    {
        if (DOWN == FALSE)
        {
            LEFT = FALSE;
            RIGHT = FALSE;
            UP = TRUE;
            DOWN = FALSE;
        }       
    }

    public void onDownButtonClick()
    {
        if (UP == FALSE)
        {
            LEFT = FALSE;
            RIGHT = FALSE;
            UP = FALSE;
            DOWN = TRUE;
        }
    }

    public void onLeftButtonClick()
    {
        if (RIGHT == FALSE)
        {
            LEFT = TRUE;
            RIGHT = FALSE;
            UP = FALSE;
            DOWN = FALSE;
        }
    }

    public void onRightButtonClick()
    {
        if (LEFT == FALSE)
        {
            LEFT = FALSE;
            RIGHT = TRUE;
            UP = FALSE;
            DOWN = FALSE;
        }
    }
}
