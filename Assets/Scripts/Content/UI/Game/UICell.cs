using UnityEngine;
using UnityEngine.UI;

public class UICell : UIBase
{
    private Image _image;
    private Text _text;
    private Color _color;
    
    private Cell _cell;
    
    public override bool Initialized()
    {
        if (base.Initialized() == false)
        {
            return false;
        }
        init = true;
        
        _image = Utils.FindChild<Image>(gameObject);
        _text = Utils.FindChild<Text>(gameObject);
        
        return init;
    }

    public void SetData(Cell cell)
    {
    }
}
