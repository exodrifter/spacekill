using UnityEngine;
using System.Collections;

public class Vec3 {
	
	#region Member Variables
	
	private float _x, _y, _z;
	
	#endregion
	
	#region Properties
	
	public float x {
		get { return _x; }
		set { _x = value; }
	}
	
	public float y {
		get { return _y; }
		set { _y = value; }
	}
	
	public float z {
		get { return _z; }
		set { _z = value; }
	}
	
	#endregion
	
	#region Constructors
	
	public Vec3() {
		this.x = 0;
		this.y = 0;
		this.z = 0;
	}
	
	public Vec3(float v) {
		this.x = v;
		this.y = v;
		this.z = v;
	}
	
	public Vec3(float x, float y, float z) {
		this.x = x;
		this.y = y;
		this.z = z;
	}
	
	public Vec3(Vec2 vec) {
		this.x = vec.x;
		this.y = vec.y;
		this.z = 0;
	}
	
	public Vec3(Vec2 vec, float z) {
		this.x = vec.x;
		this.y = vec.y;
		this.z = z;
	}
	
	public Vec3(Vec3 vec) {
		this.x = vec.x;
		this.y = vec.y;
		this.z = vec.z;
	}
	
	#endregion
	
	#region Methods
	
	public float Length() {
		return Mathf.Sqrt((x * x) + (y * y) + (z * z));
	}
	
	public float Length2() {
		return (x * x) + (y * y) + (z * z);
	}
	
	public Vec3 Normalize() {
		float len = Length();
		this.x /= len;
		this.y /= len;
		this.z /= len;
		return this;
	}
	
	public float Dot(Vec3 vec) {
		return (x * vec.x) + (y * vec.y) + (z * vec.z);
	}
	
	public Vec3 Cross(Vec3 vec) {
		return new Vec3((x * vec.z) - (z * vec.x),
		                (z * vec.x) - (x * vec.z),
		                (x * vec.y) - (y * vec.x));
	}
	
	public float Distance(Vec3 vec) {
		return (vec - this).Length();
	}
	
	public float Distance2(Vec3 vec) {
		return (vec - this).Length2();
	}
	
	public bool Approximately(Vec3 vec) {
		return Mathf.Approximately(x, vec.x)
		    && Mathf.Approximately(y, vec.y)
		    && Mathf.Approximately(z, vec.z);
	}
	
	public override bool Equals(object obj) {
		Vec3 vec = obj as Vec3;
		if (vec == null) {
			return false;
		}
		return this == vec;
	}
	
	public override int GetHashCode() {
		unchecked
		{
			int hash = 17;
			hash = hash * 23 + x.GetHashCode();
			hash = hash * 23 + y.GetHashCode();
			hash = hash * 23 + z.GetHashCode();
			return hash;
		}
	}
	
	public override string ToString()
	{
		return typeof(Vec3).Name + "<x=" + x + ",y=" + y + ",z=" + z + ">";
	}
	
	#endregion
	
	#region Operator Overloads
	
	public static Vec3 operator +(Vec3 l, Vec3 r)  {
		return new Vec3(l.x + r.x, l.y + r.y, l.z + r.z);
	}
	
	public static Vec3 operator +(Vector3 l, Vec3 r)  {
		return new Vec3(l.x + r.x, l.y + r.y, l.z + r.z);
	}
	
	public static Vec3 operator +(Vec3 l, Vector3 r)  {
		return new Vec3(l.x + r.x, l.y + r.y, l.z + r.z);
	}
	
	public static Vec3 operator +(Vec3 l, float r)  {
		return new Vec3(l.x + r, l.y + r, l.z + r);
	}
	
	public static Vec3 operator +(float l, Vec3 r)  {
		return new Vec3(l + r.x, l + r.y, l + r.z);
	}
	
	public static Vec3 operator -(Vec3 l, Vec3 r)  {
		return new Vec3(l.x - r.x, l.y - r.y, l.z - r.z);
	}
	
