using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammotype;
        public int ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        var ammoSlot = GetAmmoSlot(ammoType);
        return ammoSlot.ammoAmount;
    }

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        var ammoSlot = GetAmmoSlot(ammoType);
        ammoSlot.ammoAmount--;
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount)
    {
        var ammoSlot = GetAmmoSlot(ammoType);
        ammoSlot.ammoAmount += ammoAmount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (var slot in ammoSlots)
        {
            if (slot.ammotype == ammoType)
                return slot;
        }
        return null;
    }
}
