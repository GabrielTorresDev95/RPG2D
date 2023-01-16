using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]
public class DialogueSet : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite spearkerSprite;
    public string setence;

    public List<Sentences> dialogues = new List<Sentences>();  
}

[System.Serializable]
  public class Sentences
{
    public string actorName;
    public Sprite profile;
    public Languages sentence;
}


[System.Serializable]
public class Languages
{
    public string portuguese;
    public string english;
    public string spanish;
}

    //nos permitiu criar um botão no inspector 
#if UNITY_EDITOR
[CustomEditor(typeof(DialogueSet))]
public class BuiderEditor : Editor
{


    public override void OnInspectorGUI()
    {
        //permite modificar o inspector
        DrawDefaultInspector();

        DialogueSet ds = (DialogueSet)target;

        Languages l = new Languages();
        l.portuguese = ds.setence;

        //referenciar o sprite junto a fala.
        Sentences s = new Sentences();
        s.profile = ds.spearkerSprite;
        s.sentence = l;


        //lógica para o botão add os profile e fala ao inspector quando clicar ele ira gerar uma novo botão.
        if(GUILayout.Button("Create Dialogue"))
        {

            //caso a fala esteja vazia não ira adicionar nada.
            if(ds.setence!= "")
            { 
            ds.dialogues.Add(s);
            ds.spearkerSprite= null;
            ds.setence= "";
            
            }

        }
    }
}


#endif