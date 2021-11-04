using System;
using XS_Utils;


[UnityEngine.CreateAssetMenu(menuName = "Xido Studio/Esdeveniment/Int")]
public class Canal_Integre : Esdeveniment.Canal<int> { 
    public void Emetre(int argument) => Invocar(argument);
    public void Emetre(Single argument) => Invocar((int)argument);
    public void Emetre(string argument) => Invocar(argument.ToInt());
}
