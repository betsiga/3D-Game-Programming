using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DiskFactoryManager : MonoBehaviour
{
    DiskFactory _diskFactory;
    public GameObject disk;

    void Awake()
    {
        _diskFactory = DiskFactory.getFactory();
        _diskFactory.disk = this.disk;
    }
}