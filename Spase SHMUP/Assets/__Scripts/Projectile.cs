using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private BoundsCheck bndCheck;
    private Renderer rend;
    public static bool moveChancher = false;
    public float y0;
    public Transform proj;

    [Header("Set Dinamically")]
    public Rigidbody rigid;
    [SerializeField]
    private WeaponType _type;
    private float birthTime;
    private float waveFrequency = 0.7f;
    private float waveWidth = 5;

    public WeaponType type
    {
        get
        {
            return (_type);
        }
        set
        {
            SetType(value);
        }
    }

    private void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
        rend = GetComponent<Renderer>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        birthTime = Time.time;
    }

    private void Update()
    {
        if (proj != null)
        {
            if (moveChancher)
            {
                ChangeMove(proj);
            }
        }
        if (bndCheck.offRight)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeMove(Transform p)
    {
        float age = Time.time - birthTime;
        Vector3 posProjectile;
        float theta = Mathf.PI * 2 * age / waveFrequency;
        posProjectile = p.transform.position;
        posProjectile.y = y0 + Mathf.Sin(theta) * waveWidth;
        p.transform.position = posProjectile;
    }

    ///<param name="eType">Тип WeaponType используемого оружия.</param>
    public void SetType(WeaponType eType)
    {
        _type = eType;
        WeaponDefinition def = Main.GetWeaponDefinition(_type);
        rend.material.color = def.projectileColor;
    }
}
