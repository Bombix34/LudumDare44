using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DescentContainer : MonoBehaviour
{
    public GameObject InheritorViewGameObject;
    public GameObject LinkGameObject;
    public float HeightBetween;
    public float WidthBetween;
    public Inheritor Origin { get; set; }
    public Dictionary<Inheritor, GameObject> InheritorsView { get; set; }
    private Dictionary<int, List<Inheritor>> layers;
    // Start is called before the first frame update
    void Start()
    {
        this.Origin = new Inheritor(){
            Name = "Joe",
            isWomen = false,
            Reigning = true,
            Spouse = null,
        };
        this.Origin.Childrens = new List<Inheritor>(){
                new Inheritor
                {
                    Name = "John",
                    isWomen = false,
                    Reigning = true,
                    Spouse = null,
                    Parent = this.Origin,
                    Childrens = new List<Inheritor>()
                },
                new Inheritor
                {
                    Name = "Pierre",
                    isWomen = false,
                    Reigning = true,
                    Spouse = null,
                    Parent = this.Origin,
                    Childrens = new List<Inheritor>()
                },
                new Inheritor
                {
                    Name = "Pierre",
                    isWomen = false,
                    Reigning = true,
                    Spouse = null,
                    Parent = this.Origin,
                    Childrens = new List<Inheritor>()
                }
            };
        int index = 0;
        foreach (var item in this.Origin.Childrens)
        {
            index++;
            if(index == 2){
                continue;
            }
            item.Childrens = new List<Inheritor>(){
                new Inheritor
                {
                    Name = "John",
                    isWomen = false,
                    Reigning = true,
                    Spouse = null,
                    Parent = item,
                    Childrens = new List<Inheritor>()
                },
                new Inheritor
                {
                    Name = "Pierre",
                    isWomen = false,
                    Reigning = true,
                    Spouse = null,
                    Parent = item,
                    Childrens = new List<Inheritor>()
                },
                new Inheritor
                {
                    Name = "Pierre",
                    isWomen = false,
                    Reigning = true,
                    Spouse = null,
                    Parent = item,
                    Childrens = new List<Inheritor>()
                }
            };
        }
        
        this.InheritorsView = new Dictionary<Inheritor, GameObject>();
        this.UpdateView();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateView(){
        this.layers = new Dictionary<int, List<Inheritor>>();
        this.createLayers(0, ref this.layers, new List<Inheritor>() { this.Origin });
        this.setLayer(this.layers.Count - 1);        
    }

    private void createLayers(int layer, ref Dictionary<int, List<Inheritor>> layers, List<Inheritor> inheritors){
        if(inheritors.Count == 0 || !inheritors.Any(q => q != null)){
            return;
        }
        layers.Add(layer, inheritors);

        List<Inheritor> childrens = new List<Inheritor>();
        foreach (var inheritor in inheritors)
        {
            if(inheritor == null){
                continue;
            }
            if(inheritor.Childrens.Count > 0){
                childrens.AddRange(inheritor.Childrens);
            }   else
            {
                childrens.Add(null);
            }
            
        }

        createLayers(layer+1, ref layers, childrens);
    }

    private void setLayer(int layer){
        if(layer < 0){
            return;
        }
        
        var inheritors = this.layers[layer];

        float distanceFromCenterX = (WidthBetween / 2f * (inheritors.Count - 1));

        for (int i = 0; i < inheritors.Count; i++)
        {
            var inheritor = inheritors[i];

            if(inheritor == null){
                continue;
            }

            Vector3? position = null;

            if(inheritor.Childrens.Count > 0 && this.InheritorsView.ContainsKey(inheritor.Childrens[0])){
                var positions = new List<float>();
                foreach (var child in inheritor.Childrens)
                {
                    positions.Add(this.InheritorsView[child].transform.position.x);
                }
                position = new Vector3(positions.Average(), -layer * HeightBetween);
            }

            if(!position.HasValue){
                position = new Vector3(i * WidthBetween - distanceFromCenterX, -layer * HeightBetween);
            }

            var inheritorView = Instantiate(InheritorViewGameObject, position.Value, Quaternion.identity);
            this.InheritorsView.Add(inheritor, inheritorView);

            inheritorView.GetComponent<CharacterManager>().CharacterInfos = inheritor;
            inheritorView.GetComponentInChildren<CharacterManager>().CharacterInfos = inheritor.Spouse;
            
            if(inheritor.Childrens.Count > 0){
                foreach (var children in inheritor.Childrens)
                {
                    var link = Instantiate(LinkGameObject, inheritorView.transform);
                    var lineRenderer = link.GetComponent<LineRenderer>();
                    lineRenderer.positionCount = 4;
                    var childrenPosition = this.InheritorsView[children].transform.position;
                    lineRenderer.SetPositions(new List<Vector3>(){
                        inheritorView.transform.position,
                        new Vector3(inheritorView.transform.position.x,inheritorView.transform.position.y - HeightBetween / 2),
                        new Vector3(childrenPosition.x,inheritorView.transform.position.y - HeightBetween / 2),
                        childrenPosition
                    }.ToArray());
                }    
                
            }
        }

        this.setLayer(layer - 1);
    }
}
