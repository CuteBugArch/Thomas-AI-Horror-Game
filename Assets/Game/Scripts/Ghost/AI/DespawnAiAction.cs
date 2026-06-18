using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Despawn AI", story: "Despawn [AI]", category: "Action", id: "77b1463256a78caf5a9a819afad789b6")]
public partial class DespawnAiAction : Action
{
    [SerializeReference] public BlackboardVariable<GhostAIController> AI;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        // Memastikan ada reference ke AI controller
        // Jika tidak ada, maka status gagal akan langsung
        // dikembalikan 
        if (AI.Value == null)
        {
            return Status.Failure;
        }
        // Melakukan despawn AI
        AI.Value.Despawn();
        // Mengembalikan status berhasil setelah despawn AI
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

