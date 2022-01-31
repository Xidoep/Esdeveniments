using XS_Utils;

[UnityEngine.CreateAssetMenu(menuName = "Xido Studio/Esdeveniment/Float")]
public class Canal_Float : Esdeveniment.Canal<float> {

    public override void Invocar(float arg)
    {
        base.Invocar(arg);
    }
    public void Invocar(int argument) => base.Invocar(argument);
    public void Invocar(string argument) => base.Invocar(argument.ToFloat()); 
}
