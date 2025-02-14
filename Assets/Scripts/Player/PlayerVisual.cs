using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerVisual : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private SpriteRenderer characterRenderer;

    private const string IS_RUNNING = "IsRunning";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        characterRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        animator.SetBool(IS_RUNNING, Player.Instance.isRunning);
        AdjustPlayerFacingDirection();

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Object"); // Объекты с тегом "Object"
        foreach (GameObject obj in objects)
        {
            SpriteRenderer objRenderer = obj.GetComponent<SpriteRenderer>();
            if (objRenderer != null)
            {
                objRenderer.sortingOrder = -Mathf.RoundToInt(obj.transform.position.y * 100);
            }
        }

        characterRenderer.sortingOrder = -Mathf.RoundToInt(transform.position.y * 100); // Порядок рендеринга персонажа
    }


    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = GameInput.Instance.GetMousePosition();
        Vector3 playerPosition = Player.Instance.GetPlayerScreenPosition();

        if (mousePos.x < playerPosition.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
