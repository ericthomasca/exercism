using System;

abstract class Character
{
    public string characterType;

    protected Character(string characterType)
    {
        this.characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return String.Format("Character is a {0}", this.characterType);
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{
    private bool spellPrepared;
    public Wizard() : base("Wizard")
    {
        this.spellPrepared = false;
    }

    public override int DamagePoints(Character target)
    {
        return spellPrepared ? 12 : 3;
    }

    public void PrepareSpell()
    {
        this.spellPrepared = true;
    }

    public override bool Vulnerable()
    {
        return !this.spellPrepared;
    }
}
