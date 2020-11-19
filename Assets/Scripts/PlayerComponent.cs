﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct PlayerComponent : IComponentData
{
    public float _speed;
    public float _rotationAngle;
}
