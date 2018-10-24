using System;
using UnityEngine;
using Gui3D.Controls;
using System.Threading;
using System.Collections.Generic;

namespace Scripts.MyLibs
{
	public class MyHelpers
	{
		public static GameObject getRaycastedGameObject(Vector3 origin, Camera cam)
		{
			Ray ray;
			RaycastHit hit;
			var mousWorldPos = cam.ScreenToWorldPoint (origin);
			var direction = cam.ScreenPointToRay (origin).direction;

			ray = new Ray (mousWorldPos, direction);

			UnityEngine.Debug.DrawRay(ray.origin, 1000f * ray.direction, Color.green, 1.1f, true);

            //agregado ledr --- GovernmentWorkOut
            int mask = (1 << LayerMask.NameToLayer("Scroll0"));
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask)) {
                GameObject mgame = hit.transform.gameObject;
                if (mgame.name == "circle(Clone)") {
                    return mgame;
                }
            }
            //-----------

                if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
				GameObject mgame = hit.transform.gameObject;
				if (mgame != null) {
					MyHandClass hitGo =  mgame.GetComponent<MyHandClass>();
                    SpriteRenderer hitGo3 = mgame.GetComponent<SpriteRenderer>();
                 
                    if (hitGo != null ||  (hitGo3 != null && (hitGo3.gameObject.name.ToUpper().Contains("OBS") || hitGo3.gameObject.name.Contains("FinalPoint") || hitGo3.gameObject.name.Contains("StartPoint")))) {
                        return mgame;
					} 
				} 
			}
			return null;
		}
	}
	public static class ThreadSafeRandom
	{
		[ThreadStatic] private static System.Random Local;

		public static System.Random ThisThreadsRandom
		{
			get { return Local ?? (Local = new System.Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
		}
	}

	static class MyExtensions
	{
		public static void Shuffle<T>(this IList<T> list)
		{
			int n = list.Count;
			while (n > 1)
			{
				n--;
				int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}
	}
}