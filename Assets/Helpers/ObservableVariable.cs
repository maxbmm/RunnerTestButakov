using System;
public class ObservableVariable<T>
{
    public event Action<T> OnChanged;

    private T _value;
    public T Value
    {
        get { return _value; }
        set {
            _value = value;
            OnChanged?.Invoke(value); 
        }
    }

    public ObservableVariable()
    {
        Value = default;
    }
    public ObservableVariable(T defaultValue)
    {
        Value = defaultValue;
    }
    
}
