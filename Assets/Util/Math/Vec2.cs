using UnityEngine;
using System.Collections;

public class Vec2 {
	
	#region Member Variables
	
	private float _x, _y;
	
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
	
	public float radians {
		get { return Mathf.Atan2(y, x); }
		set {
			float rad = value;
			float len = this.Length();
			this.x = Mathf.Cos(rad) * len;
			this.y = Mathf.Sin(rad) * len;
		}
	}
	
	public float degrees {
		get { return Mathf.Atan2(y, x) * 180.0f / Mathf.PI; }
		set {
			float rad = value*Mathf.PI / 180.0f;
			float len = this.Length();
			this.x = Mathf.Cos(rad) * len;
			this.y = Mathf.Sin(rad) * len;
		}
	}
	
	#endregion
	
	#region Constructors
	
	public Vec2() {
		this.x = 0;
		this.y = 0;
	}
	
	public Vec2(float v) {
		this.x = v;
		this.y = v;
	}
	
	public Vec2(float x, float y) {
		this.x = x;
		this.y = y;
	}
	
	public Vec2(Vec2 vec) {
		this.x = vec.x;
		this.y = vec.y;
	}
	
	public Vec2(Vec3 vec) {
		this.x = vec.x;
		this.y = vec.y;
	}
	
	#endregion
	
	#region Methods
	
	public float Length() {
		return Mathf.Sqrt((x * x) + (y * y));
	}
	
	public float Length2() {
		return (x * x) + (y * y);
	}
	
	public Vec2 Normalize() {
		float len = Length();
		this.x /= len;
		this.y /= len;
		return this;
	}
	
	public float Dot(Vec2 vec) {
		return (x * vec.x) + (y * vec.y);
	}
	
	public float Cross(Vec2 vec) {
		return (x * vec.y) - (y * vec.x);
	}
	
	public float Distance(Vec2 vec) {
		return (vec - this).Length();
	}
	
	public float Distance2(Vec2 vec) {
		return (vec - this).Length2();
	}
	
	public bool Approximately(Vec2 vec) {
		return Mathf.Approximately(x, vec.x) && Mathf.Approximately(y, vec.y);
	}
	
	public override bool Equals(object obj) {
		Vec2 vec = obj as Vec2;
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
			return hash;
		}
	}
	
	public override string ToString()
	{
		return typeof(Vec2).Name + "<x=" + x + ",y=" + y + ">";
	}
	
	#endregion
	
	#region Operator Overloads
	
	public static Vec2 operator +(Vec2 l, Vec2 r)  {
		return new Vec2(l.x + r.x, l.y + r.y);
	}
	
	public static Vec2 operator +(Vec2 l, float r)  {
		return new Vec2(l.x + r, l.y + r);
	}
	
	public static Vec2 operator +(float l, Vec2 r)  {
		return new Vec2(l + r.x, l + r.y);
	}
	
	public static Vec2 operator -(Vec2 l, Vec2 r)  {
		return new Vec2(l.x - r.x, l.y - r.y);
	}
	
	public static Vec2 operator -(Vec2 l, float r)  {
		return new Vec2(l.x - r, l.y - r);
	}
	
	public static Vec2 operator -(float l, Vec2 r)  {
		return new Vec2(l - r.x, l - r.y);
	}
	
	public static Vec2 operator *(Vec2 l, Vec2 r)  {
		return new Vec2(l.x * r.x, l.y * r.y);
	}
	
	public static Vec2 operator *(Vec2 l, float r)  {
		return new Vec2(l.x * r, l.y * r);
	}
	
	public static Vec2 operator *(float l, Vec2 r)  {
		return new Vec2(l * r.x, l * r.y);
	}
	
	public static Vec2 operator /(Vec2 l, Vec2 r)  {
		return new Vec2(l.x / r.x, l.y / r.y);
	}
	
	public static Vec2 operator /(Vec2 l, float r)  {
		return new Vec2(l.x / r, l.y / r);
	}
	
	public static Vec2 operator /(float l, Vec2 r)  {
		return new Vec2(l / r.x, l / r.y);
	}
	
	public static bool operator ==(Vec2 l, Vec2 r) {
		return (l.x == r.x) && (l.y == r.y);
	}
	
	public static bool operator !=(Vec2 l, Vec2 r) {
		return (l.x != r.x) || (l.y != r.y);
	}
	
	#endregion
	
	#region Conversion Operator Overloads
	
	public static implicit operator Vec2(Vector2 vec) {
		return new Vec2(vec.x, vec.y);
	}
	
	public static implicit operator Vector2(Vec2 vec) {
		return new Vector2(vec.x, vec.y);
	}
	
	public static explicit operator Vec2(Vector3 vec) {
		return new Vec2(vec.x, vec.y);
	}
	
	public static explicit operator Vector3(Vec2 vec) {
		return new Vector3(vec.x, vec.y, 0);
	}
	
	public static explicit operator Vec3(Vec2 vec) {
		return new Vec3(vec.x, vec.y, 0);
	}
	
	public static explicit operator Vec2(Vec3 vec) {
		return new Vec2(vec.x, vec.y);
	}
	
	#endregion
}
