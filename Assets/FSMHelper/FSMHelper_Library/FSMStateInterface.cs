using UnityEngine;
using System.Collections;

namespace FSMHelper
{
    /// <summary>
    /// We need an interface for validation of base states, since we allow the user to 
    /// specify any class type when adding children into the definition, or when transiting to another state
    /// </summary>
    public interface FSMStateInterface
    {
        void Enter();
        void Update();
        void Exit();
    }

}
