﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEatable
{
    float ObjSize { get; }
    EatableObjSO objSO;
}
