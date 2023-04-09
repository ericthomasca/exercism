using System;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public static bool operator ==(CurrencyAmount currencyAmount1, CurrencyAmount currencyAmount2)
    {
        if (currencyAmount1.currency == currencyAmount2.currency)
        {
            return currencyAmount1.amount == currencyAmount2.amount;
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public static bool operator !=(CurrencyAmount currencyAmount1, CurrencyAmount currencyAmount2)
    {
        if (currencyAmount1.currency == currencyAmount2.currency)
        {
            return currencyAmount1.amount != currencyAmount2.amount;
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public bool Equals(CurrencyAmount currencyAmount)  
   {  
        if (this.currency == currencyAmount.currency)
        {
            return this.amount == currencyAmount.amount;
        }
        else
        {
            throw new ArgumentException();
        } 
   }  
    
    public static bool operator <(CurrencyAmount currencyAmount1, CurrencyAmount currencyAmount2)
    {
        if (currencyAmount1.currency == currencyAmount2.currency)
        {
            return currencyAmount1.amount < currencyAmount2.amount;
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public static bool operator >(CurrencyAmount currencyAmount1, CurrencyAmount currencyAmount2)
    {
        if (currencyAmount1.currency == currencyAmount2.currency)
        {
            return currencyAmount1.amount > currencyAmount2.amount;
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public static CurrencyAmount operator +(CurrencyAmount currencyAmount1, CurrencyAmount currencyAmount2)
    {
        if (currencyAmount1.currency == currencyAmount2.currency)
        {
            return new CurrencyAmount(currencyAmount1.amount + currencyAmount2.amount, currencyAmount1.currency);
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public static CurrencyAmount operator -(CurrencyAmount currencyAmount1, CurrencyAmount currencyAmount2)
    {
        if (currencyAmount1.currency == currencyAmount2.currency)
        {
            return new CurrencyAmount(currencyAmount1.amount - currencyAmount2.amount, currencyAmount1.currency);
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public static CurrencyAmount operator *(CurrencyAmount currencyAmount1, decimal multipliedAmount)
        => new CurrencyAmount(currencyAmount1.amount * multipliedAmount, currencyAmount1.currency);

    public static CurrencyAmount operator /(CurrencyAmount currencyAmount1, decimal dividedAmount)
        => new CurrencyAmount(currencyAmount1.amount / dividedAmount, currencyAmount1.currency);
    
    public static explicit operator double(CurrencyAmount currencyAmount)
        => (double)currencyAmount.amount;

    public static implicit operator decimal(CurrencyAmount currencyAmount)
        => currencyAmount.amount;

    
}
