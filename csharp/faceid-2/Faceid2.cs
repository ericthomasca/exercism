using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public bool Equals(FacialFeatures facialFeatures) => EyeColor == facialFeatures.EyeColor 
        && PhiltrumWidth == facialFeatures.PhiltrumWidth;

    public override int GetHashCode() => HashCode.Combine(EyeColor, PhiltrumWidth);
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public bool Equals(Identity identity) => Email == identity.Email 
        && FacialFeatures == identity.FacialFeatures;

    public override int GetHashCode() => HashCode.Combine(Email);
}

public class Authenticator
{
    public Dictionary<int, Identity> registered = new Dictionary<int, Identity>(); 
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) => identity.Email.Equals("admin@exerc.ism")
        && identity.FacialFeatures.EyeColor.Equals("green")
        && identity.FacialFeatures.PhiltrumWidth.Equals(0.9m);

    public bool Register(Identity identity) => registered.TryAdd(identity.GetHashCode(), identity);

    public bool IsRegistered(Identity identity) => registered.ContainsKey(identity.GetHashCode());

    public static bool AreSameObject(Identity identityA, Identity identityB) => identityA.Equals(identityB);
}
