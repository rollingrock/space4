using Unity.VisualScripting;
using UnityEngine;

public static class HexMetrics {

	public const float outerRadius = 10f;

	public const float innerRadius = outerRadius * 0.866025404f;

	public const float hexSpacing = 0.3f;

	public static Vector3[] corners = {
		new Vector3(0f, 0f, outerRadius - hexSpacing),
		new Vector3(innerRadius - hexSpacing, 0f, 0.5f * outerRadius - hexSpacing),
		new Vector3(innerRadius - hexSpacing, 0f, -0.5f * outerRadius + hexSpacing),
		new Vector3(0f, 0f, -outerRadius + hexSpacing),
		new Vector3(-innerRadius + hexSpacing, 0f, -0.5f * outerRadius + hexSpacing),
		new Vector3(-innerRadius + hexSpacing, 0f, 0.5f * outerRadius - hexSpacing),
		new Vector3(0f, 0f, outerRadius - hexSpacing)
	};
}