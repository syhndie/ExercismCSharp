using System;
using System.Threading.Tasks;

public class BankAccount
{
    private float _balance;
    private bool IsOpen;
    private object _lock = new object();

    public void Open()
    {
        IsOpen = true;
        _balance = 0; 
    }

    public void Close()
    {
        IsOpen = false;        
    }

    public float Balance
    {
        get
        {
            if (IsOpen) return _balance;
            throw new InvalidOperationException("This account is closed and may not be accessed.");
        }
    }

    public void UpdateBalance(float change)
    {
        lock (_lock)
        {
            if (IsOpen) _balance = _balance + change;
            else throw new InvalidOperationException("This account is closed and may not be accessed.");
        }
    }
}
