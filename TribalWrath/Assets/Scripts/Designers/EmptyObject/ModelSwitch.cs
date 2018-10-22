using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSwitch : MonoBehaviour {
    public static GameObject currentModel { get; private set; }

    [Tooltip("Element0 == High Jump Model,\nElement1 == AcidSpit Model,\nElement2 == Owl Sight Model, etc.")]
    public List<GameObject> models = new List<GameObject>();
    [Tooltip("Normal Player Model")]
    public GameObject defaultModel;
    
    public ModelSwitch()
    {

    }
    private void Start()
    {
        currentModel = defaultModel;
        for (int i = 0; i < models.Count; i++)
        {
            GameObject temp = Instantiate(this.models[i], currentModel.transform.position, currentModel.transform.rotation);
            temp.SetActive(false);
            models[i] = temp;
        }
    }
    private void Update()
    {
        if (Abilities.Ability == AbilityState.HighJump && currentModel != models[0])
        {
            SwitchAbilityModels(models[0]);
        }
        else if (Abilities.Ability == AbilityState.AcidSpit && currentModel != models[1])
        {
            SwitchAbilityModels(models[1]);
        }
        else if (Abilities.Ability == AbilityState.OwlSight && currentModel != models[2])
        {
            SwitchAbilityModels(models[2]);
        }
        else if(Abilities.Ability == AbilityState.Normal && currentModel != defaultModel)
        {
            SwitchAbilityModels(defaultModel);
        }
    }
    private void SwitchAbilityModels(GameObject _modeltoswitchto)
    {
        GameObject nextModel = _modeltoswitchto;
        currentModel.SetActive(false);
        nextModel.transform.position = currentModel.transform.position;
        nextModel.transform.rotation = currentModel.transform.rotation;
        nextModel.SetActive(true);
        currentModel = nextModel;
    }
}
