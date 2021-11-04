using System;
using XS_Utils;

[UnityEngine.CreateAssetMenu(menuName = "Xido Studio/Esdeveniment/Float")]
public class Canal_Float : Esdeveniment.Canal<float> {
    public void Emetre(int argument) => Invocar(argument);
    public void Emetre(float argument) => Invocar(argument);
    public void Emetre(string argument) => Invocar(argument.ToFloat()); 
}
