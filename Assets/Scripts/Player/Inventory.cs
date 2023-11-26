using UnityEngine;

public class Inventory : MonoBehaviour
{

    private bool _isFinish;

    private bool _salad;
    private bool _bacon;
    private bool _cheese;
    
    

    private void Update()
    {
        if (_salad && _bacon && _cheese)
        {
            _isFinish = true;
            Debug.Log("FINISH!");
        }
    }
    

    public bool IsFinish
    {
        get => _isFinish;
        set => _isFinish = value;
    }

    public bool Salad
    {
        get => _salad;
        set => _salad = value;
    }

    public bool Bacon
    {
        get => _bacon;
        set => _bacon = value;
    }

    public bool Cheese
    {
        get => _cheese;
        set => _cheese = value;
    }
}
