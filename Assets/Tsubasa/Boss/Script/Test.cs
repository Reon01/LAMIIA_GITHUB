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



	int zakoNumber;      //�G���̐�

	int maxNum;

	Vector3 cubeSize;
	Vector3 offset;
	const float min = -0.5f;
	const float max = 0.5f;


	void Start()
	{
		rb = GetComponent<Rigidbody>();

		cubeSize = gameObject.transform.localScale;
		offset = gameObject.transform.localPosition;

		zakoNumber = 0;
		maxNum = 0;

		taget = GameObject.FindGameObjectWithTag("Player");

	}

    private void Update()
    {
		InstantiateZako();
    }




    void InstantiateSmallCubeAtRandom()
	{
		// �I�u�W�F�N�g�𗧕��̓��̃����_���Ȉʒu�ɃC���X�^���X������
		for (int i = 1; i <= batchNum; i++)
		{
			float xPos = GetRandomRangeInCube() * cubeSize.x;
			float yPos = GetRandomRangeInCube() * cubeSize.y;
			float zPos = GetRandomRangeInCube() * cubeSize.z;
			Vector3 position = new Vector3(xPos, yPos, zPos) + offset;

			// Prefab���C���X�^���X������
			GameObject obj = Instantiate(cubePrefab, position, Quaternion.identity);
			obj.transform.SetParent(gameObject.transform);
		}
	}

	/// <summary>
	/// �����̎G�����v���C���[�Ɍ������Ă���U��
	/// </summary>
	void InstantiateZako()
    {
		while(zakoNumber <= batchNum)
        {
			float xPos = GetRandomRangeInCube() * cubeSize.x;
			float yPos = GetRandomRangeInCube() * cubeSize.y;
			float zPos = GetRandomRangeInCube() * cubeSize.z;
			Vector3 position = new Vector3(xPos, yPos, zPos) + offset;

			GameObject obj = Instantiate(zakoPrefab, position, Quaternion.identity);


			var dir = taget.transform.position - obj.transform.position;

			var lookAtRotation = Quaternion.LookRotation(dir, Vector3.up);

			obj.transform.rotation = lookAtRotation;
				
		    obj.GetComponent<Rigidbody>().AddForce(dir.normalized * speed, ForceMode.Impulse);

			zakoNumber++;

		}
    }

	float GetRandomRangeInCube()
	{
		float randomRange = Random.Range(min, max);
		return randomRange;
	}

}
