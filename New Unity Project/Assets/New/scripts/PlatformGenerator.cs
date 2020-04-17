using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public Transform generationPoint;
    private float platformWidth;

    // PLATFORMS
    private int platformSelector;
    public ObjectPooler[] stage1ObjectPools;
    public ObjectPooler[] stage2ObjectPools;
    public ObjectPooler[] stage3ObjectPools;
    public ObjectPooler[] stage4ObjectPools;
    public ObjectPooler[] stage5ObjectPools;

    // BACKGROUNDS
    public GameObject[] stage1Background;
    public GameObject[] stage2Background;
    public GameObject[] stage3Background;
    public GameObject[] stage4Background;
    public GameObject[] stage5Background;
    private GameObject[][] backgrounds;

    // DECORATIONS
    public GameObject[] stage1Decorations;
    public GameObject[] stage2Decorations;
    public GameObject[] stage3Decorations;
    public GameObject[] stage4Decorations;
    public GameObject[] stage5Decorations;
    private GameObject[][] decorations;

    private int stageIndex = 0;
    private int[] stageLengths = new int[] { 10, 40, 20, 40, 10 };
    private ObjectPooler[][] stagesObjectPools;
    private int genCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        stagesObjectPools = new ObjectPooler[][] { stage1ObjectPools, stage2ObjectPools, stage3ObjectPools, stage4ObjectPools, stage5ObjectPools };
        backgrounds = new GameObject[][] { stage1Background, stage2Background, stage3Background, stage4Background, stage5Background };
        decorations = new GameObject[][] { stage1Decorations, stage2Decorations, stage3Decorations, stage4Decorations, stage5Decorations };
        platformWidth = stagesObjectPools[0][0].pooledObject.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            platformSelector = Random.Range(0, stagesObjectPools[stageIndex].Length);

            transform.position = new Vector3(transform.position.x + platformWidth, generationPoint.transform.position.y, transform.position.z);
            //Instantiate(platform, transform.position, transform.rotation);
            if (transform.position.x >= 15)
            {
                GameObject newPlatform = stagesObjectPools[stageIndex][platformSelector].GetPooledObject();
                newPlatform.transform.position = transform.position;
                newPlatform.transform.rotation = transform.rotation;
                newPlatform.SetActive(true);

                int shouldMakeShrub = Random.Range(0, 2);
                if (shouldMakeShrub == 0)
                {
                    int decorationIndex = Random.Range(0, decorations[stageIndex].Length);
                    GameObject decoration = decorations[stageIndex][decorationIndex];
                    int randomXOffset = Random.Range(2, 9);
                    Vector3 pos = new Vector3(transform.position.x + randomXOffset, transform.position.y, 0);
                    Instantiate(decoration, pos, transform.rotation);
                }

                shouldMakeShrub = Random.Range(0, 2);
                if (shouldMakeShrub == 0)
                {
                    int decorationIndex = Random.Range(0, decorations[stageIndex].Length);
                    GameObject decoration = decorations[stageIndex][decorationIndex];
                    int randomXOffset = Random.Range(2, 9);
                    Vector3 pos = new Vector3(transform.position.x + randomXOffset, transform.position.y, 0);
                    Instantiate(decoration, pos, transform.rotation);
                }

                genCount++;
                if (genCount >= stageLengths[stageIndex])
                {
                    // New level started
                    genCount = 0;
                    stageIndex++;
                    for (int i = 0; i < backgrounds[stageIndex - 1].Length; i++)
                    {
                        backgrounds[stageIndex - 1][i].SetActive(false);
                    }
                }
            }
        }
    }
}
