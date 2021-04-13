using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Turret))]
[CanEditMultipleObjects]
public class TurretEditor : Editor
{
    bool showLaserVFX;
    bool showSetupFields;

    public override void OnInspectorGUI()
    {
        var turretEditor = target as Turret;

        turretEditor.useLaser = GUILayout.Toggle(turretEditor.useLaser, "Is Laser Turret");
        GUILayout.Space(10f);
        

        if (turretEditor.useLaser)
        {
            turretEditor.range = EditorGUILayout.Slider("Range", turretEditor.range, 0f, 100f);
            turretEditor.damageOverTime = EditorGUILayout.IntSlider("DoT", turretEditor.damageOverTime, 1, 100);
            turretEditor.slowPrefab = (GameObject)EditorGUILayout.ObjectField("Debuff", turretEditor.slowPrefab, typeof(GameObject), true);

            showLaserVFX = EditorGUILayout.BeginFoldoutHeaderGroup(showLaserVFX, "Laser VFX");
            if (showLaserVFX)
            {
                turretEditor.lineRenderer = (LineRenderer)EditorGUILayout.ObjectField("Line Renderer", turretEditor.lineRenderer, typeof(LineRenderer), true);
                turretEditor.impactEffect = (ParticleSystem)EditorGUILayout.ObjectField("Impact Effect", turretEditor.impactEffect, typeof(ParticleSystem), true);
                turretEditor.impactLight = (Light)EditorGUILayout.ObjectField("Impact Light", turretEditor.impactLight, typeof(Light), true);
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

        }
        else
        {
            turretEditor.range = EditorGUILayout.Slider("Range", turretEditor.range, 0f, 100f);
            turretEditor.damage = EditorGUILayout.IntSlider("Damage", turretEditor.damage, 1, 100);
            turretEditor.fireRate = EditorGUILayout.Slider("Fire Rate", turretEditor.fireRate, 0f, 10f);
            turretEditor.projectileSpeed = EditorGUILayout.Slider("Projectile speed", turretEditor.projectileSpeed, 1, 200);
            turretEditor.explosionRadius = EditorGUILayout.Slider("Explosion Radius", turretEditor.explosionRadius, 0, 50);
        }

        showSetupFields = EditorGUILayout.BeginFoldoutHeaderGroup(showSetupFields, "Unity Setup Fields");
        if (showSetupFields)
        {
            turretEditor.enemyTag = EditorGUILayout.TextField("Enemy Tag", turretEditor.enemyTag);
            turretEditor.partToRotate = (Transform)EditorGUILayout.ObjectField("Part to rotate", turretEditor.partToRotate, typeof(Transform), true);
            turretEditor.rotationSpeed = EditorGUILayout.Slider("Turret rotation speed", turretEditor.rotationSpeed, 0, 100);
            turretEditor.bulletPrefab = (GameObject)EditorGUILayout.ObjectField("Bullet Prefab", turretEditor.bulletPrefab, typeof(GameObject), true);
            turretEditor.firePoint = (Transform)EditorGUILayout.ObjectField("Firepoint", turretEditor.firePoint, typeof(Transform), true);
        }
    }
}
