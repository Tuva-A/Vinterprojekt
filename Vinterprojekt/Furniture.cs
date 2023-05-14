// Klass för möbler används knappt, hann inte göra mer än en brevlåda. Men movable finns som property eftersom det skulle funnits möbler man kan flytta.
public class Furniture : GameObject {
	public bool Moveable { get; set; }
	public int Weight { get; set; }
	public string ExamineText { get; set; }

	//tom konstruktor så json kan deserialiseras.
	public Furniture()
	{
	}

	public Furniture(int id, string name, string descsription, bool moveable, int weight,string examineText) : base(id,name,descsription)
	{
		Moveable = moveable;
		Weight = weight;
		ExamineText = examineText;
	}

	//När man skriver ut en furniture i rumsbeskrivning så får dess namn (look kommer visa desc, examine kommer visa examine text)
	public override string ToString()
	{
		return Name;
	}
}
