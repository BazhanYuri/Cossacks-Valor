using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPUInstancingEnabler : MonoBehaviour
{
    private void Awake()
    {
        MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMeshRenderer.SetPropertyBlock(materialPropertyBlock);
    }
}
