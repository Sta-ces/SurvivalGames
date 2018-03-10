using UnityEditor;

[CustomEditor(typeof(LaserWeapon))]
public class Editor_LaserWeapon : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LaserWeapon laser = target as LaserWeapon;
        laser.CreateLaserWeapon();
    }
}