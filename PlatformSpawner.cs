using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform, AllTheCubes, star;
    private GameObject blockInst;
    private Vector3 blockPos;
    private float speed = 5f;
    private bool IfOnPlace = false;

    void Spawn()
    {
        blockPos = new Vector3(Random.Range(1f, 1.7f), -Random.Range(1f, 3.2f), -1f);
        blockInst = Instantiate(platform, new Vector3(5f, -6f, 0f), Quaternion.identity);
        blockInst.transform.localScale = new Vector3(RandomScale(), blockInst.transform.localScale.y, blockInst.transform.localScale.z);
        blockInst.transform.parent = AllTheCubes.transform; //Платформа становится дочерним объектом кубов, нужно для того, чтобы можно было двигать все объекты на экране одним движением.
        if ((CubeJump.CountBlocks % 3 == 0) && (CubeJump.CountBlocks != 0))
        {
            GameObject StarInst = Instantiate (star, new Vector3(blockInst.transform.position.x, blockInst.transform.position.y + 0.5f, blockInst.transform.position.z), Quaternion.Euler(Camera.main.transform.eulerAngles)) as GameObject; //Делаем новый GameObject, так как платформа изначально находится вне экрана и звезда появляется не там, где нужно.
            StarInst.transform.parent = blockInst.transform;
        }
    }

    void Start()
    {
        Spawn();
    }

    void Update()
    {
        if ((blockInst.transform.position != blockPos) && (IfOnPlace == false))
        {
            blockInst.transform.position = Vector3.MoveTowards(blockInst.transform.position, blockPos, Time.deltaTime * speed);
        }
        else if (blockInst.transform.position == blockPos)
        {
            IfOnPlace = true;
        }
        if ((CubeJump.jump == true) && (CubeJump.nextblock == true)) //Проверка того, можно ли уже создавать новую платформу.
        {
            Spawn();
            IfOnPlace = false; //Чтобы платформа двигалась к указанному ей месту.
        }
    }

    float RandomScale ()
    {
        float rand;
        if (Random.Range (0, 100) > 80)
        {
            rand = Random.Range(1.2f, 1.6f);
            return rand;
        }
        else
        {
            rand = Random.Range(1.2f, 1.5f);
            return rand;
        }
    }


}
