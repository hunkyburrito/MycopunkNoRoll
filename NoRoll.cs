using HarmonyLib;
using UnityEngine;
using Pigeon.Movement;

namespace NoRoll.Patches;

[HarmonyPatch(typeof(Pigeon.Movement.Headbob))]
public class RollPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Pigeon.Movement.Headbob.RollCoroutine))]
    private static void OnRoll(ref float speed, ref AnimationCurve rotationCurve, AnimationCurve positionCurve, Vector3 addPosition, float zRotation)
    {
        rotationCurve.ClearKeys();
        speed = 10;

    }
}
