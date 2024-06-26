using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
	
	

	[SerializeField]
	GameObject cubePrefab;

	[SerializeField]
	GameObject zakoPrefab;

	[SerializeField]
	int batchNum = 5;

	[SerializeField]
	float coolTime;

	[SerializeField]
	float speed;

	Rigidbody rb;

	GameObject taget;

	GameObject zako;



	int zakoNumber;      //雑魚の数

	int maxNum;

	Vector3 cubeSize;
	Vector3 offset;
	const float min = -0.5f;
	const float max = 0.5f;



	public bool oneShotFlag;
	
	private bool flagCache;


	void Start()
	{
		rb = GetComponent<Rigidbody>();

		cubeSize = gameObject.transform.localScale;
		offset = gameObject.transform.localPosition;

		zakoNumber = 0;
		maxNum = 0;

		taget = GameObject.Find("Player");

		flagCache = true;

		oneShotFlag = false;

	}

    private void Update()
    {
		if (oneShotFlag == false)
			return;

		InstantiateZako();

		oneShotFlag = false;


	}




    void InstantiateSmallCubeAtRandom()
	{
		// オブジェクトを立方体内のランダムな位置にインスタンス化する
		for (int i = 1; i <= batchNum; i++)
		{
			float xPos = GetRandomRangeInCube() * cubeSize.x;
			float yPos = GetRandomRangeInCube() * cubeSize.y;
			float zPos = GetRandomRangeInCube() * cubeSize.z;
			Vector3 position = new Vector3(xPos, yPos, zPos) + offset;

			// Prefabをインスタンス化する
			GameObject obj = Instantiate(cubePrefab, position, Quaternion.identity);
			obj.transform.SetParent(gameObject.transform);
		}
	}

	/// <summary>
	/// 複数の雑魚がプレイヤーに向かってくる攻撃
	/// </summary>
	public void InstantiateZako()
    {

		while(zakoNumber <= batchNum)
        {
			float xPos = GetRandomRangeInCube() * cubeSize.x;
			float yPos = GetRandomRangeInCube() * cubeSize.y;
			float zPos = GetRandomRangeInCube() * cubeSize.z;
			Vector3 position = new Vector3(xPos, yPos, zPos) + offset;

		    zako = Instantiate(zakoPrefab, position, Quaternion.identity);


			var dir = taget.transform.position - zako.transform.position;

			var lookAtRotation = Quaternion.LookRotation(dir, Vector3.up);

			zako.transform.rotation = lookAtRotation;
				
		    zako.GetComponent<Rigidbody>().AddForce(dir.normalized * speed, ForceMode.Impulse);

			zakoNumber++;

			Destroy(zako, 10f);

		}

		if(zakoNumber >= batchNum)
        {
			zakoNumber = 0;
        }
    }

	float GetRandomRangeInCube()
	{
		float randomRange = Random.Range(min, max);
		return randomRange;
	}

}
