using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using UnityEngine;

[CreateAssetMenu]
public class SoSharedSpawnPositions : ScriptableObject
{
    public SoBlueprintSpawnPositions soBluePrintSpawnPositions;
    private List<Vector3> slots = new List<Vector3>();
    private List<Vector3> slotsTaken = new List<Vector3>();
    public void Reset() {
        slots.Clear();
        slotsTaken.Clear();
        foreach(Vector3 slot in soBluePrintSpawnPositions.Slots) {
            slots.Add(slot);
        }
    }

    public Vector3 TakeRandomSlot() {

        int i = Random.Range(0, slots.Count);
        Vector3 point = slots[i];
        slotsTaken.Add(slots[i]);
        slots.Remove(slots[i]);
        return point;
    }
    public void FreeSlot(Vector3 point) {
        for(int i=0; i < slotsTaken.Count; i++) {
            if (point == slotsTaken[i]) {
                slots.Add(point);
                slotsTaken.Remove(slotsTaken[i]);

            }
        }
    }
    public bool HasFreeSlots() {
        if(slots.Count > 0) {
            return true;
        } else {
            return false;
        }
    }
}
