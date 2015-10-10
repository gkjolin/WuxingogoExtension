using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public class XData : ScriptableObject{
    public List<XDataModel> AllData = new List<XDataModel>();

	public XData(){
	}
}

[System.Serializable]
public class XDataModel{
	
	public string _title = "" ;
	
	public XDataModel _Child = null;
	
	
	private string _StrValue;
	private int _IntValue;
	private float _FloatValue;
	
//	private DataType _
	
}

public enum DataType{
	Int,
	String,
	Float
}