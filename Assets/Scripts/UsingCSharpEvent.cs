using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class UsingCSharpEvent : MonoBehaviour
{

    #region Def

    public readonly static string MapUI = "UI";
    public readonly static string MapGame = "Player";

    #endregion

    #region Event

    public event System.Action<Vector2> onUINavigate;
    public event System.Action onUIConfirm;
    public event System.Action onUIReturn;
    public event System.Action onUISubmit;
    public event System.Action onUICancel;

    public event System.Action<Vector2> onGameMove;
    public event System.Action onGameFire;
    public event System.Action onGameOption;
    public event System.Action onGameMenu;

    #endregion

    #region Attribute

    PlayerInput m_Inptut;

    #endregion

    #region Lifecycle

    void Awake()
    {
        m_Inptut = GetComponent<PlayerInput>();

        m_Inptut.onActionTriggered +=
            ctx =>
        {
            if (ctx.action.name == "Navigate")
            {
                OnNavigate(ctx);
            }
            if (ctx.action.name == "Confirm")
            {
                OnConfirm(ctx);
            }
        };

    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    // void Update()
    // {
    // }

    #endregion

    #region Method

    #region Map

    public void SwitchMap(string name)
    {
        if (m_Inptut == null || !m_Inptut.inputIsActive)
        {
            return;
        }
        m_Inptut.SwitchCurrentActionMap(name);
    }

    public void SwitchMap2UI()
    {
        SwitchMap(MapUI);
    }

    public void SwitchMap2Game()
    {
        SwitchMap(MapGame);
    }

    #endregion

    #region UI

    public void OnNavigate(InputAction.CallbackContext ctx)
    {
        var value = ctx.ReadValue<Vector2>();
        Debug.LogFormat("OnNavigate: {0}", value);
        onUINavigate?.Invoke(value);
    }

    public void OnConfirm(InputAction.CallbackContext ctx)
    {
        Debug.LogFormat("OnConfirm: {0}", ctx.phase);
        if (ctx.phase == InputActionPhase.Performed)
        {
            onUIConfirm?.Invoke();
        }
    }

    void OnReturn(InputValue ctx)
    {
        Debug.LogFormat("OnReturn: {0}", ctx.isPressed);
        if (ctx.isPressed)
        {
            onUIReturn?.Invoke();
        }
    }

    void OnClick(InputValue ctx)
    {
        Debug.LogFormat("OnClick: {0}", ctx.isPressed);
    }

    void OnSubmit(InputValue ctx)
    {
        Debug.LogFormat("OnSubmit");
        onUISubmit?.Invoke();
    }

    void OnCancel(InputValue ctx)
    {
        Debug.LogFormat("OnCancel");
        onUICancel?.Invoke();
    }

    #endregion

    #region Game

    void OnMove(InputValue ctx)
    {
        var value = ctx.Get<Vector2>();
        Debug.LogFormat("OnMove: {0}", value);
        onGameMove?.Invoke(value);
    }

    void OnFire(InputValue ctx)
    {
        Debug.LogFormat("OnFire: {0}", ctx.isPressed);
        if (ctx.isPressed)
        {
            onGameFire?.Invoke();
        }
    }

    void OnOption(InputValue ctx)
    {
        Debug.LogFormat("OnOption: {0}", ctx.isPressed);
        if (ctx.isPressed)
        {
            onGameOption?.Invoke();
        }
    }

    void OnMenu(InputValue ctx)
    {
        Debug.LogFormat("OnMenu: {0}", ctx.isPressed);
        if (ctx.isPressed)
        {
            onGameMenu?.Invoke();
        }
    }

    #endregion

    #endregion

}
