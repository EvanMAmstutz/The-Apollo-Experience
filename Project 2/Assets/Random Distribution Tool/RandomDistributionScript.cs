using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomDistributionScript : MonoBehaviour {

	//enums
	public enum ChannelType
	{
		Red = 0,
		Green = 1,
		Blue = 2,
		Alpha = 3
	};
	
	public enum EditType
	{
		None = 0,
		Rndom = 1,
		Map = 2
	};
	
	public enum MaskType
	{
		None = 0,
		Mask = 1,
		Density = 2
	};
	
	public enum DistributionType
	{
		Rndom = 0,
		HaltonSequence = 1
	};
	
	public enum FilterType
	{
		Point = 0,
		Bilinear = 1
	};
	
	public enum RotationType
	{
		None = 0,
		LocalUp = 1,
		WorldUp = 2,
		NormalUp = 3
	};
	
	
	//public
	public List<GameObject> pool;
	public List<float> poolWeight;
	public int amount = 10;
	public Vector3 bounds = new Vector3(5, 1, 5);
	public Texture2D distributionMap;
	public FilterType filterType = FilterType.Point;
	public bool inverted = false;
	
	//optimization
	public bool applyVertexColor = false;
	public bool combineMeshes = false;
	
	//distribution
	public DistributionType distributionType = DistributionType.Rndom;
	public int seed = 0;
	
	//projection
	public bool projectToSurface = true;
			
	//density
	public MaskType maskType = MaskType.None;
	public ChannelType maskChannel = ChannelType.Red;
	[Range(0f, 1f)]
	public float maskThreshold = 0.25f;
	
	//color
	public EditType colorType = EditType.None;
	public ChannelType colorChannel = ChannelType.Green;
	public Color colorMax = Color.black;
	public Color colorMin = Color.white;
	
	//scale
	public EditType scaleType = EditType.None;
	public ChannelType  scaleChannel = ChannelType.Blue;
	public float scaleMax = 1f;
	public float scaleMin = 0.25f;
	
	//rotation
	public RotationType rotationType = RotationType.None;
	[Range(0f, 180f)]
	public float rotationDeltaX = 0f;
	[Range(0f, 180f)]
	public float rotationDeltaY = 180f;
	[Range(0f, 180f)]
	public float rotationDeltaZ = 0f;
	
	
	//private
	private RaycastHit rh;
	private float[] values;
	private GameObject[] groups;
	
	private void OnValidate()
	{
		if(rotationType == RotationType.NormalUp && projectToSurface == false)
		{
			rotationType = RotationType.None;
			Debug.LogWarning("Project to Surface must be true for this option to work.");
		}
	
		while(poolWeight.Count < pool.Count)
		{
			poolWeight.Add(1f);
		}
		
		while(poolWeight.Count > pool.Count)
		{
			poolWeight.RemoveAt(poolWeight.Count - 1);
		}
	}
	
	private void Start()
	{
		if(pool == null || distributionMap == null)
		{
			Debug.LogWarning("Some or all public variables is null.", this);
			return;
		}
		
		if(pool.Count < 1)
		{
			Debug.LogWarning("Object pool not fully populated", this);
			return;
		}
		
		for(int i = 0; i < pool.Count; i++)
		{
			if(pool[i] == null)
			{
				Debug.LogWarning("Object pool not fully populated", this);
				return;
			}
		}
		
		if(distributionMap.width < 2 || distributionMap.height < 2)
		{
			Debug.LogWarning("Distribution map resolution unde 2 is not supportet", this);
			return;
		}
		
		//initiate weighted pool data
		float total = 0f;
		float cumulative = 0f;
		values = new float[poolWeight.Count];
		for(int i = 0; i < poolWeight.Count; i++)
		{
			total += poolWeight[i];
		}
		for(int i = 0; i < poolWeight.Count; i++)
		{
			cumulative += poolWeight[i] / total;
			values[i] = cumulative;
		}
		
		groups = new GameObject[pool.Count];
		for(int i = 0; i < groups.Length; i++)
		{
			groups[i] = new GameObject(pool[i].name + " Group");
			groups[i].transform.parent = transform;
		}
		
		int tries = 0;
		if(seed != -1)
		{
			Random.seed = seed;
		}
		
		for(int i = 0; i < amount; i++)
		{
			//distribution
			Vector3 rndPos;
			if(distributionType == 0)
			{
				rndPos = new Vector3(Random.Range(0, bounds.x), bounds.y, Random.Range(0, bounds.z));;
			}
			else
			{
				rndPos = new Vector3(Mathf.Lerp(0f, bounds.x, HaltonSequence(20 + i + tries, 2)),
				                     bounds.y,
				                     Mathf.Lerp(0f, bounds.z, HaltonSequence(20 + i + tries, 3)));	
			}
			
			//mask
			switch(maskType)
			{
			case MaskType.Mask:
				if(FindMapValue(FindMapPosition(rndPos), maskChannel) < maskThreshold)
				{
					tries += 1; 
					if(tries > amount * 10)
					{
						Debug.LogWarning("Not able to find valid positions. Try a different map", this);
						return;
					}
					i--;
					continue;
				}
				break;
			case MaskType.Density:
				if(FindMapValue(FindMapPosition(rndPos), maskChannel) < maskThreshold || FindMapValue(FindMapPosition(rndPos), maskChannel) < Random.Range(0f, 1f))
				{
					tries += 1; 
					if(tries > amount * 10)
					{
						Debug.LogWarning("Not able to find valid positions. Try a different map", this);
						return;
					}
					i--;
					continue;
				}
				break;
			}
			
			//projection
			Vector3 worldPos = Vector3.zero;
			if(projectToSurface == true && Physics.Raycast(transform.TransformPoint(rndPos), -transform.up, out rh, bounds.y) == true)
			{
				worldPos = rh.point;
			}
			else
			{
				if(projectToSurface == true)
				{
					tries += 1; 
					if(tries > amount * 10)
					{
						Debug.LogWarning("Not able to find valid positions. Try a different map or disable Project to surface.", this);
						return;
					}
					i--;
					continue;
				}
				else
				{
					worldPos = transform.TransformPoint(rndPos + Vector3.down * bounds.y);
				}
			}
			
			//create new object
			int poolIndex = GetPrefabIndex(Random.value);
			GameObject go = GameObject.Instantiate(pool[poolIndex], worldPos, Quaternion.identity) as GameObject;
			go.name = pool[poolIndex].name;	
			go.transform.parent = groups[poolIndex].transform;		
			
			//color
			switch(colorType)
			{
			case EditType.Rndom:
				SetColor(go, Color.Lerp(colorMin, colorMax, Random.Range(0f, 1f)));
				break;
			case EditType.Map:
				SetColor(go, Color.Lerp(colorMin, colorMax, FindMapValue(FindMapPosition(rndPos), colorChannel)));
				break;
			}
			
			//scale
			float scale = go.transform.localScale.x;
			switch(scaleType)
			{
			case EditType.Rndom:
				scale = Mathf.Lerp(scaleMin, scaleMax, Random.Range(0f, 1f));
				go.transform.localScale = new Vector3(scale, scale, scale);
				break;
			case EditType.Map:
				scale = Mathf.Lerp(scaleMin, scaleMax, FindMapValue(FindMapPosition(rndPos), scaleChannel));
				go.transform.localScale = new Vector3(scale, scale, scale);
				break;
			}
			
			//rotation
			switch(rotationType)
			{
				case RotationType.LocalUp:
				go.transform.localRotation = Quaternion.Euler(Random.Range(-rotationDeltaX, rotationDeltaX),
				                                              Random.Range(-rotationDeltaY, rotationDeltaY),
				                                              Random.Range(-rotationDeltaZ, rotationDeltaZ));
				break;
				case RotationType.WorldUp:
				go.transform.rotation = Quaternion.Euler(Random.Range(-rotationDeltaX, rotationDeltaX),
				                                              Random.Range(-rotationDeltaY, rotationDeltaY),
				                                              Random.Range(-rotationDeltaZ, rotationDeltaZ));
				break;
				case RotationType.NormalUp:
				go.transform.rotation = Quaternion.FromToRotation(Vector3.up, rh.normal) * Quaternion.Euler(Random.Range(-rotationDeltaX, rotationDeltaX),
				                                                                                            Random.Range(-rotationDeltaY, rotationDeltaY),
				                                                                                            Random.Range(-rotationDeltaZ, rotationDeltaZ));
				break;
			}
		}
		
		if(combineMeshes == true)
		{
			OptimizeMeshes();
		}
		//reset seed
		Random.seed = (int)System.DateTime.Now.Ticks;
	}
	
	private Vector2 FindMapPosition(Vector3 pos)
	{
		float bx = Mathf.InverseLerp(0, bounds.x, pos.x);
		float by = Mathf.InverseLerp(0, bounds.z, pos.z);
		
		if(filterType == FilterType.Bilinear)
		{
			return new Vector2(Mathf.Lerp(0f, distributionMap.width - 1, bx), Mathf.Lerp(0f, distributionMap.height - 1, by));
		}
		return new Vector2(Mathf.Lerp(0f, distributionMap.width, bx), Mathf.Lerp(0f, distributionMap.height, by)); 
	}
	
	private float FindMapValue(Vector2 pos, ChannelType channel)
	{	
		float p = 0f;
		if(filterType == FilterType.Bilinear)
		{
			p = BilinearFilteringMap(pos, channel);
		}
		else
		{
			p = NoneBilinearFilteringMap(pos, channel);
		}
		
		if(inverted == true)
		{
			return 1f - p;
		}
		return p;
	}
	
	private float BilinearFilteringMap(Vector2 pos, ChannelType channel)
	{
		float x1 = (int)pos.x;
		float x2 = Mathf.CeilToInt(pos.x);
		float y1 = (int)pos.y;
		float y2 = Mathf.CeilToInt(pos.y);
		
		Color a = distributionMap.GetPixel((int)x1, (int)y1);
		Color b = distributionMap.GetPixel((int)x2, (int)y1);
		Color c = distributionMap.GetPixel((int)x1, (int)y2);
		Color d = distributionMap.GetPixel((int)x2, (int)y2);
		
		float r1 = ((x2 - pos.x)/(x2 - x1))*a[(int)channel] + ((pos.x - x1)/(x2 - x1)) * b[(int)channel];
		float r2 = ((x2 - pos.x)/(x2 - x1))*c[(int)channel]+ ((pos.x - x1)/(x2 - x1)) * d[(int)channel];
		
		return((y2 - pos.y)/(y2 - y1)) * r1 + ((pos.y - y1)/(y2 - y1)) * r2;
	}
	
	private float NoneBilinearFilteringMap(Vector2 pos, ChannelType channel)
	{
		Color a = distributionMap.GetPixel((int)pos.x, (int)pos.y);
		return a[(int)channel];
	}
	
	private int GetPrefabIndex(float delta)
	{
		if(values != null)
		{
			for(int i = 0; i < values.Length; i++)
			{
				if(delta < values[i])
				{
					return i;
				}
			}
		}
		return 0;
	}
	
	private float HaltonSequence(int index, int haltonBase)
	{
		float result = 0f;
		float f = 1f / haltonBase;
		int i = index;
		while(i > 0)
		{
			result = result + f * (i % haltonBase);
			i = (int)Mathf.Floor(i / (float)haltonBase);
			f = f / haltonBase;
		}
		return result;
	}

	private void SetColor(GameObject go, Color c)
	{
		if(applyVertexColor == true)
		{
			Mesh m = (go.GetComponent(typeof(MeshFilter)) as MeshFilter).mesh;
			if(m != null)
			{
				Color32[] colorList = m.colors32;
				for(int i = 0; i < colorList.Length; i++)
				{
					colorList[i] = c;
				}
				m.colors32 = colorList;
			}
			else
			{
				Debug.Log("Mesh not found!", this);
			}
		}
		else
		{
			go.GetComponent<Renderer>().material.color = c;
		}	
	}
	
	private void OptimizeMeshes()
	{
		for(int i = 0; i < groups.Length; i++)
		{
			GameObject g = groups[i];
			MeshFilter gmf = (MeshFilter)g.AddComponent(typeof(MeshFilter));
			MeshRenderer gmr = (MeshRenderer)g.AddComponent(typeof(MeshRenderer));
			
			MeshFilter[] meshFilters = g.GetComponentsInChildren<MeshFilter>();
			if(meshFilters.Length < 2)continue;
			int tmp = (meshFilters[1].gameObject.GetComponents(typeof(Component)) as Component[]).Length;
			
			CombineInstance[] combine = new CombineInstance[meshFilters.Length - 1];
			int index = 0;
			for(int j = 1; j < meshFilters.Length; j++) {
				combine[index].mesh = meshFilters[j].sharedMesh;
				combine[index].transform = meshFilters[j].transform.localToWorldMatrix;
				meshFilters[j].GetComponent<Renderer>().enabled = false;
				
				if(tmp <= 3)
				{
					Destroy(meshFilters[j].gameObject);
				}
				else
				{
					Destroy(meshFilters[j].GetComponent<Renderer>());
					Destroy(meshFilters[j]);
				}
				index++;
			}
			
			gmf.mesh = new Mesh();
			gmf.mesh.CombineMeshes(combine);
			gmr.castShadows = pool[i].GetComponent<Renderer>().castShadows;
			gmr.receiveShadows = pool[i].GetComponent<Renderer>().receiveShadows;
			gmr.useLightProbes = pool[i].GetComponent<Renderer>().useLightProbes;
			gmr.sharedMaterial = new Material(pool[i].GetComponent<Renderer>().sharedMaterial);
		}
	}
	
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.DrawWireCube(new Vector3(bounds.x/2f, bounds.y/2f, bounds.z/2f), 
		                    new Vector3(bounds.x, bounds.y, bounds.z));
	}
}