	public static Vec3 operator -(Vector3 l, Vec3 r)  {
		return new Vec3(l.x - r.x, l.y - r.y, l.z - r.z);
	}
	
	public static Vec3 operator -(Vec3 l, Vector3 r)  {
		return new Vec3(l.x - r.x, l.y - r.y, l.z - r.z);
	}
	
	public static Vec3 operator -(Vec3 l, float r)  {
		return new Vec3(l.x - r, l.y - r, l.z - r);
	}
	
	public static Vec3 operator -(float l, Vec3 r)  {
		return new Vec3(l - r.x, l - r.y, l - r.z);
	}
	
	public static Vec3 operator *(Vec3 l, Vec3 r)  {
		return new Vec3(l.x * r.x, l.y * r.y, l.z * r.z);
	}
	
	public static Vec3 operator *(Vector3 l, Vec3 r)  {
		return new Vec3(l.x * r.x, l.y * r.y, l.z * r.z);
	}
	
	public static Vec3 operator *(Vec3 l, Vector3 r)  {
		return new Vec3(l.x * r.x, l.y * r.y, l.z * r.z);
	}
	
	public static Vec3 operator *(Vec3 l, float r)  {
		return new Vec3(l.x * r, l.y * r, l.z * r);
	}
	
	public static Vec3 operator *(float l, Vec3 r)  {
		return new Vec3(l * r.x, l * r.y, l * r.z);
	}
	
	public static Vec3 operator /(Vec3 l, Vec3 r)  {
		return new Vec3(l.x / r.x, l.y / r.y, l.z / r.z);
	}
	
	public static Vec3 operator /(Vector3 l, Vec3 r)  {
		return new Vec3(l.x / r.x, l.y / r.y, l.z / r.z);
	}
	
	public static Vec3 operator /(Vec3 l, Vector3 r)  {
		return new Vec3(l.x / r.x, l.y / r.y, l.z / r.z);
	}
	
	public static Vec3 operator /(Vec3 l, float r)  {
		return new Vec3(l.x / r, l.y / r, l.z / r);
	}
	
	public static Vec3 operator /(float l, Vec3 r)  {
		return new Vec3(l / r.x, l / r.y, l / r.z);
	}
	
	public static bool operator ==(Vec3 l, Vec3 r) {
		return (l.x == r.x) && (l.y == r.y) && (l.z == r.z);
	}
	
	public static bool operator ==(Vector3 l, Vec3 r) {
		return (l.x == r.x) && (l.y == r.y) && (l.z == r.z);
	}
	
	public static bool operator ==(Vec3 l, Vector3 r) {
		return (l.x == r.x) && (l.y == r.y) && (l.z == r.z);
	}
	
	public static bool operator !=(Vec3 l, Vec3 r) {
		return (l.x != r.x) || (l.y != r.y) || (l.z != r.z);
	}
	
	public static bool operator !=(Vector3 l, Vec3 r) {
		return (l.x != r.x) || (l.y != r.y) || (l.z != r.z);
	}
	
	public static bool operator !=(Vec3 l, Vector3 r) {
		return (l.x != r.x) || (l.y != r.y) || (l.z != r.z);
	}
	
	#endregion
	
	#region Conversion Operator Overloads
	
	public static explicit operator Vec3(Vector2 vec) {
		return new Vec3(vec.x, vec.y, 0);
	}
	
	public static explicit operator Vector2(Vec3 vec) {
		return new Vector2(vec.x, vec.y);
	}
	
	public static implicit operator Vec3(Vector3 vec) {
		return new Vec3(vec.x, vec.y, vec.z);
	}
	
	public static implicit operator Vector3(Vec3 vec) {
		return new Vector3(vec.x, vec.y, vec.z);
	}
	
	public static explicit operator Vec3(Vec2 vec) {
		return new Vec3(vec.x, vec.y, 0);
	}
	
	public static explicit operator Vec2(Vec3 vec) {
		return new Vec2(vec.x, vec.y);
	}
	
	#endregion
}
