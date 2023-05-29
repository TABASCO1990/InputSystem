using UnityEngine.InputSystem;

public class SimpleInteraction : IInputInteraction
{
    public float Duration = 0.2f; //чтобы отображался в окне InputAction

    // метод чтобы шаблон появился в меню выбора
    [UnityEditor.InitializeOnLoadMethod]
    private static void Register()
    {
        InputSystem.RegisterInteraction<SimpleInteraction>();
    }

    // обработка
    public void Process(ref InputInteractionContext context)
    {
        if (context.timerHasExpired)
        {
            context.Canceled();
            return;
        }

        switch (context.phase)
        {
            case InputActionPhase.Waiting: // ввод токо ожидается
                if(context.ReadValue<float>() == 1)
                {
                    context.Started(); // ввод считан
                    context.SetTimeout(Duration);
                }
                break;
            case InputActionPhase.Started:
                if(context.ReadValue<float>() == -1)
                {
                    context.Performed();
                }
                break;
        }
    }

    // в основном остаётся пустым
    // нужен для того чтобы сбросить состояние
    public void Reset()
    {
        
    }
}
