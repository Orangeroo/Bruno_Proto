using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class BackgroundController : MonoBehaviour {

	private List<Transform> backgroundPart;
	public bool isAllPartsSameLength = true;
	private Vector3 length;

	void Start () {

		// Create a list of all the background parts
		backgroundPart = new List<Transform>();

		for(int i=0; i < transform.childCount; i++)
		{
			Transform child = transform.GetChild(i);

			if(child.GetComponent<Renderer>() != null)
			{
				backgroundPart.Add(child);
			}

			// Sort by position
			backgroundPart = backgroundPart.OrderBy( t => t.position.x).ToList();
		}

		// Set the length of the part
		Transform firstPart = backgroundPart.FirstOrDefault();
		if(firstPart != null)
		{
			length = firstPart.GetComponent<Renderer>().bounds.max - firstPart.GetComponent<Renderer>().bounds.min;
		}
		else
		{
			length = new Vector3();
		}
	}
	
	// Update is called once per frame
	void Update () {
		Transform firstPart = backgroundPart.FirstOrDefault();

		if(( firstPart != null)
		   // Check this first, less heavy than using IsVisibleFrom()
		   && (firstPart.position.x < Camera.main.transform.position.x)
		   && (!firstPart.GetComponent<Renderer>().IsVisibleFrom(Camera.main)) )
		{


			// Get the last child position
			Transform lastPart = backgroundPart.LastOrDefault();
			Vector3 lastPosition = lastPart.position;

			if( !isAllPartsSameLength )
			{
				length = lastPart.GetComponent<Renderer>().bounds.max - lastPart.GetComponent<Renderer>().bounds.min;
			}

			firstPart.position = new Vector3( lastPosition.x + length.x, firstPart.position.y, firstPart.position.z );

			backgroundPart.Remove(firstPart);
			backgroundPart.Add(firstPart);

				
		}
	}
}
