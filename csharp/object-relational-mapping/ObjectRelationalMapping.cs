using System;

public class Orm : IDisposable
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
        switch (database.DbState)
        {
            case Database.State.Closed:
                database.BeginTransaction();
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public void Write(string data)
    {
        try
        {
            switch (database.DbState)
            {
                case Database.State.TransactionStarted:
                    database.Write(data);
                    break;
                default:
                    database.Dispose();
                    throw new InvalidOperationException();
            }
        }
        catch
        {
            database.Dispose();
            throw new InvalidOperationException();
        }
            
    }

    public void Commit()
    {
        try
        {
            switch (database.DbState)
            {
            case Database.State.DataWritten:
                database.EndTransaction();
                break;
            default:
                throw new InvalidOperationException();
            }
        }
        catch
        {
            throw new InvalidOperationException();
        }
        
    }

    public void Dispose() => database.Dispose();
}
