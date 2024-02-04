using UnityEngine;

public class RagdollSwitcher : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public Rigidbody[] rigids;
    [ContextMenu("Retrieve Rigibodies")]
    private void RetrieveRigibodies()
    {
        rigids = GetComponentsInChildren<Rigidbody>();
    }

    [ContextMenu("Clear Ragdoll")]
    private void ClearRagdoll()
    {
        CharacterJoint[] joins = GetComponentsInChildren<CharacterJoint>();
        for (int i = 0; i < joins.Length; i++)
        {
            DestroyImmediate(joins[i]);
        }

        Rigidbody[] rigidsList = GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < rigidsList.Length; i++)
        {
            DestroyImmediate(rigidsList[i]);
        }

        Collider[] colls = GetComponentsInChildren<Collider>();
        for (int i = 0; i < colls.Length; i++)
        {
            DestroyImmediate(colls[i]);
        }
    }

    [ContextMenu("Enable Ragdoll")]
    public void EnableRagdoll()
    {
        SetRagdoll(true);
    }
    [ContextMenu("Disable Ragdoll")]
    public void DisableRagdoll()
    {
        SetRagdoll(false);
    }

    private void SetRagdoll(bool ragdollEnable)
    {
        anim.enabled = !ragdollEnable;
        for (int i = 0; i < rigids.Length; i++)
        {
            rigids[i].isKinematic = !ragdollEnable;
        }
    }
}
