using UnityEditor;

[CustomEditor(typeof(Weapon))]
public class Editor_Weapon : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Weapon weapon = target as Weapon;
        weapon.LaserWeapon();
    }
}
