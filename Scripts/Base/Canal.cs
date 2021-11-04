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

        public UnityAction Registrar { set { enInvocar += value; } }
        public UnityAction Desregistrar { set { enInvocar -= value; } }
        public void Netejar() => enInvocar = null;

        public void Invocar()
        {
            if (enInvocar != null)
            {
                enInvocar.Invoke();
            }
        }
    }

    public class Canal<T> : Canal
    {
        UnityAction<T> enInvocar;

        public UnityAction<T> Registrar { set { enInvocar += value; } }
        public UnityAction<T> Desregistrar { set { enInvocar -= value; } }
        public void Netejar() => enInvocar = null;

        public void Invocar(T arg)
        {
            if(enInvocar != null)
            {
                enInvocar.Invoke(arg);
            }
        }
        
    }
    public class Canal<T1, T2> : Canal
    {
        UnityAction<T1, T2> enInvocar;

        public UnityAction<T1, T2> Registrar { set { enInvocar += value; } }
        public UnityAction<T1, T2> Desregistrar { set { enInvocar -= value; } }
        public void Netejar() => enInvocar = null;

        public void Invocar(T1 arg1, T2 arg2)
        {
            if (enInvocar != null)
            {
                enInvocar.Invoke(arg1, arg2);
            }
        }

    }
    public class Canal<T1, T2, T3> : Canal
    {
        UnityAction<T1, T2, T3> enInvocar;

        public UnityAction<T1, T2, T3> Registrar { set { enInvocar += value; } }
        public UnityAction<T1, T2, T3> Desregistrar { set { enInvocar -= value; } }
        public void Netejar() => enInvocar = null;

        public void Invocar(T1 arg1, T2 arg2, T3 arg3)
        {
            if (enInvocar != null)
            {
                enInvocar.Invoke(arg1, arg2, arg3);
            }
        }

    }

    public abstract class CanalRetorn<T, R> : Canal
    {
        public delegate R EnInvocar(T arg);
        EnInvocar enInvocar;

        public EnInvocar Registrar { set { enInvocar += value; } }
        public EnInvocar Desregistrar { set { enInvocar -= value; } }
        public void Netejar() => enInvocar = null;

        public R Invocar(T arg)
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

        public EnInvocar Registrar { set { enInvocar += value; } }
        public EnInvocar Desregistrar { set { enInvocar -= value; } }
        public void Netejar() => enInvocar = null;

        public R Invocar(T1 arg1, T2 arg2)
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

