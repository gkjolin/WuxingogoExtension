﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.CodeDom;
using System;
using Object = UnityEngine.Object;

[System.Serializable]
public class CodeBase {

    public CodeType type = CodeType.Field;
    public List<string> comment = new List<string>();
    public MemberAttributes attrs = MemberAttributes.Public | MemberAttributes.Final;
    public string name = "";

    public string memberType = "";

    private int typeID = 0;
    public int TypeID
    {
        get
        {
            return typeID;
        }
        set
        {
            typeID = value;
            objectType = supposeArray[typeID];
        }
    }
    public Type objectType = null;
    Type[] supposeArray = new Type[]{
        typeof(void),
        typeof(int),
        typeof(float),
        typeof(string),
        typeof(Object),
        typeof(Enum)
    };
    public CodeBase()
    {
        TypeID = 0;
    }

    public CodeTypeMember Member()
    {
        CodeTypeMember member = null;
        switch( type )
        {
            case CodeType.Event:
                member = GenerateField();
                break;
            case CodeType.Field:
                member = GenerateField();
                break;
            case CodeType.Method:
                member = GenerateMethod();
                break;
            case CodeType.Property:
                member = GenerateProperty();
                break;
        }
        member.Name = name;
        member.Attributes = attrs;
       // add custom attribute
//		member.CustomAttributes.Add(new CodeAttributeDeclaration(new CodeTypeReference(typeof(SerializableAttribute))));
			for( int i = 0; i < comment.Count; i++ )
        {
            member.Comments.Add( new CodeCommentStatement( comment[i] ) );
        }
        return member;
    }

    public CodeTypeMember GenerateField()
    {
        CodeMemberField field = new CodeMemberField(objectType, name);
        return field;
    }
    public CodeTypeMember GenerateEvent()
    {
        CodeMemberEvent e = new CodeMemberEvent();
        return e;
    }
    public CodeTypeMember GenerateProperty()
    {
        CodeMemberProperty property = new CodeMemberProperty();
        property.Type = new CodeTypeReference( objectType );
        return property;
    }
    public CodeTypeMember GenerateMethod()
    {
        CodeMemberMethod method = new CodeMemberMethod();
        method.ReturnType = new CodeTypeReference( objectType );
		
        return method;
    }
    
    public void Draw(CodeGenerateEditor editor){
    
		editor.BeginHorizontal();
		
		type = (CodeType)editor.CreateEnumSelectable( "mode", type );
		attrs = (MemberAttributes)editor.CreateEnumPopup( "Type", attrs );
		
		TypeID = editor.CreateSelectableString(TypeID, editor.supposeArray );
		name = editor.CreateStringField( "Name", name );
		
		if( editor.CreateSpaceButton( "Add Commen" ) )
		{
			comment.Add( "TODO List" );
		}
		
		editor.EndHorizontal();
		
        switch( type )
        {
            case CodeType.Event:
           
                break;
            case CodeType.Field:
               
                break;
            case CodeType.Method:
                
                break;
            case CodeType.Property:
                
                break;
        }
		
		for( int pos = 0; pos < comment.Count; pos++ )
		{
			editor.BeginHorizontal();
			comment[pos] = editor.CreateStringField( "//", comment[pos] );
			
			if( editor.CreateSpaceButton( "Delete Comment" ) )
			{
				comment.RemoveAt( pos );
				comment.TrimExcess();
				
			}
			editor.EndHorizontal();
		} 
    }
    
    
    
}
public enum CodeType{
    Method,
    Field,
    Property,
    Event
}
