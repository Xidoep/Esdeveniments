using UnityEngine;
using UnityEngine.Events;

public class Escoltador_Bool : MonoBehaviour
{
    public Canal_Bool canal;
    public UnityEvent<bool> escoltador;
    public UnityEvent enTrue;
    public UnityEvent enFalse;

    private void OnEnable() 
    {
        if (enTrue != null || enFalse != null) canal.Registrar(escoltadorTrueFalse);
        canal.Registrar(escoltador.Invoke);
    }
    private void OnDisable() 
    {
        if(enTrue != null || enFalse != null) canal.Desregistrar(escoltadorTrueFalse);
        canal.Desregistrar(escoltador.Invoke);
    }

    void escoltadorTrueFalse(bool resultat)
    {
        if (resultat) enTrue?.Invoke();
        else enFalse?.Invoke();
    }
}
