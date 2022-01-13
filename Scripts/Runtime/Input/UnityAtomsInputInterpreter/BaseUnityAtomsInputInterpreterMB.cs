using niscolas.UnityUtils.Core;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.InputSystem;

namespace niscolas.UnityUtils.Extras
{
    public abstract class BaseUnityAtomsInputInterpreterMB<T, P, C, V, E1, E2, EI, ER, F, VI, R> :
        CachedMonoBehaviour
        where T : struct
        where P : struct, IPair<T>
        where C : AtomBaseVariable<T>
        where V : AtomVariable<T, P, E1, E2, F>
        where E1 : AtomEvent<T>
        where E2 : AtomEvent<P>
        where EI : AtomEventInstancer<T, E1>
        where ER : AtomEventReference<T, V, E1, VI, EI>
        where F : AtomFunction<T, T>
        where VI : AtomVariableInstancer<V, P, T, E1, E2, F>
        where R : AtomReference<T, P, C, V, E1, E2, F, VI>
    {
        [SerializeField]
        private ER _startedEvent;

        [SerializeField]
        private ER _performedEvent;

        [SerializeField]
        private ER _canceledEvent;

        [SerializeField]
        private ER _waitingEvent;

        [SerializeField]
        private ER _disabledEvent;

        [SerializeField]
        private R _value;

        [SerializeField]
        private BoolReference _valueAsButton;

        protected const string NiceClassSuffix = " Unity Atoms Input Interpreter";

        private bool _initialized;

        private void OnEnable()
        {
            _initialized = true;
        }

        public void Interpret(InputAction.CallbackContext context)
        {
            Raise(context);
            UpdateValues(context);
        }

        public void Raise(InputAction.CallbackContext context)
        {
            T value = context.ReadValue<T>();
            switch (context.phase)
            {
                case InputActionPhase.Disabled:
                    if (_disabledEvent?.Event) _disabledEvent?.Event.Raise(value);

                    break;

                case InputActionPhase.Waiting:
                    if (_waitingEvent?.Event) _waitingEvent?.Event.Raise(value);

                    break;

                case InputActionPhase.Started:
                    if (_startedEvent?.Event) _startedEvent?.Event.Raise(value);

                    break;

                case InputActionPhase.Performed:
                    if (_performedEvent?.Event) _performedEvent?.Event.Raise(value);

                    break;

                case InputActionPhase.Canceled:
                    if (_canceledEvent?.Event) _canceledEvent?.Event.Raise(value);

                    break;
            }
        }

        public void UpdateValues(InputAction.CallbackContext context)
        {
            if (!_initialized)
            {
                return;
            }

            if (_value != null)
            {
                _value.Value = context.ReadValue<T>();
            }

            if (!_valueAsButton.IsUnassigned)
            {
                _valueAsButton.Value = context.ReadValueAsButton();
            }
        }
    }
}