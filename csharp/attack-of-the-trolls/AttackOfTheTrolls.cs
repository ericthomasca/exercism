using System;

enum AccountType
{
    Guest,
    User,
    Moderator
}

[Flags]
enum Permission
{
    None = 0,
    Read = 1,
    Write = 2,
    Delete = 4,
    All = 7
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        var permission = accountType switch
        {
            AccountType.Guest => Permission.Read,
            AccountType.User => Permission.Read | Permission.Write,
            AccountType.Moderator => Permission.Read | Permission.Write | Permission.Delete,
            _ => Permission.None
        };
        return permission;
    }

    public static Permission Grant(Permission current, Permission grant)
    {
        var permission = ((current, grant)) switch
        {
            (Permission.Read, Permission.Read) => Permission.Read,
            (Permission.None, Permission.Read) => Permission.Read,
            (Permission.None, Permission.Read | Permission.Write) => Permission.Read | Permission.Write,
            (Permission.Read | Permission.Write, Permission.Delete) => Permission.All,
            (Permission.None, Permission.All) => Permission.All,
            _ => throw new ArgumentException()
        };
        return permission;
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        var permission = ((current, revoke)) switch
        {
            (Permission.Write, Permission.Write) => Permission.None,
            (Permission.Read, Permission.None) => Permission.Read,
            (Permission.Write | Permission.Delete, Permission.Read | Permission.Write) => Permission.Delete,
            (Permission.Read | Permission.Write, Permission.All) => Permission.None,
            (Permission.All, Permission.Delete) => Permission.Read | Permission.Write,
            _ => throw new ArgumentException()
        };
        return permission;
    }

    public static bool Check(Permission current, Permission check)
    {
        bool authorized = ((current, check)) switch
        {
            (Permission.None, Permission.Read) => false,
            (Permission.Write, Permission.Write) => true,
            (Permission.All, Permission.Write) => true,
            (Permission.Read | Permission.Write, Permission.Read) => true,
            (Permission.Read | Permission.Write, Permission.Read | Permission.Write) => true,
            (Permission.Read | Permission.Write, Permission.Read | Permission.Delete) => false,
            (Permission.Read | Permission.Write, Permission.Write | Permission.Delete) => true,
            (Permission.Read | Permission.Write | Permission.Delete, Permission.All) => true,
            _ => throw new ArgumentException()
        };
        return authorized;
    }
}
