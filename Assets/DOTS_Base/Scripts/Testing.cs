using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Transforms;
using Unity.Entities;
using Unity.Collections;
using Unity.Rendering;
using Unity.Mathematics;

public class Testing : MonoBehaviour
{
    [SerializeField] private Mesh mesh;
    [SerializeField] private Material material;
    //[SerializeField] private Text text;
    [SerializeField] private SpawModel spawModel;
    enum SpawModel
    {
        ComponentType, EntityPrefab,Mul
    }
    // Start is called before the first frame update
    void Start()
    {
        //switch (spawModel)
        //{
        //    case SpawModel.ComponentType:
        //        componentTypesToCreateEntity();
        //        break;
        //    case SpawModel.EntityPrefab:
        //        UseInstantiateEntity();
        //        break;
        //    case SpawModel.Mul:
        //        MulEntities();
        //        break;
        //    default:
        //        break;
        //}

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UseInstantiateEntity();
        }
    }
    [SerializeField] private Mesh mesh2;
    [SerializeField] private Material material2;
    void componentTypesToCreateEntity()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        ComponentType[] componentTypes = new ComponentType[]
        {typeof(Translation),//Translation/Rotation必须要有1个,不然没有生成位置
            typeof(RenderMesh), typeof(LocalToWorld), typeof(RenderBounds)//渲染需要引入
        };
        Entity entity = entityManager.CreateEntity(componentTypes);
        entityManager.AddSharedComponentData(entity, new RenderMesh { mesh = mesh2, material = material2 });
    }

    void componentTypeToCreateEntity()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        //自定义组件类型的读写权限,可通过设置提高效率
        ComponentType translation = new ComponentType(typeof(Translation), ComponentType.AccessMode.ReadWrite);
        ComponentType renderMesh = new ComponentType(typeof(RenderMesh), ComponentType.AccessMode.ReadWrite);
        ComponentType localToWorld = new ComponentType(typeof(LocalToWorld), ComponentType.AccessMode.ReadWrite);
        ComponentType renderBounds = new ComponentType(typeof(RenderBounds), ComponentType.AccessMode.ReadWrite);

        EntityArchetype entityArchetype = entityManager.CreateArchetype(translation, renderMesh, localToWorld, renderBounds);
        Entity entity = entityManager.CreateEntity(entityArchetype);
        entityManager.AddSharedComponentData(entity, new RenderMesh { mesh = mesh2, material = material2 });
        
    }
    /// <summary>
    /// 使用预制体生成Entity
    /// 流程:prefab-entityPrefab-entity
    /// </summary>
    [SerializeField] private GameObject prefab;
    BlobAssetStore blobAssetStore ;
    // [DeallocateNativeContainerOnJobCompletion]
    void UseInstantiateEntity()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        //BlobAssetStore blobAssetStore = new BlobAssetStore();
         blobAssetStore = new BlobAssetStore();
        GameObjectConversionSettings gameObjectConversionSettings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld,blobAssetStore);
        Entity entityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(prefab, gameObjectConversionSettings);
        Entity entity = entityManager.Instantiate(entityPrefab);
        entityManager.AddSharedComponentData(entity,new RenderMesh { mesh = mesh, material = material2 });
        //blobAssetStore.Dispose();
    }
    void MulEntities()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        EntityArchetype entityArchetype = entityManager.CreateArchetype(typeof(LevelComponent), typeof(Translation),
            typeof(RenderMesh), typeof(LocalToWorld), typeof(RenderBounds)//渲染需要引入
            , typeof(MoveSpeedComponent)
            // , typeof(MsgComponent)
            );
        NativeArray<Entity> nativeArray = new NativeArray<Entity>(100, Allocator.Temp);


        /*Entity entity=*/
        entityManager.CreateEntity(entityArchetype, nativeArray);
        // Entity entity= entityManager.CreateEntity(typeof(LevelComponent));
        for (int i = 0; i < nativeArray.Length; i++)
        {
            Entity entity = nativeArray[i];
            entityManager.SetComponentData(entity, new LevelComponent { Level = UnityEngine.Random.Range(10, 30) });
            entityManager.SetComponentData(entity, new MoveSpeedComponent { MoveSpeed = UnityEngine.Random.Range(1f, 3f) });
            entityManager.SetComponentData(entity, new Translation { Value = new float3(UnityEngine.Random.Range(-8f, 8f), UnityEngine.Random.Range(-5f, 5f), 0) });
            entityManager.SetSharedComponentData(entity, new RenderMesh { mesh = mesh, material = material });
            //entityManager.SetComponentData(entity, new MsgComponent { msg = "hhhh", Text= "jjjj" });
            // entityManager.
        }
        nativeArray.Dispose();
    }
    private void OnDestroy()
    {
        blobAssetStore.Dispose();
    }
}
