using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Reflection;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Esdeveniment
{
    public class Canal : ScriptableObject
    {
        [SerializeField] [Informacio] string escoltadors = "Registraren la funcio que tenen tant aviat com poden i esperen. No saben els valors.";
        [SerializeField] [Informacio] string emisors = "Criden les funcions registrades quan volen, aportant els valors.";
        [SerializeField] [Informacio] string funcions = "";
        [SerializeField] [Informacio] string registrar = "Afageix les funcions amb els (VALORS) que es vulguin cridar mes endevant.";
        [SerializeField] [Informacio] string invocar = "Crida les funcions registrades amb els (VALORS) que es passin";
        [SerializeField] [Informacio] string aquest = "";

    }

    public class CanalVoid : Canal
    {
        UnityAction enInvocar;

        public void Registrar(UnityAction value) => enInvocar += value; 
        public void Desregistrar(UnityAction value) => enInvocar -= value;
        public void Netejar() => enInvocar = null;

        public virtual void Invocar() => enInvocar?.Invoke();
    }

    public class Canal<T> : Canal
    {
        UnityAction<T> enInvocar;

        public void Registrar(UnityAction<T> value) => enInvocar += value; 
        public void Desregistrar(UnityAction<T> value) => enInvocar -= value; 
        public void Netejar() => enInvocar = null;

        public virtual void Invocar(T arg) => enInvocar?.Invoke(arg);

    }
    public class Canal<T1, T2> : Canal
    {
        UnityAction<T1, T2> enInvocar;

        public void Registrar(UnityAction<T1, T2> value) => enInvocar += value;
        public void Desregistrar(UnityAction<T1, T2> value) => enInvocar -= value; 
        public void Netejar() => enInvocar = null;

        public virtual void Invocar(T1 arg1, T2 arg2) => enInvocar?.Invoke(arg1, arg2);

    }
    public class Canal<T1, T2, T3> : Canal
    {
        UnityAction<T1, T2, T3> enInvocar;

        public void Registrar(UnityAction<T1, T2, T3> value) => enInvocar += value; 
        public void Desregistrar(UnityAction<T1, T2, T3> value) => enInvocar -= value; 
        public void Netejar() => enInvocar = null;

        public virtual void Invocar(T1 arg1, T2 arg2, T3 arg3) => enInvocar?.Invoke(arg1, arg2, arg3);

    }

    public abstract class CanalRetorn<T, R> : Canal
    {
        public delegate R EnInvocar(T arg);
        EnInvocar enInvocar;

        public void Registrar(EnInvocar value) => enInvocar += value; 
        public void Desregistrar(EnInvocar value) => enInvocar -= value; 
        public void Netejar() => enInvocar = null;

        public virtual R Invocar(T arg)
        {
            if (enInvocar != null)
                return Success(arg);
            else return Nul();
        }

        R Success(T arg) => enInvocar.Invoke(arg);

        /// <summary>
        /// funcio pensada per retornar un valor en cas que enInvocar sigui null;
        /// </summary>
        /// <returns></returns>
        public abstract R Nul();
    }
    public abstract class CanalRetorn<T1, T2, R> : Canal
    {
        public delegate R EnInvocar(T1 arg1, T2 arg2);
        EnInvocar enInvocar;

        public void Registrar(EnInvocar value) => enInvocar += value; 
        public void Desregistrar(EnInvocar value) => enInvocar -= value; 
        public void Netejar() => enInvocar = null;

        public virtual R Invocar(T1 arg1, T2 arg2)
        {
            if (enInvocar != null)
                return Success(arg1, arg2);
            else return Nul();
        }

        R Success(T1 arg1, T2 arg2) => enInvocar.Invoke(arg1, arg2);

        /// <summary>
        /// funcio pensada per retornar un valor en cas que enInvocar sigui null;
        /// </summary>
        /// <returns></returns>
        public abstract R Nul();
    }
}

