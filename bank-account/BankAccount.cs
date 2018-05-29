using System;



public class BankAccount
{
    private float _balance;

    public void Open()
    {
        _balance = 0; 
    }

    public void Close()
    {
        
    }

    public float Balance
    {
        get
        {
            return _balance;
        }
    }

    public void UpdateBalance(float change)
    {

    }
}
